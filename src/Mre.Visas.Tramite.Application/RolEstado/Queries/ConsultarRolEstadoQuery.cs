using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.RolEstado.Queries
{
    public class ConsultarRolEstadoQuery : IRequest<ApiResponseWrapper>
    {
        public ConsultarRolEstadoQuery()
        {
        }

        public class ConsultarRolEstadoHandler : BaseHandler, IRequestHandler<ConsultarRolEstadoQuery, ApiResponseWrapper>
        {
            public ConsultarRolEstadoHandler(IUnitOfWork unitOfWork)
                : base(unitOfWork)
            {
            }

            public async Task<ApiResponseWrapper> Handle(ConsultarRolEstadoQuery query, CancellationToken cancellationToken)
            {
                var tramite = await UnitOfWork.RolEstadoRepository.GetAllAsync();

                var response = new ApiResponseWrapper(HttpStatusCode.OK, tramite);

                return response;
            }
        }
    }

    public class ConsultarRolEstadoValidator : AbstractValidator<ConsultarRolEstadoQuery>
    {
        public ConsultarRolEstadoValidator()
        {
            //no aplica validadores
            //RuleFor(e => e.Value)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull().WithMessage("{PropertyName} must not be null.");
        }
    }
}