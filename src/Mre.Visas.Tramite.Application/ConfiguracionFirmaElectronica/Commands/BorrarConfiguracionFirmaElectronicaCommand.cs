using AutoMapper;
using MediatR;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Repositories;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Commands
{

    public class BorrarConfiguracionFirmaElectronicaCommand : IRequest<ApiResponseWrapper>
    {

        public BorrarConfiguracionFirmaElectronicaCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class BorrarConfiguracionFirmaElectronicaHandler : BaseHandler, IRequestHandler<BorrarConfiguracionFirmaElectronicaCommand, ApiResponseWrapper>
    {
        private readonly IMapper mapper;
        private readonly IConfiguracionFirmaElectronicaRepository configuracionFirmaElectronicaRepository;

        public BorrarConfiguracionFirmaElectronicaHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IConfiguracionFirmaElectronicaRepository configuracionFirmaElectronicaRepository)
            : base(unitOfWork)
        {
            this.mapper = mapper;
            this.configuracionFirmaElectronicaRepository = configuracionFirmaElectronicaRepository;
        }

        public async Task<ApiResponseWrapper> Handle(BorrarConfiguracionFirmaElectronicaCommand request, CancellationToken cancellationToken)
        {
            var configuracionFirmaElectronica = await configuracionFirmaElectronicaRepository.GetByIdAsync(request.Id);
            if (configuracionFirmaElectronica == null)
            {
                return new ApiResponseWrapper(HttpStatusCode.NotFound, "Configuración de Firma Electrónica no encontrada");
            }
              
            var resultado = await configuracionFirmaElectronicaRepository.DeleteAsync(request.Id);
            if (!resultado.Item1)
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, resultado.Item2);


            var resultSaveChanges = await UnitOfWork.SaveChangesAsync();
            if (!resultSaveChanges.Item1)
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, resultSaveChanges.Item2);


            return new ApiResponseWrapper(HttpStatusCode.OK, null);
        }
    }
}
