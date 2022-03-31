using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mre.Visas.Tramite.Application.Catalogo.Commands;
using Mre.Visas.Tramite.Application.Catalogo.Queries;
using Mre.Visas.Tramite.Application.Catalogo.Requests;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Api.Controllers
{
  public class CalidadMigratoriaController : BaseController
  {
    [HttpGet("ConsultarCalidadMigratoria")]
    [ActionName(nameof(ConsultarCalidadMigratoria))]
    public async Task<IActionResult> ConsultarCalidadMigratoria()
    {
      return Ok(await Mediator.Send(new ConsultarCalidadMigratoriaQuery()).ConfigureAwait(false));
    }

    // POST: api/CalidadMigratoria/CrearCalidadMigratoria
    [HttpPost("CrearCalidadMigratoria")]
    [ActionName(nameof(CrearCalidadMigratoriaAsync))]
    public async Task<IActionResult> CrearCalidadMigratoriaAsync(CalidadMigratoriaRequest request)
    {
      return Ok(await Mediator.Send(new CrearCalidadMigratoriaCommand(request)).ConfigureAwait(false));
    }

  }
  public class TipoConvenioController : BaseController
  {
    [HttpGet("ConsultarTipoConvenio")]
    [ActionName(nameof(ConsultarTipoConvenio))]
    public async Task<IActionResult> ConsultarTipoConvenio()
    {
      return Ok(await Mediator.Send(new ConsultarTipoConvenioQuery()).ConfigureAwait(false));
    }

    // POST: api/TipoConvenio/CrearTipoConvenio
    [HttpPost("CrearTipoConvenio")]
    [ActionName(nameof(CrearTipoConvenioAsync))]
    public async Task<IActionResult> CrearTipoConvenioAsync(TipoConvenioRequest request)
    {
      return Ok(await Mediator.Send(new CrearTipoConvenioCommand(request)).ConfigureAwait(false));
    }

  }
  public class TipoVisaController : BaseController
  {
    [HttpGet("ConsultarTipoVisaPorConvenioCodigo")]
    [ActionName(nameof(ConsultarTipoVisaPorConvenioCodigo))]
    public async Task<IActionResult> ConsultarTipoVisaPorConvenioCodigo(string convenioCodigo)
    {
      ConsultarCatalogoRequest request = new()
      {
        Codigo = convenioCodigo
      };
      return Ok(await Mediator.Send(new ConsultarTipoVisaQuery(request)).ConfigureAwait(false));
    }


    // POST: api/TipoVisa/CrearTipoVisa
    [HttpPost("CrearTipoVisa")]
    [ActionName(nameof(CrearTipoVisaAsync))]
    public async Task<IActionResult> CrearTipoVisaAsync(TipoVisaRequest request)
    {
      return Ok(await Mediator.Send(new CrearTipoVisaCommand(request)).ConfigureAwait(false));
    }

  }
  public class ActividadDesarrollarController : BaseController
  {
    [HttpGet("ConsultarActividadDesarrollarPorTipoVisaCodigo")]
    [ActionName(nameof(ConsultarActividadDesarrollarPorTipoVisaCodigo))]
    public async Task<IActionResult> ConsultarActividadDesarrollarPorTipoVisaCodigo(string tipoVisaCodigo)
    {
      ConsultarCatalogoRequest request = new()
      {
        Codigo = tipoVisaCodigo
      };
      return Ok(await Mediator.Send(new ConsultarActividadDesarrollarQuery(request)).ConfigureAwait(false));
    }

    // POST: api/ActividadDesarrollar/CrearActividadDesarrollar
    [HttpPost("CrearActividadDesarrollar")]
    [ActionName(nameof(CrearActividadDesarrollarAsync))]
    public async Task<IActionResult> CrearActividadDesarrollarAsync(ActividadDesarrollarRequest request)
    {
      return Ok(await Mediator.Send(new CrearActividadDesarrollarCommand(request)).ConfigureAwait(false));
    }


  }

  public class ConfiguracionController : BaseController
  {
    [HttpGet("ConsultarConfiguracion")]
    [ActionName(nameof(ConsultarConfiguracion))]
    public async Task<IActionResult> ConsultarConfiguracion(string codigoTipoConfiguracion)
    {
      ConsultarCatalogoRequest request = new()
      {
        Codigo = codigoTipoConfiguracion
      };
      return Ok(await Mediator.Send(new ConsultarConfiguracionQuery(request)).ConfigureAwait(false));
    }
  }

}
