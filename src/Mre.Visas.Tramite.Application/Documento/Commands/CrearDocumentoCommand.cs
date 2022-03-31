using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
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
  public class CrearDocumentoCommand : CrearDocumentoRequest, IRequest<ApiResponseWrapper>
  {
    public CrearDocumentoCommand(CrearDocumentoRequest request)
    {
      TramiteId = request.TramiteId;
      CreatedId = request.CreatedId;
      Documentos = request.Documentos;
    }

    public class CrearDocumentoCommandHandler : BaseHandler, IRequestHandler<CrearDocumentoCommand, ApiResponseWrapper>
    {
      public CrearDocumentoCommandHandler(IUnitOfWork unitOfWork, IOptions<RemoteServices> remoteServices)
          : base(unitOfWork)
      {
        this.remoteServices = remoteServices.Value;
      }

      private readonly RemoteServices remoteServices;

      [Authorize(Contracts.TramitePermissionDefinition.DocumentoCrear)]
      public async Task<ApiResponseWrapper> Handle(CrearDocumentoCommand command, CancellationToken cancellationToken)
      {
        var tramite = await UnitOfWork.TramiteRepository.GetByIdTramiteCompleto(command.TramiteId);
        if (tramite == null)
        {
          return new ApiResponseWrapper(HttpStatusCode.NotFound, "Tramite no encontrado");
        }
        else
        {
          foreach (var item in command.Documentos)
          {
            var documentoNuevo = new Domain.Entities.Documento
            {
              TramiteId = command.TramiteId,
              Nombre = item.Nombre,
              Ruta = remoteServices.documentos + "PagoComprobante/" + item.Nombre,
              EstadoProceso = Domain.Const.EstadoDocumentoConst.Validar,
              TipoDocumento = item.TipoDocumento,
              Created = DateTime.Now,
              LastModified = DateTime.Now,
              LastModifierId = command.CreatedId,
              CreatorId = command.CreatedId,
              IsDeleted = false,
              DescripcionDocumento = string.Empty,
              IconoNombre = string.Empty,
              ImagenNombre = item.Nombre,
              Observacion = string.Empty
            };
            documentoNuevo.AssignId();
            var resultado = UnitOfWork.DocumentoRepository.InsertAsync(documentoNuevo);
          }
          var resultDocumentos = await UnitOfWork.SaveChangesAsync();
          if (resultDocumentos.Item1)
          {
            return new ApiResponseWrapper(HttpStatusCode.OK, "Documentos creados");
          }
          else
          {
            return new ApiResponseWrapper(HttpStatusCode.BadRequest, "No se pudo actualizar");
          }
        }
      }
    }
  }

  public class CrearDocumentoCommandValidator : AbstractValidator<CrearDocumentoCommand>
  {
    public CrearDocumentoCommandValidator()
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