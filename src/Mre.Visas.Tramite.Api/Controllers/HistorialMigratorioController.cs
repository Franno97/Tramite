using Microsoft.AspNetCore.Mvc;
using Mre.Visas.Tramite.Application.HistorialMigratorio.Commands;
using Mre.Visas.Tramite.Application.HistorialMigratorio.Queries;
using Mre.Visas.Tramite.Application.HistorialMigratorio.Requests;
using Mre.Visas.Tramite.Application.Tramite.Commands;
using Mre.Visas.Tramite.Application.Tramite.Queries;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Api.Controllers
{
  public class HistorialMigratorioController : BaseController
  {
    // POST: api/Tramite/CrearTramite
    [HttpPost("GuardarHistorialMigratorio")]
    [ActionName(nameof(GuardarHistorialMigratorioAsync))]
    public async Task<IActionResult> GuardarHistorialMigratorioAsync(HistorialMigratorioRequest request)
    {
      return Ok(await Mediator.Send(new GuardarHistorialMigratorioCommand(request)).ConfigureAwait(false));
    }

    [HttpGet("ConsultarHistorialMigratorio")]
    [ActionName(nameof(ConsultarHistorialMigratorio))]
    public async Task<IActionResult> ConsultarHistorialMigratorio(Guid tramiteId)
    {
      ConsultarHistorialMigratorioRequest request = new ConsultarHistorialMigratorioRequest
      {
        TramiteId = tramiteId
      };

      return Ok(await Mediator.Send(new ConsultarHistorialMigratorioQuery(request)).ConfigureAwait(false));
    }

  }
}
