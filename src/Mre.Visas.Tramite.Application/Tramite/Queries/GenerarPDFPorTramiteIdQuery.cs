using Mre.Visas.Tramite.Application.Tramite.Requests;
using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.Visas.Tramite.Application.Tramite.Queries
{
  public class GenerarPDFPorTramiteIdQuery : GenerarPDFPorTramiteIdRequest, IRequest<ApiResponseWrapper>
  {
    public GenerarPDFPorTramiteIdQuery(GenerarPDFPorTramiteIdRequest request)
    {
      Id = request.Id;
    }

    public class GenerarPDFPorTramiteIdQueryHandler : BaseHandler, IRequestHandler<GenerarPDFPorTramiteIdQuery, ApiResponseWrapper>
    {
      public GenerarPDFPorTramiteIdQueryHandler(IUnitOfWork unitOfWork)
          : base(unitOfWork)
      {
      }

      public async Task<ApiResponseWrapper> Handle(GenerarPDFPorTramiteIdQuery query, CancellationToken cancellationToken)
      {
        try
        {
          var tramite = await UnitOfWork.TramiteRepository.GetByIdTramiteCompleto(query.Id);
          return new ApiResponseWrapper(HttpStatusCode.OK, tramite);
        }
        catch (System.Exception ex)
        {
          return new ApiResponseWrapper(HttpStatusCode.BadRequest, ex.Message);
        }
        
        
      }
    }
  }

  public class GenerarPDFPorTramiteIdQueryValidator : AbstractValidator<GenerarPDFPorTramiteIdQuery>
  {
    public GenerarPDFPorTramiteIdQueryValidator()
    {
      RuleFor(e => e.Id)
          .NotEmpty().WithMessage("{PropertyName} es requerdio.")
          .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
    }
  }
}