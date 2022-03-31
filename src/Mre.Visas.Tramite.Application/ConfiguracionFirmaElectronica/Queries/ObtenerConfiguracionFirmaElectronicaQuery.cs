using AutoMapper;
using MediatR;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries
{
    public class ObtenerConfiguracionFirmaElectronicaQuery: IRequest<ApiResponseWrapper<ConfiguracionFirmaElectronicaResponse>>
    {
        public virtual Guid Id { get; set; }

        public ObtenerConfiguracionFirmaElectronicaQuery(Guid id)
        {
            Id = id;
        }

    }


    public class ObtenerConfiguracionFirmaElectronicaHandler : BaseHandler, IRequestHandler<ObtenerConfiguracionFirmaElectronicaQuery, ApiResponseWrapper<ConfiguracionFirmaElectronicaResponse>>
    {
        private readonly IMapper mapper;

        public ObtenerConfiguracionFirmaElectronicaHandler(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            this.mapper = mapper;
        }

        public async Task<ApiResponseWrapper<ConfiguracionFirmaElectronicaResponse>> Handle(ObtenerConfiguracionFirmaElectronicaQuery request, CancellationToken cancellationToken)
        {
            try
            {
               
                var configuracionFirmaElectronica = await UnitOfWork.ConfiguracionFirmaElectronicaRepository.GetByIdAsync(request.Id);

                var configuracionFirmaElectronicaResponse = mapper.Map<ConfiguracionFirmaElectronicaResponse>(configuracionFirmaElectronica);


                return new ApiResponseWrapper<ConfiguracionFirmaElectronicaResponse>(HttpStatusCode.OK, configuracionFirmaElectronicaResponse);

            }
            catch (System.Exception ex)
            {

                return new ApiResponseWrapper<ConfiguracionFirmaElectronicaResponse>(HttpStatusCode.BadRequest, message: ex.Message);
            }
        }

    }
}
