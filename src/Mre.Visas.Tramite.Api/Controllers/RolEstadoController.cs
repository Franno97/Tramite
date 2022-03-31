using Microsoft.AspNetCore.Mvc;
using Mre.Visas.Tramite.Application.RolEstado.Queries;
using Mre.Visas.Tramite.Application.RolEstado.Requests;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Api.Controllers
{
    public class RolEstadoController : BaseController
    {
        // GET: api/Tramite/ConsultarRolEstadoPorNombreRol
        /// <summary>
        /// ConsultarRolEstadoPorNombreRol
        /// </summary>
        /// <param name="nombreRol"></param>
        /// <returns></returns>
        [HttpGet("ConsultarRolEstadoPorNombreRol")]
        [ActionName(nameof(ConsultarRolEstadoPorNombreRol))]
        public async Task<IActionResult> ConsultarRolEstadoPorNombreRol(string nombreRol)
        {
            ConsultarRolEstadoPorNombreRolRequest request = new()
            {
                NombreRol = nombreRol
            };
            return Ok(await Mediator.Send(new ConsultarRolEstadoPorNombreRolQuery(request)).ConfigureAwait(false));
        }

        // GET: api/Tramite/ConsultarSiguientesEstadosPorEstadosActual
        /// <summary>
        /// ConsultarSiguientesEstadosPorEstadosActual
        /// </summary>
        /// <param name="estadoActual"></param>
        /// <returns></returns>
        [HttpGet("ConsultarSiguientesEstadosPorEstadoActual")]
        [ActionName(nameof(ConsultarSiguientesEstadosPorEstadoActual))]
        public async Task<IActionResult> ConsultarSiguientesEstadosPorEstadoActual(string estadoActual)
        {
            ConsultarEstadosSiguientesPorEstadoActualRequest request = new()
            {
                EstadoActual = estadoActual
            };
            return Ok(await Mediator.Send(new ConsultarRolEstadosSiguientesPorEstadoActualQuery(request)).ConfigureAwait(false));
        }

        // GET: api/Tramite/ConsultarRolEstado
        /// <summary>
        /// ConsultarRolEstado
        /// </summary>
        /// <returns></returns>
        [HttpGet("ConsultarRolEstado")]
        [ActionName(nameof(ConsultarRolEstado))]
        public async Task<IActionResult> ConsultarRolEstado()
        {
            return Ok(await Mediator.Send(new ConsultarRolEstadoQuery()).ConfigureAwait(false));
        }
    }
}