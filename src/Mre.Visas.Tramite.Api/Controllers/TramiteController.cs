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

namespace Mre.Visas.Tramite.Api.Controllers
{
  public class TramiteController : BaseController
  {
    private IConfiguration configuration;
    //public const string BearerPrefix = "Bearer ";
    //public const string CabeceraAutentificacion = "Authorization";
    //public string TokenAcceso = string.Empty;

    public TramiteController(IConfiguration iconfiguration)
    {
      configuration = iconfiguration;
    }

    // POST: api/Tramite/CrearTramite
    [HttpPost("CrearTramite")]
    [ActionName(nameof(CrearTramiteAsync))]
    public async Task<IActionResult> CrearTramiteAsync(CrearTramiteRequest request)
    {
      return Ok(await Mediator.Send(new CrearTramiteCommand(request)).ConfigureAwait(false));
    }

    // POST: api/Tramite/ConsultarTramitePorId
    [HttpPost("ConsultarTramitePorId")]
    [ActionName(nameof(ConsultarTramitePorIdAsync))]
    public async Task<IActionResult> ConsultarTramitePorIdAsync(ConsultarTramitePorIdRequest request)
    {
      return Ok(await Mediator.Send(new ConsultarTramitePorIdQuery(request)).ConfigureAwait(false));
    }

    // POST: api/Tramite/ConsultarTramitePorId
    /// <summary>
    /// Este metodo permite obtener todos los tramites
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("ConsultarTramitesPorCiudadanoId")]
    [ActionName(nameof(ConsultarTramitesPorCiudadanoId))]
    public async Task<IActionResult> ConsultarTramitesPorCiudadanoId(ConsultarTramitePorCiudadanoIdRequest request)
    {
      return Ok(await Mediator.Send(new ConsultarTramitePorCiudadanoIdQuery(request)).ConfigureAwait(false));
    }

