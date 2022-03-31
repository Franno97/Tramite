using Microsoft.AspNetCore.Mvc;
using Mre.Visas.Tramite.Application.Movimiento.Commands;
using Mre.Visas.Tramite.Application.Movimiento.Request;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Mre.Visas.Tramite.Application.Tramite.Commands;
using Mre.Visas.Tramite.Application.Tramite.Requests;

namespace Mre.Visas.Tramite.Api.Controllers
{
  public class MovimientoController : BaseController
  {
    private IConfiguration configuration;
    public MovimientoController(IConfiguration iconfiguration)
    {
      configuration = iconfiguration;
    }

    // POST: api/Tramite/CrearMovimiento
    /// <summary>
    /// CrearMovimiento
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("CrearMovimiento")]
    [ActionName(nameof(CrearMovimientoAsync))]
    public async Task<IActionResult> CrearMovimientoAsync(CrearMovimientoRequest request)
    {
      var re = HttpContext.Request;
      var headers = re.Headers;
      string autentificacionCabecera = headers["Authorization"];
      string BearerPrefix = "Bearer ";
      string TokenAcceso = string.Empty;

      if (autentificacionCabecera != null && autentificacionCabecera.StartsWith("Bearer ") && !string.IsNullOrEmpty(autentificacionCabecera))
      {
        TokenAcceso = autentificacionCabecera.Substring(BearerPrefix.Length);
      }

      return Ok(await Mediator.Send(new CrearMovimientoCommand(request, TokenAcceso)).ConfigureAwait(false));
    }

    // POST: api/Tramite/ActualizarMovimiento
    /// <summary>
    /// ActualizarMovimiento
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("ActualizarMovimiento")]
    [ActionName(nameof(ActualizarMovimientoAsync))]
    public async Task<IActionResult> ActualizarMovimientoAsync(ActualizarMovimientoRequest request)
    {
      return Ok(await Mediator.Send(new ActualizarMovimientoCommand(request)).ConfigureAwait(false));
    }

    // POST: api/Tramite/CrearMovimientoCredulacion
    /// <summary>
    /// CrearMovimiento
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("CrearMovimientoCedulacion")]
    [ActionName(nameof(CrearMovimientoCedulacionAsync))]
    public async Task<IActionResult> CrearMovimientoCedulacionAsync(CrearMovimientoCedulacionRequest request)
    {

      return Ok(await Mediator.Send(new CrearMovimientoCedulacionCommand(request)).ConfigureAwait(false));
    }


    // PUT: api/Tramite/ActualizarMovimientoReasignacion
    /// <summary>
    /// ActualizarMovimiento Reasignación
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("ActualizarMovimientoReasignacion")]
    [ActionName(nameof(ActualizarMovimientoReasignacionAsync))]
    public async Task<IActionResult> ActualizarMovimientoReasignacionAsync(ActualizarMovimientoReasignacionRequest request)
    {
      return Ok(await Mediator.Send(new ActualizarMovimientoReasignacionCommand(request)).ConfigureAwait(false));
    }

  }
}