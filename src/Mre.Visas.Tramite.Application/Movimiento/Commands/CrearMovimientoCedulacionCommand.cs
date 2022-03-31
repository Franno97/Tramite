using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Security;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using Mre.Visas.Tramite.Domain.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SignatarioDto = Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos.SignatarioDto;
using Mre.Visas.Tramite.Application.Externos.Responses;
using Mre.Visas.Tramite.Application.Movimiento.Dtos;
using Mre.Visas.Tramite.Application.Movimiento.Request;
using Mre.Visas.Tramite.Application.Movimiento.Responses;
using Mre.Visas.Tramite.Domain.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using ArancelDto = Mre.Visas.Tramite.Application.Movimiento.Dtos.ArancelDto;
using GrabarFacturaResultadoResponse = Mre.Visas.Tramite.Application.Movimiento.Responses.GrabarFacturaResultadoResponse;
using Mre.Visas.Tramite.Application.OrdenCedulacion;
using Mre.Visas.Tramite.Application.Shared.Responses;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace Mre.Visas.Tramite.Application.Movimiento.Commands
{
  public class CrearMovimientoCedulacionCommand : CrearMovimientoCedulacionRequest, IRequest<ApiResponseWrapper>
  {
    public CrearMovimientoCedulacionCommand(CrearMovimientoCedulacionRequest request)
    {
      TramiteId = request.TramiteId;
      Estado = request.Estado;
      CreatorId = request.CreatorId;
    }

    public partial class CrearMovimientoCedulacionCommandHandler : BaseHandler, IRequestHandler<CrearMovimientoCedulacionCommand, ApiResponseWrapper>
    {
      public CrearMovimientoCedulacionCommandHandler(IUnitOfWork unitOfWork, IHttpApiAutentificacion httpApiAutentificacion, ILogger<CrearMovimientoCedulacionCommandHandler> logger,
        IUnidadAdministrativaClient unidadAdministrativaClient,
        IUnidadAdministrativaFuncionalClient unidadAdministrativaFuncionalClient,
        INotificadorClient notificadorClient,
        IConfigurarFirmaElectronicaClient configurarFirmaElectronicaClient,
        IFirmaElectronicaClient firmaElectronicaClient,
        IUsuarioClient usuarioClient,
        IMediator mediator,
        IOptions<OrdenCedulacionConfiguracion> ordenCedulacionConfiguracion
        )
          : base(unitOfWork)
      {
        HttpApiAutentificacion = httpApiAutentificacion;
        Logger = logger;
        UnidadAdministrativaClient = unidadAdministrativaClient;
        UnidadAdministrativaFuncionalClient = unidadAdministrativaFuncionalClient;
        ConfigurarFirmaElectronicaClient = configurarFirmaElectronicaClient;
        FirmaElectronicaClient = firmaElectronicaClient;
        UsuarioClient = usuarioClient;
        Mediator = mediator;
        NotificadorClient = notificadorClient;
        this.ordenCedulacionConfiguracion = ordenCedulacionConfiguracion.Value;
      }
      public IHttpApiAutentificacion HttpApiAutentificacion { get; }
      public ILogger<CrearMovimientoCedulacionCommandHandler> Logger { get; }
      public IUnidadAdministrativaClient UnidadAdministrativaClient { get; }
      public IUnidadAdministrativaFuncionalClient UnidadAdministrativaFuncionalClient { get; }
      public IConfigurarFirmaElectronicaClient ConfigurarFirmaElectronicaClient { get; }
      public IFirmaElectronicaClient FirmaElectronicaClient { get; }
      public IUsuarioClient UsuarioClient { get; }
      public IMediator Mediator { get; }
      public INotificadorClient NotificadorClient2 { get; }
      private readonly OrdenCedulacionConfiguracion ordenCedulacionConfiguracion;

      [Authorize(Contracts.TramitePermissionDefinition.MovimientoCrear)]
      public async Task<ApiResponseWrapper> Handle(CrearMovimientoCedulacionCommand command, CancellationToken cancellationToken)
      {
        var response = new CrearMovimientoCedulacionResponse();

        var tramite = await UnitOfWork.TramiteRepository.GetByIdTramiteCompleto(command.TramiteId);

        if (tramite == null)
        {
          return new ApiResponseWrapper(HttpStatusCode.NotFound, "No existe el IdTramite");
        }
        else
        {
          try
          {
            Domain.Entities.RolEstado rolEstado = new Domain.Entities.RolEstado();
            rolEstado = UnitOfWork.RolEstadoRepository.GetRolEstadoByEstado(command.Estado.ToString());
            if (rolEstado == null)
            {
              response = new CrearMovimientoCedulacionResponse
              {
                Estado = "ERROR",
                Mensaje = "No existe estado"
              };
              return new ApiResponseWrapper(HttpStatusCode.BadRequest, response);
            }
            #region Anterior Movimiento

            var ultimoMovimiento = tramite.Movimientos.LastOrDefault(x => x.Vigente.Equals(true));
            ultimoMovimiento.Vigente = false;
            ultimoMovimiento.LastModified = System.DateTime.Now;
            ultimoMovimiento.LastModifierId = command.CreatorId;
            var resultado1 = UnitOfWork.MovimientoRepository.Update(ultimoMovimiento);

            #endregion Anterior Movimiento

            #region Nuevo Movimiento

            var nuevoMovimiento = new Domain.Entities.Movimiento
            {
              Orden = tramite.Movimientos.Count + 1,
              ObservacionDatosPersonales = string.Empty,
              ObservacionDomicilios = string.Empty,
              ObservacionMovimientoMigratorio = string.Empty,
              ObservacionMultas = string.Empty,
              ObservacionSoportesGestion = string.Empty,
              NombreRol = rolEstado.NombreRol,
              Estado = command.Estado.ToString(),
              UnidadAdministrativaId = ultimoMovimiento.UnidadAdministrativaId,
              Vigente = true,
              DiasTranscurridos = 0,
              NombreEstado = rolEstado.NombreEstado,
              FechaHoraCita = new DateTime(1900, 1, 1),
              UsuarioId = ultimoMovimiento.UsuarioId,
              Created = System.DateTime.Now,
              CreatorId = command.CreatorId,
              LastModifierId = command.CreatorId,
              LastModified = System.DateTime.Now,
              TramiteId = tramite.Id
            };
            nuevoMovimiento.AssignId();
            var resultado = UnitOfWork.MovimientoRepository.InsertAsync(nuevoMovimiento);
            if (!resultado.Result.Item1)
              return new ApiResponseWrapper(HttpStatusCode.BadRequest, resultado.Result.Item2);

            var result2 = await UnitOfWork.SaveChangesAsync();
            if (!result2.Item1)
              return new ApiResponseWrapper(HttpStatusCode.BadRequest, result2.Item2);

            response = new CrearMovimientoCedulacionResponse
            {
              Estado = "OK",
              Mensaje = "Movimiento creado"
            };
            return new ApiResponseWrapper(HttpStatusCode.OK, response);

            #endregion Nuevo Movimiento
          }
          catch (Exception ex)
          {
            response = new CrearMovimientoCedulacionResponse
            {
              Estado = "ERROR",
              Mensaje = ex.Message
            };
            return new ApiResponseWrapper(HttpStatusCode.BadRequest, response);
          }
        }
      }
      /// <summary>
      /// Método que obtiene los valores de los aranceles a pagar
      /// </summary>
      /// <param name="edad"></param>
      /// <param name="porcentajeDiscapacidad"></param>
      /// <param name="servicioId"></param>
      /// <param name="urlUnidadAdministrativa"></param>
      /// <param name="tokenAcceso"></param>
      /// <param name="listaConfiguracion"></param>
      /// <returns></returns>
      private async Task<Tuple<string, List<ArancelDto>>> ObtenerValoresAPagarAsync(int edad, decimal porcentajeDiscapacidad, Guid servicioId, string urlUnidadAdministrativa, string tokenAcceso, List<ConfiguracionPago> listaConfiguracion)
      {
        HttpClient Client = new();
        Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenAcceso);
        String Uri = string.Empty;
        string PlacesJson = string.Empty;

        HttpResponseMessage Response;
        List<ArancelDto> aranceles = new List<ArancelDto>();

        // Verificando que existan configuraciones de pagos a realizar
        if (listaConfiguracion.Count == 0)
          return new Tuple<string, List<ArancelDto>>("Error al obtener configuración de aranceles.", null);

        // Generando los aranceles a cobrar
        foreach (var configuracionPago in listaConfiguracion)
        {
          // Obtener datos del arancel
          #region Obtener Arancel
          Uri = $"{urlUnidadAdministrativa}api/unidad-administrativa/partida-arancelaria-servicio/{configuracionPago.ServicioIdPago}";
          Response = await Client.GetAsync(Uri);
          if (Response.StatusCode != HttpStatusCode.OK)
          {
            return new Tuple<string, List<ArancelDto>>($"Error al obtener la configuración de las partidas arancelarias.{Environment.NewLine}" +
              $"{Response.StatusCode}{Environment.NewLine}{Response.RequestMessage}", null);
          }

          PlacesJson = Response.Content.ReadAsStringAsync().Result;
          ListaPartidaArancelaria listaPartidasArancelarias = new ListaPartidaArancelaria();
          listaPartidasArancelarias = JsonConvert.DeserializeObject<ListaPartidaArancelaria>(PlacesJson);

          if (listaPartidasArancelarias.Items.Count == 0)
          {
            return new Tuple<string, List<ArancelDto>>("No existen partidas arancelarias configuradas.", null);
          }

          var arancel = new ArancelDto
          {
            ServicioId = configuracionPago.ServicioIdPago,
            DescripcionArancelaria = configuracionPago.Descripcion,
            PartidaArancelaria = listaPartidasArancelarias.Items[0].PartidaArancelaria,
            ValorArancelario = listaPartidasArancelarias.Items[0].Valor,
            ArancelId = listaPartidasArancelarias.Items[0].ArancelId,
            PartidaArancelariaId = listaPartidasArancelarias.Items[0].PartidaArancelariaId,
            Servicio = listaPartidasArancelarias.Items[0].Servicio,
            NumeroPartida = listaPartidasArancelarias.Items[0].NumeroPartida,
            JerarquiaArancelariaId = listaPartidasArancelarias.Items[0].JerarquiaArancelariaId,
            JerarquiaArancelaria = listaPartidasArancelarias.Items[0].JerarquiaArancelaria,
            Arancel = listaPartidasArancelarias.Items[0].Arancel,
            FacturarEn = configuracionPago.FacturarEn
          };

          #endregion

          #region Obtener Exoneraciones

          Uri = $"{urlUnidadAdministrativa}api/unidad-administrativa/convenio/exoneration/{configuracionPago.ServicioIdPago}";

          Response = await Client.GetAsync(Uri);
          if (Response.StatusCode != HttpStatusCode.OK)
          {
            return new Tuple<string, List<ArancelDto>>("Error al obtener las configuraciones de exoneraciones.", null);
          }

          PlacesJson = Response.Content.ReadAsStringAsync().Result;
          ListaConvenios listaConvenios = new ListaConvenios();
          listaConvenios = JsonConvert.DeserializeObject<ListaConvenios>(PlacesJson);

          if (listaConvenios.Items.Count > 0)
          {
            var convenioTeceraEdad = listaConvenios.Items.FirstOrDefault(x => edad >= x.EdadInicial && !x.Discapacitado.Value && x.EdadInicial > 0);
            if (convenioTeceraEdad != null)
            {
              arancel.ValorArancelario = convenioTeceraEdad.Valor;
              arancel.ConvenioId = convenioTeceraEdad.ConvenioId;
              arancel.TipoServicio = convenioTeceraEdad.TipoServicio;
              arancel.TipoExoneracionId = convenioTeceraEdad.TipoExoneracionId;
              arancel.TipoExoneracion = convenioTeceraEdad.TipoExoneracion;
            }

            if (porcentajeDiscapacidad >= 30)
            {
              var convenioDiscapacidad = listaConvenios.Items.FirstOrDefault(x => x.Discapacitado.Value);
              if (convenioDiscapacidad != null)
              {
                arancel.ValorArancelario = convenioDiscapacidad.Valor;
                arancel.ConvenioId = convenioDiscapacidad.ConvenioId;
                arancel.TipoServicio = convenioDiscapacidad.TipoServicio;
                arancel.TipoExoneracionId = convenioDiscapacidad.TipoExoneracionId;
                arancel.TipoExoneracion = convenioDiscapacidad.TipoExoneracion;

              }
            }

          }

          aranceles.Add(arancel);
          #endregion
        }

        return new Tuple<string, List<ArancelDto>>("", aranceles);
      }
      #region FirmaElectronica

      public async Task<FirmaElectronicaInput> ObtenerFirmaElectronicaInputAsync(byte[] documentoFirmar,
          SignatarioDto signatario,
          Guid servicioId,
          Guid tramiteId)
      {
        //1. Obtener configuacion
        Logger.LogInformation("Obtener configuracion de firma electronica. Usuario {usuario}. TramiteId {tramiteId}", signatario.UsuarioId, tramiteId);

        var token = await HttpApiAutentificacion.GetAccessTokenAsync();
        ConfigurarFirmaElectronicaClient.SetAccessToken(token);
        var configurarFirmaElectronicaDto = await ConfigurarFirmaElectronicaClient.ConfigurarFirmaElectronicaGetAsync(signatario.UsuarioId);

        if (configurarFirmaElectronicaDto == null)
        {
          throw new Exception(TextosConsts.FirmaElectronica.NoExisteConfiguracionFirma);
        }


        //Recuperar configuracion posiciones firma electronica
        var obtenerListaConfiguracionFirmaElectronicaQuery = new ObtenerListaConfiguracionFirmaElectronicaQuery();
        obtenerListaConfiguracionFirmaElectronicaQuery.ServicioId = servicioId;
        obtenerListaConfiguracionFirmaElectronicaQuery.TipoDocumentoCodigo = ordenCedulacionConfiguracion.TipoDocumentoCodigo;

        //2. Obtener configuacion inumos
        Logger.LogInformation("Obtener configurar de insumos firma electronica. ServicioId {servicioId}. TipoDocumentoCodigo {tipoDocumentoCodigo}", servicioId, ordenCedulacionConfiguracion.TipoDocumentoCodigo);


        var firmaElectronicaInsumosRespuesta = await Mediator.Send(obtenerListaConfiguracionFirmaElectronicaQuery);

        if (firmaElectronicaInsumosRespuesta.HttpStatusCode != HttpStatusCode.OK ||
            firmaElectronicaInsumosRespuesta.Result.TotalRegistros != 1)
        {
          throw new Exception(TextosConsts.FirmaElectronica.NoExisteFirmaInsumos);
        }

        var firmaElectronicaInsumo = firmaElectronicaInsumosRespuesta.Result.Items.SingleOrDefault();

        var firmaElectronicaInput = new FirmaElectronicaInput();

        var insumosFirmaDto = new InsumosFirmaDto();
        insumosFirmaDto.Pass = configurarFirmaElectronicaDto.Clave;
        insumosFirmaDto.ModeloFirma = firmaElectronicaInsumo.ModeloFirma;
        insumosFirmaDto.Cargo = signatario.Cargo;
        insumosFirmaDto.TamanoFirma = firmaElectronicaInsumo.TamanioFirma.ToString();
        insumosFirmaDto.PosicionX = firmaElectronicaInsumo.PosicionX.ToString();
        insumosFirmaDto.PosicionY = firmaElectronicaInsumo.PosicionY.ToString();
        insumosFirmaDto.PaginaAFirmar = firmaElectronicaInsumo.NumeroPagina.ToString();

        firmaElectronicaInput.Firma = configurarFirmaElectronicaDto.Data;
        firmaElectronicaInput.Documento = documentoFirmar;
        firmaElectronicaInput.InsumosFirma = insumosFirmaDto;

        return firmaElectronicaInput;
      }

      public async Task<FirmaElectronicaOutput> FirmarOrdenCedulacionAsync(byte[] documentoFirmar,
          SignatarioDto signatario,
          Guid servicioId,
          Guid tramiteId)
      {
        //Obtener valores para la firma
        var firmaElectronicaInput = await ObtenerFirmaElectronicaInputAsync(documentoFirmar, signatario, servicioId, tramiteId);

        Logger.LogInformation("Firmar electronicamente orden cedulación. TramiteId {tramiteId}", tramiteId);

        //realizar firma electronica
        return await FirmaElectronicaClient.FirmarAsync(firmaElectronicaInput);
      }


      #endregion FirmaElectronica

      private async Task<ApiResponseWrapper<SignatarioDto>> ObtenerInformacionSignatarioAsync(Guid usuarioId)
      {
        var token = await HttpApiAutentificacion.GetAccessTokenAsync();

        if (string.IsNullOrEmpty(token))
        {
          return new ApiResponseWrapper<SignatarioDto>(HttpStatusCode.Unauthorized, TextosConsts.UsuarioNoAutenticado);
        }

        UsuarioClient.SetAccessToken(token);
        var listaIds = new List<Guid>() { usuarioId };
        var usuarios = await UsuarioClient.UsuarioGetAsync(listaIds);
        var usuario = usuarios.SingleOrDefault();

        UnidadAdministrativaFuncionalClient.SetAccessToken(token);
        var funcionarioInfo = await UnidadAdministrativaFuncionalClient.FuncionarioAsync(usuarioId);

        var respuesta = new SignatarioDto()
        {
          UsuarioId = usuarioId,
          Nombre = usuario.Name,
          Apellido = usuario.Surname,
          Cargo = funcionarioInfo.Cargo,
          Ciudad = funcionarioInfo.Ciudad
        };

        return new ApiResponseWrapper<SignatarioDto>(HttpStatusCode.OK, respuesta);
      }
    }
  }

  public class CrearMovimientoCedulacionCommandValidator : AbstractValidator<CrearMovimientoCedulacionCommand>
  {
    public CrearMovimientoCedulacionCommandValidator()
    {
      RuleFor(e => e.TramiteId)
           .NotEmpty().WithMessage("{PropertyName} es requerido.")
           .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

      RuleFor(e => e.Estado)
           .NotEmpty().WithMessage("{PropertyName} es requerido.")
           .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
           .InclusiveBetween(1, 200);

      RuleFor(e => e.CreatorId)
           .NotEmpty().WithMessage("{PropertyName} es requerido.")
           .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
    }
  }


}