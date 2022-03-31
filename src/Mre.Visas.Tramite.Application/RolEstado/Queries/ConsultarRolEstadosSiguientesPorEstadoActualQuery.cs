using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.RolEstado.Requests;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.RolEstado.Queries
{
    public class ConsultarRolEstadosSiguientesPorEstadoActualQuery : ConsultarEstadosSiguientesPorEstadoActualRequest, IRequest<ApiResponseWrapper>
    {
        public ConsultarRolEstadosSiguientesPorEstadoActualQuery(ConsultarEstadosSiguientesPorEstadoActualRequest request)
        {
            EstadoActual = request.EstadoActual;
        }

        public class ConsultarRolEstadosSiguientesPorEstadoActualHandler : BaseHandler, IRequestHandler<ConsultarRolEstadosSiguientesPorEstadoActualQuery, ApiResponseWrapper>
        {
            public ConsultarRolEstadosSiguientesPorEstadoActualHandler(IUnitOfWork unitOfWork)
                : base(unitOfWork)
            {
            }

            public async Task<ApiResponseWrapper> Handle(ConsultarRolEstadosSiguientesPorEstadoActualQuery query, CancellationToken cancellationToken)
            {
                var tramite = await UnitOfWork.RolEstadoRepository.GetRolEstadoByEstadoActual(query.EstadoActual);

                var response = new ApiResponseWrapper(HttpStatusCode.OK, tramite);

                return response;
            }
        }
    }

    public class ConsultarRolEstadosSiguientesPorEstadoActualValidator : AbstractValidator<ConsultarRolEstadosSiguientesPorEstadoActualQuery>
    {
        public ConsultarRolEstadosSiguientesPorEstadoActualValidator()
        {
            RuleFor(e => e.EstadoActual)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
        }
    }
}