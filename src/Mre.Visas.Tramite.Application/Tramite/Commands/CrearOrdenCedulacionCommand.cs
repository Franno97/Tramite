using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.Movimiento.Request;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Security;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Requests;
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
  public class CrearOrdenCedulacionCommand : CrearTramiteRequest, IRequest<ApiResponseWrapper>
  {
    public string Token { get; set; }
    public string UrlUnidadAdministrativa { get; set; }
    public string UrlTramite { get; set; }
    public string UrlMensajes { get; set; }
    public CrearOrdenCedulacionCommand(CrearTramiteRequest request, string token, string urlUnidadAdministrativa, string urlTramite, string urlMensajes)
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
      Token = token;
      UrlUnidadAdministrativa = urlUnidadAdministrativa;
      UrlTramite = urlTramite;
      ServicioId = request.ServicioId;
      CodigoPais = request.CodigoPais;
      UrlMensajes = urlMensajes;
    }

    public class CrearOrdenCedulacionCommandHandler : BaseHandler, IRequestHandler<CrearOrdenCedulacionCommand, ApiResponseWrapper>
    {
      public CrearOrdenCedulacionCommandHandler(IUnitOfWork unitOfWork, ITokenAcceso tokenAcceso, INotificadorClient notificadorClient)
          : base(unitOfWork, tokenAcceso, notificadorClient)
      {
      }

      public async Task<ApiResponseWrapper> Handle(CrearOrdenCedulacionCommand command, CancellationToken cancellationToken)
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

        #region ObtenerConsultor Asignado
        Client = new HttpClient();
        Uri = command.UrlTramite + "api/ObtenerFuncionarioAsignar/ObtenerFuncionarioAsignar?unidadAdministrativaId=" + command.UnidadAdministrativaIdCEV + "&servicioId=" + command.ServicioId + "&nombreRol=Consultor";
        Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + command.Token);
        Response = await Client.GetAsync(Uri);
        if (Response.StatusCode == HttpStatusCode.OK)
        {
          PlacesJson = Response.Content.ReadAsStringAsync().Result;
          Application.AsignarFuncionario.Response.ObtenerFuncionarioAsignarResponse datos = new Application.AsignarFuncionario.Response.ObtenerFuncionarioAsignarResponse();
          datos = JsonConvert.DeserializeObject<Application.AsignarFuncionario.Response.ObtenerFuncionarioAsignarResponse>(PlacesJson);
          if (datos.httpStatusCode == 200)
          {
            usuarioId = datos.result;
          }
          else
          {
            response = new ApiResponseWrapper(HttpStatusCode.BadRequest, "No se logro obtener un usuario consultor para asignar");
            return response;
          }
        }
        else
        {
          response = new ApiResponseWrapper(HttpStatusCode.NotFound, "Errores al consultar Unidad Administrativa Zonal");
          return response;
        }
        #endregion

        #region Obtener Unidad Administrativa Zonal
        Client = new HttpClient();
        Uri = command.UrlUnidadAdministrativa + "api/unidad-administrativa/unidad-administrativa/jurisdiccion/" + command.Beneficiario.Domicilio.Ciudad + "";
        Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + command.Token);
        Response = await Client.GetAsync(Uri);
        if (Response.StatusCode == HttpStatusCode.OK)
        {
          PlacesJson = Response.Content.ReadAsStringAsync().Result;
          Application.Tramite.Responses.UnidadAdministrativaListaResponse datos = new Responses.UnidadAdministrativaListaResponse();
          datos = JsonConvert.DeserializeObject<Application.Tramite.Responses.UnidadAdministrativaListaResponse>(PlacesJson);
          unidadAdministrativaResponseZonal = datos.items.Where(x => x.siglas != "CEV").FirstOrDefault();
          if (unidadAdministrativaResponseZonal == null)
          {
            response = new ApiResponseWrapper(HttpStatusCode.BadRequest, "No tiene Unidad Administrativa Zonal");
            return response;
          }
        }
        else
        {
          response = new ApiResponseWrapper(HttpStatusCode.NotFound, "Errores al consultar Unidad Administrativa Zonal");
          return response;
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
            PersonaId = command.UsuarioId,
            ServicioId = command.ServicioId,
            CodigoPais = command.CodigoPais,
            UnidadAdministrativaIdCEV = command.UnidadAdministrativaIdCEV,
            UnidadAdministrativaIdZonal = unidadAdministrativaResponseZonal.id,
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
          tramite.CreatorId = tramite.Solicitante.Id;

          foreach (var documento in command.Documentos)
          {
            switch (documento.TipoDocumento)
            {
              case "CEDU":
                documento.Ruta = "http://172.31.3.27/Cedula/" + documento.Nombre;
                break;
              case "APEN":
                documento.Ruta = "http://172.31.3.27/AntecedentesPenales/" + documento.Nombre;
                break;
              case "COND":
                documento.Ruta = "http://172.31.3.27/CarnetDiscapacidad/" + documento.Nombre;
                break;
              case "PASP":
                documento.Ruta = "http://172.31.3.27/Pasaporte/" + documento.Nombre;
                break;
              case "RCON":
                documento.Ruta = "http://172.31.3.27/RegistroConsular/" + documento.Nombre;
                break;
              case "PAGO":
                documento.Ruta = "http://172.31.3.27/PagoComprobante/" + documento.Nombre;
                break;
              case "PNAC":
                documento.Ruta = "http://172.31.3.27/PartidaNacimiento/" + documento.Nombre;
                break;
              case "FOTO":
                documento.Ruta = "http://172.31.3.27/Foto/" + documento.Nombre;
                break;
            }

            tramite.Documentos.Add(new Domain.Entities.Documento
            {
              TramiteId = tramite.Id,
              Nombre = documento.Nombre,
              Ruta = documento.Ruta,
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
            ObservacionDatosPersonales = string.Empty,
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
            ObservacionDatosPersonales = string.Empty,
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
          Uri = command.UrlMensajes + "SharePointMensajes/api/mensaje?modulo=MensajesVisa&pagina=" + primerEstado.NombreEstado + "";
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
          var salida = new NotificacionMensajeDto();
          salida.Codigo = "NOTIFICACION.GENERAL.01";
          salida.Asunto = primerEstado.NombreEstado;
          salida.Destinatarios = tramite.Solicitante.Correo;
          salida.Model = new Dictionary<string, object>();
          salida.Model.Add("PersonaNombreApellido", tramite.Solicitante.Nombres);
          salida.Model.Add("Cuerpo", datos.Mensaje);

          string token = await TokenAcceso.ObtenerAsync();
          NotificadorClient.SetAccessToken(token);
          var re = await NotificadorClient.NotificadorAsync(salida);
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

  public class CrearOrdenCedulacionCommandValidator : AbstractValidator<CrearOrdenCedulacionCommand>
  {
    public CrearOrdenCedulacionCommandValidator()
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