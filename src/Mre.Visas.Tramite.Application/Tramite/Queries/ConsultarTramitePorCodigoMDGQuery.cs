using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.Visas.Tramite.Application.Tramite.Queries
{
  public class ConsultarTramitePorCodigoMDGQuery : ConsultarTramitePorCodigoMDGRequest, IRequest<ApiResponseWrapper>
  {
    public ConsultarTramitePorCodigoMDGQuery(ConsultarTramitePorCodigoMDGRequest request)
    {
      CodigoMDG = request.CodigoMDG;
    }

    public class ConsultarTramitePorCodigoMDGQueryHandler : BaseHandler, IRequestHandler<ConsultarTramitePorCodigoMDGQuery, ApiResponseWrapper>
    {
      public ConsultarTramitePorCodigoMDGQueryHandler(IUnitOfWork unitOfWork)
          : base(unitOfWork)
      {
      }

      public async Task<ApiResponseWrapper> Handle(ConsultarTramitePorCodigoMDGQuery query, CancellationToken cancellationToken)
      {
        var vigente = await UnitOfWork.TramiteRepository.GetByCodigoMDGTramiteVigente(query.CodigoMDG);

        var response = new ApiResponseWrapper(HttpStatusCode.OK, vigente);

        return response;
      }
    }
  }

  public class ConsultarTramitePorCodigoMDGQueryValidator : AbstractValidator<ConsultarTramitePorCodigoMDGQuery>
  {
    public ConsultarTramitePorCodigoMDGQueryValidator()
    {
      RuleFor(e => e.CodigoMDG)
          .NotEmpty().WithMessage("{PropertyName} es requerdio.")
          .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
    }
  }
}