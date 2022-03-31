using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Mre.Visas.Tramite.Application.RolEstado.Requests;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.RolEstado.Queries
{
  public class ConsultarRolEstadoPorNombreRolQuery : ConsultarRolEstadoPorNombreRolRequest, IRequest<ApiResponseWrapper>
  {
    public ConsultarRolEstadoPorNombreRolQuery(ConsultarRolEstadoPorNombreRolRequest request)
    {
      NombreRol = request.NombreRol;
    }

    public class ConsultarRolEstadoPorNombreRolHandler : BaseHandler, IRequestHandler<ConsultarRolEstadoPorNombreRolQuery, ApiResponseWrapper>
    {
      public ConsultarRolEstadoPorNombreRolHandler(IUnitOfWork unitOfWork)
          : base(unitOfWork)
      {

      }
      public async Task<ApiResponseWrapper> Handle(ConsultarRolEstadoPorNombreRolQuery query, CancellationToken cancellationToken)
      {
        var tramite = await UnitOfWork.RolEstadoRepository.GetRolEstadoByNombreRol(query.NombreRol);

        var response = new ApiResponseWrapper(HttpStatusCode.OK, tramite);

        return response;
      }
    }
  }

  public class ConsultarRolEstadoPorIdRolValidator : AbstractValidator<ConsultarRolEstadoPorNombreRolQuery>
  {
    public ConsultarRolEstadoPorIdRolValidator()
    {
      RuleFor(e => e.NombreRol)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull().WithMessage("{PropertyName} must not be null.");
    }
  }
}