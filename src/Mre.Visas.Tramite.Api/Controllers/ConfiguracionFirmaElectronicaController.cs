using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Commands;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Shared.Responses;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Mre.Visas.Tramite.Api.Controllers
{

    [Authorize]
    public class ConfiguracionFirmaElectronicaController : BaseController
    {
        private IMapper _mapper;
        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
 
        
        [HttpGet]
        public  Task<ApiResponseWrapper<ResultadoPaginadoResponse<ConfiguracionFirmaElectronicaResponse>>> ObtenerListaAsync([FromQuery] ObtenerListaConfiguracionFirmaElectronicaRequest paginadoRequest)
        {
            var obtenerListaConfiguracionFirmaElectronicaQuery = Mapper.Map<ObtenerListaConfiguracionFirmaElectronicaQuery>(paginadoRequest);

            return Mediator.Send(obtenerListaConfiguracionFirmaElectronicaQuery); 
        }



        [HttpGet]
        [Route("{id}")]
        public Task<ApiResponseWrapper<ConfiguracionFirmaElectronicaResponse>> ObtenerAsync(Guid id)
        {
            var obtenerListaConfiguracionFirmaElectronicaQuery = new ObtenerConfiguracionFirmaElectronicaQuery(id);

            return Mediator.Send(obtenerListaConfiguracionFirmaElectronicaQuery);
        }


        [HttpPost]
        public Task<ApiResponseWrapper<Guid>> CrearAsync(CrearConfiguracionFirmaElectronicaRequest request)
        {
            var crearConfiguracionFirmaElectronicaCommand = Mapper.Map<CrearConfiguracionFirmaElectronicaCommand>(request);

            return Mediator.Send(crearConfiguracionFirmaElectronicaCommand);
        }

        [HttpPut]
        public Task<ApiResponseWrapper> ActualizarAsync(ActualizarConfiguracionFirmaElectronicaRequest request)
        {
            var actualizarConfiguracionFirmaElectronicaCommand = Mapper.Map<ActualizarConfiguracionFirmaElectronicaCommand>(request);

            return Mediator.Send(actualizarConfiguracionFirmaElectronicaCommand);
        }


        [HttpDelete("{id}")]
        public async Task<ApiResponseWrapper> BorrarAsync(Guid id)
        {
            return await this.Mediator.Send(new BorrarConfiguracionFirmaElectronicaCommand(id));
        }
    }
}
