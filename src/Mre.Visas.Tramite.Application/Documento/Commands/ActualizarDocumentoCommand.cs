using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.Documento.Request;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.Visas.Tramite.Application.Documento.Commands
{
  public class ActualizarDocumentoCommand : ActualizarDocumentoRequest, IRequest<ApiResponseWrapper>
  {
    public ActualizarDocumentoCommand(ActualizarDocumentoRequest request)
    {
      Documentos = request.Documentos;
    }

    public class ActualizarDocumentoCommandHandler : BaseHandler, IRequestHandler<ActualizarDocumentoCommand, ApiResponseWrapper>
    {
      public ActualizarDocumentoCommandHandler(IUnitOfWork unitOfWork)
          : base(unitOfWork)
      {
      }

      public async Task<ApiResponseWrapper> Handle(ActualizarDocumentoCommand command, CancellationToken cancellationToken)
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

  public class ActualizarDocumentoCommandValidator : AbstractValidator<ActualizarDocumentoCommand>
  {
    public ActualizarDocumentoCommandValidator()
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