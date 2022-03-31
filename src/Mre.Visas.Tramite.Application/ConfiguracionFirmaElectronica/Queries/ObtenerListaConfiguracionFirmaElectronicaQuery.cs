using AutoMapper;
using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Repositories;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Requests;
using Mre.Visas.Tramite.Application.Shared.Responses;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries
{

    public class ObtenerListaConfiguracionFirmaElectronicaRequest : PaginadoYOrdenadoRequest
    {
        public Guid? ServicioId { get; set; }

        public string TipoDocumentoCodigo { get; set; }

    }

    public class ObtenerListaConfiguracionFirmaElectronicaQuery : ObtenerListaConfiguracionFirmaElectronicaRequest, IRequest<ApiResponseWrapper<ResultadoPaginadoResponse<ConfiguracionFirmaElectronicaResponse>>>
    {

    }




    public class ObtenerListaConfiguracionFirmaElectronicaHandler : BaseHandler, IRequestHandler<ObtenerListaConfiguracionFirmaElectronicaQuery, ApiResponseWrapper<ResultadoPaginadoResponse<ConfiguracionFirmaElectronicaResponse>>>
    {
        private readonly IMapper mapper;
        private readonly IConfiguracionFirmaElectronicaRepository configuracionFirmaElectronicaRepository;

        public ObtenerListaConfiguracionFirmaElectronicaHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IConfiguracionFirmaElectronicaRepository configuracionFirmaElectronicaRepository)
            : base(unitOfWork)
        {
            this.mapper = mapper;
            this.configuracionFirmaElectronicaRepository = configuracionFirmaElectronicaRepository;
        }

        public async Task<ApiResponseWrapper<ResultadoPaginadoResponse<ConfiguracionFirmaElectronicaResponse>>> Handle(ObtenerListaConfiguracionFirmaElectronicaQuery request, CancellationToken cancellationToken)
        {
            try
            {
              
                var resultadoPaginado = await configuracionFirmaElectronicaRepository.ObtenerListaAsync(request);
    
                var resultadoPaginadoResponse = mapper.Map< ResultadoPaginadoResponse < Domain.Entities.ConfiguracionFirmaElectronica>,
                        ResultadoPaginadoResponse <ConfiguracionFirmaElectronicaResponse>>(resultadoPaginado);


                return new ApiResponseWrapper<ResultadoPaginadoResponse<ConfiguracionFirmaElectronicaResponse>>(HttpStatusCode.OK, resultadoPaginadoResponse);
 
            }
            catch (System.Exception ex)
            {

                return new ApiResponseWrapper<ResultadoPaginadoResponse<ConfiguracionFirmaElectronicaResponse>>(HttpStatusCode.BadRequest, message: ex.Message);
            }
        }

    
    }


    public class ObtenerListaConfiguracionFirmaElectronicaValidator : AbstractValidator<ObtenerListaConfiguracionFirmaElectronicaQuery>
    {
        public ObtenerListaConfiguracionFirmaElectronicaValidator()
        {
            //RuleFor(e => e.ServicioId)
            //     .NotEmpty().WithMessage("{PropertyName} es requerido.")
            //     .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
        }
    }
}
