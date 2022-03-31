using AutoMapper;
using MediatR;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries;
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
    public class ObtenerOrdenCedulacionQuery : IRequest<ApiResponseWrapper<OrdenCedulacionResponse>>
    {
        public virtual Guid Id { get; set; }

        public ObtenerOrdenCedulacionQuery(Guid id)
        {
            Id = id;
        }

    }

    public class ObtenerOrdenCedulacionHandler : BaseHandler, IRequestHandler<ObtenerOrdenCedulacionQuery, ApiResponseWrapper<OrdenCedulacionResponse>>
    {
        private readonly IMapper mapper;

        public ObtenerOrdenCedulacionHandler(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            this.mapper = mapper;
        }

        public async Task<ApiResponseWrapper<OrdenCedulacionResponse>> Handle(ObtenerOrdenCedulacionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var ordenCedulacion = await UnitOfWork.OrdenCedulacionRepository.GetByIdAsync(request.Id);
                var ordenCedulacionResponse = mapper.Map<OrdenCedulacionResponse>(ordenCedulacion);
                return new ApiResponseWrapper<OrdenCedulacionResponse>(HttpStatusCode.OK, ordenCedulacionResponse);
            }
            catch (System.Exception ex)
            {
                return new ApiResponseWrapper<OrdenCedulacionResponse>(HttpStatusCode.BadRequest, message: ex.Message);
            }
        }

    }
}
