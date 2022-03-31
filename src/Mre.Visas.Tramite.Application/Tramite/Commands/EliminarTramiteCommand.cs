using Mre.Visas.Tramite.Application.Tramite.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Mre.Visas.Tramite.Application.Tramite.Commands
{
  public class EliminarTramiteCommand : EliminarTramiteRequest, IRequest<ApiResponseWrapper>
  {

    public EliminarTramiteCommand(EliminarTramiteRequest request)
    {
      TramiteId = request.TramiteId;
    }

    public class ActualizarTramiteEliminarHandler : BaseHandler, IRequestHandler<EliminarTramiteCommand, ApiResponseWrapper>
    {

      public ActualizarTramiteEliminarHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
      {
      }

      [Authorize(Contracts.TramitePermissionDefinition.TramiteEliminar)]
      public async Task<ApiResponseWrapper> Handle(EliminarTramiteCommand command, CancellationToken cancellationToken)
      {

        // Obteniendo el trámite
        var tramite = await UnitOfWork.TramiteRepository.GetByIdTramiteCompleto(command.TramiteId);
        if (tramite == null)
        {
          return new ApiResponseWrapper(HttpStatusCode.NotFound, "Tramite no encontrado");
        }
        else
        {
          if (tramite.IsDeleted)
          {
            return new ApiResponseWrapper(HttpStatusCode.OK, "Tramite ya se encuentra eliminado");
          }
          else
          {
            #region Actualizar trámite
            tramite.IsDeleted = true;
            tramite.LastModified = DateTime.Now;
            UnitOfWork.TramiteRepository.Update(tramite);

            var grabarResult = await UnitOfWork.SaveChangesAsync();
            if (grabarResult.Item1)
            {
              return new ApiResponseWrapper(HttpStatusCode.OK, "Tramite eliminado");
            }
            else
            {
              return new ApiResponseWrapper(HttpStatusCode.BadRequest, grabarResult.Item2);
            }
            #endregion
          }



        }
      }


    }


  }
}
