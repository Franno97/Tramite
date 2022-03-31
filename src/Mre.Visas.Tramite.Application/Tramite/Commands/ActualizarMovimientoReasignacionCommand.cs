using MediatR;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Commands
{
  public class ActualizarMovimientoReasignacionCommand : ActualizarMovimientoReasignacionRequest, IRequest<ApiResponseWrapper>
  {
    public ActualizarMovimientoReasignacionCommand(ActualizarMovimientoReasignacionRequest reasignacionRequest)
    {
      UsuarioIdAsignado = reasignacionRequest.UsuarioIdAsignado;
      UsuarioIdCreaTransaccion = reasignacionRequest.UsuarioIdCreaTransaccion;
      ListaMovimientos = reasignacionRequest.ListaMovimientos;
    }

    public class ActualizarMovimientoReasignacionHandler : BaseHandler, IRequestHandler<ActualizarMovimientoReasignacionCommand, ApiResponseWrapper>
    {

      public ActualizarMovimientoReasignacionHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
      {

      }

      public async Task<ApiResponseWrapper> Handle(ActualizarMovimientoReasignacionCommand command, CancellationToken cancellationToken)
      {
        try
        {

          // Barremos los movimientos que van a ser reasignados
          foreach (var id in command.ListaMovimientos)
          {
            var movimiento = await UnitOfWork.MovimientoRepository.GetByIdAsync(id);
            if (movimiento == null)
            {
              throw new Exception("Error al encontrar movimiento.");
            }

            movimiento.LastModified = DateTime.Now;
            movimiento.LastModifierId = command.UsuarioIdCreaTransaccion;
            movimiento.UsuarioId = command.UsuarioIdAsignado;

            UnitOfWork.MovimientoRepository.Update(movimiento);
          }
                   
          var grabarResult = await UnitOfWork.SaveChangesAsync();

          if (!grabarResult.Item1)
            throw new Exception(grabarResult.Item2);

          return new ApiResponseWrapper(HttpStatusCode.OK, "OK");
        }
        catch (Exception ex)
        {
          return new ApiResponseWrapper(HttpStatusCode.BadRequest, ex.Message ?? ex.InnerException.InnerException.ToString());
        }
                
      }
    }
  }
}
