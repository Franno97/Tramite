using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using Mre.Visas.Tramite.Application.Shared.Interfaces;

namespace Mre.Visas.Tramite.Application.AsignarFuncionario.Handler
{
    public abstract class HandlerWithClients : BaseHandler
    {
        protected HandlerWithClients()
        {
        }

        protected HandlerWithClients(IUnitOfWork unitOfWork,
            IUsuarioClient usuarioClient,
            IUnidadAdministrativaFuncionalClient unidadAdministrativaFuncionalClient): base (unitOfWork)
        {
            IdentidadClient = usuarioClient;
            UnidadAdministrativaFuncionalClient = unidadAdministrativaFuncionalClient;
        }

        protected IUsuarioClient IdentidadClient;

        protected IUnidadAdministrativaFuncionalClient UnidadAdministrativaFuncionalClient;
    }
}