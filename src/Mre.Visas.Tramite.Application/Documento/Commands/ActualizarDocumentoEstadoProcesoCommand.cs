using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Mre.Visas.Tramite.Application.Documento.Request;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Documento.Commands
{
  public class ActualizarDocumentoEstadoProcesoCommand : ActualizarDocumentoEstadoProcesoRequest, IRequest<ApiResponseWrapper>
  {
    public ActualizarDocumentoEstadoProcesoCommand(ActualizarDocumentoEstadoProcesoRequest request)
    {
      Documentos = request.Documentos;
    }

    public class ActualizarDocumentoEstadoProcesoCommandHandler : BaseHandler, IRequestHandler<ActualizarDocumentoEstadoProcesoCommand, ApiResponseWrapper>
    {
      public ActualizarDocumentoEstadoProcesoCommandHandler(IUnitOfWork unitOfWork)
          : base(unitOfWork)
      {
      }

      [Authorize(Contracts.TramitePermissionDefinition.DocumentoActualizar)]
      public async Task<ApiResponseWrapper> Handle(ActualizarDocumentoEstadoProcesoCommand command, CancellationToken cancellationToken)
      {
        var tramite = await UnitOfWork.TramiteRepository.GetByIdTramiteCompleto(command.Documentos.FirstOrDefault().TramiteId);
        if (tramite == null)
        {
          return new ApiResponseWrapper(HttpStatusCode.NotFound, "Tramite no encontrado");
        }
        else
        {
          foreach (var item in command.Documentos)
          {
            var ultimoDocumento = tramite.Documentos.FirstOrDefault(x => x.Id.Equals(item.DocumentoId));
            if (ultimoDocumento != null)
            {
              ultimoDocumento.LastModified = System.DateTime.Now;
              ultimoDocumento.Observacion = item.Descripcion;
              ultimoDocumento.EstadoProceso = item.EstadoProceso.Equals(true) ? Domain.Const.EstadoDocumentoConst.Ok : Domain.Const.EstadoDocumentoConst.Error;
              var resultado = UnitOfWork.DocumentoRepository.Update(ultimoDocumento);

              //return new ApiResponseWrapper(HttpStatusCode.OK, "Se actualizo el Documento");
            }
          }
          var resultDocumentos = await UnitOfWork.SaveChangesAsync();
          if (resultDocumentos.Item1)
          {
            return new ApiResponseWrapper(HttpStatusCode.OK, "Datos actualizados");
          }
          else
          {
            return new ApiResponseWrapper(HttpStatusCode.BadRequest, "No se pudo actualizar");
          }
        }
      }
    }
  }

  public class ActualizarDocumentoEstadoProcesoCommandValidator : AbstractValidator<ActualizarDocumentoEstadoProcesoCommand>
  {
    public ActualizarDocumentoEstadoProcesoCommandValidator()
    {
      //RuleForEach(x => x.Documentos).NotNull().WithMessage("Documentos {CollectionIndex} is required.");

      //  RuleFor(e => e.DocumentoId)
      //  .NotEmpty().WithMessage("{PropertyName} es requerido.")
      //  .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

      //  RuleFor(e => e.UsuarioId)
      //  .NotEmpty().WithMessage("{PropertyName} es requerido.")
      //  .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
    }
  }
}