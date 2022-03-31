using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Mre.Visas.Tramite.Application.AsignarFuncionario.Queries;
using Mre.Visas.Tramite.Application.AsignarFuncionario.Requests;
using Mre.Visas.Tramite.Application.Movimiento.Request;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Security;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using Mre.Visas.Tramite.Domain.Const;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Commands
{
  public class CrearTramiteCommand : CrearTramiteRequest, IRequest<ApiResponseWrapper>
  {
    public CrearTramiteCommand(CrearTramiteRequest request)
    {
      UsuarioId = request.UsuarioId;
      UnidadAdministrativaIdCEV = request.UnidadAdministrativaIdCEV;
      Beneficiario = request.Beneficiario;
      Documentos = request.Documentos;
      Solicitante = request.Solicitante;
      TipoConvenioId = request.TipoConvenioId;
      CalidadMigratoriaId = request.CalidadMigratoriaId;
      ActividadId = request.ActividadId;
      TipoVisaId = request.TipoVisaId;
      ServicioId = request.ServicioId;
      CodigoPais = request.CodigoPais;
      Observacion = request.Observacion;
      PersonaId = request.PersonaId;
    }

    public class CrearTramiteCommandHandler : BaseHandler, IRequestHandler<CrearTramiteCommand, ApiResponseWrapper>
    {
      public CrearTramiteCommandHandler(IUnitOfWork unitOfWork, ITokenAcceso tokenAcceso, INotificadorClient notificadorClient, IHttpApiAutentificacion httpApiAutentificacion,
        IOptions<RemoteServices> remoteServices, IUnidadAdministrativaClient unidadAdministrativaClient, IUsuarioClient usuarioClient, IUnidadAdministrativaFuncionalClient unidadAdministrativaFuncionalClient,
        IMediator mediator)
          : base(unitOfWork, tokenAcceso, notificadorClient)
      {
        HttpApiAutentificacion = httpApiAutentificacion;
        this.remoteServices = remoteServices.Value;
        UnidadAdministrativaClient = unidadAdministrativaClient;
        IdentidadClient = usuarioClient;
        UnidadAdministrativaFuncionalClient = unidadAdministrativaFuncionalClient;
        Mediator = mediator;
      }

      public IHttpApiAutentificacion HttpApiAutentificacion { get; }
      public IMediator Mediator { get; }

      private readonly RemoteServices remoteServices;
      IUnidadAdministrativaClient UnidadAdministrativaClient;
      protected IUsuarioClient IdentidadClient;
      protected IUnidadAdministrativaFuncionalClient UnidadAdministrativaFuncionalClient;


      [Authorize(Contracts.TramitePermissionDefinition.TramiteCrear)]
      public async Task<ApiResponseWrapper> Handle(CrearTramiteCommand command, CancellationToken cancellationToken)
      {
        Application.Tramite.Responses.CrearTramiteResponse crearTramiteResponse = new Responses.CrearTramiteResponse();
        ApiResponseWrapper response = new ApiResponseWrapper(HttpStatusCode.OK, null);
        Guid usuarioId = new Guid();
        HttpClient Client;
        String Uri = string.Empty;
        string PlacesJson = string.Empty;
        HttpResponseMessage Response;
        var unidadAdministrativaResponseZonal = new Application.Tramite.Responses.UnidadAdministrativaResponse();

        var RolEstados = await UnitOfWork.RolEstadoRepository.GetAllAsync();
        //obtener el token
        string token = await HttpApiAutentificacion.GetAccessTokenAsync();
        if (string.IsNullOrEmpty(token))
        {
          return new ApiResponseWrapper(HttpStatusCode.Unauthorized, "El usuario no esta autenticado");
        }

        #region ObtenerConsultor Asignado

        var request = new ObtenerFuncionarioAsignarRequest
        {
          UnidadAdministrativaId = command.UnidadAdministrativaIdCEV,
          ServicioId = command.ServicioId,
          NombreRol = "Consultor",
        };

        var responseWrapper = await Mediator.Send(new ObtenerFuncionarioAsignarQuery(request));

        var guid = responseWrapper.Result as Guid?;

        usuarioId = guid.Value;


        #endregion

        #region Obtener Unidad Administrativa Zonal
        UnidadAdministrativaInfoDto unidadAdministrativaZonal;
        try
        {
          UnidadAdministrativaClient.SetAccessToken(token);
          var unidades = await UnidadAdministrativaClient.JurisdiccionAsync(command.Beneficiario.Domicilio.Ciudad);
          unidadAdministrativaZonal = unidades.Items.FirstOrDefault();

          if (unidadAdministrativaZonal == null)
            return new ApiResponseWrapper(HttpStatusCode.BadRequest, "Error al obtener unidades administrativas.");
        }
        catch (Exception ex)
        {
          return new ApiResponseWrapper(HttpStatusCode.NotFound, "Error al obtener unidad administrativa");
        }


        #endregion

        string image = command.Beneficiario.Foto.Substring(0, 21);
        if (command.Beneficiario.Foto.Substring(0, 22) != "data:image/jpeg;base64"
         && command.Beneficiario.Foto.Substring(0, 21) != "data:image/jpg;base64"
         && command.Beneficiario.Foto.Substring(0, 21) != "data:image/png;base64")
        {
          response = new ApiResponseWrapper(HttpStatusCode.BadRequest, "El formato del campo foto de beficiario no cumple con el formato de base 64");
          return response;
        }

        try
        {
          UnitOfWork.TramiteRepository.BeginTransaction();

          #region Crear
          //solicitud de visa
          var NumeroTramite = await UnitOfWork.TramiteRepository.GetNumeroTramite("SV");
          Domain.Entities.Tramite tramite = new Domain.Entities.Tramite();
          tramite = new Domain.Entities.Tramite
          {
            TipoTramite = "SV",
            PersonaId = command.PersonaId,
            ServicioId = command.ServicioId,
            CodigoPais = command.CodigoPais,
            UnidadAdministrativaIdCEV = command.UnidadAdministrativaIdCEV,
            UnidadAdministrativaIdZonal = unidadAdministrativaZonal.Id,
            Fecha = System.DateTime.Now.ToString("yyyy-MM-dd"),
            CreatorId = command.UsuarioId,
            Created = System.DateTime.Now,
            LastModified = System.DateTime.Now,
            LastModifierId = command.UsuarioId,
            ActividadId = command.ActividadId,
            Numero = NumeroTramite,
            Beneficiario = new Domain.Entities.Beneficiario
            {
              FechaEmisionConadis = command.Beneficiario.FechaEmisionConadis ?? new DateTime(1900, 1, 1),
              FechaCaducidadConadis = command.Beneficiario.FechaCaducidadConadis ?? new DateTime(1900, 1, 1),
              TipoCiudadano = command.Beneficiario.TipoCiudadano,
              CarnetConadis = command.Beneficiario.CarnetConadis,
              CiudadNacimiento = command.Beneficiario.CiudadNacimiento,
              CodigoMDG = command.Beneficiario.CodigoMDG,
              Correo = command.Beneficiario.Correo,
              Domicilio = new Domain.Entities.Domicilio
              {
                Ciudad = command.Beneficiario.Domicilio.Ciudad,
                Direccion = command.Beneficiario.Domicilio.Direccion,
                Pais = command.Beneficiario.Domicilio.Pais,
                Provincia = command.Beneficiario.Domicilio.Provincia,
                TelefonoCelular = command.Beneficiario.Domicilio.TelefonoCelular,
                TelefonoDomicilio = command.Beneficiario.Domicilio.TelefonoDomicilio,
                TelefonoTrabajo = command.Beneficiario.Domicilio.TelefonoTrabajo
              },
              Edad = 0,
              EstadoCivil = command.Beneficiario.EstadoCivil,
              FechaNacimiento = command.Beneficiario.FechaNacimiento,
              Foto = command.Beneficiario.Foto, // Convert.FromBase64String(command.Beneficiario.Foto),
              Genero = command.Beneficiario.Genero,
              Ocupacion = command.Beneficiario.Ocupacion,
              NacionalidadId = command.Beneficiario.NacionalidadId,
              Nacionalidad = command.Beneficiario.Nacionalidad,
              Nombres = command.Beneficiario.Nombres,
              PaisNacimiento = command.Beneficiario.PaisNacimiento,
              Pasaporte = new Domain.Entities.Pasaporte
              {
                CiudadEmision = command.Beneficiario.Pasaporte.CiudadEmision,
                FechaEmision = command.Beneficiario.Pasaporte.FechaEmision,
                FechaExpiracion = command.Beneficiario.Pasaporte.FechaExpiracion,
                FechaNacimiento = command.Beneficiario.Pasaporte.FechaNacimiento,
                Nombres = command.Beneficiario.Pasaporte.Nombres,
                Numero = command.Beneficiario.Pasaporte.Numero,
                PaisEmision = command.Beneficiario.Pasaporte.PaisEmision,
                // Comentario Tipo DocumentoIdentidad Id
                TipoDocumentoIdentidadId = command.Beneficiario.Pasaporte.TipoDocumentoIdentidadId ?? "PAS",
              },
              PorcentajeDiscapacidad = command.Beneficiario.PorcentajeDiscapacidad,
              PoseeDiscapacidad = command.Beneficiario.PoseeDiscapacidad,
              PrimerApellido = command.Beneficiario.PrimerApellido,
              SegundoApellido = command.Beneficiario.SegundoApellido,
              Visa = new Domain.Entities.Visa
              {
                PoseeVisa = command.Beneficiario.Visa.PoseeVisa.Value,
                ConfirmacionVisa = command.Beneficiario.Visa.ConfirmacionVisa.Value,
                EstadoVisa = command.Beneficiario.Visa.EstadoVisa,
                FechaCaducidad = command.Beneficiario.Visa.FechaCaducidad.Value,
                FechaConcesion = command.Beneficiario.Visa.FechaConcesion.Value,
                IdActoConsularVisa = command.Beneficiario.Visa.IdActoConsularVisa,
                IdCentroAdministrativo = command.Beneficiario.Visa.IdCentroAdministrativo,
                IdPersona = command.Beneficiario.Visa.IdPersona,
                IdTramite = command.Beneficiario.Visa.IdTramite,
                NombreActoConsularVisa = command.Beneficiario.Visa.NombreActoConsularVisa,
                NombreCentroAdministrativo = command.Beneficiario.Visa.NombreCentroAdministrativo,
                Nombres = command.Beneficiario.Visa.Nombres,
                NumeroPasaporte = command.Beneficiario.Visa.NumeroPasaporte,
                NumeroVisa = command.Beneficiario.Visa.NumeroVisa,
                PrimerApellido = command.Beneficiario.Visa.PrimerApellido,
                SegundoApellido = command.Beneficiario.Visa.SegundoApellido,
              }
            },
            CalidadMigratoriaId = command.CalidadMigratoriaId,
            Documentos = new List<Domain.Entities.Documento>(),
            SoporteGestiones = new List<Domain.Entities.SoporteGestion>(),
            Movimientos = new List<Domain.Entities.Movimiento>(),
            TipoConvenioId = command.TipoConvenioId,
            Solicitante = new Domain.Entities.Solicitante
            {
              Identificacion = command.Solicitante.Identificacion,
              TipoIdentificacion = command.Solicitante.TipoIdentificacion,
              Ciudad = command.Solicitante.Ciudad,
              ConsuladoNombre = command.Solicitante.ConsuladoNombre,
              ConsuladoPais = command.Solicitante.ConsuladoPais,
              Direccion = command.Solicitante.Direccion,
              Edad = command.Solicitante.Edad,
              Correo = command.Solicitante.Correo,
              Nacionalidad = command.Solicitante.Nacionalidad,
              Nombres = command.Solicitante.Nombres,
              Pais = command.Solicitante.Pais,
              Telefono = command.Solicitante.Telefono
            },
            TipoVisaId = command.TipoVisaId
          };

          tramite.AssignId();
          tramite.OrigenId = tramite.Id;
          tramite.Solicitante.AssignId();

          foreach (var documento in command.Documentos)
          {
            tramite.Documentos.Add(new Domain.Entities.Documento
            {
              TramiteId = tramite.Id,
              Nombre = documento.Nombre,
              Ruta = Shared.Util.Util.ObtenerUrlDocumento(remoteServices.documentos.BaseUrl, documento.TipoDocumento, documento.Nombre),
              Observacion = documento.Observacion,
              TipoDocumento = documento.TipoDocumento ?? "",
              IconoNombre = documento.IconoNombre,
              ImagenNombre = documento.ImagenNombre,
              DescripcionDocumento = documento.DescripcionDocumento,
              CreatorId = command.UsuarioId,
              LastModifierId = command.UsuarioId,
              Created = System.DateTime.Now,
              LastModified = System.DateTime.Now,
              EstadoProceso = Domain.Const.EstadoDocumentoConst.Validar
            });
          }

          #region Crear 1 movimiento            
          var primerEstado = RolEstados.FirstOrDefault(x => x.CodigoEstado.Equals("1"));
          tramite.Movimientos.Add(new Domain.Entities.Movimiento
          {
            CreatorId = command.UsuarioId,
            LastModifierId = command.UsuarioId,
            UsuarioId = Guid.Empty,
            NombreRol = primerEstado.NombreRol,
            Orden = 1,
            Vigente = false,
            NombreEstado = primerEstado.NombreEstado,
            FechaHoraCita = new DateTime(1900, 1, 1),
            UnidadAdministrativaId = Guid.Empty,
            ObservacionDatosPersonales = command.Observacion ?? string.Empty,
            ObservacionSoportesGestion = string.Empty,
            ObservacionDomicilios = string.Empty,
            ObservacionMovimientoMigratorio = string.Empty,
            ObservacionMultas = string.Empty,
            Estado = primerEstado.CodigoEstado,
            DiasTranscurridos = 0,
            Created = System.DateTime.Now,
            LastModified = System.DateTime.Now
          });
          #endregion

          #region Crear 2 movimiento
          var segundoEstado = RolEstados.FirstOrDefault(x => x.CodigoEstado.Equals(primerEstado.CodigosEstadoSiguiente));
          #endregion

          tramite.Movimientos.Add(new Domain.Entities.Movimiento
          {
            CreatorId = command.UsuarioId,
            LastModifierId = command.UsuarioId,
            UsuarioId = usuarioId,//temporal
            NombreRol = segundoEstado.NombreRol,
            Orden = 2,
            Vigente = true,
            NombreEstado = segundoEstado.NombreEstado,
            FechaHoraCita = new DateTime(1900, 1, 1),
            UnidadAdministrativaId = command.UnidadAdministrativaIdCEV,
            ObservacionDatosPersonales = command.Observacion ?? string.Empty,
            ObservacionSoportesGestion = string.Empty,
            ObservacionDomicilios = string.Empty,
            ObservacionMovimientoMigratorio = string.Empty,
            ObservacionMultas = string.Empty,
            Estado = segundoEstado.CodigoEstado,
            DiasTranscurridos = 0,
            Created = System.DateTime.Now,
            LastModified = System.DateTime.Now
          });

          var insert = await UnitOfWork.TramiteRepository.InsertAsync(tramite);
          if (insert.Item1.Equals(true))
          {
            bool commit = false;
            do
            {
              var result = await UnitOfWork.SaveChangesAsync();

              if (result.Item1)
              {
                crearTramiteResponse.Id = tramite.Id;
                crearTramiteResponse.Numero = tramite.Numero;
                crearTramiteResponse.Mensaje = "Tramite creado";
                response = new ApiResponseWrapper(HttpStatusCode.OK, crearTramiteResponse);
                commit = true;
              }
              else
              {
                if (result.Item2.Contains("Violation of UNIQUE KEY"))
                {
                  //solicitud de visa
                  var NumeroTramite2 = await UnitOfWork.TramiteRepository.GetNumeroTramite("SV");
                  tramite.Numero = NumeroTramite2;
                  await UnitOfWork.TramiteRepository.InsertAsync(tramite);
                }
                else
                {
                  crearTramiteResponse.Mensaje = result.Item2;
                  response = new ApiResponseWrapper(HttpStatusCode.BadRequest, crearTramiteResponse);
                  commit = true;
                }
              }
            } while (commit == false);
          }
          else
          {
            crearTramiteResponse.Mensaje = insert.Item2;
            response = new ApiResponseWrapper(HttpStatusCode.BadRequest, crearTramiteResponse);
          }
          #endregion

          UnitOfWork.TramiteRepository.CommitTransaction();

          #region Mensajes
          var datos = new CrearMovimientoSharePointResponse();
          Client = new HttpClient();
          Uri = remoteServices.sharePoint.BaseUrl + "SharePointMensajes/api/mensaje?modulo=MensajesVisa&pagina=" + primerEstado.NombreEstado + "";
          Response = await Client.GetAsync(Uri);
          if (Response.StatusCode == HttpStatusCode.OK)
          {
            PlacesJson = Response.Content.ReadAsStringAsync().Result;
            datos = JsonConvert.DeserializeObject<CrearMovimientoSharePointResponse>(PlacesJson);
            if (datos.Mensaje.Contains("Error al obtener la lista de mensajes"))
            {
              return new ApiResponseWrapper(HttpStatusCode.BadRequest, "No se logro encontrar mensaje acorde al estado:" + primerEstado.NombreEstado);
            }
          }
          else
          {
            return new ApiResponseWrapper(HttpStatusCode.BadRequest, "No se logro encontrar mensaje acorde al estado:" + primerEstado.NombreEstado);
          }
          #endregion

          #region Notificar

          //en definición proceso de notificación
          var salida = new NotificacionMensajeDto
          {
            Codigo = TramitesConst.Plantilla,
            Asunto = $"Trámite creado - [{primerEstado.NombreEstado} - {tramite.Numero}]",
            Destinatarios = tramite.Solicitante.Correo,
            Model = new Dictionary<string, object>()
          };
          salida.Model.Add("PersonaNombreApellido", tramite.Solicitante.Nombres);
          salida.Model.Add("Cuerpo", datos.Mensaje);
          salida.Model.Add("InformacionTramite", tramite.Numero);

          try
          {
            NotificadorClient.SetAccessToken(token);
            var re = await NotificadorClient.NotificadorAsync(salida);
          }
          catch
          {
            //no hay defincion  de parte de se cae el servicio
          }
          #endregion

        }
        catch (Exception ex)
        {

          UnitOfWork.TramiteRepository.RollbackTransaction();
          crearTramiteResponse.Mensaje = ex.InnerException.Message;
          response = new ApiResponseWrapper(HttpStatusCode.BadRequest, crearTramiteResponse);
        }
        return response;
      }
    }
  }

  public class CrearTramiteCommandValidator : AbstractValidator<CrearTramiteCommand>
  {
    public CrearTramiteCommandValidator()
    {
      RuleFor(e => e.Beneficiario)
          .NotEmpty().WithMessage("{PropertyName} es requerida.")
          .NotNull().WithMessage("{PropertyName} No puede ser nulo.");

      RuleFor(e => e.Documentos)
          .NotEmpty().WithMessage("{PropertyName} es requerida.")
          .NotNull().WithMessage("{PropertyName} No puede ser nulo.");

      RuleFor(e => e.Solicitante)
          .NotEmpty().WithMessage("{PropertyName} es requerida.")
          .NotNull().WithMessage("{PropertyName} No puede ser nulo.");
    }
  }
}