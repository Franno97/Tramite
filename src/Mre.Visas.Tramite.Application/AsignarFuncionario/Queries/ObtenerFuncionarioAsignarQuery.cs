using FluentValidation;
using MediatR;
using Mre.Visas.Tramite.Application.AsignarFuncionario.Handler;
using Mre.Visas.Tramite.Application.AsignarFuncionario.Requests;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using Mre.Visas.Tramite.Application.Shared.Security;

namespace Mre.Visas.Tramite.Application.AsignarFuncionario.Queries
{
    public class ObtenerFuncionarioAsignarQuery: ObtenerFuncionarioAsignarRequest, IRequest<ApiResponseWrapper>
    {
        private const string NombreClienteOpenId = "Tramite";

        public ObtenerFuncionarioAsignarQuery(ObtenerFuncionarioAsignarRequest request)
        {
            UnidadAdministrativaId = request.UnidadAdministrativaId;
            ServicioId = request.ServicioId;
            NombreRol = request.NombreRol;
        }

        public class ObtenerFuncionarioAsignarHandler : HandlerWithClients, IRequestHandler<ObtenerFuncionarioAsignarQuery, ApiResponseWrapper>
        {

            public ObtenerFuncionarioAsignarHandler(IUnitOfWork unitOfWork, 
                IUsuarioClient usuarioClient,
                IUnidadAdministrativaFuncionalClient unidadAdministrativaFuncionalClient, 
                IConfiguration configuration,
                IHttpApiAutentificacion httpApiAutentificacion,
                ILogger<ObtenerFuncionarioAsignarHandler> logger
                )
                : base(unitOfWork, usuarioClient, unidadAdministrativaFuncionalClient)
            {
                Configuracion = configuration;
                HttpApiAutentificacion = httpApiAutentificacion;
                Logger = logger;
            }

            public IConfiguration Configuracion { get; }
            public IHttpApiAutentificacion HttpApiAutentificacion { get; }
            public ILogger<ObtenerFuncionarioAsignarHandler> Logger { get; }

            public async Task<ApiResponseWrapper> Handle(ObtenerFuncionarioAsignarQuery query, CancellationToken cancellationToken)
            {
                var token = await HttpApiAutentificacion.GetAccessTokenAsync();

                if (string.IsNullOrEmpty(token))
                {
                    return new ApiResponseWrapper(HttpStatusCode.Unauthorized, "El usuario no esta autenticado");
                }

                UnidadAdministrativaFuncionalClient.SetAccessToken(token);
                var listaIds = new List<Guid>();

                try
                {
                    var funcionarios = await UnidadAdministrativaFuncionalClient.FuncionariosAsync(query.UnidadAdministrativaId);
                    listaIds = funcionarios.Items.Select(f => f.UsuarioId).ToList();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex.Message);
                    return new ApiResponseWrapper(HttpStatusCode.InternalServerError, "No se puede procesar su solicitud en este momento");
                }

                IdentidadClient.SetAccessToken(token);
                var usuariosAsignar = new List<Guid>();

                try
                {
                    var usuarioRoles = await IdentidadClient.UsuarioGetAsync(listaIds);
                    foreach (var usuarioRol in usuarioRoles)
                    {
                        var extraProperties = usuarioRol.ExtraProperties;
                        var roles = JsonConvert.DeserializeObject<List<string>>(extraProperties["Roles"].ToString());
                        var existe = roles.Any(x => x.ToUpper() == query.NombreRol.ToUpper());
                        if (existe) usuariosAsignar.Add(usuarioRol.Id);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex.Message);
                    return new ApiResponseWrapper(HttpStatusCode.InternalServerError, "No se puede procesar su solicitud en este momento");
                }


                var response = new ApiResponseWrapper();

                if (!usuariosAsignar.Any())
                {
                    response.HttpStatusCode = HttpStatusCode.OK;
                    response.Result = "No existe un usuario para asignar";
                    return response;
                }

                response.HttpStatusCode = HttpStatusCode.OK;
                response.Result = usuariosAsignar.FirstOrDefault();

                return response;
            }
        }

        public class ObtenerFuncionarioAsignarValidator : AbstractValidator<ObtenerFuncionarioAsignarQuery>
        {
            public ObtenerFuncionarioAsignarValidator()
            {
                RuleFor(e => e.UnidadAdministrativaId)
                    .NotEmpty().WithMessage("{PropertyName} es requerido.")
                    .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
                RuleFor(e => e.ServicioId)
                    .NotEmpty().WithMessage("{PropertyName} es requerido.")
                    .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
                RuleFor(e => e.NombreRol)
                    .NotEmpty().WithMessage("{PropertyName} es requerido.")
                    .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            }
        }
    }
}
