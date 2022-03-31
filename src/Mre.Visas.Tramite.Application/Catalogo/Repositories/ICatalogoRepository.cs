using Mre.Visas.Tramite.Application.Shared.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Catalogo.Repositories
{
  public interface ICalidadMigratoriaRepository : IRepository<Domain.Entities.CalidadMigratoria>
  {
    Task<List<Domain.Entities.CalidadMigratoria>> GetAllCalidadMigratoria();

    Task<Domain.Entities.CalidadMigratoria> GetCalidadMigratoriaByCodigo(int calidadMigratoriaId);
  }

  public interface ITipoConvenioRepository : IRepository<Domain.Entities.TipoConvenio>
  {
    Task<List<Domain.Entities.TipoConvenio>> GetAllTipoConvenio();
  }

  public interface ITipoVisaRepository : IRepository<Domain.Entities.TipoVisa>
  {
    Task<List<Domain.Entities.TipoVisa>> GetTipoVisaByConvenioCodigo(string convenioCodigo);

    Task<Domain.Entities.TipoVisa> GetTipoVisaByCodigo(string codigo);
  }

  public interface IActividadDesarrollarRepository : IRepository<Domain.Entities.ActividadDesarrollar>
  {
    Task<List<Domain.Entities.ActividadDesarrollar>> GetActividadDesarrollarByTipoVisaCodigo(string tipoVisaCodigo);
  }

  public interface IConfiguracionRepository : IRepository<Domain.Entities.Configuracion>
  {
    Task<Domain.Entities.Configuracion> GetConfiguracion(string tipoConfiguracionCodigo);
  }
}
