using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Mre.Visas.Tramite.Application.Tramite.Commands
{
  public class ActualizarTramiteSubsanacionCommand : ActualizarTramiteSubsanacionRequest, IRequest<ApiResponseWrapper>
  {

    public ActualizarTramiteSubsanacionCommand(ActualizarTramiteSubsanacionRequest request)
    {
      UsuarioId = request.UsuarioId;
      TramiteId = request.TramiteId;
      BeneficiarioDtoSubsanacion = request.BeneficiarioDtoSubsanacion;
      Documentos = request.Documentos;
      CrearMovimientoRequest = request.CrearMovimientoRequest;
    }

    public class ActualizarTramiteSubsanacionHandler : BaseHandler, IRequestHandler<ActualizarTramiteSubsanacionCommand, ApiResponseWrapper>
    {

      public ActualizarTramiteSubsanacionHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
      {
      }

      [Authorize(Contracts.TramitePermissionDefinition.TramiteActualizar)]
      public async Task<ApiResponseWrapper> Handle(ActualizarTramiteSubsanacionCommand command, CancellationToken cancellationToken)
      {
        Guid usuarioId = new Guid();
        Guid unidadAdministrativaId = new Guid();

        // Obteniendo el trámite
        var tramite = await UnitOfWork.TramiteRepository.GetByIdTramiteCompleto(command.TramiteId);
        if (tramite == null)
        {
          return new ApiResponseWrapper(HttpStatusCode.NotFound, "Tramite no encontrado");
        }
        else
        {

          #region Actualizar trámite

          // Obteniendo los objetos del trámite para actualizar
          var pasaporte = tramite.Beneficiario.Pasaporte;
          var beneficiario = tramite.Beneficiario;
          var domicilio = tramite.Beneficiario.Domicilio;

          // Actualizando los datos
          pasaporte.CiudadEmision = command.BeneficiarioDtoSubsanacion.Pasaporte.CiudadEmision;
          domicilio.TelefonoCelular = command.BeneficiarioDtoSubsanacion.Domicilio.TelefonoCelular;
          domicilio.TelefonoDomicilio = command.BeneficiarioDtoSubsanacion.Domicilio.TelefonoDomicilio;
          domicilio.TelefonoTrabajo = command.BeneficiarioDtoSubsanacion.Domicilio.TelefonoTrabajo;
          domicilio.Pais = command.BeneficiarioDtoSubsanacion.Domicilio.Pais;
          beneficiario.CarnetConadis = command.BeneficiarioDtoSubsanacion.CarnetConadis;
          beneficiario.PorcentajeDiscapacidad = command.BeneficiarioDtoSubsanacion.PorcentajeDiscapacidad;
          beneficiario.PoseeDiscapacidad = command.BeneficiarioDtoSubsanacion.PoseeDiscapacidad;

          // Marcando como eliminados a los documentos con observaciones
          foreach (var item in command.Documentos)
          {
            var ultimoDocumento = tramite.Documentos.FirstOrDefault(x => x.Id.Equals(item.Id));
            if (ultimoDocumento != null)
            {
              ultimoDocumento.LastModified = DateTime.Now;
              ultimoDocumento.LastModifierId = command.UsuarioId;
              ultimoDocumento.IsDeleted = true;
            }

            Domain.Entities.Documento nuevoDocumento = new()
            {
              TramiteId = command.TramiteId,
              IsDeleted = false,
              Nombre = item.Nombre,
              Ruta = item.Ruta,
              Observacion = item.Observacion,
              TipoDocumento = item.TipoDocumento,
              IconoNombre = item.IconoNombre,
              ImagenNombre = item.ImagenNombre,
              DescripcionDocumento = item.DescripcionDocumento,
              CreatorId = command.UsuarioId,
              Created = DateTime.Now,
              LastModifierId = command.UsuarioId,
              LastModified = DateTime.Now
            };
            nuevoDocumento.AssignId();

            // Incrustando nuevos documentos
            await UnitOfWork.DocumentoRepository.InsertAsync(nuevoDocumento);
          }
          #endregion

          #region crear movimiento
          #region Estado
          var RolEstado = UnitOfWork.RolEstadoRepository.GetRolEstadoByEstado(command.CrearMovimientoRequest.Estado.ToString());
          if (RolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Consultor)) && RolEstado.EsZonal.Equals(false))
          {
            //Se dirigue al consultor asignado al inicio
            var primerMovimiento = tramite.Movimientos.FirstOrDefault(x => x.Orden.Equals(2));
            usuarioId = primerMovimiento.UsuarioId;
            unidadAdministrativaId = primerMovimiento.UnidadAdministrativaId;
          }
          else if (RolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Ciudadano)) && RolEstado.EsZonal.Equals(false))
          {
            //Se dirigue al consultor asignado al inicio
            var primerMovimiento = tramite.Movimientos.FirstOrDefault(x => x.Orden.Equals(2));
            usuarioId = primerMovimiento.UsuarioId;
            unidadAdministrativaId = primerMovimiento.UnidadAdministrativaId;
          }
          else if ((RolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Funcionario)) || RolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Perito))) && RolEstado.EsZonal.Equals(false))
          {
            //primero validamos si existe asignacion anterior o sino se deja en modo de unidad administrativa y sin usuario
            var movimiento = tramite.Movimientos.Where(x => x.NombreRol.Equals(RolEstado.NombreRol)).OrderBy(x => x.Orden).FirstOrDefault();
            if (movimiento == null)
              usuarioId = Guid.Empty;
            else
              usuarioId = movimiento.UsuarioId;
            unidadAdministrativaId = tramite.UnidadAdministrativaIdCEV;
          }
          else if ((RolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Funcionario)) || RolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Perito))) && RolEstado.EsZonal.Equals(true))
          {
            //primero validamos si existe asignacion anterior o sino se deja en modo de unidad administrativa y sin usuario
            var movimiento = tramite.Movimientos.Where(x => x.NombreRol.Equals(RolEstado.NombreRol)).OrderBy(x => x.Orden).FirstOrDefault();
            if (movimiento == null)
              usuarioId = Guid.Empty;
            else
              usuarioId = movimiento.UsuarioId;

            unidadAdministrativaId = tramite.UnidadAdministrativaIdZonal;
          }
          else
          {
            //Se dirigue al consultor asignado al inicio
            var primerMovimiento = tramite.Movimientos.FirstOrDefault(x => x.Orden.Equals(2));
            usuarioId = primerMovimiento.UsuarioId;
            unidadAdministrativaId = primerMovimiento.UnidadAdministrativaId;
          }

          #endregion

          #region Anterior Movimiento

          var ultimoMovimiento = tramite.Movimientos.LastOrDefault(x => x.Vigente.Equals(true));
          ultimoMovimiento.Vigente = false;
          ultimoMovimiento.LastModified = System.DateTime.Now;
          ultimoMovimiento.LastModifierId = command.UsuarioId;
          var resultado1 = UnitOfWork.MovimientoRepository.Update(ultimoMovimiento);
          if (!resultado1.Item1)
          {
            return new ApiResponseWrapper(HttpStatusCode.BadRequest, resultado1.Item2);
          }
          #endregion Anterior Movimiento

          #region Nuevo Movimiento

          var nuevoMovimiento = new Domain.Entities.Movimiento
          {
            Orden = tramite.Movimientos.Count + 1,
            ObservacionDatosPersonales = command.CrearMovimientoRequest.ObservacionDatosPersonales,
            ObservacionDomicilios = command.CrearMovimientoRequest.ObservacionDomicilios,
            ObservacionMovimientoMigratorio = command.CrearMovimientoRequest.ObservacionMovimientoMigratorio,
            ObservacionMultas = command.CrearMovimientoRequest.ObservacionMultas,
            ObservacionSoportesGestion = command.CrearMovimientoRequest.ObservacionSoportesGestion,
            NombreRol = RolEstado.NombreRol,
            Estado = command.CrearMovimientoRequest.Estado.ToString(),
            UnidadAdministrativaId = unidadAdministrativaId,
            Vigente = true,
            DiasTranscurridos = 0,
            NombreEstado = RolEstado.NombreEstado,
            FechaHoraCita = command.CrearMovimientoRequest.FechaHoraCita == null || command.CrearMovimientoRequest.FechaHoraCita.Value.Equals(string.Empty) ? new DateTime(1900,1,1) : command.CrearMovimientoRequest.FechaHoraCita.Value,
            UsuarioId = usuarioId,
            Created = System.DateTime.Now,
            CreatorId = command.UsuarioId,
            LastModifierId = command.UsuarioId ,
            LastModified = System.DateTime.Now,
            TramiteId = tramite.Id
          };
          nuevoMovimiento.AssignId();

          var resultado = UnitOfWork.MovimientoRepository.InsertAsync(nuevoMovimiento);
          if (!resultado.Result.Item1)
          {
            return new ApiResponseWrapper(HttpStatusCode.BadRequest, resultado.Result.Item2);
          }

          #endregion Nuevo Movimiento
          #endregion


          UnitOfWork.TramiteRepository.Update(tramite);

          var grabarResult = await UnitOfWork.SaveChangesAsync();
          if (grabarResult.Item1)
          {
            return new ApiResponseWrapper(HttpStatusCode.OK, "Datos actualizados");
          }
          else
          {
            return new ApiResponseWrapper(HttpStatusCode.BadRequest, grabarResult.Item2);
          }
        }

      }


    }


  }
}
