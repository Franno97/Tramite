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
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Commands
{
  public class CrearTramiteCedulacionCommand : CrearTramiteCedulacionRequest, IRequest<ApiResponseWrapper>
  {
    public CrearTramiteCedulacionCommand(CrearTramiteCedulacionRequest request)
    {
      UsuarioId = request.UsuarioId;
      TramiteId = request.TramiteId;
      UnidadAdministrativaId = request.UnidadAdministrativaId;
    }

    public class CrearTramiteCedulacionCommandHandler : BaseHandler, IRequestHandler<CrearTramiteCedulacionCommand, ApiResponseWrapper>
    {
      public CrearTramiteCedulacionCommandHandler(IUnitOfWork unitOfWork, ITokenAcceso tokenAcceso, INotificadorClient notificadorClient)
          : base(unitOfWork, tokenAcceso, notificadorClient)
      {
      }

      public async Task<ApiResponseWrapper> Handle(CrearTramiteCedulacionCommand command, CancellationToken cancellationToken)
      {
        var crearTramiteResponse = new Responses.CrearTramiteCedulacionResponse();
        ApiResponseWrapper response = new ApiResponseWrapper(HttpStatusCode.OK, null);

        String Uri = string.Empty;
        string PlacesJson = string.Empty;
        var RolEstados = await UnitOfWork.RolEstadoRepository.GetAllAsync();

        try
        {
          UnitOfWork.TramiteRepository.BeginTransaction();

          #region Crear tramite cedulación
          //codigo 02 = tramite cedulación
          var NumeroTramite = await UnitOfWork.TramiteRepository.GetNumeroTramite("OC");

          var tramiteSolicitudVisa = await UnitOfWork.TramiteRepository.GetByIdTramiteCompleto(command.TramiteId);
          Domain.Entities.Tramite tramiteOrdenCedulacion = new Domain.Entities.Tramite
          {
            ActividadId = tramiteSolicitudVisa.ActividadId,
            CreatorId = command.UsuarioId,
            CodigoPais = tramiteSolicitudVisa.CodigoPais,
            TipoConvenioId = tramiteSolicitudVisa.TipoConvenioId,
            CalidadMigratoriaId = tramiteSolicitudVisa.TipoConvenioId,
            Numero = NumeroTramite,
            OrigenId = command.TramiteId,
            TipoTramite = "OC",
            Fecha = DateTime.Now.ToString("yyyy-MM-dd"),
            ServicioId = Guid.Parse("585A5FC9-3EBA-5AC6-D503-3A01AA446115"),//quemado por el momento del servicio de cedulación
            PersonaId = tramiteSolicitudVisa.PersonaId,
            Documentos = new List<Domain.Entities.Documento>(),
            SoporteGestiones = new List<Domain.Entities.SoporteGestion>(),
            TipoVisaId = tramiteSolicitudVisa.TipoVisaId,
            UnidadAdministrativaIdCEV = tramiteSolicitudVisa.UnidadAdministrativaIdCEV,
            UnidadAdministrativaIdZonal = tramiteSolicitudVisa.UnidadAdministrativaIdZonal,
            Beneficiario = new Domain.Entities.Beneficiario
            {
              FechaEmisionConadis = tramiteSolicitudVisa.Beneficiario.FechaEmisionConadis,
              FechaCaducidadConadis = tramiteSolicitudVisa.Beneficiario.FechaCaducidadConadis,
              TipoCiudadano = tramiteSolicitudVisa.Beneficiario.TipoCiudadano,
              CarnetConadis = tramiteSolicitudVisa.Beneficiario.CarnetConadis,
              CiudadNacimiento = tramiteSolicitudVisa.Beneficiario.CiudadNacimiento,
              CodigoMDG = tramiteSolicitudVisa.Beneficiario.CodigoMDG,
              Correo = tramiteSolicitudVisa.Beneficiario.Correo,
              Domicilio = new Domain.Entities.Domicilio
              {
                Ciudad = tramiteSolicitudVisa.Beneficiario.Domicilio.Ciudad,
                Direccion = tramiteSolicitudVisa.Beneficiario.Domicilio.Direccion,
                Pais = tramiteSolicitudVisa.Beneficiario.Domicilio.Pais,
                Provincia = tramiteSolicitudVisa.Beneficiario.Domicilio.Provincia,
                TelefonoCelular = tramiteSolicitudVisa.Beneficiario.Domicilio.TelefonoCelular,
                TelefonoDomicilio = tramiteSolicitudVisa.Beneficiario.Domicilio.TelefonoDomicilio,
                TelefonoTrabajo = tramiteSolicitudVisa.Beneficiario.Domicilio.TelefonoTrabajo
              },
              Edad = 0,
              EstadoCivil = tramiteSolicitudVisa.Beneficiario.EstadoCivil,
              FechaNacimiento = tramiteSolicitudVisa.Beneficiario.FechaNacimiento,
              Foto = tramiteSolicitudVisa.Beneficiario.Foto,
              Genero = tramiteSolicitudVisa.Beneficiario.Genero,
              Ocupacion = tramiteSolicitudVisa.Beneficiario.Ocupacion,
              NacionalidadId = tramiteSolicitudVisa.Beneficiario.NacionalidadId,
              Nacionalidad = tramiteSolicitudVisa.Beneficiario.Nacionalidad,
              Nombres = tramiteSolicitudVisa.Beneficiario.Nombres,
              PaisNacimiento = tramiteSolicitudVisa.Beneficiario.PaisNacimiento,
              Pasaporte = new Domain.Entities.Pasaporte
              {
                CiudadEmision = tramiteSolicitudVisa.Beneficiario.Pasaporte.CiudadEmision,
                FechaEmision = tramiteSolicitudVisa.Beneficiario.Pasaporte.FechaEmision,
                FechaExpiracion = tramiteSolicitudVisa.Beneficiario.Pasaporte.FechaExpiracion,
                FechaNacimiento = tramiteSolicitudVisa.Beneficiario.Pasaporte.FechaNacimiento,
                Nombres = tramiteSolicitudVisa.Beneficiario.Pasaporte.Nombres,
                Numero = tramiteSolicitudVisa.Beneficiario.Pasaporte.Numero,
                PaisEmision = tramiteSolicitudVisa.Beneficiario.Pasaporte.PaisEmision,
                TipoDocumentoIdentidadId = tramiteSolicitudVisa.Beneficiario.Pasaporte.TipoDocumentoIdentidadId ?? "PAS",
              },
              PorcentajeDiscapacidad = tramiteSolicitudVisa.Beneficiario.PorcentajeDiscapacidad,
              PoseeDiscapacidad = tramiteSolicitudVisa.Beneficiario.PoseeDiscapacidad,
              PrimerApellido = tramiteSolicitudVisa.Beneficiario.PrimerApellido,
              SegundoApellido = tramiteSolicitudVisa.Beneficiario.SegundoApellido,
              Visa = new Domain.Entities.Visa
              {
                PoseeVisa = tramiteSolicitudVisa.Beneficiario.Visa.PoseeVisa,
                ConfirmacionVisa = tramiteSolicitudVisa.Beneficiario.Visa.ConfirmacionVisa,
                EstadoVisa = tramiteSolicitudVisa.Beneficiario.Visa.EstadoVisa,
                FechaCaducidad = tramiteSolicitudVisa.Beneficiario.Visa.FechaCaducidad,
                FechaConcesion = tramiteSolicitudVisa.Beneficiario.Visa.FechaConcesion,
                IdActoConsularVisa = tramiteSolicitudVisa.Beneficiario.Visa.IdActoConsularVisa,
                IdCentroAdministrativo = tramiteSolicitudVisa.Beneficiario.Visa.IdCentroAdministrativo,
                IdPersona = tramiteSolicitudVisa.Beneficiario.Visa.IdPersona,
                IdTramite = tramiteSolicitudVisa.Beneficiario.Visa.IdTramite,
                NombreActoConsularVisa = tramiteSolicitudVisa.Beneficiario.Visa.NombreActoConsularVisa,
                NombreCentroAdministrativo = tramiteSolicitudVisa.Beneficiario.Visa.NombreCentroAdministrativo,
                Nombres = tramiteSolicitudVisa.Beneficiario.Visa.Nombres,
                NumeroPasaporte = tramiteSolicitudVisa.Beneficiario.Visa.NumeroPasaporte,
                NumeroVisa = tramiteSolicitudVisa.Beneficiario.Visa.NumeroVisa,
                PrimerApellido = tramiteSolicitudVisa.Beneficiario.Visa.PrimerApellido,
                SegundoApellido = tramiteSolicitudVisa.Beneficiario.Visa.SegundoApellido,
              }

            },
            Solicitante = new Domain.Entities.Solicitante
            {
              Identificacion = tramiteSolicitudVisa.Solicitante.Identificacion,
              TipoIdentificacion = tramiteSolicitudVisa.Solicitante.TipoIdentificacion,
              Ciudad = tramiteSolicitudVisa.Solicitante.Ciudad,
              ConsuladoNombre = tramiteSolicitudVisa.Solicitante.ConsuladoNombre,
              ConsuladoPais = tramiteSolicitudVisa.Solicitante.ConsuladoPais,
              Direccion = tramiteSolicitudVisa.Solicitante.Direccion,
              Edad = tramiteSolicitudVisa.Solicitante.Edad,
              Correo = tramiteSolicitudVisa.Solicitante.Correo,
              Nacionalidad = tramiteSolicitudVisa.Solicitante.Nacionalidad,
              Nombres = tramiteSolicitudVisa.Solicitante.Nombres,
              Pais = tramiteSolicitudVisa.Solicitante.Pais,
              Telefono = tramiteSolicitudVisa.Solicitante.Telefono
            }

          };
          var primerEstado = RolEstados.FirstOrDefault(x => x.CodigoEstado.Equals("101"));
          tramiteOrdenCedulacion.Movimientos = new List<Domain.Entities.Movimiento>();
          tramiteOrdenCedulacion.Movimientos.Add(new Domain.Entities.Movimiento
          {

            CreatorId = command.UsuarioId,
            LastModifierId = command.UsuarioId,
            UsuarioId = command.UsuarioId,
            NombreRol = primerEstado.NombreRol,
            Orden = 1,
            Vigente = true,
            NombreEstado = primerEstado.NombreEstado,
            FechaHoraCita = new DateTime(1900, 1, 1),
            UnidadAdministrativaId = command.UnidadAdministrativaId,
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



          tramiteOrdenCedulacion.AssignId();
          tramiteOrdenCedulacion.Solicitante.AssignId();
          tramiteOrdenCedulacion.Beneficiario.AssignId();
          #region Crear 1 movimiento            
          ///a partir de 101

          #endregion


          var insert = await UnitOfWork.TramiteRepository.InsertAsync(tramiteOrdenCedulacion);
          if (insert.Item1.Equals(true))
          {
            bool commit = false;
            do
            {
              var result = await UnitOfWork.SaveChangesAsync();

              if (result.Item1)
              {
                crearTramiteResponse.Id = tramiteOrdenCedulacion.Id;
                crearTramiteResponse.Numero = tramiteOrdenCedulacion.Numero;
                crearTramiteResponse.Mensaje = "Tramite creado";
                response = new ApiResponseWrapper(HttpStatusCode.OK, crearTramiteResponse);
                commit = true;
              }
              else
              {
                if (result.Item2.Contains("Violation of UNIQUE KEY"))
                {
                  var NumeroTramite2 = await UnitOfWork.TramiteRepository.GetNumeroTramite("OC");
                  tramiteOrdenCedulacion.Numero = NumeroTramite2;
                  await UnitOfWork.TramiteRepository.InsertAsync(tramiteOrdenCedulacion);
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
          //var datos = new CrearMovimientoSharePointResponse();
          //Client = new HttpClient();
          //Uri = command.UrlMensajes + "SharePointMensajes/api/mensaje?modulo=MensajesVisa&pagina=" + primerEstado.NombreEstado + "";
          //Response = await Client.GetAsync(Uri);
          //if (Response.StatusCode == HttpStatusCode.OK)
          //{
          //  PlacesJson = Response.Content.ReadAsStringAsync().Result;
          //  datos = JsonConvert.DeserializeObject<CrearMovimientoSharePointResponse>(PlacesJson);
          //  if (datos.Mensaje.Contains("Error al obtener la lista de mensajes"))
          //  {
          //    return new ApiResponseWrapper(HttpStatusCode.BadRequest, "No se logro encontrar mensaje acorde al estado:" + primerEstado.NombreEstado);
          //  }
          //}
          //else
          //{
          //  return new ApiResponseWrapper(HttpStatusCode.BadRequest, "No se logro encontrar mensaje acorde al estado:" + primerEstado.NombreEstado);
          //}
          #endregion

          #region Notificar

          //en definición proceso de notificación
          //var salida = new NotificacionMensajeDto();
          //salida.Codigo = "NOTIFICACION.GENERAL.01";
          //salida.Asunto = primerEstado.NombreEstado;
          //salida.Destinatarios = tramite.Solicitante.Correo;
          //salida.Model = new Dictionary<string, object>();
          //salida.Model.Add("PersonaNombreApellido", tramite.Solicitante.Nombres);
          //salida.Model.Add("Cuerpo", datos.Mensaje);

          //string token = await TokenAcceso.ObtenerAsync();
          //NotificadorClient.SetAccessToken(token);
          //var re = await NotificadorClient.NotificadorAsync(salida);
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

  public class CrearTramiteCedulacionCommandValidator : AbstractValidator<CrearTramiteCedulacionCommand>
  {
    public CrearTramiteCedulacionCommandValidator()
    {
      RuleFor(e => e.TramiteId)
          .NotEmpty().WithMessage("{PropertyName} es requerida.")
          .NotNull().WithMessage("{PropertyName} No puede ser nulo.");

      RuleFor(e => e.UsuarioId)
          .NotEmpty().WithMessage("{PropertyName} es requerida.")
          .NotNull().WithMessage("{PropertyName} No puede ser nulo.");

      RuleFor(e => e.UnidadAdministrativaId)
          .NotEmpty().WithMessage("{PropertyName} es requerida.")
          .NotNull().WithMessage("{PropertyName} No puede ser nulo.");
    }
  }
}