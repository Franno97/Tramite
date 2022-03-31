using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.SoporteGestion.Requests;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.SoporteGestion.Commands
{
  public class CrearSoporteGestionCommand : CrearSoporteGestionRequest, IRequest<ApiResponseWrapper>
  {
    public CrearSoporteGestionCommand(CrearSoporteGestionRequest request)
    {
      TramiteId = request.TramiteId;
      Ruta = request.Ruta;
      Nombre = request.Nombre;
      Descripcion = request.Descripcion;
      CreatorId = request.CreatorId;
    }

    public class CrearSoporteGestionCommandHandler : BaseHandler, IRequestHandler<CrearSoporteGestionCommand, ApiResponseWrapper>
    {
      public CrearSoporteGestionCommandHandler(IUnitOfWork unitOfWork)
          : base(unitOfWork)
      {
      }

      [Authorize(Contracts.TramitePermissionDefinition.SoporteGestionCrear)]
      public async Task<ApiResponseWrapper> Handle(CrearSoporteGestionCommand command, CancellationToken cancellationToken)
      {
        var tramite = await UnitOfWork.TramiteRepository.GetByIdTramiteCompleto(command.TramiteId);

        if (tramite == null)
        {
          return new ApiResponseWrapper(HttpStatusCode.NotFound, string.Empty);
        }
        else
        {
          #region Nuevo Soporte de gestión

          var soporteGestion = new Domain.Entities.SoporteGestion
          {
            Nombre = command.Nombre,
            Ruta = command.Ruta,
            Descripcion=command.Descripcion,
            Created = System.DateTime.Now,
            CreatorId = command.CreatorId,
            LastModifierId = command.CreatorId,
            LastModified = System.DateTime.Now,
            TramiteId = tramite.Id
          };
          soporteGestion.AssignId();
          var resultado = UnitOfWork.SoporteGestionRepository.InsertAsync(soporteGestion);
          var ef = await UnitOfWork.SaveChangesAsync();

          return new ApiResponseWrapper(HttpStatusCode.OK, soporteGestion.Id);

          #endregion Nuevo Movimiento
        }
      }
    }
  }

  public class CrearSoporteGestionCommandValidator : AbstractValidator<CrearSoporteGestionCommand>
  {
    public CrearSoporteGestionCommandValidator()
    {
      RuleFor(e => e.TramiteId)
           .NotEmpty().WithMessage("{PropertyName} es requerido.")
           .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

      RuleFor(e => e.Nombre)
           .NotEmpty().WithMessage("{PropertyName} es requerido.")
           .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

      RuleFor(e => e.Ruta)
           .NotEmpty().WithMessage("{PropertyName} es requerido.")
           .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
    }
  }
}