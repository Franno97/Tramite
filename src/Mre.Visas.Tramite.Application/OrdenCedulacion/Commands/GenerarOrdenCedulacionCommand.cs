using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mre.Visas.Tramite.Application.AsignarFuncionario.Requests;
using Mre.Visas.Tramite.Application.Catalogo.Queries;
using Mre.Visas.Tramite.Application.Catalogo.Requests;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Mappings;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Queries;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Requests;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Responses;
using Mre.Visas.Tramite.Application.OrdenCedulacion.Validations;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Security;
using Mre.Visas.Tramite.Application.Shared.Util;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Queries;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using Mre.Visas.Tramite.Application.Tramite.Responses;
using Mre.Visas.Tramite.Domain.Const;
using Mre.Visas.Tramite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SignatarioDto = Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos.SignatarioDto;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Commands
{
  public class GenerarOrdenCedulacionCommand : GenerarOrdenCedulacionRequest, IRequest<ApiResponseWrapper<GenerarOrdenCedulacionResponse>>
  {

    public GenerarOrdenCedulacionCommand(GenerarOrdenCedulacionRequest request)
    {
      TramiteId = request.TramiteId;
      PagoId = request.PagoId;
      ConyugeNombres = request.ConyugeNombres;
      ConyugePrimerApellido = request.ConyugePrimerApellido;
      ConyugeSegundoApellido = request.ConyugeSegundoApellido;
      ConyugeNacionalidadCodigo = request.ConyugeNacionalidadCodigo;
      ConyugeNacionalidad = request.ConyugeNacionalidad;
      ConyugeCorreoElectronico = request.ConyugeCorreoElectronico;
      Observacion = request.Observacion;
      UsuarioId = request.UsuarioId;
    }

    public class GenerarOrdenCedulacionHandler : BaseHandler, IRequestHandler<GenerarOrdenCedulacionCommand, ApiResponseWrapper<GenerarOrdenCedulacionResponse>>
    {
      private readonly OrdenCedulacionConfiguracion ordenCedulacionConfiguracion;
      private readonly IOrdenCedulacionReporteClient ordenCedulacionReporteClient;
      private readonly ILogger<GenerarOrdenCedulacionHandler> logger;
      private readonly IOrdenCedulacionMapper ordenCedulacionMapper;

      public IPersonaClient PersonaClient { get; }
      public IUsuarioClient UsuarioClient { get; }
      public IUnidadAdministrativaFuncionalClient UnidadAdministrativaFuncionalClient { get; }
      public IHttpApiAutentificacion HttpApiAutentificacion { get; }
      public IMediator Mediator { get; }
      public IFirmaElectronicaClient FirmaElectronicaClient { get; }
      public IVisaElectronicaClient VisaElectronicaClient { get; }
      public IConfigurarFirmaElectronicaClient ConfigurarFirmaElectronicaClient { get; }

      public GenerarOrdenCedulacionHandler(IUnitOfWork unitOfWork,
          IPersonaClient personaClient,
          IUsuarioClient usuarioClient,
          IUnidadAdministrativaFuncionalClient unidadAdministrativaFuncionalClient,
          IHttpApiAutentificacion httpApiAutentificacion,
          IMediator mediator,
          IFirmaElectronicaClient firmaElectronicaClient,
          IVisaElectronicaClient visaElectronicaClient,
          IConfigurarFirmaElectronicaClient configurarFirmaElectronicaClient,
          IOrdenCedulacionReporteClient ordenCedulacionReporteClient,
          IOptions<OrdenCedulacionConfiguracion> ordenCedulacionConfiguracion,
          ILogger<GenerarOrdenCedulacionHandler> logger,
          IOrdenCedulacionMapper ordenCedulacionMapper,
          IMapper mapper)
          : base(unitOfWork)
      {
        PersonaClient = personaClient;
        UsuarioClient = usuarioClient;
        UnidadAdministrativaFuncionalClient = unidadAdministrativaFuncionalClient;
        HttpApiAutentificacion = httpApiAutentificacion;
        Mediator = mediator;
        FirmaElectronicaClient = firmaElectronicaClient;
        VisaElectronicaClient = visaElectronicaClient;
        ConfigurarFirmaElectronicaClient = configurarFirmaElectronicaClient;
        this.ordenCedulacionReporteClient = ordenCedulacionReporteClient;
        this.ordenCedulacionConfiguracion = ordenCedulacionConfiguracion.Value;
        this.logger = logger;
        this.ordenCedulacionMapper = ordenCedulacionMapper;
        Mapper = mapper;
      }

      public async Task<ApiResponseWrapper<GenerarOrdenCedulacionResponse>> Handle(GenerarOrdenCedulacionCommand command, CancellationToken cancellationToken)
      {
        
        #region obtener informacion

        //Obtener tramite
        logger.LogInformation("Obtener informacion del tramite, tramiteId: {tramiteId}", command.TramiteId);
        var tramiteResponse = await Mediator.Send(new ConsultarTramitePorIdQuery(new ConsultarTramitePorIdRequest() { Id = command.TramiteId }));

        if (tramiteResponse.HttpStatusCode != HttpStatusCode.OK)
        {
          logger.LogError("Error al obtener el tramite, tramiteId: {tramiteId}, {respuesta}", command.TramiteId, tramiteResponse.ToStringErrors());
          return new ApiResponseWrapper<GenerarOrdenCedulacionResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
        }

        var tramite = (TramiteCompletoResponse)tramiteResponse.Result;

        //Validacion del tipo y estado del tramite
        logger.LogInformation("Validar informacion del tramite, tramiteId: {tramiteId}", command.TramiteId);
        var validador = new OrdenCedulacionValidaciones<GenerarOrdenCedulacionHandler>(logger);
        var resultadoValidacion = validador.ValidarInformacionTramite(tramite);
        if (resultadoValidacion.HttpStatusCode != HttpStatusCode.OK)
        {
          return new ApiResponseWrapper<GenerarOrdenCedulacionResponse>(resultadoValidacion.HttpStatusCode, resultadoValidacion.Message);
        }

        //Obtener la orden de cedulacion
        logger.LogInformation("Obtener la orden de cedulacion, tramiteId: {tramiteId}", command.TramiteId);
        var ordenCedulacionResponse = await ObtenerOrdenCedulacionAsync(command.TramiteId);

        if (ordenCedulacionResponse.HttpStatusCode != HttpStatusCode.OK)
        {
          return new ApiResponseWrapper<GenerarOrdenCedulacionResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
        }

        var ordenCedulacion = ordenCedulacionResponse.Result;
        
        #endregion obtener informacion

        //Validar el estado de la orden de cedulacion
        if (ordenCedulacion.Estado == EstadoOrdenCedulacion.Firmada)
        {
          var respuestaFirmada = new GenerarOrdenCedulacionResponse()
          {
            NumeroOrden = ordenCedulacion.Numero,
            CodigoVerificacion = ordenCedulacion.CodigoVerificacion,
            NumeroTransaccion = ordenCedulacion.IdTramiteEsigex,
            OrdenCedulacion = Convert.ToBase64String(ordenCedulacion.OrdenCedulacionPdf)
          };

          var respuesta = new ApiResponseWrapper<GenerarOrdenCedulacionResponse>(HttpStatusCode.OK, respuestaFirmada);

          return respuesta;
        }


        logger.LogInformation("Obtener informacion del signatario, tramiteId: {tramiteId}", command.TramiteId);
        var obtenerSignatarioResponse = await ObtenerInformacionSignatarioAsync(command.UsuarioId);

        if (obtenerSignatarioResponse.HttpStatusCode != HttpStatusCode.OK)
        {
          logger.LogError("Error al obtener signatarios, tramiteId: {tramiteId}, usuarioId: {usuarioId}, {respuesta}", command.TramiteId, command.UsuarioId, obtenerSignatarioResponse.ToStringErrors());
          return new ApiResponseWrapper<GenerarOrdenCedulacionResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
        }

        var signatario = obtenerSignatarioResponse.Result;

        //Maperar los datos en el dto de orden de cedulacion
        var ordenCedulacionRequest = await MapearOrdenCedulacionAsync(ordenCedulacion, command, signatario);

        logger.LogInformation("Generar el documento Pdf de la orden de cedulacion, tramiteId: {tramiteId}", command.TramiteId);
        var ordenCedulacionPdf = await GenerarOrdenCedulacionPdfAsync(ordenCedulacionRequest);

        if(ordenCedulacionPdf == null)
        {
            logger.LogError("Error al generar la orden de cedulacion, tramiteId: {tramiteId}", command.TramiteId);
            return new ApiResponseWrapper<GenerarOrdenCedulacionResponse>(HttpStatusCode.BadRequest, TextosConsts.ErrorGenerico);
        }

        //Enviar a firmar el documento de orden de cedulacion
        logger.LogInformation("Llamar al servicio de firma electronica, tramiteId: {tramiteId}", command.TramiteId);
        var ordenFirmada = await FirmarOrdenCedulacionAsync(ordenCedulacionPdf, signatario, tramite.ServicioId, tramite.Id);


        //Guardar orden de cedulacion
        logger.LogInformation("Actualizar orden cedulacion con informacion signatario y conyuge. TramiteId {tramiteId}", tramite.Id);
        ordenCedulacionRequest.OrdenCedulacionPdf = ordenFirmada.DocumentoFirmado;
        var resultadoGuardarOrden = await GuardarOrdenCedulacionAsync(ordenCedulacionRequest);
        if (resultadoGuardarOrden.HttpStatusCode != HttpStatusCode.OK)
        {
          logger.LogError("Error al guardar la orden de cedulacion, tramiteId: {tramiteId}, {respuesta}", command.TramiteId, resultadoGuardarOrden.ToStringErrors());
          return new ApiResponseWrapper<GenerarOrdenCedulacionResponse>(HttpStatusCode.InternalServerError, TextosConsts.ErrorGenerico);
        }

        var respuestaGenerarOrden = new GenerarOrdenCedulacionResponse()
        {
          NumeroOrden = ordenCedulacionRequest.Numero,
          CodigoVerificacion = ordenCedulacionRequest.CodigoVerificacion,
          NumeroTransaccion = ordenCedulacionRequest.IdTramiteEsigex,
          OrdenCedulacion = Convert.ToBase64String(ordenCedulacionRequest.OrdenCedulacionPdf)
        };

        logger.LogInformation("Respuesta de fase de generacion de orden, tramiteId: {tramiteId}, respuestaFacturacion: {respuestaGenerarOrden}", tramite.Id, respuestaGenerarOrden);
        var response = new ApiResponseWrapper<GenerarOrdenCedulacionResponse>(HttpStatusCode.OK, respuestaGenerarOrden);

        return response;
      }

      private async Task<ActualizarOrdenCedulacionRequest> MapearOrdenCedulacionAsync(OrdenCedulacionResponse ordenCedulacion, GenerarOrdenCedulacionCommand command, SignatarioDto signatario)
      {

        ordenCedulacion.ConyugePrimerApellido = command.ConyugePrimerApellido;
        ordenCedulacion.ConyugeSegundoApellido = command.ConyugeSegundoApellido;
        ordenCedulacion.ConyugeNombres = command.ConyugeNombres;
        ordenCedulacion.ConyugeNacionalidadCodigo = command.ConyugeNacionalidadCodigo;
        ordenCedulacion.ConyugeNacionalidad = command.ConyugeNacionalidad;
        ordenCedulacion.ConyugeCorreoElectronico = command.ConyugeCorreoElectronico;
        ordenCedulacion.Observacion = command.Observacion;
        ordenCedulacion.FechaEmision = DateTime.Now;
        ordenCedulacion.FechaInicioValidez = DateTime.Now;
        ordenCedulacion.FechaFinValidez = DateTime.Now.AddDays(ordenCedulacion.Validez);
        ordenCedulacion.FechaRegistro = DateTime.Now;
        ordenCedulacion.SignatarioUsuarioId = signatario.UsuarioId;
        ordenCedulacion.SignatarioApellido = signatario.Apellido;
        ordenCedulacion.SignatarioNombre = signatario.Nombre;
        ordenCedulacion.SignatarioCargo = signatario.Cargo;
        ordenCedulacion.SignatarioCiudad = signatario.Ciudad;

        ordenCedulacion.Estado = EstadoOrdenCedulacion.Firmada;

        var actualizarOrdenReq = await ordenCedulacionMapper.MapearOrdenCedulacionAsync(ordenCedulacion);

        return actualizarOrdenReq;
      }

      private async Task<ApiResponseWrapper> GuardarOrdenCedulacionAsync(ActualizarOrdenCedulacionRequest ordenCedulacion)
      {
        var actualizarOrdenCommand = Mapper.Map<ActualizarOrdenCedulacionCommand>(ordenCedulacion);

        return await Mediator.Send(actualizarOrdenCommand);
      }

      private async Task<byte[]> GenerarOrdenCedulacionPdfAsync(ActualizarOrdenCedulacionRequest ordenCedulacion)
      {
        
        var ordenCedulacionReporteRequest =  new OrdenCedulacionReporteRequest();

        if (!string.IsNullOrEmpty(ordenCedulacion.ConyugeNombres)) {

            ordenCedulacionReporteRequest.ApellidosConyuge = $"{ordenCedulacion.ConyugePrimerApellido} {ordenCedulacion.ConyugeSegundoApellido}";
            ordenCedulacionReporteRequest.NacionalidadConyuge = ordenCedulacion.ConyugeNacionalidad;
            ordenCedulacionReporteRequest.NombresConyuge = ordenCedulacion.ConyugeNombres;

        }


        ordenCedulacionReporteRequest.CategoriaVisa = ordenCedulacion.CategoriaVisa;
        ordenCedulacionReporteRequest.CiudadNacimiento = ordenCedulacion.CiudadNacimiento;
        ordenCedulacionReporteRequest.CodigoVerificacion = ordenCedulacion.CodigoVerificacion;
        ordenCedulacionReporteRequest.EstadoCivil = ordenCedulacion.EstadoCivil;
        ordenCedulacionReporteRequest.FechaEmision = ordenCedulacion.FechaEmision;
        ordenCedulacionReporteRequest.FechaNacimiento = ordenCedulacion.FechaNacimiento;
        ordenCedulacionReporteRequest.FechaOtorgamientoVisa = ordenCedulacion.FechaOtorgamientoVisa;
        ordenCedulacionReporteRequest.Fotografia = Convert.ToBase64String(ordenCedulacion.Fotografia);
        ordenCedulacionReporteRequest.Nacionalidad = ordenCedulacion.Nacionalidad;
        ordenCedulacionReporteRequest.Nombres = ordenCedulacion.Nombres;

        ordenCedulacionReporteRequest.Numero = ordenCedulacion.Numero;
        ordenCedulacionReporteRequest.NumeroVisa = ordenCedulacion.NumeroVisa;
        ordenCedulacionReporteRequest.PaisNacimiento = ordenCedulacion.PaisNacimiento;
        ordenCedulacionReporteRequest.PrimerApellido = ordenCedulacion.PrimerApellido;
        ordenCedulacionReporteRequest.SegundoApellido = ordenCedulacion.SegundoApellido;
        ordenCedulacionReporteRequest.Sexo = ordenCedulacion.Sexo;
        ordenCedulacionReporteRequest.Signatario = $"{ordenCedulacion.SignatarioNombre} {ordenCedulacion.SignatarioApellido}";
        ordenCedulacionReporteRequest.TiempoVigenciaVisa = ordenCedulacion.TiempoVigenciaVisa.ToString();
        ordenCedulacionReporteRequest.TipoVisa = ordenCedulacion.TipoVisa;

        ordenCedulacionReporteRequest.UnidadOtorgamientoVisa = ordenCedulacion.UnidadOtorgamientoVisa;
        ordenCedulacionReporteRequest.Validez = ordenCedulacion.Validez;
 
        var ordenCedulacionReporteResponse = await ordenCedulacionReporteClient.GenerarAsync(ordenCedulacionReporteRequest);

        return ordenCedulacionReporteResponse.Reporte;
      }


      #region FirmaElectronica

      public async Task<FirmaElectronicaInput> ObtenerFirmaElectronicaInputAsync(byte[] documentoFirmar,
          SignatarioDto signatario,
          Guid servicioId,
          Guid tramiteId)
      {
        //1. Obtener configuacion
        logger.LogInformation("Obtener configuracion de firma electronica. Usuario {usuario}. TramiteId {tramiteId}", signatario.UsuarioId, tramiteId);

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
        logger.LogInformation("Obtener configurar de insumos firma electronica. ServicioId {servicioId}. TipoDocumentoCodigo {tipoDocumentoCodigo}", servicioId, ordenCedulacionConfiguracion.TipoDocumentoCodigo);

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

        logger.LogInformation("Firmar electronicamente orden cedulacion. TramiteId {tramiteId}", tramiteId);

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

      private async Task<ApiResponseWrapper<OrdenCedulacionResponse>> ObtenerOrdenCedulacionAsync(Guid tramiteId)
      {
        //Obtener la orden de cedulacion
        logger.LogInformation("Verificar si existe una orden de cedulacion creada, tramiteId: {tramiteId}", tramiteId);
        var consultarOrdenResponse = await Mediator.Send(new ObtenerOrdenCedulacionPorTramiteIdQuery(tramiteId));

        if (consultarOrdenResponse.HttpStatusCode != HttpStatusCode.OK)
        {
          logger.LogInformation("Error al obtener la orden de cedulacion, tramiteId: {tramiteId}", tramiteId);
          return consultarOrdenResponse;
        }

        return consultarOrdenResponse;
      }


    }
  }
}
