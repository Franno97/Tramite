using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using Mre.Visas.Tramite.Application.Tramite.Responses;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Queries
{
  public class ConsultarTramitesBaseQuery : ConsultarTramitesBaseRequest, IRequest<ApiResponseWrapper>
  {

    public ConsultarTramitesBaseQuery(ConsultarTramitesBaseRequest request)
    {
      UsuarioId = request.UsuarioId;
      ServicioId = request.ServicioId;
      UnidadAdministrativaId = request.UnidadAdministrativaId;

    }

    public class ConsultarTramitesBaseQueryHandler : BaseHandler, IRequestHandler<ConsultarTramitesBaseQuery, ApiResponseWrapper>
    {
      public ConsultarTramitesBaseQueryHandler(IUnitOfWork unitOfWork)
          : base(unitOfWork)
      {
      }

      public async Task<ApiResponseWrapper> Handle(ConsultarTramitesBaseQuery query, CancellationToken cancellationToken)
      {
        ConsultarTramiteBaseResponse respuesta = new ConsultarTramiteBaseResponse();

        try
        {
        
          var tramitesPendientes = await UnitOfWork.TramiteRepository.GetTramitesBaseAsync(query.ServicioId, query.UnidadAdministrativaId, query.UsuarioId);

          respuesta.Error = "OK";
          respuesta.ListaTramiteBase = tramitesPendientes;
          
          var response = new ApiResponseWrapper(HttpStatusCode.OK, respuesta);

          return response;

        }
        catch (System.Exception ex)
        {
          respuesta.Error = ex.Message == null ? ex.InnerException.ToString() : ex.Message;
          var response = new ApiResponseWrapper(HttpStatusCode.BadRequest, respuesta);

          return response;
        }

      }
    }



  }

  public class ConsultarTramitesBaseQueryValidator : AbstractValidator<ConsultarTramitesBaseQuery>
  {
    public ConsultarTramitesBaseQueryValidator()
    {
      RuleFor(e => e.UsuarioId)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull().WithMessage("{PropertyName} must not be null.");
    }
  }

}