    // POST: api/Tramite/ConsultarTramitePorRolId
    /// <summary>
    /// Este metodo permite obtener todos los tramites
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("ConsultarTramitePorFiltrosRol")]
    [ActionName(nameof(ConsultarTramitePorFiltrosRol))]
    public async Task<IActionResult> ConsultarTramitePorFiltrosRol(ConsultarTramitePorRolFiltrosRequest request)
    {
      return Ok(await Mediator.Send(new ConsultarTramitePorFiltrosQuery(request)).ConfigureAwait(false));
    }

    //[HttpGet("ConsultaGenericaBase64Default")]
    //[ActionName(nameof(ConsultarGenericaBase64Default))]
    //public string ConsultarGenericaBase64Default()
    //{
    //  byte[] imageBytes = new byte[1];
    //  return Convert.ToBase64String(imageBytes);
    //}
    //[HttpGet("ConsultaGenericaByteDefault")]
    //[ActionName(nameof(ConsultaGenericaByteDefault))]
    //public byte[] ConsultaGenericaByteDefault()
    //{
    //  byte[] imageBytes = new byte[1];
    //  return imageBytes;
    //}

    // POST: api/Tramite/ConsultarTramitePorId
    [HttpPost("ConsultarTramitePorCodigoMDG")]
    [ActionName(nameof(ConsultarTramitePorCodigoMDGAsync))]
    public async Task<IActionResult> ConsultarTramitePorCodigoMDGAsync(ConsultarTramitePorCodigoMDGRequest request)
    {
      return Ok(await Mediator.Send(new ConsultarTramitePorCodigoMDGQuery(request)).ConfigureAwait(false));
    }

    // POST: api/Tramite/GenerarPDF
    //[HttpPost("GenerarPDFPorTramiteId")]
    //[ActionName(nameof(GenerarPDFPorTramiteIdAsync))]
    //public async Task<IActionResult> GenerarPDFPorTramiteIdAsync(GenerarPDFPorTramiteIdRequest request)
    //{
    //  //string a =Path.Combine(Environment.CurrentDirectory,"Reports", "Activity.rdlc");
    //  var dato = await Mediator.Send(new GenerarPDFPorTramiteIdQuery(request)).ConfigureAwait(false);
    //  if (dato.HttpStatusCode == System.Net.HttpStatusCode.OK)
    //  {
    //    string base64 = new Shared.Handlers.ReportHandler().GeneratePDFTramite((Domain.Entities.Tramite)dato.Result);
    //    var response = new ApiResponseWrapper(HttpStatusCode.OK, base64);
    //    return Ok(response);
    //  }
    //  else
    //  {
    //    var response = new ApiResponseWrapper(HttpStatusCode.NotFound, "Error al genear el pdf ");
    //    return BadRequest();

    //  }
    //}



    // POST: api/Tramite/CrearTramite
    [HttpPost("ActualizarTramiteSubsanacion")]
    [ActionName(nameof(ActualizarTramiteSubsanacionAsync))]
    public async Task<IActionResult> ActualizarTramiteSubsanacionAsync(ActualizarTramiteSubsanacionRequest request)
    {
      return Ok(await Mediator.Send(new ActualizarTramiteSubsanacionCommand(request)).ConfigureAwait(false));

    }

    // POST: api/Tramite/CrearTramiteCedulacion
    [HttpPost("CrearTramiteCedulacion")]
    [ActionName(nameof(CrearTramiteCedulacionAsync))]
    public async Task<IActionResult> CrearTramiteCedulacionAsync(CrearTramiteCedulacionRequest request)
    {
      return Ok(await Mediator.Send(new CrearTramiteCedulacionCommand(request)).ConfigureAwait(false));
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="unidadAdministrativaId"></param>
    /// <returns></returns>
    [HttpGet("Tramite/unidadAdministrativa/{unidadAdministrativaId}")]
    [ActionName(nameof(ExistenTramitesPorUnidadAdministrativaAsync))]
    public async Task<ExistenTramitesResponse> ExistenTramitesPorUnidadAdministrativaAsync(Guid unidadAdministrativaId)
    {
      //TODO: Implementar
      Random random = new Random();
      bool randomBool = random.Next(2) == 1;

      return new ExistenTramitesResponse { Activo = randomBool, CuentaActivo = 10, CuentaTotal = 20 };
    }

    [HttpGet("Tramite/unidadAdministrativa/{unidadAdministrativaId}/servicio/{servicioId}")]
    [ActionName(nameof(ExistenTramitesPorUnidadAdministrativaServicioAsync))]
    public async Task<ExistenTramitesResponse> ExistenTramitesPorUnidadAdministrativaServicioAsync(Guid unidadAdministrativaId, Guid servicioId)
    {
      //TODO: Implementar
      Random random = new Random();
      bool randomBool = random.Next(2) == 1;

      return new ExistenTramitesResponse { Activo = randomBool, CuentaActivo = 10, CuentaTotal = 20 };
    }


    [HttpGet("Tramite/unidadAdministrativa/{unidadAdministrativaId}/funcional/{usuarioId}")]
    [ActionName(nameof(ExistenTramitesPorUnidadAdministrativaFuncionarioAsync))]
    public async Task<ExistenTramitesResponse> ExistenTramitesPorUnidadAdministrativaFuncionarioAsync(Guid unidadAdministrativaId, Guid usuarioId)
    {
      //TODO: Implementar
      Random random = new Random();
      bool randomBool = random.Next(2) == 1;

      return new ExistenTramitesResponse { Activo = randomBool, CuentaActivo = 10, CuentaTotal = 20 };
    }


    // PUT: api/Tramite/CrearTramite
    [HttpPut("EliminarTramite")]
    [ActionName(nameof(EliminarTramiteAsync))]
    public async Task<IActionResult> EliminarTramiteAsync(EliminarTramiteRequest request)
    {
      return Ok(await Mediator.Send(new EliminarTramiteCommand(request)).ConfigureAwait(false));

    }

    // POST: api/Tramite/ConsultarTramitesBase
    /// <summary>
    /// Este metodo permite obtener los trámites de un usuario, por unidad administrativa y por servicio
    /// </summary>
    /// <param name="request">Objeto request que contiene las propiedades de Servicio, UnidadAdministrativa, Usuario</param>
    /// <returns></returns>
    [HttpPost("ConsultarTramitesBase")]
    [ActionName(nameof(ConsultarTramitesBaseQuery))]
    public async Task<IActionResult> ConsultarTramitesBaseQuery(ConsultarTramitesBaseRequest request)
    {
      return Ok(await Mediator.Send(new ConsultarTramitesBaseQuery(request)).ConfigureAwait(false));
    }

    // GET: api/Tramite/ConsultarTramitesBase
    /// <summary>
    /// Metodo para obtener informacion de reportes
    /// </summary>
    /// <param name="fechaDesde">Fecha Inicio desde de los tramites</param>
    /// <param name="fechaHasta">Fecha Hasta de los tramites</param>
    /// <param name="tipoTramite">codigo del tramite</param>
    /// <param name="rolEstado">id del estado del tramite, sino viene no filtra</param>
    /// <param name="usuarioId">Id del usuario que gestiona, si viene vacio no filtra</param>
    /// <param name="unidadAdministrativaId">Id de unidad adninistrativa si viene vacio no filtra</param>
    /// <returns></returns>
    [HttpPost("ConsultarTramitesGeneral")]
    [ActionName(nameof(ConsultarTramitesGeneralAsyn))]
    public async Task<IActionResult> ConsultarTramitesGeneralAsyn(string fechaDesde, string fechaHasta, string tipoTramite, string codigoEstado, Guid usuarioId, Guid unidadAdministrativaId)
    {
      return Ok(await Mediator.Send(new ConsultarTramitesGeneralQuery(fechaDesde, fechaHasta, tipoTramite, codigoEstado, usuarioId, unidadAdministrativaId)).ConfigureAwait(false));
    }


  }
}