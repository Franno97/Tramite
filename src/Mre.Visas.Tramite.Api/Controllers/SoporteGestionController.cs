using Microsoft.AspNetCore.Mvc;
using Mre.Visas.Tramite.Application.SoporteGestion.Commands;
using Mre.Visas.Tramite.Application.SoporteGestion.Requests;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Api.Controllers
{
    public class SoporteGestionController : BaseController
    {
        // POST: api/Tramite/CrearSoporteGestion
        /// <summary>
        /// CrearSoporteGestion
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CrearSoporteGestion")]
        [ActionName(nameof(CrearSoporteGestionAsync))]
        public async Task<IActionResult> CrearSoporteGestionAsync(CrearSoporteGestionRequest request)
        {
            return Ok(await Mediator.Send(new CrearSoporteGestionCommand(request)).ConfigureAwait(false));
        }
    }
}