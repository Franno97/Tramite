using Mre.Visas.Tramite.Application.Shared.Repositories;
using Mre.Visas.Tramite.Application.Tramite.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Repositories
{
  public interface ITramiteRepository : IRepository<Domain.Entities.Tramite>
  {
    Task<List<Domain.Entities.Tramite>> GetByCiudadanoId(string usuarioId);

    Task<List<Domain.Entities.Tramite>> GetByRolFiltros(string nombreRol, Guid usuarioId, Guid unidadAdministrativaId, string nombreEstado);

    Task<string> GetNumeroTramite(string codigo);

    Task<Domain.Entities.Tramite> GetByIdTramiteCompleto(Guid TramiteId);

    Task<bool> GetByCodigoMDGTramiteVigente(string codigoMDG);

    Task<List<TramiteBaseDto>> GetTramitesBaseAsync(Guid servicioId, Guid unidadAdministrativaId, Guid usuarioId);
    List<Domain.Entities.Tramite> GetTramitesGeneral(string fechaDesde, string fechaHasta, string tipoTramite, string codigoEstado, Guid usuarioId, Guid unidadAdministrativaId);
  }
}