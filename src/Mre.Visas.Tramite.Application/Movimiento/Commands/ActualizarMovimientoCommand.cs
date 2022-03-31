using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Mre.Visas.Tramite.Application.Movimiento.Request;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Commands
{
  public class ActualizarMovimientoCommand : ActualizarMovimientoRequest, IRequest<ApiResponseWrapper>
  {
    public ActualizarMovimientoCommand(ActualizarMovimientoRequest request)
    {
      UsuarioId = request.UsuarioId;
      TramiteId = request.TramiteId;
      MovimientoId = request.MovimientoId;
    }

    public class ActualizarMovimientoCommandHandler : BaseHandler, IRequestHandler<ActualizarMovimientoCommand, ApiResponseWrapper>
    {
      public ActualizarMovimientoCommandHandler(IUnitOfWork unitOfWork)
          : base(unitOfWork)
      {
      }

      [Authorize(Contracts.TramitePermissionDefinition.MovimientoActualizar)]
      public async Task<ApiResponseWrapper> Handle(ActualizarMovimientoCommand command, CancellationToken cancellationToken)
      {
        var tramite = await UnitOfWork.TramiteRepository.GetByIdTramiteCompleto(command.TramiteId);
        if (tramite == null)
        {
          return new ApiResponseWrapper(HttpStatusCode.NotFound, "Tramite no encontrado");
        }
        else
        {
          var ultimoMovimiento = tramite.Movimientos.FirstOrDefault(x => x.Id.Equals(command.MovimientoId));
          if (ultimoMovimiento.UsuarioId.Equals(System.Guid.Empty) && ultimoMovimiento.Vigente.Equals(true))
          {
            ultimoMovimiento.UsuarioId = command.UsuarioId;
            ultimoMovimiento.LastModified = System.DateTime.Now;
            ultimoMovimiento.LastModifierId = command.UsuarioId;
            var resultado = UnitOfWork.MovimientoRepository.Update(ultimoMovimiento);
            var result2 = await UnitOfWork.SaveChangesAsync();
            return new ApiResponseWrapper(HttpStatusCode.OK, "Se actualizo el movimiento");
          }
          else
          {
            return new ApiResponseWrapper(HttpStatusCode.BadRequest, "El tramite ya tiene asignado un usuario");
          }

        }
      }
    }
  }

  public class ActualizarMovimientoCommandValidator : AbstractValidator<ActualizarMovimientoCommand>
  {
    public ActualizarMovimientoCommandValidator()
    {
      RuleFor(e => e.TramiteId)
      .NotEmpty().WithMessage("{PropertyName} es requerido.")
      .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

      RuleFor(e => e.MovimientoId)
      .NotEmpty().WithMessage("{PropertyName} es requerido.")
      .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

      RuleFor(e => e.UsuarioId)
      .NotEmpty().WithMessage("{PropertyName} es requerido.")
      .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
    }
  }
}