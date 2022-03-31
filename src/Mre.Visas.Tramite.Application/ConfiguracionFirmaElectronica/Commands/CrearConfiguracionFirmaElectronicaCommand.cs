using AutoMapper;
using MediatR;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Repositories;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Domain;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Commands
{
    public class CrearConfiguracionFirmaElectronicaCommand : CrearConfiguracionFirmaElectronicaRequest, IRequest<ApiResponseWrapper<Guid>>
    {

        public CrearConfiguracionFirmaElectronicaCommand()
        {

        }
    }

    public class CrearConfiguracionFirmaElectronicaHandler : BaseHandler, IRequestHandler<CrearConfiguracionFirmaElectronicaCommand, ApiResponseWrapper<Guid>>
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly IConfiguracionFirmaElectronicaRepository configuracionFirmaElectronicaRepository;

        public CrearConfiguracionFirmaElectronicaHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator,
            IConfiguracionFirmaElectronicaRepository configuracionFirmaElectronicaRepository)
            : base(unitOfWork)
        {
            this.mapper = mapper;
            this.mediator = mediator;
            this.configuracionFirmaElectronicaRepository = configuracionFirmaElectronicaRepository;
        }

        public async Task<ApiResponseWrapper<Guid>> Handle(CrearConfiguracionFirmaElectronicaCommand request, CancellationToken cancellationToken)
        {
            var configuracionFirmaElectronica = mapper.Map<Domain.Entities.ConfiguracionFirmaElectronica>(request);

            //Reglas
            var obtenerListaConfiguracionFirmaElectronicaQuery = new ObtenerListaConfiguracionFirmaElectronicaQuery();
            obtenerListaConfiguracionFirmaElectronicaQuery.ServicioId = request.ServicioId;
            obtenerListaConfiguracionFirmaElectronicaQuery.TipoDocumentoCodigo = request.TipoDocumentoCodigo;

            var resultadoReglas = await mediator.Send(obtenerListaConfiguracionFirmaElectronicaQuery);
            if (resultadoReglas.Result.Items.Count > 0) {
                throw new ReglaNegocioException("Existe una configuración con los mismos valores del servicio y tipo documento");
            }


            configuracionFirmaElectronica.AssignId();
            var resultado = await configuracionFirmaElectronicaRepository.InsertAsync(configuracionFirmaElectronica);
            if (!resultado.Item1)
                return new ApiResponseWrapper<Guid>(HttpStatusCode.BadRequest, resultado.Item2);

            var resultSaveChanges = await UnitOfWork.SaveChangesAsync();
            if (!resultSaveChanges.Item1)
                return new ApiResponseWrapper<Guid>(HttpStatusCode.BadRequest, resultSaveChanges.Item2);

            return new ApiResponseWrapper<Guid>(HttpStatusCode.OK, configuracionFirmaElectronica.Id);
        }
    }

}
