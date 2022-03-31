using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mre.Visas.Tramite.Application.Catalogo.Queries;
using Mre.Visas.Tramite.Application.Catalogo.Requests;
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
using Mre.Visas.Tramite.Domain.Entities;
using Mre.Visas.Tramite.Domain.Enums;
using ServiceAsuntosMigratorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Commands
{
    public class FacturarServicioCommand : FacturarServicioRequest, IRequest<ApiResponseWrapper<FacturarServicioResponse>>
    {


        public FacturarServicioCommand(FacturarServicioRequest request)
        {
            TramiteId = request.TramiteId;
            PagoId = request.PagoId;
        }

        public class FacturarServicioHandler : BaseHandler, IRequestHandler<FacturarServicioCommand, ApiResponseWrapper<FacturarServicioResponse>>
        {
            private readonly IFacturaElectronicaClient facturaElectronicaClient;
            private readonly ISharepointClient sharepointClient;
            private readonly IVisaElectronicaClient visaElectronicaClient;
            private readonly IMediator mediator;
            private readonly ILogger<FacturarServicioHandler> logger;
            private readonly IOrdenCedulacionMapper ordenCedulacionMapper;
            private readonly IHttpApiAutentificacion httpApiAutentificacion;
            private readonly ICatalogoClient catalogoClient;
            private readonly AsuntosMigratoriosServicioConfiguracion asuntosMigratoriosConfiguracion;
            private readonly ServiceAsuntosMigratoriosClient serviceAsuntosMigratoriosClient;

            public FacturarServicioHandler(IUnitOfWork unitOfWork,
                IFacturaElectronicaClient facturaElectronicaClient,
                ISharepointClient sharepointClient,
                INotificadorClient notificadorClient,
                IVisaElectronicaClient visaElectronicaClient,
                IMediator mediator,
                IOrdenCedulacionMapper ordenCedulacionMapper,
                IHttpApiAutentificacion httpApiAutentificacion,
                IMapper mapper,
                ICatalogoClient catalogoClient,
                IOptions<AsuntosMigratoriosServicioConfiguracion> asuntosMigratoriosConfiguracion,
                ILogger<FacturarServicioHandler> logger
                )
                : base(unitOfWork)
            {
                this.facturaElectronicaClient = facturaElectronicaClient;
                this.sharepointClient = sharepointClient;
                this.NotificadorClient = notificadorClient;
                this.visaElectronicaClient = visaElectronicaClient;
                this.mediator = mediator;
                this.ordenCedulacionMapper = ordenCedulacionMapper;
                this.httpApiAutentificacion = httpApiAutentificacion;
                this.catalogoClient = catalogoClient;
                this.asuntosMigratoriosConfiguracion = asuntosMigratoriosConfiguracion.Value;
                Mapper = mapper;
                this.logger = logger;

                this.serviceAsuntosMigratoriosClient = new ServiceAsuntosMigratoriosClient();
                //this.serviceAsuntosMigratoriosClient.Endpoint.Address = new System.ServiceModel.EndpointAddress(this.asuntosMigratoriosConfiguracion.Url);

            }

            public async Task<ApiResponseWrapper<FacturarServicioResponse>> Handle(FacturarServicioCommand command, CancellationToken cancellationToken)
            {
                var respuesta = new ApiResponseWrapper<FacturarServicioResponse>();

                #region obtener informacion

                //Obtener el tramite
                logger.LogInformation("Obtener informacion del tramite, tramiteId: {tramiteId}", command.TramiteId);
                var tramiteResponse = await mediator.Send(new ConsultarTramitePorIdQuery(new ConsultarTramitePorIdRequest() { Id = command.TramiteId }));

                if (tramiteResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogError("Error al obtener el tramite, tramiteId: {tramiteId}, {respuesta}", command.TramiteId, tramiteResponse.ToStringErrors());
                    return new ApiResponseWrapper<FacturarServicioResponse>(tramiteResponse.HttpStatusCode, TextosConsts.ErrorGenerico);
                }
                var tramite = tramiteResponse.Result as TramiteCompletoResponse;

               if(tramite == null)
                {
                    return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);
                }

                //Validacion del tipo y estado del tramite
                logger.LogInformation("Validar informacion del tramite, tramiteId: {tramiteId}", command.TramiteId);
                var validador = new OrdenCedulacionValidaciones<FacturarServicioHandler>(logger);
                var resultadoValidacion = validador.ValidarInformacionTramite(tramite);
                if (resultadoValidacion.HttpStatusCode != HttpStatusCode.OK)
                {
                    return new ApiResponseWrapper<FacturarServicioResponse>(resultadoValidacion.HttpStatusCode, resultadoValidacion.Message);
                }

                //Obtener pago
                logger.LogInformation("Obtener informacion del pago, tramiteId: {tramiteId}", command.TramiteId);
                var pagoResponse = await mediator.Send(new ObtenerPagoQuery(new ObtenerPagoRequest() { TramiteId = command.TramiteId }));

                if (pagoResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogError("Error al obtener el pago, tramiteId: {tramiteId}, {respuesta}", command.TramiteId, pagoResponse.ToStringErrors());
                    return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }
                var pago = pagoResponse.Result;

                //Obtener la orden de cedulacion
                logger.LogInformation("Obtener informacion de la orden de cedulacion, tramiteId: {tramiteId}", command.TramiteId);
                var ordenCedulacionResponse = await ObtenerOrdenCedulacionAsync(tramite, command.PagoId);

                if (ordenCedulacionResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }

                var ordenCedulacion = ordenCedulacionResponse.Result;

                #endregion obtener informacion

                //Validar el estado de la orden
                #region validacion estado
                if (ordenCedulacion.Estado == EstadoOrdenCedulacion.Finalizada)
                {
                    //El tramite de orden de cedulacion ya finalizo
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}", TextosConsts.ErrorTramiteFinalizado, command.TramiteId);
                    return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.BadRequest, TextosConsts.ErrorTramiteFinalizado);
                }


                if (ordenCedulacion.Estado == EstadoOrdenCedulacion.CreadaEsigex
                    || ordenCedulacion.Estado == EstadoOrdenCedulacion.Firmada)
                {
                    //En estos casos devolver los datos preexistentes
                    //Obtener la factura
                    logger.LogInformation("Obtener factura desde servicio de facturacion, tramiteId: {tramiteId}", tramite.Id);
                    var requestFactura = new ConsultarFacturaPorClaveAccesoRequest() { ClaveAcceso = ordenCedulacion.ClaveAccesoFactura };
                    var respuestaObtenerFactura = await facturaElectronicaClient.ObtenerFacturaPorClaveAccesoAsync(requestFactura);

                    if (respuestaObtenerFactura.HttpStatusCode != HttpStatusCode.OK)
                    {
                        logger.LogError("{mensajeError}, tramiteId: {tramiteId}, {respuestaApi}", TextosConsts.ErrorObtenerFactura, tramite.Id, respuestaObtenerFactura.Message);
                        return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.BadRequest, TextosConsts.ErrorObtenerFactura);
                    }

                    var infoFactura = respuestaObtenerFactura.Result;

                    var facturarResponse = new FacturarServicioResponse()
                    {
                        NumeroOrden = ordenCedulacion.Numero,
                        CodigoVerificacion = ordenCedulacion.CodigoVerificacion,
                        NumeroTransaccion = ordenCedulacion.IdTramiteEsigex,
                        RutaAlmacenamientoFactura = ordenCedulacion.RutaAlmacenamientoFactura,
                        NumeroFactura = infoFactura.Numero,
                        EstadoOrden = (int)ordenCedulacion.Estado
                    };

                    return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.OK, facturarResponse);
                }

                //Si se llego a facturar
                if (ordenCedulacion.Estado == EstadoOrdenCedulacion.Facturada)
                {
                    //Si se facturo pero no se ha notificado y guardado en sharepoint y esigex
                    var resultadoGestionarPdf = await GestionarDocumentoPdf(tramite, pago, ordenCedulacion);
                    if (resultadoGestionarPdf.HttpStatusCode != HttpStatusCode.OK)
                    {
                        return new ApiResponseWrapper<FacturarServicioResponse>(resultadoGestionarPdf.HttpStatusCode, resultadoGestionarPdf.Message);
                    }

                    //Obtener la factura
                    logger.LogInformation("Obtener factura desde servicio de facturacion, tramiteId: {tramiteId}", tramite.Id);
                    var requestFactura = new ConsultarFacturaPorClaveAccesoRequest() { ClaveAcceso = ordenCedulacion.ClaveAccesoFactura };
                    var respuestaObtenerFactura = await facturaElectronicaClient.ObtenerFacturaPorClaveAccesoAsync(requestFactura);

                    if (respuestaObtenerFactura.HttpStatusCode != HttpStatusCode.OK)
                    {
                        logger.LogError("{mensajeError}, tramiteId: {tramiteId}, {respuestaApi}", TextosConsts.ErrorObtenerFactura, tramite.Id, respuestaObtenerFactura.Message);
                        return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.BadRequest, TextosConsts.ErrorObtenerFactura);
                    }

                    var infoFactura = respuestaObtenerFactura.Result;

                    //Crear orden de cedulacion en esigex
                    logger.LogInformation("Enviar informacion del pago y crear orden de cedulacion en Esigex, tramiteId: {tramiteId}", tramite.Id);
                    var resultCrearEsigex = await GenerarOrdenCedulacionEsigexAsync(tramite, ordenCedulacion, pago, infoFactura);

                    if (resultCrearEsigex.HttpStatusCode != HttpStatusCode.OK)
                    {
                        return new ApiResponseWrapper<FacturarServicioResponse>(resultCrearEsigex.HttpStatusCode, resultCrearEsigex.Message);
                    }

                    //Actualizar orden cedulacion
                    var resultActualizar = await ActualizarOrdenConInformacionEsigex(ordenCedulacion, resultCrearEsigex.Result);
                    if (resultActualizar.HttpStatusCode != HttpStatusCode.OK)
                    {
                        logger.LogError("{mensajeError}, tramiteId: {tramiteId}, {respuestaApi}", "Error al actualizar orden cedulacion", tramite.Id, resultActualizar.ToStringErrors());
                        return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                    }

                    var facturarResponse = new FacturarServicioResponse()
                    {
                        NumeroOrden = ordenCedulacion.Numero,
                        CodigoVerificacion = ordenCedulacion.CodigoVerificacion,
                        NumeroTransaccion = ordenCedulacion.IdTramiteEsigex,
                        RutaAlmacenamientoFactura = ordenCedulacion.RutaAlmacenamientoFactura,
                        NumeroFactura = infoFactura.Numero,
                        EstadoOrden = (int)ordenCedulacion.Estado
                    };

                    logger.LogInformation("Respuesta de fase de facturacion, tramiteId: {tramiteId}, respuestaFacturacion: {respuestaFacturacion}", tramite.Id, facturarResponse);
                    respuesta = new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.OK, facturarResponse);

                    return respuesta;

                }


                //El estado del flujo normal que se debe recibir es creada
                if (ordenCedulacion.Estado != EstadoOrdenCedulacion.Creada)
                {
                    //El estado del tramite no corresponde con esta fase
                    logger.LogError("El estado de la orden de cedulacion no corresponde a la fase de facturacion, tramiteId: {tramiteId}", command.TramiteId);
                    return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);

                }

                #endregion validacion estado

                //Facturar
                var grabarFacturaRequest = await CrearFacturaRequest(tramite, pago);

                //Llamar al servicio de facturacion electronica
                logger.LogInformation("LLamar al servicio de facturacion, tramiteId: {tramiteId}", command.TramiteId);
                var resultadoFacturar = new GrabarFacturaResultadoResponse();
                try
                {
                    resultadoFacturar = await facturaElectronicaClient.GrabarFacturaAsync(grabarFacturaRequest);
                }
                catch (Exception ex)
                {
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}, {excepcion}", TextosConsts.ErrorFacturacion, command.TramiteId, ex);
                    return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }

                if (resultadoFacturar.Estado == null || !resultadoFacturar.Estado.Equals("OK"))
                {
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}, {metodo}", TextosConsts.ErrorFacturacion, command.TramiteId, "GrabarFactura");
                    return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }


                //Guardar clave de acceso
                logger.LogInformation("Actualizar orden cedulacion con clave de acceso de facturacion, tramiteId: {tramiteId}", tramite.Id);
                ordenCedulacion.ClaveAccesoFactura = resultadoFacturar.ClaveAcceso;
                ordenCedulacion.Estado = EstadoOrdenCedulacion.Facturada;
                var resultadoActualizar = await ActualizarOrdenCedulacionAsync(ordenCedulacion);
                if (resultadoActualizar.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}, {respuestaApi}", "Error al actualizar orden cedulacion", command.TramiteId, resultadoActualizar.ToStringErrors());
                    return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }

                //Enviar factura pdf al correo del ciudadano y sharepoint
                //var resultGestionarPdf= await GestionarDocumentoPdf(tramite, pago, ordenCedulacion);
                //if (resultGestionarPdf.HttpStatusCode != HttpStatusCode.OK)
                //{
                //    return new ApiResponseWrapper<FacturarServicioResponse>(resultGestionarPdf.HttpStatusCode, resultGestionarPdf.Message);
                //}

                //Obtener la factura
                logger.LogInformation("Obtener factura desde servicio de facturacion, tramiteId: {tramiteId}", tramite.Id);
                var request = new ConsultarFacturaPorClaveAccesoRequest() { ClaveAcceso = ordenCedulacion.ClaveAccesoFactura };
                var respuestaFactura = await facturaElectronicaClient.ObtenerFacturaPorClaveAccesoAsync(request);

                if (respuestaFactura.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}, {respuestaApi}", TextosConsts.ErrorObtenerFactura, tramite.Id, respuestaFactura.Message);
                    return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.BadRequest, TextosConsts.ErrorObtenerFactura);
                }

                var factura = respuestaFactura.Result;


                //Crear orden de cedulacion en esigex
                logger.LogInformation("Enviar informacion del pago y crear orden de cedulacion en Esigex, tramiteId: {tramiteId}", tramite.Id);
                var resultadoCrearEsigex = await GenerarOrdenCedulacionEsigexAsync(tramite, ordenCedulacion, pago, factura);
                
                if (resultadoCrearEsigex.HttpStatusCode != HttpStatusCode.OK)
                {
                    return new ApiResponseWrapper<FacturarServicioResponse>(resultadoCrearEsigex.HttpStatusCode, resultadoCrearEsigex.Message);
                }

                //Actualizar orden cedulacion
                resultadoActualizar = await ActualizarOrdenConInformacionEsigex(ordenCedulacion, resultadoCrearEsigex.Result);
                if (resultadoActualizar.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}, {respuestaApi}", "Error al actualizar orden cedulacion", tramite.Id, resultadoActualizar.ToStringErrors());
                    return new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }

                var facturarRespuesta = new FacturarServicioResponse()
                {
                    NumeroOrden = ordenCedulacion.Numero,
                    CodigoVerificacion = ordenCedulacion.CodigoVerificacion,
                    NumeroTransaccion = ordenCedulacion.IdTramiteEsigex,
                    RutaAlmacenamientoFactura = ordenCedulacion.RutaAlmacenamientoFactura,
                    NumeroFactura = factura.Numero,
                    EstadoOrden = (int)ordenCedulacion.Estado
                };

                logger.LogInformation("Respuesta de fase de facturacion, tramiteId: {tramiteId}, respuestaFacturacion: {respuestaFacturacion}", tramite.Id, facturarRespuesta);
                respuesta = new ApiResponseWrapper<FacturarServicioResponse>(HttpStatusCode.OK, facturarRespuesta);

                return respuesta;
            }


            #region Metodos soporte

            private async Task<GrabarFacturaRequest> CrearFacturaRequest(TramiteCompletoResponse tramite, PagoDto pago)
            {
                var grabarFacturaRequest = new GrabarFacturaRequest();
                grabarFacturaRequest.Factura = MapearDatosFactura(tramite, pago);
                return grabarFacturaRequest;
            }

            private Factura MapearDatosFactura(Tramite.Responses.TramiteCompletoResponse tramite, PagoDto pago)
            {
                if(!pago.PagoDetalles.Any())
                {
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}, {pagoId}", TextosConsts.DetallePagoNoExiste, tramite.Id, pago.Id);
                    return null;
                }

                var pagoDetalle = pago.PagoDetalles.SingleOrDefault();

                var factura = new Factura()
                {
                    CodigoOficina = OrdenCedulacionConsts.Facturacion.CodigoOficina,
                    CodigoUsuario = OrdenCedulacionConsts.Facturacion.CodigoUsuario,
                    TipoIdentificacionComprador = tramite.Solicitante.TipoIdentificacion,
                    RazonSocialComprador = tramite.Solicitante.Nombres,
                    IdentificacionComprador = tramite.Solicitante.Identificacion,
                    DireccionComprador = tramite.Solicitante.Direccion,
                    TelefonoComprador = tramite.Solicitante.Telefono,
                    CorreoComprador = tramite.Solicitante.Correo,
                    TotalSinImpuestos = pagoDetalle.ValorTotal,
                    TotalDescuento = pagoDetalle.ValorDescuento,
                    ImporteTotal = pagoDetalle.ValorTotal,
                    Porcentaje = pagoDetalle.PorcentajeDescuento,
                    FechaEmisionLocal = DateTime.Now.ToString("yyyyMMdd"),
                    Referencia = OrdenCedulacionConsts.Facturacion.Referencia,
                    Origen = OrdenCedulacionConsts.Facturacion.Origen,
                    NumeroTramite = tramite.Numero,
                    DescripcionGeneral = OrdenCedulacionConsts.Facturacion.DescripcionGeneral,
                    FacturaDetalle = new List<FacturaDetalle>(),
                    FacturaPagos = new List<FacturaPagos>()
                };

                var facturaDetalle = new FacturaDetalle()
                {
                    OrdenDetalle = 1,
                    CodigoPrincipal = tramite.Numero,
                    CodigoAuxiliar = pagoDetalle.NumeroPartida,
                    Descripcion = pagoDetalle.Descripcion,
                    Cantidad = 1,
                    PrecioUnitario = pagoDetalle.ValorArancel,
                    Descuento = pagoDetalle.ValorDescuento,
                    PrecioTotalSinImpuesto = pagoDetalle.ValorTotal,
                    CampoAdicional1Nombre = string.Empty,
                    CampoAdicional1Valor = string.Empty,
                    CampoAdicional2Nombre = string.Empty,
                    CampoAdicional2Valor = string.Empty,
                    CampoAdicional3Nombre = string.Empty,
                    CampoAdicional3Valor = string.Empty,
                    IdArancel = pagoDetalle.ArancelId
                };

                var facturaPago = new FacturaPagos()
                {
                    Orden = 1,
                    FormaPago = pago.FormaPago,
                    Total = pagoDetalle.ValorTotal,
                    IdPagoDetalle = pagoDetalle.Id
                };

                factura.FacturaDetalle.Add(facturaDetalle);
                factura.FacturaPagos.Add(facturaPago);

                return factura;
            }

            private async Task<ApiResponseWrapper> GestionarDocumentoPdf(TramiteCompletoResponse tramite, PagoDto pago, OrdenCedulacionResponse ordenCedulacion)
            {
                logger.LogInformation("Obtener factura en PDF desde servicio de facturacion, tramiteId: {tramiteId}", tramite.Id);
                var respuestaObtenerPdf = await facturaElectronicaClient.CrearPDFAsync(
                    new ConsultarFacturaPorClaveAccesoRequest() { ClaveAcceso = ordenCedulacion.ClaveAccesoFactura }
                    );

                if (respuestaObtenerPdf == null || !respuestaObtenerPdf.Estado.Equals(OrdenCedulacionConsts.RespuestaOk))
                {
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}, {respuestaApi}", TextosConsts.ErrorObtenerPdf, tramite.Id, respuestaObtenerPdf.Mensaje);
                    return new ApiResponseWrapper(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }

                var facturaPdfBase64 = respuestaObtenerPdf.Pdf;

                //1. Enviar documento de factura al correo electronico
                logger.LogInformation("Enviar notificacion de la factura en PDF, tramiteId: {tramiteId}", tramite.Id);
                var resultNotificacion = await EnviarNotificacionFactura(tramite, Convert.FromBase64String(facturaPdfBase64));


                //2. Guardar documento de factura en expediente unico - sharepoint
                logger.LogInformation("Enviar factura en PDF al expediente unico - sharepoint, tramiteId: {tramiteId}", tramite.Id);
                var guardarFacturaPdfRequest = new GrabarBibliotecaRequest()
                {
                    CodigoMdg = tramite.Beneficiario.CodigoMDG,
                    Biblioteca = OrdenCedulacionConsts.ExpedienteUnico.BibliotecaFactura,
                    Archivo = Convert.FromBase64String(facturaPdfBase64),
                    NombreArchivo = $"{OrdenCedulacionConsts.ExpedienteUnico.NombreArchivoFactura}{OrdenCedulacionConsts.ExtensionArchivo}"
                };
                var respuestaGuardarFacturaPdf = await sharepointClient.GrabarBibliotecaAsync(guardarFacturaPdfRequest);
                if (!respuestaGuardarFacturaPdf.Estado.Equals(OrdenCedulacionConsts.RespuestaOk))
                {
                    logger.LogError("Error al guardar factura Pdf en expediente unico, tramiteId: {tramiteId}, mensaje: {mensaje}", tramite.Id, respuestaGuardarFacturaPdf.Mensaje);
                    return new ApiResponseWrapper(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);
                }

                //2.1. Actualizar ruta de sharepoint en orden de cedulacion
                ordenCedulacion.RutaAlmacenamientoFactura = respuestaGuardarFacturaPdf.Ruta;

                return new ApiResponseWrapper(HttpStatusCode.OK, string.Empty);
            }


            private async Task<bool> EnviarNotificacionFactura(TramiteCompletoResponse tramite, byte[] documento)
            {
                var adjuntos = new List<FileParameter>();
                var archivoEnviar = new FileParameter(new MemoryStream(documento), OrdenCedulacionConsts.Notificaciones.NombreAdjuntoFactura, OrdenCedulacionConsts.Notificaciones.PdfMimeType);
                adjuntos.Add(archivoEnviar);

                var nombreCompleto = string.IsNullOrEmpty(tramite.Beneficiario.SegundoApellido) ? $"{tramite.Beneficiario.Nombres} {tramite.Beneficiario.PrimerApellido}" : $"{tramite.Beneficiario.Nombres} {tramite.Beneficiario.PrimerApellido} {tramite.Beneficiario.SegundoApellido}";
                var asunto = OrdenCedulacionConsts.Notificaciones.AsuntoFactura;
                var mensaje = OrdenCedulacionConsts.Notificaciones.MensajeFactura;

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


            private async Task<ApiResponseWrapper> ActualizarOrdenCedulacionAsync(OrdenCedulacionResponse ordenCedulacion)
            {
                var actualizarOrdenReq = await ordenCedulacionMapper.MapearOrdenCedulacionAsync(ordenCedulacion);

                var actualizarOrdenCommand = Mapper.Map<ActualizarOrdenCedulacionCommand>(actualizarOrdenReq);

                return await mediator.Send(actualizarOrdenCommand);
            }


            private async Task<ApiResponseWrapper<GenerarOrdenCedulacionEsigexResponse>> GenerarOrdenCedulacionEsigexAsync(TramiteCompletoResponse tramite, OrdenCedulacionResponse ordenCedulacion, PagoDto pago, Factura factura)
            {
                
                var ordenCedulacionRequest = await MapearInformacionEsigex(tramite, ordenCedulacion, pago, factura);

                if (ordenCedulacionRequest == null)
                {
                    return new ApiResponseWrapper<GenerarOrdenCedulacionEsigexResponse>(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);
                }

                logger.LogInformation("Llamar a servicio GenerarOrdenCedulacion de Esigex, tramiteId: {tramiteId}, request: {request}", ordenCedulacion.TramiteId, ordenCedulacionRequest.ToString());
                var generarOrdenEsigex = await serviceAsuntosMigratoriosClient.GenerarOrdenCedulacionAsync(ordenCedulacionRequest);

                var convertirCodigo = Int32.TryParse(generarOrdenEsigex.Codigo, out int codigoRespuesta);
                if (!convertirCodigo)
                {
                    logger.LogError("No se puede convertir el codigo de respuesta de esigex a numero, tramiteId: {tramiteId}, codigoRespuesta: {codigoRespuesta}, descripcionCodigo: {respuesta}", ordenCedulacion.TramiteId, generarOrdenEsigex.Codigo, generarOrdenEsigex.CodigoDescripcion);
                    return new ApiResponseWrapper<GenerarOrdenCedulacionEsigexResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }

                if (codigoRespuesta != (int)CodigoRespuestaEsigex.DatoEncontrado)
                {
                    logger.LogError("Error al crear la orden de cedulacion en Esigex, tramiteId: {tramiteId}, {respuesta}", ordenCedulacion.TramiteId, generarOrdenEsigex.CodigoDescripcion);
                    return new ApiResponseWrapper<GenerarOrdenCedulacionEsigexResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                }

                var respuesta = new GenerarOrdenCedulacionEsigexResponse()
                {
                    CodigoVerificacion = generarOrdenEsigex.CodigoVerificacion,
                    IdTramiteOrdenCedulacion = generarOrdenEsigex.IdTramiteOrdenCedulacion.ToString(),
                    SecuencialActuacion = generarOrdenEsigex.SecuencialActuacion.ToString(),
                    NumeroTramite = generarOrdenEsigex.NumeroTramite
                };

                return new ApiResponseWrapper<GenerarOrdenCedulacionEsigexResponse>(HttpStatusCode.OK, respuesta);
            }


            private async Task<OrdenCedulacionInfo> MapearInformacionEsigex(TramiteCompletoResponse tramite, OrdenCedulacionResponse ordenCedulacion, PagoDto pago, Factura factura)
            {
                var pagoDetalle = pago.PagoDetalles.SingleOrDefault();

                #region Catalogos

                
                var idFuncionario = tramite.Movimientos.OrderBy(x => x.Orden).LastOrDefault().UsuarioId;

                logger.LogInformation("Obtener codigo esigex de funcionario, tramiteId: {tramiteId}, idFuncionario: {idFuncionario}", tramite.Id, idFuncionario);
                var catalogoFuncionario = await catalogoClient.ConsultarCatalogoPorCodigoAsync(CatalogoConsts.Funcionario, idFuncionario.ToString());
                var idFuncionarioEsigex = catalogoFuncionario.Result.CodigoEsigex;

                var result = Int32.TryParse(idFuncionarioEsigex, out int idFuncionarioEsigexNum);
                if (!result)
                {
                    logger.LogError("No se puede convertir el valor del id de funcionario Esigex a numero, tramiteId: {tramiteId}, idFuncionarioEsigex: {idFuncionarioEsigex}", ordenCedulacion.TramiteId, idFuncionarioEsigex);
                    return null;
                }

                logger.LogInformation("Obtener codigo esigex de funcionario pago, tramiteId: {tramiteId}, idFuncionario: {idFuncionario}", tramite.Id, pagoDetalle.CreatorId);
                var catalogoFuncionarioPago = await catalogoClient.ConsultarCatalogoPorCodigoAsync(CatalogoConsts.Funcionario, pagoDetalle.CreatorId.ToString());
                result = Int32.TryParse(catalogoFuncionarioPago.Result.CodigoEsigex, out int idFuncionarioPagoEsigex);
                if (!result)
                {
                    logger.LogError("No se puede convertir el valor del id de funcionario pago Esigex a numero, tramiteId: {tramiteId}, idFuncionarioPagoEsigex: {idFuncionarioPagoEsigex}", ordenCedulacion.TramiteId, catalogoFuncionarioPago.Result.CodigoEsigex);
                    return null;
                }

                logger.LogInformation("Obtener codigo esigex de tipo pago, tramiteId: {tramiteId}, idFormaPago: {idFormaPago}", tramite.Id, pago.FormaPago);
                var catalogoTipoPago = await catalogoClient.ConsultarCatalogoPorCodigoAsync(CatalogoConsts.TipoPago, pago.FormaPago.ToString());
                result = Int32.TryParse(catalogoTipoPago.Result.CodigoEsigex, out int idTipoPago);
                if (!result)
                {
                    logger.LogError("No se puede convertir el valor del id de tipo de pago Esigex a numero, tramiteId: {tramiteId}, idTipoPagoEsigex: {idTipoPagoEsigex}", ordenCedulacion.TramiteId, catalogoTipoPago.Result.CodigoEsigex);
                    return null;
                }

                logger.LogInformation("Obtener codigo esigex de servicio, tramiteId: {tramiteId}, idServicio: {idServicio}", tramite.Id, tramite.ServicioId);
                var catalogoServicio = await catalogoClient.ConsultarCatalogoPorCodigoAsync(CatalogoConsts.Servicio, tramite.ServicioId.ToString());
                result = Int32.TryParse(catalogoServicio.Result.CodigoEsigex, out int idServicioEsigex);
                if (!result)
                {
                    logger.LogError("No se puede convertir el valor del id de servicio Esigex a numero, tramiteId: {tramiteId}, idServicioEsigex: {idServicioEsigex}", ordenCedulacion.TramiteId, catalogoServicio.Result.CodigoEsigex);
                    return null;
                }

                logger.LogInformation("Obtener codigo esigex de unidad administrativa, tramiteId: {tramiteId}, idUnidadAdministrativa: {idUnidadAdministrativa}", tramite.Id, ordenCedulacion.UnidadAdministrativaId);
                var catalogoUnidadAdmin = await catalogoClient.ConsultarCatalogoPorCodigoAsync(CatalogoConsts.UnidadAdministrativa, ordenCedulacion.UnidadAdministrativaId.ToString());
                result = Int32.TryParse(catalogoUnidadAdmin.Result.CodigoEsigex, out int idUnidadAdministrativaEsigex);
                if (!result)
                {
                    logger.LogError("No se puede convertir el valor del id de unidad administrativa Esigex a numero, tramiteId: {tramiteId}, idUnidadAdministrativaEsigex: {idUnidadAdministrativaEsigex}", ordenCedulacion.TramiteId, catalogoUnidadAdmin.Result.CodigoEsigex);
                    return null;
                }

                #endregion Catalogos

                var ordenCedulacionInfo = new OrdenCedulacionInfo();
                ordenCedulacionInfo.UsuarioWs = asuntosMigratoriosConfiguracion.Usuario;
                ordenCedulacionInfo.ContraseniaWs = asuntosMigratoriosConfiguracion.Clave;
                ordenCedulacionInfo.DiasValidez = ordenCedulacion.Validez;
                ordenCedulacionInfo.FechaFactura = DateTime.ParseExact(factura.FechaEmisionLocal,"yyyyMMdd", null);
                ordenCedulacionInfo.FechaFinValidezOrdenCedulacion = ordenCedulacion.FechaFinValidez;
                ordenCedulacionInfo.FechaInicioValidezOrdenCedulacion = ordenCedulacion.FechaInicioValidez;
                ordenCedulacionInfo.FechaPago = DateTime.Now;
                ordenCedulacionInfo.FechaRegistroOrdenCedulacion = ordenCedulacion.FechaRegistro;
                ordenCedulacionInfo.IdActoConsularOrdenCedulacion = idServicioEsigex;
                ordenCedulacionInfo.IdCentroAdministrativoOrdenCedulacion = idUnidadAdministrativaEsigex;
                //TODO: No llega el id de exoneracion en el pago
                ordenCedulacionInfo.IdExoneracion = 1;
                ordenCedulacionInfo.IdFormaPago = idTipoPago;
                ordenCedulacionInfo.IdFuncionarioCajero = idFuncionarioEsigexNum;
                ordenCedulacionInfo.IdFuncionarioCreacionEsigex = idFuncionarioEsigexNum;
                ordenCedulacionInfo.IdFuncionarioNuevoSistema = tramite.Movimientos.OrderBy(x => x.Orden).LastOrDefault().UsuarioId;
                ordenCedulacionInfo.IdFuncionarioPagoEsigex = idFuncionarioPagoEsigex;
                ordenCedulacionInfo.IdFuncionarioSignatarioEsigex = idFuncionarioEsigexNum;
                ordenCedulacionInfo.IdTramiteNuevoSistema = tramite.Id;
                //TODO: No llega el numero del tramite de visa en esigex
                ordenCedulacionInfo.IdTramiteVisaEsigex = 7144386;
                //TODO: No esta llegando el numero de transaccion, es requerido, se debe llenar en el registro de pago
                ordenCedulacionInfo.NumeroComprobantePago = "123456123456"; //pagoDetalle.NumeroTransaccion;
                ordenCedulacionInfo.NumeroFactura = factura.Numero;
                ordenCedulacionInfo.ObservacionOrdenCedulacion = ordenCedulacion.Observacion;

                return ordenCedulacionInfo;
            }


            private async Task<ApiResponseWrapper<OrdenCedulacionResponse>> ObtenerOrdenCedulacionAsync(TramiteCompletoResponse tramite, Guid pagoId)
            {
                //Verificar si existe una orden crada para el tramite, si no existe crear una
                logger.LogInformation("Verificar si existe una orden de cedulacion creada, tramiteId: {tramiteId}", tramite.Id);
                var consultarOrdenResponse = await mediator.Send(new ObtenerOrdenCedulacionPorTramiteIdQuery(tramite.Id));

                if (consultarOrdenResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogError("Error al obtener la orden de cedulacion, tramiteId: {tramiteId}, respuesta: {respuesta}", tramite.Id, consultarOrdenResponse.ToStringErrors());
                    return consultarOrdenResponse;
                }

                if (consultarOrdenResponse.Result == null)
                {
                    logger.LogInformation("No existe orden de cedulacion, tramiteId: {tramiteId}", tramite.Id);
                    logger.LogInformation("Crear orden de cedulacion, tramiteId: {tramiteId}", tramite.Id);

                    //Obtener visa
                    var request = new ConsultarVisaElectronicaPorTramiteIdRequest();
                    request.TramiteId = tramite.OrigenId;
                    var visaResponse = await visaElectronicaClient.ConsultarVisaElectronicaPorTramiteIdAsync(request);

                    if (visaResponse.HttpStatusCode != HttpStatusCode.OK)
                    {
                        logger.LogError("Error al obtener la visa, tramiteId: {tramiteId}, {respuesta}", tramite.Id, visaResponse.ToStringErrors());
                        return new ApiResponseWrapper<OrdenCedulacionResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                    }

                    var visa = visaResponse.Result;

                    //Obtener configuracion de dias de vigencia de la orden de cedulacion
                    var configuracionResponse = await mediator.Send(new ConsultarConfiguracionQuery(new ConsultarCatalogoRequest() { Codigo = OrdenCedulacionConsts.CodigoDiasVigencia }));

                    if (configuracionResponse.HttpStatusCode != HttpStatusCode.OK)
                    {
                        logger.LogError("Error al obtener configuracion de orden de cedulacion, tramiteId: {tramiteId}, {respuesta}", tramite.Id, configuracionResponse.ToStringErrors());
                        return new ApiResponseWrapper<OrdenCedulacionResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
                    }

                    //Obtener configuracion de dias de vigencia de orden de cedulacion
                    var diasVigenciaOrdCed = configuracionResponse.Result as Configuracion;

                    var ordenCedulacionReq = await ordenCedulacionMapper.MapearOrdenCedulacionAsync(tramite, visa, pagoId, diasVigenciaOrdCed.ValorEntero);

                    var crearOrdenCeulacionCommand = Mapper.Map<CrearOrdenCedulacionCommand>(ordenCedulacionReq);

                    var crearOrdenResponse = await mediator.Send(crearOrdenCeulacionCommand);

                    return await mediator.Send(new ObtenerOrdenCedulacionQuery(crearOrdenResponse.Result));
                }

                return consultarOrdenResponse;
            }

            private async Task<ApiResponseWrapper> ActualizarOrdenConInformacionEsigex(OrdenCedulacionResponse ordenCedulacion, GenerarOrdenCedulacionEsigexResponse esigexData)
            {
                var fechaActual = DateTime.Now;

                ordenCedulacion.Numero = $"{esigexData.SecuencialActuacion} / {fechaActual.Year}";
                ordenCedulacion.CodigoVerificacion = esigexData.CodigoVerificacion;
                ordenCedulacion.IdTramiteEsigex = esigexData.IdTramiteOrdenCedulacion;
                ordenCedulacion.NumeroTramiteEsigex = esigexData.NumeroTramite;
                ordenCedulacion.SecuencialActuacion = esigexData.SecuencialActuacion;
                ordenCedulacion.Estado = EstadoOrdenCedulacion.CreadaEsigex;

                var actualizarOrdenReq = await ordenCedulacionMapper.MapearOrdenCedulacionAsync(ordenCedulacion);

                var actualizarOrdenCommand = Mapper.Map<ActualizarOrdenCedulacionCommand>(actualizarOrdenReq);

                return await mediator.Send(actualizarOrdenCommand);
            }



            #endregion Metodos soporte
        }
    }
}
