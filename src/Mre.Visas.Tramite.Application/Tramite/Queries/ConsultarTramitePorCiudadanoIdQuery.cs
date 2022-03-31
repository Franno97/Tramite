using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Queries
{
  public class ConsultarTramitePorCiudadanoIdQuery : ConsultarTramitePorCiudadanoIdRequest, IRequest<ApiResponseWrapper>
  {
    public ConsultarTramitePorCiudadanoIdQuery(ConsultarTramitePorCiudadanoIdRequest request)
    {
      UsuarioId = request.UsuarioId;
    }

    public class ConsultarTramitePorCiudadanoIdQueryHandler : BaseHandler, IRequestHandler<ConsultarTramitePorCiudadanoIdQuery, ApiResponseWrapper>
    {
      public ConsultarTramitePorCiudadanoIdQueryHandler(IUnitOfWork unitOfWork)
          : base(unitOfWork)
      {
      }

      public async Task<ApiResponseWrapper> Handle(ConsultarTramitePorCiudadanoIdQuery query, CancellationToken cancellationToken)
      {
        var tramites = await UnitOfWork.TramiteRepository.GetByCiudadanoId(query.UsuarioId.ToString());

        var tramiteCompletoResponse = new List<Tramite.Responses.TramiteCompletoResponse>();
        foreach (var item in tramites)
        {
          tramiteCompletoResponse.Add(Shared.Util.Util.MapearTramite(item));
        }

        var response = new ApiResponseWrapper(HttpStatusCode.OK, tramiteCompletoResponse);

        return response;
      }
    }
  }

  public class ConsultarTramitePorCiudadanoIdQueryValidator : AbstractValidator<ConsultarTramitePorCiudadanoIdQuery>
  {
    public ConsultarTramitePorCiudadanoIdQueryValidator()
    {
      RuleFor(e => e.UsuarioId)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull().WithMessage("{PropertyName} must not be null.");
    }
  }
}