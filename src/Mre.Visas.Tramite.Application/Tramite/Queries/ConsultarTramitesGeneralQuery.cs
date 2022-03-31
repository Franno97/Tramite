using FluentValidation;
using MediatR;
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

namespace Mre.Visas.Tramite.Application.Tramite.Queries
{
  public class ConsultarTramitesGeneralQuery : IRequest<ApiResponseWrapper>
  {
    public ConsultarTramitesGeneralQuery(string fechaDesde, string fechaHasta, string tipoTramite, string codigoEstado, Guid usuarioId, Guid unidadAdministrativaId)
    {
      FechaDesde = fechaDesde;
      FechaHasta = fechaHasta;
      TipoTramite = tipoTramite;
      CodigoEstado = codigoEstado == null ? string.Empty : codigoEstado;
      UsuarioId = usuarioId;
      UnidadAdministrativaId = unidadAdministrativaId;
    }

    public string FechaDesde { get; }
    public string FechaHasta { get; }
    public string TipoTramite { get; }
    public string CodigoEstado { get; }
    public Guid UsuarioId { get; }
    public Guid UnidadAdministrativaId { get; }

    public class ConsultarTramitesGeneralQueryHandler : BaseHandler, IRequestHandler<ConsultarTramitesGeneralQuery, ApiResponseWrapper>
    {
      public ConsultarTramitesGeneralQueryHandler(IUnitOfWork unitOfWork)
          : base(unitOfWork)
      {
      }

      public async Task<ApiResponseWrapper> Handle(ConsultarTramitesGeneralQuery query, CancellationToken cancellationToken)
      {
        var tramites = UnitOfWork.TramiteRepository.GetTramitesGeneral(query.FechaDesde, query.FechaHasta, query.TipoTramite, query.CodigoEstado, query.UsuarioId, query.UnidadAdministrativaId);

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

  public class ConsultarTramitesGeneralQueryValidator : AbstractValidator<ConsultarTramitesGeneralQuery>
  {
    public ConsultarTramitesGeneralQueryValidator()
    {
      RuleFor(e => e.FechaDesde)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull().WithMessage("{PropertyName} must not be null.");

      RuleFor(e => e.FechaHasta)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull().WithMessage("{PropertyName} must not be null.");

      RuleFor(e => e.TipoTramite)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull().WithMessage("{PropertyName} must not be null.");

      //RuleFor(e => e.CodigoEstado).NotNull().WithMessage("{PropertyName} must not be null.");

      RuleFor(e => e.UsuarioId).NotNull().WithMessage("{PropertyName} must not be null.");

      RuleFor(e => e.UnidadAdministrativaId).NotNull().WithMessage("{PropertyName} must not be null.");
    }
  }
}
