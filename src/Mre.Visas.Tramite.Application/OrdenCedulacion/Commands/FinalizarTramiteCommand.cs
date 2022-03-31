using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mre.Visas.Tramite.Application.Movimiento.Commands;
using Mre.Visas.Tramite.Application.Movimiento.Request;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Mappings;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Queries;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Requests;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Responses;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Validations;
using Mre.Visas.Tramite.Application.Shared;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Security;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Queries;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using Mre.Visas.Tramite.Application.Tramite.Responses;
using Mre.Visas.Tramite.Domain.Const;
using Mre.Visas.Tramite.Domain.Enums;
using ServiceAsuntosMigratorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Commands
{
    public class FinalizarTramiteCommand : FinalizarTramiteRequest, IRequest<ApiResponseWrapper<FinalizarTramiteResponse>>
    {
        public FinalizarTramiteCommand(FinalizarTramiteRequest request)
        {
            TramiteId = request.TramiteId;
        }


        public class FinalizarTramiteHandler : BaseHandler, IRequestHandler<FinalizarTramiteCommand, ApiResponseWrapper<FinalizarTramiteResponse>>
        {
            private readonly IMediator mediator;
            private readonly IHttpApiAutentificacion httpApiAutentificacion;
            private readonly IOrdenCedulacionMapper ordenCedulacionMapper;
            private readonly AsuntosMigratoriosServicioConfiguracion asuntosMigratoriosConfiguracion;
            private readonly ILogger<FinalizarTramiteHandler> logger;
            private readonly ServiceAsuntosMigratoriosClient serviceAsuntosMigratoriosClient;

            public ISharepointClient SharepointClient { get; }
            public ICatalogoClient CatalogoClient { get; }

            public FinalizarTramiteHandler(IUnitOfWork unitOfWork,
                ISharepointClient sharepointClient,
                INotificadorClient notificadorClient,
                ICatalogoClient catalogoClient,
                IMapper mapper,
                IMediator mediator,
                IHttpApiAutentificacion httpApiAutentificacion,
                IOrdenCedulacionMapper ordenCedulacionMapper,
                IOptions<AsuntosMigratoriosServicioConfiguracion> asuntosMigratoriosConfiguracion,
                ILogger<FinalizarTramiteHandler> logger)
                : base(unitOfWork)
            {
                SharepointClient = sharepointClient;
                CatalogoClient = catalogoClient;
                NotificadorClient = notificadorClient;
                Mapper = mapper;
                this.mediator = mediator;
                this.httpApiAutentificacion = httpApiAutentificacion;
                this.ordenCedulacionMapper = ordenCedulacionMapper;
                this.asuntosMigratoriosConfiguracion = asuntosMigratoriosConfiguracion.Value;
                this.logger = logger;

                this.serviceAsuntosMigratoriosClient = new ServiceAsuntosMigratoriosClient();
                this.serviceAsuntosMigratoriosClient.Endpoint.Address = new System.ServiceModel.EndpointAddress(this.asuntosMigratoriosConfiguracion.Url);

            }
           
            public async Task<ApiResponseWrapper<FinalizarTramiteResponse>> Handle(FinalizarTramiteCommand command, CancellationToken cancellationToken)
            {
                #region obtener informacion

                //Obtener tramite
                logger.LogInformation("Obtener informacion del tramite, tramiteId: {tramiteId}", command.TramiteId);
                var tramiteResponse = await mediator.Send(new ConsultarTramitePorIdQuery(new ConsultarTramitePorIdRequest() { Id = command.TramiteId }));

                if (tramiteResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogError("Error al obtener el tramite, tramiteId: {tramiteId}, {respuesta}", command.TramiteId, tramiteResponse.ToStringErrors());
                    return new ApiResponseWrapper<FinalizarTramiteResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }

                var tramite = (TramiteCompletoResponse)tramiteResponse.Result;

                //Validacion del tipo y estado del tramite
                logger.LogInformation("Validar informacion del tramite, tramiteId: {tramiteId}", command.TramiteId);
                var validador = new OrdenCedulacionValidaciones<FinalizarTramiteHandler>(logger);
                var resultadoValidacion = validador.ValidarInformacionTramite(tramite);
                if (resultadoValidacion.HttpStatusCode != HttpStatusCode.OK)
                {
                    return new ApiResponseWrapper<FinalizarTramiteResponse>(resultadoValidacion.HttpStatusCode, resultadoValidacion.Message);
                }

                //Obtener la orden de cedulacion
                logger.LogInformation("Obtener la orden de cedulacion, tramiteId: {tramiteId}", command.TramiteId);
                var ordenCedulacionResponse = await ObtenerOrdenCedulacionAsync(command.TramiteId);

                if (ordenCedulacionResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    return new ApiResponseWrapper<FinalizarTramiteResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }

                var ordenCedulacion = ordenCedulacionResponse.Result;

                #endregion obtener informacion

                //Validar el estado de la orden
                #region validacion estado
                if (ordenCedulacion.Estado == EstadoOrdenCedulacion.Finalizada)
                {
                    //El tramite de orden de cedulacion ya finalizo
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}", TextosConsts.ErrorTramiteFinalizado, command.TramiteId);
                    return new ApiResponseWrapper<FinalizarTramiteResponse>(HttpStatusCode.BadRequest, TextosConsts.ErrorTramiteFinalizado);
                }

                //El estado del flujo normal que se debe recibir es firmada
                if (ordenCedulacion.Estado != EstadoOrdenCedulacion.Firmada)
                {
                    //El estado del tramite no corresponde con esta fase
                    logger.LogError("El estado de la orden de cedulacion no corresponde a la fase de finalizacion, tramiteId: {tramiteId}", command.TramiteId);
                    return new ApiResponseWrapper<FinalizarTramiteResponse>(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);

                }

                #endregion validacion estado


                #region flujo

                //1. Gestionar pdf
                var resultadoGestionarPdf = await GestionarPdfAsync(ordenCedulacion, tramite);
                if(resultadoGestionarPdf.HttpStatusCode != HttpStatusCode.OK)
                {
                    return new ApiResponseWrapper<FinalizarTramiteResponse>(resultadoGestionarPdf.HttpStatusCode, resultadoGestionarPdf.Message);
                }

                //2. Enviar información de la orden de cedulación al esigex
                ordenCedulacion.FechaRegistro = DateTime.Now;
                var resultadoEsigex = await ActualizarOrdenCedulacionEsigex(ordenCedulacion, tramite);

                if(resultadoEsigex.HttpStatusCode != HttpStatusCode.OK)
                {
                    return new ApiResponseWrapper<FinalizarTramiteResponse>(resultadoEsigex.HttpStatusCode, resultadoEsigex.Message);
                }

                //2.1 Actualizar estado de orden de cedulacion
                ordenCedulacion.Estado = EstadoOrdenCedulacion.Finalizada;
                var resultadoActualizar = await ActualizarOrdenCedulacionAsync(ordenCedulacion);

                if (resultadoActualizar.HttpStatusCode != HttpStatusCode.OK)
                {
                    return new ApiResponseWrapper<FinalizarTramiteResponse>(resultadoActualizar.HttpStatusCode, resultadoActualizar.Message);
                }

                //3. Finalizar tramite
                var resultadoFinalizar = await FinalizarTramite(tramite);

                if(!resultadoFinalizar)
                {
                    logger.LogError("Error al finalizar tramite, tramiteId: {tramiteId}, mensaje: {mensaje}", command.TramiteId, resultadoFinalizar.ToString());
                }

                #endregion flujo


                var finalizarResponse = new FinalizarTramiteResponse()
                {
                    Mensaje = TextosConsts.TramiteFinalizadoCorrectamente
                };

                logger.LogInformation("Respuesta de fase de finalizacion, tramiteId: {tramiteId}, respuestaFinalizacion: {respuestaFinalizacion}", tramite.Id, finalizarResponse);
                var response = new ApiResponseWrapper<FinalizarTramiteResponse>(HttpStatusCode.OK, finalizarResponse);

                return response;
            }

            #region metodos soporte

            private async Task<ApiResponseWrapper> GestionarPdfAsync(OrdenCedulacionResponse ordenCedulacion, TramiteCompletoResponse tramite)
            {
                //1. Enviar documento de orden de cedulacion al correo electronico
                logger.LogInformation("Enviar notificacion de la orden de cedulacion en PDF, tramiteId: {tramiteId}", tramite.Id);
                var resultadoNotificacion = await EnviarNotificacionOrdenCedulacion(ordenCedulacion, tramite);


                //2. Guardar documento de orden de cedulacion en expediente unico - sharepoint
                logger.LogInformation("Enviar orden cedulacion PDF al expediente unico - sharepoint, tramiteId: {tramiteId}", tramite.Id);
                var guardarOrdenPdfRequest = new GrabarBibliotecaRequest()
                {
                    CodigoMdg = tramite.Beneficiario.CodigoMDG,
                    Biblioteca = OrdenCedulacionConsts.ExpedienteUnico.BibliotecaOrdenCedulacion,
                    Archivo = ordenCedulacion.OrdenCedulacionPdf,
                    NombreArchivo = $"{OrdenCedulacionConsts.ExpedienteUnico.NombreArchivoOrdenCedulacion}{OrdenCedulacionConsts.ExtensionArchivo}"
                };
                var result = await SharepointClient.GrabarBibliotecaAsync(guardarOrdenPdfRequest);
                if (!result.Estado.Equals(OrdenCedulacionConsts.RespuestaOk))
                {
                    logger.LogError("Error al guardar orden cedulacion Pdf en expediente unico, tramiteId: {tramiteId}, mensaje: {mensaje}", tramite.Id, result.Mensaje);
                    return new ApiResponseWrapper(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);
                }

                //2.1. Actualizar ruta de sharepoint en orden de cedulacion
                ordenCedulacion.RutaAlmacenamientoOrdenCedulacion = result.Ruta;

                return new ApiResponseWrapper(HttpStatusCode.OK, true);
            }

            private async Task<bool> EnviarNotificacionOrdenCedulacion(OrdenCedulacionResponse ordenCedulacion, TramiteCompletoResponse tramite)
            {
                var adjuntos = new List<FileParameter>();
                var archivoEnviar = new FileParameter(new MemoryStream(ordenCedulacion.OrdenCedulacionPdf), OrdenCedulacionConsts.Notificaciones.NombreAdjuntoOrdenCedulacion, OrdenCedulacionConsts.Notificaciones.PdfMimeType);
                adjuntos.Add(archivoEnviar);

                var nombreCompleto = string.IsNullOrEmpty(tramite.Beneficiario.SegundoApellido) ? $"{tramite.Beneficiario.Nombres} {tramite.Beneficiario.PrimerApellido}" : $"{tramite.Beneficiario.Nombres} {tramite.Beneficiario.PrimerApellido} {tramite.Beneficiario.SegundoApellido}";
                var asunto = OrdenCedulacionConsts.Notificaciones.AsuntoOrdenCedulacion;
                var mensaje = OrdenCedulacionConsts.Notificaciones.MensajeOrdenCedulacion;

                var model = new Dictionary<string, string>();
                model.Add("PersonaNombreApellido", nombreCompleto);
                model.Add("Cuerpo", mensaje);

                var token = await httpApiAutentificacion.GetAccessTokenAsync();
                if (string.IsNullOrEmpty(token))
                {
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}", "El usuario no esta autenticado", tramite.Id);
                    return false;
                }

                var result = false;
                try
                {
                    NotificadorClient.SetAccessToken(token);
                    result = await NotificadorClient.EnviarConAdjuntosAsync(
                    adjuntos,
                    OrdenCedulacionConsts.Notificaciones.NotificacionGeneral01,
                    asunto,
                    tramite.Beneficiario.Correo,
                    model);
                }
                catch (Exception ex)
                {
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}, excepcion: {excepcion}", "Error al enviar notificacion", tramite.Id, ex);
                }

                return result;
            }

            private async Task<ApiResponseWrapper<ActualizarOrdenCedulacionEsigexResponse>> ActualizarOrdenCedulacionEsigex(OrdenCedulacionResponse ordenCedulacion, TramiteCompletoResponse tramite)
            {
                var ordenCedulacionRequest = await MapearInformacionEsigex(ordenCedulacion, tramite);

                if(ordenCedulacionRequest == null)
                {
                    return new ApiResponseWrapper<ActualizarOrdenCedulacionEsigexResponse>(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);
                }

                logger.LogInformation("Llamar a servicio ActualizarOrdenCedulacion de Esigex, tramiteId: {tramiteId}, request: {request}", ordenCedulacion.TramiteId, ordenCedulacionRequest.ToString());
                var actualizarOrdenEsigex = await serviceAsuntosMigratoriosClient.ActualizarOrdenCedulacionAsync(ordenCedulacionRequest);

                var convertirCodigo = Int32.TryParse(actualizarOrdenEsigex.Codigo, out int codigoRespuesta);
                if (!convertirCodigo)
                {
                    logger.LogError("No se puede convertir el codigo de respuesta de esigex a numero, tramiteId: {tramiteId}, codigoRespuesta: {codigoRespuesta}, descripcionCodigo: {respuesta}", ordenCedulacion.TramiteId, actualizarOrdenEsigex.Codigo, actualizarOrdenEsigex.CodigoDescripcion);
                    return new ApiResponseWrapper<ActualizarOrdenCedulacionEsigexResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }

                if (codigoRespuesta != (int)CodigoRespuestaEsigex.DatoEncontrado)
                {
                    logger.LogError("Error al crear la orden de cedulacion en Esigex, tramiteId: {tramiteId}, {respuesta}", ordenCedulacion.TramiteId, actualizarOrdenEsigex.CodigoDescripcion);
                    return new ApiResponseWrapper<ActualizarOrdenCedulacionEsigexResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }

                var respuesta = new ActualizarOrdenCedulacionEsigexResponse()
                {
                    CodigoVerificacion = actualizarOrdenEsigex.CodigoVerificacion,
                    IdTramiteOrdenCedulacion = actualizarOrdenEsigex.IdTramiteOrdenCedulacion.ToString(),
                    SecuencialActuacion = actualizarOrdenEsigex.SecuencialActuacion.ToString()
                };

                return new ApiResponseWrapper<ActualizarOrdenCedulacionEsigexResponse>(HttpStatusCode.OK, respuesta);
            }


            private async Task<OrdenCedulacionV2Info> MapearInformacionEsigex(OrdenCedulacionResponse ordenCedulacion, TramiteCompletoResponse tramite)
            {
                var result = Int32.TryParse(ordenCedulacion.IdTramiteEsigex, out int idTramiteOrdenCedulacionEsigex);
                if (!result)
                {
                    logger.LogError("No se puede convertir el valor de numero de transaccion a numero, tramiteId: {tramiteId}, numeroTransaccion: {numeroTransaccion}", ordenCedulacion.TramiteId, ordenCedulacion.IdTramiteEsigex);
                    return null;
                }

                var idFuncionario= tramite.Movimientos.OrderBy(x => x.Orden).LastOrDefault().UsuarioId;
                var catalogoFuncionario = await CatalogoClient.ConsultarCatalogoPorCodigoAsync(CatalogoConsts.Funcionario ,idFuncionario.ToString());
                var idFuncionarioEsigex = catalogoFuncionario.Result.CodigoEsigex;

                result = Int32.TryParse(idFuncionarioEsigex, out int idFuncionarioEsigexNum);
                if (!result)
                {
                    logger.LogError("No se puede convertir el valor del id de funcionario Esigex a numero, tramiteId: {tramiteId}, idFuncionarioEsigex: {idFuncionarioEsigex}", ordenCedulacion.TramiteId, idFuncionarioEsigex);
                    return null;
                }


                var ordenCedulacionV2Info = new OrdenCedulacionV2Info();
                ordenCedulacionV2Info.UsuarioWs = asuntosMigratoriosConfiguracion.Usuario;
                ordenCedulacionV2Info.ContraseniaWs = asuntosMigratoriosConfiguracion.Clave;
                ordenCedulacionV2Info.DocumentoPdf = ordenCedulacion.OrdenCedulacionPdf;
                ordenCedulacionV2Info.FechaRegistroOrdenCedulacion = ordenCedulacion.FechaRegistro;
                ordenCedulacionV2Info.IdFuncionarioNuevoSistema = idFuncionario;
                ordenCedulacionV2Info.IdFuncionarioOrdenCedulacionEsigex = idFuncionarioEsigexNum;
                ordenCedulacionV2Info.IdTramiteNuevoSistema = tramite.Id;
                ordenCedulacionV2Info.IdTramiteOrdenCedulacionEsigex = idTramiteOrdenCedulacionEsigex;

                return ordenCedulacionV2Info;
            }


            private async Task<ApiResponseWrapper<OrdenCedulacionResponse>> ObtenerOrdenCedulacionAsync(Guid tramiteId)
            {
                //Obtener la orden de cedulacion
                logger.LogInformation("Verificar si existe una orden de cedulacion creada, tramiteId: {tramiteId}", tramiteId);
                var consultarOrdenResponse = await mediator.Send(new ObtenerOrdenCedulacionPorTramiteIdQuery(tramiteId));

                if (consultarOrdenResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogInformation("Error al obtener la orden de cedulacion, tramiteId: {tramiteId}", tramiteId);
                    return consultarOrdenResponse;
                }

                return consultarOrdenResponse;
            }

            private async Task<ApiResponseWrapper> ActualizarOrdenCedulacionAsync(OrdenCedulacionResponse ordenCedulacion)
            {
                var actualizarOrdenReq = await ordenCedulacionMapper.MapearOrdenCedulacionAsync(ordenCedulacion);

                var actualizarOrdenCommand = Mapper.Map<ActualizarOrdenCedulacionCommand>(actualizarOrdenReq);

                return await mediator.Send(actualizarOrdenCommand);
            }

            private async Task<bool> FinalizarTramite(TramiteCompletoResponse tramite)
            {
                //Para finalizar el tramite se crea un movimiento adicional con el estado de finalizacion de orden de cedulacion
                var request = new CrearMovimientoCedulacionRequest() {
                    TramiteId = tramite.Id,
                    Estado = OrdenCedulacionConsts.EstadoFinalizado,
                    CreatorId = tramite.Movimientos.OrderBy(x => x.Orden).LastOrDefault().UsuarioId
                };

                //Llamar a crer un movimiento para finalizar el tramite
                logger.LogInformation("Crear movimiento de finalizacion, tramiteId: {tramiteId}", tramite.Id);
                var result= await mediator.Send(new CrearMovimientoCedulacionCommand(request));

                if(result.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogError("Error al crear el movimiento de finalizacion, tramiteId: {tramiteId}, excepcion: {excepcion}", tramite.Id, result.ToStringErrors());
                    return false;
                }

                return true;
            }

            #endregion metodos soporte
        }
    }
}
