using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mre.Visas.Tramite.Application.Documento.Commands;
using Mre.Visas.Tramite.Application.Documento.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Api.Controllers
{
  public class DocumentoController : BaseController
  {
    // POST: api/Tramite/ActualizarDocumento
    /// <summary>
    /// ActualizarMovimiento
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("ActualizarDocumento")]
    [ActionName(nameof(ActualizarDocumentoAsync))]
    public async Task<IActionResult> ActualizarDocumentoAsync(ActualizarDocumentoRequest request)
    {
      return Ok(await Mediator.Send(new ActualizarDocumentoCommand(request)).ConfigureAwait(false));
    }

    // POST: api/Tramite/ActualizarDocumento
    /// <summary>
    /// ActualizarMovimiento
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("ActualizarDocumentoEstadoProceso")]
    [ActionName(nameof(ActualizarDocumentoEstadoProcesoAsync))]
    public async Task<IActionResult> ActualizarDocumentoEstadoProcesoAsync(ActualizarDocumentoEstadoProcesoRequest request)
    {
      return Ok(await Mediator.Send(new ActualizarDocumentoEstadoProcesoCommand(request)).ConfigureAwait(false));
    }

    // POST: api/Tramite/CrearDocumento
    /// <summary>
    /// ActualizarMovimiento
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("CrearDocumento")]
    [ActionName(nameof(CrearDocumentoAsync))]
    public async Task<IActionResult> CrearDocumentoAsync(CrearDocumentoRequest request)
    {
      return Ok(await Mediator.Send(new CrearDocumentoCommand(request)).ConfigureAwait(false));
    }

  }
}
