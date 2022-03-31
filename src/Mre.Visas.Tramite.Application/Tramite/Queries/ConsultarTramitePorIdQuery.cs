using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Queries
{
  public class ConsultarTramitePorIdQuery : ConsultarTramitePorIdRequest, IRequest<ApiResponseWrapper>
  {
    public ConsultarTramitePorIdQuery(ConsultarTramitePorIdRequest request)
    {
      Id = request.Id;
    }

    public class ConsultarTrámitePorIdQueryHandler : BaseHandler, IRequestHandler<ConsultarTramitePorIdQuery, ApiResponseWrapper>
    {
      public ConsultarTrámitePorIdQueryHandler(IUnitOfWork unitOfWork)
          : base(unitOfWork)
      {
      }

      //[Authorize(Contracts.TramitePermissionDefinition.Tramite)]
      public async Task<ApiResponseWrapper> Handle(ConsultarTramitePorIdQuery query, CancellationToken cancellationToken)
      {
        var tramite = await UnitOfWork.TramiteRepository.GetByIdTramiteCompleto(query.Id);
        var tramiteCompleto = Shared.Util.Util.MapearTramite(tramite);
        var response = new ApiResponseWrapper(HttpStatusCode.OK, tramiteCompleto);
        return response;
      }
    }
  }

  public class ConsultarTrámitePorIdQueryValidator : AbstractValidator<ConsultarTramitePorIdQuery>
  {
    public ConsultarTrámitePorIdQueryValidator()
    {
      RuleFor(e => e.Id)
          .NotEmpty().WithMessage("{PropertyName} es requerdio.")
          .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
    }
  }
}