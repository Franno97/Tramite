using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.Catalogo.Requests;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Catalogo.Queries
{
    #region CalidadMigratoria
    public class ConsultarCalidadMigratoriaQuery : IRequest<ApiResponseWrapper>
    {
        public ConsultarCalidadMigratoriaQuery()
        {
        }

        public class ConsultarCalidadMigratoriaHandler : BaseHandler, IRequestHandler<ConsultarCalidadMigratoriaQuery, ApiResponseWrapper>
        {
            public ConsultarCalidadMigratoriaHandler(IUnitOfWork unitOfWork)
                : base(unitOfWork)
            {
            }

            public async Task<ApiResponseWrapper> Handle(ConsultarCalidadMigratoriaQuery query, CancellationToken cancellationToken)
            {
                try
                {

                    var calidadMigratorias = await UnitOfWork.CalidadMigratoriaRepository.GetAllCalidadMigratoria();

                    var response = new ApiResponseWrapper(HttpStatusCode.OK, calidadMigratorias);

                    return response;

                }
                catch (System.Exception ex)
                {

                    return new ApiResponseWrapper(HttpStatusCode.BadRequest, ex.Message == null ? ex.InnerException : ex.Message);
                }

            }
        }
    }

    public class ConsultarCalidadMigratoriaValidator : AbstractValidator<ConsultarCalidadMigratoriaQuery>
    {
        public ConsultarCalidadMigratoriaValidator()
        {
            //no aplica validadores
            //RuleFor(e => e.Value)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull().WithMessage("{PropertyName} must not be null.");
        }
    }
    #endregion

    #region TipoConvenio
    public class ConsultarTipoConvenioQuery : IRequest<ApiResponseWrapper>
    {
        public ConsultarTipoConvenioQuery()
        {
        }

        public class ConsultarTipoConvenioHandler : BaseHandler, IRequestHandler<ConsultarTipoConvenioQuery, ApiResponseWrapper>
        {
            public ConsultarTipoConvenioHandler(IUnitOfWork unitOfWork)
                : base(unitOfWork)
            {
            }

            public async Task<ApiResponseWrapper> Handle(ConsultarTipoConvenioQuery query, CancellationToken cancellationToken)
            {
                try
                {

                    var tipoConvenios = await UnitOfWork.TipoConvenioRepository.GetAllTipoConvenio();

                    var response = new ApiResponseWrapper(HttpStatusCode.OK, tipoConvenios);

                    return response;

                }
                catch (System.Exception ex)
                {

                    return new ApiResponseWrapper(HttpStatusCode.BadRequest, ex.Message == null ? ex.InnerException : ex.Message);
                }

            }
        }
    }

    public class ConsultarTipoConvenioValidator : AbstractValidator<ConsultarTipoConvenioQuery>
    {
        public ConsultarTipoConvenioValidator()
        {
            //no aplica validadores
            //RuleFor(e => e.Value)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull().WithMessage("{PropertyName} must not be null.");
        }
    }
    #endregion

    #region TipoVisa
    public class ConsultarTipoVisaQuery : ConsultarCatalogoRequest, IRequest<ApiResponseWrapper>
    {
        public ConsultarTipoVisaQuery(ConsultarCatalogoRequest request)
        {
            Codigo = request.Codigo;
        }

        public class ConsultarTipoVisaHandler : BaseHandler, IRequestHandler<ConsultarTipoVisaQuery, ApiResponseWrapper>
        {
            public ConsultarTipoVisaHandler(IUnitOfWork unitOfWork)
                : base(unitOfWork)
            {
            }

            public async Task<ApiResponseWrapper> Handle(ConsultarTipoVisaQuery query, CancellationToken cancellationToken)
            {
                try
                {

                    var tipoVisas = await UnitOfWork.TipoVisaRepository.GetTipoVisaByConvenioCodigo(query.Codigo);

                    var response = new ApiResponseWrapper(HttpStatusCode.OK, tipoVisas);

                    return response;

                }
                catch (System.Exception ex)
                {

                    return new ApiResponseWrapper(HttpStatusCode.BadRequest, ex.Message == null ? ex.InnerException : ex.Message);
                }

            }
        }
    }

    public class ConsultarTipoVisaValidator : AbstractValidator<ConsultarTipoVisaQuery>
    {
        public ConsultarTipoVisaValidator()
        {
            //no aplica validadores
            //RuleFor(e => e.Value)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull().WithMessage("{PropertyName} must not be null.");
        }
    }
    #endregion

    #region ActividadDesarrollar
    public class ConsultarActividadDesarrollarQuery : ConsultarCatalogoRequest, IRequest<ApiResponseWrapper>
    {
        public ConsultarActividadDesarrollarQuery(ConsultarCatalogoRequest request)
        {
            Codigo = request.Codigo;
        }

        public class ConsultarActividadDesarrollarHandler : BaseHandler, IRequestHandler<ConsultarActividadDesarrollarQuery, ApiResponseWrapper>
        {
            public ConsultarActividadDesarrollarHandler(IUnitOfWork unitOfWork)
                : base(unitOfWork)
            {
            }

            public async Task<ApiResponseWrapper> Handle(ConsultarActividadDesarrollarQuery query, CancellationToken cancellationToken)
            {
                try
                {

                    var actividadDesarrollars = await UnitOfWork.ActividadDesarrollarRepository.GetActividadDesarrollarByTipoVisaCodigo(query.Codigo);

                    var response = new ApiResponseWrapper(HttpStatusCode.OK, actividadDesarrollars);

                    return response;

                }
                catch (System.Exception ex)
                {

                    return new ApiResponseWrapper(HttpStatusCode.BadRequest, ex.Message == null ? ex.InnerException : ex.Message);
                }

            }
        }
    }

    public class ConsultarActividadDesarrollarValidator : AbstractValidator<ConsultarActividadDesarrollarQuery>
    {
        public ConsultarActividadDesarrollarValidator()
        {
            //no aplica validadores
            //RuleFor(e => e.Value)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull().WithMessage("{PropertyName} must not be null.");
        }
    }
    #endregion

    #region Configuracion
    public class ConsultarConfiguracionQuery : ConsultarCatalogoRequest, IRequest<ApiResponseWrapper>
    {
        public ConsultarConfiguracionQuery(ConsultarCatalogoRequest request)
        {
            Codigo = request.Codigo;
        }

        public class ConsultarConfiguracionHandler : BaseHandler, IRequestHandler<ConsultarConfiguracionQuery, ApiResponseWrapper>
        {
            public ConsultarConfiguracionHandler(IUnitOfWork unitOfWork)
                : base(unitOfWork)
            {
            }

            public async Task<ApiResponseWrapper> Handle(ConsultarConfiguracionQuery query, CancellationToken cancellationToken)
            {
                try
                {

                    var tipoVisas = await UnitOfWork.ConfiguracionRepository.GetConfiguracion(query.Codigo);

                    var response = new ApiResponseWrapper(HttpStatusCode.OK, tipoVisas);

                    return response;

                }
                catch (System.Exception ex)
                {

                    return new ApiResponseWrapper(HttpStatusCode.BadRequest, ex.Message == null ? ex.InnerException : ex.Message);
                }

            }
        }
    }

    public class ConsultarConfiguracionValidator : AbstractValidator<ConsultarTipoVisaQuery>
    {
        public ConsultarConfiguracionValidator()
        {
            //no aplica validadores
            //RuleFor(e => e.Value)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull().WithMessage("{PropertyName} must not be null.");
        }
    }
    #endregion
}