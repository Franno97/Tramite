using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Mre.Visas.Tramite.Application.AsignarFuncionario.Requests;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Requests;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Validations;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Queries
{
    public class ObtenerPagoQuery : ObtenerPagoRequest, IRequest<ApiResponseWrapper<PagoDto>>
    {

        public ObtenerPagoQuery(ObtenerPagoRequest request)
        {
            TramiteId = request.TramiteId;
        }

        public class ObtenerPagoHandler : BaseHandler, IRequestHandler<ObtenerPagoQuery, ApiResponseWrapper<PagoDto>>
        {
            private readonly IMediator mediator;
            private readonly ILogger<ObtenerPagoHandler> logger;

            public IPagoClient PagoClient { get; }
            public IHttpApiAutentificacion HttpApiAutentificacion { get; }

            public ObtenerPagoHandler(IUnitOfWork unitOfWork,
                IPagoClient pagoClient,
                IHttpApiAutentificacion httpApiAutentificacion,
                IMediator mediator,
                ILogger<ObtenerPagoHandler> logger)
                : base(unitOfWork)
            {
                PagoClient = pagoClient;
                HttpApiAutentificacion = httpApiAutentificacion;
                this.mediator = mediator;
                this.logger = logger;
            }

            public async Task<ApiResponseWrapper<PagoDto>> Handle(ObtenerPagoQuery query, CancellationToken cancellationToken)
            {
                #region obtener informacion

                // Obtener tramite
                logger.LogInformation("Obtener informacion del tramite, tramiteId: {tramiteId}", query.TramiteId);
                var tramiteResponse = await mediator.Send(new ConsultarTramitePorIdQuery(new ConsultarTramitePorIdRequest() { Id = query.TramiteId }));

                if (tramiteResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogError("Error al obtener el tramite, tramiteId: {tramiteId}, {respuesta}", query.TramiteId, tramiteResponse.ToStringErrors());
                    return new ApiResponseWrapper<PagoDto>(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);
                }

                var tramite = (TramiteCompletoResponse)tramiteResponse.Result;

                //Validacion del tipo y estado del tramite
                logger.LogInformation("Validar informacion del tramite, tramiteId: {tramiteId}", query.TramiteId);
                var validador = new OrdenCedulacionValidaciones<ObtenerPagoHandler>(logger);
                var resultadoValidacion = validador.ValidarInformacionTramite(tramite);
                if(resultadoValidacion.HttpStatusCode != HttpStatusCode.OK)
                {
                    return new ApiResponseWrapper<PagoDto>(resultadoValidacion.HttpStatusCode, resultadoValidacion.Message);
                }

                //Obtener la orden de cedulacion
                logger.LogInformation("Verificar si existe una orden de cedulacion creada, tramiteId: {tramiteId}", query.TramiteId);
                var consultarOrdenResponse = await mediator.Send(new ObtenerOrdenCedulacionPorTramiteIdQuery(query.TramiteId));

                if (consultarOrdenResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogInformation("Error al obtener la orden de cedulacion, tramiteId: {tramiteId}", query.TramiteId);
                    return new ApiResponseWrapper<PagoDto>(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);
                }

                var ordenCedulacion = consultarOrdenResponse.Result;

                #endregion obtener informacion

                //Validar el estado de la orden
                #region validacion estado
                if (ordenCedulacion != null && ordenCedulacion.Estado == EstadoOrdenCedulacion.Finalizada)
                {
                    //El tramite de orden de cedulacion ya finalizo
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}", TextosConsts.ErrorTramiteFinalizado, query.TramiteId);
                    return new ApiResponseWrapper<PagoDto>(HttpStatusCode.BadRequest, TextosConsts.ErrorTramiteFinalizado);
                }

                #endregion validacion estado

                ApiResponseWrapper<ObtenerPagoResponse> obtenerPagoResponse = null;

                //Obtener pago desde microservicio de pagos
                logger.LogInformation("Obtener el pago de la orden de cedulacion, tramiteId: {tramiteId}", query.TramiteId);

                //Se pasa el origenId del tramite ya que el pago esta asociado al tramite de visa
                //donde se registraron los pagos
                var tramiteId = tramite.OrigenId.ToString();
                var valoresMayoraCero = false;
                var facturarEn = OrdenCedulacionConsts.EstadoGenerarOrden;

                try
                {
                    obtenerPagoResponse = await PagoClient.ObtenerPagoAsync(tramiteId, valoresMayoraCero, facturarEn.ToString());
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "{mensajeError}, tramiteId: {tramiteId}", TextosConsts.ErrorApiPago, tramiteId);
                    return new ApiResponseWrapper<PagoDto>(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);
                }

                if (obtenerPagoResponse.HttpStatusCode != HttpStatusCode.OK)
                {
                    logger.LogError("{mensajeError}, tramiteId: {tramiteId}, {respuestaApi}", TextosConsts.ErrorApiPago, tramiteId, obtenerPagoResponse.ToStringErrors());
                    return new ApiResponseWrapper<PagoDto>(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);
                }

                var pagoDto = MapearPago(obtenerPagoResponse.Result);


                logger.LogInformation("Devolver informacion del pago, tramiteId: {tramiteId}", query.TramiteId);
                var response = new ApiResponseWrapper<PagoDto>(HttpStatusCode.OK, pagoDto);

                return response;
            }

            private PagoDto MapearPago(ObtenerPagoResponse response)
            {
                logger.LogInformation("Mapear respuesta del servicio del pago, tramiteId: {tramiteId}", response.IdTramite);

                var pagoDto = new PagoDto()
                {
                    Id = new Guid(response.Id),
                    TramiteId = response.IdTramite,
                    Estado = response.Estado,
                    FormaPago = response.FormaPago,
                    Observacion = response.Observacion,
                    ServicioId = response.ServicioId,
                    DocumentoIdentificacion = response.DocumentoIdentificacion,
                };

                pagoDto.PagoDetalles = MapearPagoDetalle(response);

                return pagoDto;
            }

            private ICollection<PagoDetalleDto> MapearPagoDetalle(ObtenerPagoResponse response)
            {
                logger.LogInformation("Mapear detalle del pago, tramiteId: {tramiteId}", response.IdTramite);
                var pagoDetalles = new List<PagoDetalleDto>();

                if (response.ListaPagoDetalle.Any())
                {
                    pagoDetalles = response.ListaPagoDetalle.Select(
                                   detalle => new PagoDetalleDto()
                                   {
                                       Id = detalle.Id,
                                       IdPago = detalle.IdPago,
                                       ArancelId = detalle.ArancelId,
                                       Arancel = detalle.Arancel,
                                       ClaveAcceso = detalle.ClaveAcceso,
                                       ComprobantePago = detalle.ComprobantePago,
                                       ConvenioId = detalle.ConvenioId,
                                       TipoExoneracionId = detalle.TipoExoneracionId,
                                       TipoExoneracion = detalle.TipoExoneracion,
                                       Estado = detalle.Estado,
                                       Descripcion = detalle.Descripcion,
                                       EstaFacturado = detalle.EstaFacturado,
                                       IdTramite = detalle.IdTramite,
                                       FacturarEn = detalle.FacturarEn,
                                       JerarquiaArancelaria = detalle.JerarquiaArancelaria,
                                       JerarquiaArancelariaId = detalle.JerarquiaArancelariaId,
                                       PartidaArancelariaId = detalle.PartidaArancelariaId,
                                       PartidaArancelaria = detalle.PartidaArancelaria,
                                       NumeroPartida = detalle.NumeroPartida,
                                       NumeroTransaccion = detalle.NumeroTransaccion,
                                       Orden = detalle.Orden,
                                       ServicioId = detalle.ServicioId,
                                       Servicio = detalle.Servicio,
                                       TipoServicio = detalle.TipoServicio,
                                       OrdenPago = detalle.OrdenPago,
                                       PorcentajeDescuento = detalle.PorcentajeDescuento,
                                       ValorArancel = detalle.ValorArancel,
                                       ValorDescuento = detalle.ValorDescuento,
                                       ValorTotal = detalle.ValorTotal,
                                       Created = new DateTime(detalle.Created.Year, detalle.Created.Month, detalle.Created.Day),
                                       CreatorId = detalle.CreatorId,
                                       IsDeleted = detalle.IsDeleted,
                                       LastModified = new DateTime(detalle.LastModified.Year, detalle.LastModified.Month, detalle.LastModified.Day),
                                       LastModifierId = detalle.LastModifierId
                                   }).ToList();
                }

                return pagoDetalles;
            }
        
            
        }

        public class ObtenerPagoValidator : AbstractValidator<ObtenerPagoQuery>
        {
            public ObtenerPagoValidator()
            {
                RuleFor(e => e.TramiteId)
                    .NotEmpty().WithMessage("{PropertyName} es requerido.")
                    .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            }
        }
    }
}
