using AutoMapper;
using MediatR;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Repositories;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Domain;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Commands
{


    public class ActualizarConfiguracionFirmaElectronicaCommand : ActualizarConfiguracionFirmaElectronicaRequest, IRequest<ApiResponseWrapper>
    {

        public ActualizarConfiguracionFirmaElectronicaCommand()
        {

        }
    }


    public class ActualizarConfiguracionFirmaElectronicaHandler : BaseHandler, IRequestHandler<ActualizarConfiguracionFirmaElectronicaCommand, ApiResponseWrapper>
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly IConfiguracionFirmaElectronicaRepository configuracionFirmaElectronicaRepository;

        public ActualizarConfiguracionFirmaElectronicaHandler(
            IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator,
            IConfiguracionFirmaElectronicaRepository configuracionFirmaElectronicaRepository)
            : base(unitOfWork)
        {
            this.mapper = mapper;
            this.mediator = mediator;
            this.configuracionFirmaElectronicaRepository = configuracionFirmaElectronicaRepository;
        }

        public async Task<ApiResponseWrapper> Handle(ActualizarConfiguracionFirmaElectronicaCommand request, CancellationToken cancellationToken)
        {
            var configuracionFirmaElectronica = await configuracionFirmaElectronicaRepository.GetByIdAsync(request.Id);
            if (configuracionFirmaElectronica == null)
            {
                return new ApiResponseWrapper(HttpStatusCode.NotFound, "Configuración de Firma Electrónica no encontrada");
            }


            //Reglas
            var obtenerListaConfiguracionFirmaElectronicaQuery = new ObtenerListaConfiguracionFirmaElectronicaQuery();
            obtenerListaConfiguracionFirmaElectronicaQuery.ServicioId = request.ServicioId;
            obtenerListaConfiguracionFirmaElectronicaQuery.TipoDocumentoCodigo = request.TipoDocumentoCodigo;

            var resultadoReglas = await mediator.Send(obtenerListaConfiguracionFirmaElectronicaQuery);
            if (resultadoReglas.Result.Items.Count > 0 && !resultadoReglas.Result.Items.Any(x => x.Id == request.Id))
            {
                throw new ReglaNegocioException("Existe una configuración con los mismos valores del servicio y tipo documento");
            }



            mapper.Map(request, configuracionFirmaElectronica);

           
            var resultado = configuracionFirmaElectronicaRepository.Update(configuracionFirmaElectronica);
            if (!resultado.Item1)
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, resultado.Item2);


            var resultSaveChanges = await UnitOfWork.SaveChangesAsync();
            if (!resultSaveChanges.Item1)
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, resultSaveChanges.Item2);


            return new ApiResponseWrapper(HttpStatusCode.OK, null);
        }
    }
}
