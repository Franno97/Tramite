using Microsoft.AspNetCore.Mvc;
using Mre.Visas.Tramite.Application.Tramite.Commands;
using Mre.Visas.Tramite.Application.Tramite.Queries;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System.IO;
using Mre.Visas.Tramite.Application.Tramite.Responses;
using Mre.Visas.Tramite.Application.AsignarFuncionario.Requests;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Queries;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Commands;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Requests;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Responses;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos;

namespace Mre.Visas.Tramite.Api.Controllers
{
    public class OrdenCedulacionController : BaseController
  {

        public OrdenCedulacionController(IConfiguration configuration)
        {
      
        }

        [HttpGet]
        [Route("validar-tramite")]
        public async Task<ApiResponseWrapper<bool>> ValidarTramite(Guid tramiteId)
        {
            return await Mediator.Send(new ValidarTramiteQuery(tramiteId)).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("obtener-pago")]
        public async Task<ApiResponseWrapper<PagoDto>> ObtenerPagoAsync(Guid tramiteId)
        {
            ObtenerPagoRequest request = new()
            {
                TramiteId = tramiteId
            };
            return await Mediator.Send(new ObtenerPagoQuery(request)).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("facturar-servicio")]
        public async Task<ApiResponseWrapper<FacturarServicioResponse>> FacturarServicioAsync(FacturarServicioRequest request)
        {
            return await Mediator.Send(new FacturarServicioCommand(request)).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("generar-orden-cedulacion")]
        public async Task<ApiResponseWrapper<GenerarOrdenCedulacionResponse>> GenerarOrdenCedulacionAsync(GenerarOrdenCedulacionRequest request)
        {
            return await Mediator.Send(new GenerarOrdenCedulacionCommand(request)).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("finalizar-tramite")]
        public async Task<ApiResponseWrapper<FinalizarTramiteResponse>> FinalizarTramiteAsync(FinalizarTramiteRequest request)
        {
            return await Mediator.Send(new FinalizarTramiteCommand(request)).ConfigureAwait(false);
        }
        
    }
}