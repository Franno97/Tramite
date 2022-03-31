using Microsoft.AspNetCore.Mvc;
using Mre.Visas.Tramite.Application.AsignarFuncionario.Queries;
using Mre.Visas.Tramite.Application.AsignarFuncionario.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Api.Controllers
{
    public class ObtenerFuncionarioAsignarController : BaseController
    {
        [HttpGet("ObtenerFuncionarioAsignar")]
        [ActionName(nameof(ObtenerFuncionarioAsignarAsync))]
        public async Task<IActionResult> ObtenerFuncionarioAsignarAsync(Guid unidadAdministrativaId, Guid servicioId, string nombreRol)
        {
            ObtenerFuncionarioAsignarRequest request = new()
            {
                UnidadAdministrativaId = unidadAdministrativaId,
                ServicioId = servicioId,
                NombreRol = nombreRol
            };
            return Ok(await Mediator.Send(new ObtenerFuncionarioAsignarQuery(request)).ConfigureAwait(false));
        }
    }
}
