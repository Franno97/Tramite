using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.HistorialMigratorio.Requests;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.HistorialMigratorio.Queries
{

    #region HistorialMigratorio
    public class ConsultarHistorialMigratorioQuery : ConsultarHistorialMigratorioRequest, IRequest<ApiResponseWrapper>
    {
        public ConsultarHistorialMigratorioQuery(ConsultarHistorialMigratorioRequest request)
        {
            TramiteId = request.TramiteId;
        }

        public class ConsultarHistorialMigratorioHandler : BaseHandler, IRequestHandler<ConsultarHistorialMigratorioQuery, ApiResponseWrapper>
        {
            public ConsultarHistorialMigratorioHandler(IUnitOfWork unitOfWork)
                : base(unitOfWork)
            {
            }

            public async Task<ApiResponseWrapper> Handle(ConsultarHistorialMigratorioQuery query, CancellationToken cancellationToken)
            {
                try
                {

                    var HistorialMigratorios = await UnitOfWork.HistorialMigratorioRepository.GetHistorialMigratorioByTramiteId(query.TramiteId);

                    var response = new ApiResponseWrapper(HttpStatusCode.OK, HistorialMigratorios);

                    return response;

                }
                catch (System.Exception ex)
                {

                    return new ApiResponseWrapper(HttpStatusCode.BadRequest, ex.Message == null ? ex.InnerException : ex.Message);
                }

            }
        }
    }

    public class ConsultarHistorialMigratorioValidator : AbstractValidator<ConsultarHistorialMigratorioQuery>
    {
        public ConsultarHistorialMigratorioValidator()
        {
            //no aplica validadores
            //RuleFor(e => e.Value)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull().WithMessage("{PropertyName} must not be null.");
        }
    }
    #endregion


}