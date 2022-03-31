using AutoMapper;
using MediatR;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Responses;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Queries
{
    public class ObtenerOrdenCedulacionPorTramiteIdQuery : IRequest<ApiResponseWrapper<OrdenCedulacionResponse>>
    {
        public virtual Guid TramiteId { get; set; }

        public ObtenerOrdenCedulacionPorTramiteIdQuery(Guid tramiteId)
        {
            TramiteId = tramiteId;
        }

    }

    public class ObtenerOrdenCedulacionQueryHandler : BaseHandler, IRequestHandler<ObtenerOrdenCedulacionPorTramiteIdQuery, ApiResponseWrapper<OrdenCedulacionResponse>>
    {
        private readonly IMapper mapper;

        public ObtenerOrdenCedulacionQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork)
        {
            this.mapper = mapper;
        }

        public async Task<ApiResponseWrapper<OrdenCedulacionResponse>> Handle(ObtenerOrdenCedulacionPorTramiteIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var ordenCedulacion = UnitOfWork.OrdenCedulacionRepository.ObtenerPorTramiteId(request.TramiteId);
                var ordenCedulacioResponse = mapper.Map<OrdenCedulacionResponse>(ordenCedulacion);
                return new ApiResponseWrapper<OrdenCedulacionResponse>(HttpStatusCode.OK, ordenCedulacioResponse);
            }
            catch (System.Exception ex)
            {
                return new ApiResponseWrapper<OrdenCedulacionResponse>(HttpStatusCode.BadRequest, message: ex.Message);
            }
        }

    }
}
