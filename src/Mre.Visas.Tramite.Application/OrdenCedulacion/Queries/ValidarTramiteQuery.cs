using MediatR;
using Microsoft.Extensions.Logging;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Validations;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
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

    public class ValidarTramiteQuery : IRequest<ApiResponseWrapper<bool>>
    {
        public Guid TramiteId { get; set; }

        public ValidarTramiteQuery(Guid tramiteId)
        {
            TramiteId = tramiteId;
        }
    }

    public class ValidarTramiteHandler : BaseHandler, IRequestHandler<ValidarTramiteQuery, ApiResponseWrapper<bool>>
    {
        private readonly IMediator mediator;
        private readonly ILogger<ValidarTramiteHandler> logger;

        public ValidarTramiteHandler(IUnitOfWork unitOfWork,
                IMediator mediator,
                ILogger<ValidarTramiteHandler> logger)
                : base(unitOfWork)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        public async Task<ApiResponseWrapper<bool>> Handle(ValidarTramiteQuery query, CancellationToken cancellationToken)
        {
            #region obtener informacion

            // Obtener tramite
            logger.LogInformation("Obtener informacion del tramite, tramiteId: {tramiteId}", query.TramiteId);
            var tramiteResponse = await mediator.Send(new ConsultarTramitePorIdQuery(new ConsultarTramitePorIdRequest() { Id = query.TramiteId }));

            if (tramiteResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                logger.LogError("Error al obtener el tramite, tramiteId: {tramiteId}, {respuesta}", query.TramiteId, tramiteResponse.ToStringErrors());
                return new ApiResponseWrapper<bool>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
            }

            var tramite = (TramiteCompletoResponse)tramiteResponse.Result;

            //Validacion del tipo y estado del tramite
            logger.LogInformation("Validar informacion del tramite, tramiteId: {tramiteId}", query.TramiteId);
            var validador = new OrdenCedulacionValidaciones<ValidarTramiteHandler>(logger);
            var resultadoValidacion = validador.ValidarInformacionTramite(tramite);
            if (resultadoValidacion.HttpStatusCode != HttpStatusCode.OK)
            {
                return new ApiResponseWrapper<bool>(resultadoValidacion.HttpStatusCode, resultadoValidacion.Message);
            }

            //Obtener la orden de cedulacion
            logger.LogInformation("Verificar si existe una orden de cedulacion creada, tramiteId: {tramiteId}", query.TramiteId);
            var consultarOrdenResponse = await mediator.Send(new ObtenerOrdenCedulacionPorTramiteIdQuery(query.TramiteId));

            if (consultarOrdenResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                logger.LogInformation("Error al obtener la orden de cedulacion, tramiteId: {tramiteId}", query.TramiteId);
                return new ApiResponseWrapper<bool>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
            }

            var ordenCedulacion = consultarOrdenResponse.Result;

            #endregion obtener informacion

            //Validar el estado de la orden
            #region validacion estado
            if (ordenCedulacion != null && ordenCedulacion.Estado == EstadoOrdenCedulacion.Finalizada)
            {
                //El tramite de orden de cedulacion ya finalizo
                logger.LogError("{mensajeError}, tramiteId: {tramiteId}", TextosConsts.ErrorTramiteFinalizado, query.TramiteId);
                return new ApiResponseWrapper<bool>(HttpStatusCode.BadRequest, TextosConsts.ErrorTramiteFinalizado);
            }

            #endregion validacion estado

            return new ApiResponseWrapper<bool>(HttpStatusCode.OK, true);
        }
    }

}
