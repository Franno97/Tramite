using Microsoft.EntityFrameworkCore;
using Mre.Visas.Tramite.Application.Catalogo.Repositories;
using Mre.Visas.Tramite.Domain.Entities;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Infrastructure.Catalogo.Repositories
{
  public class CalidadMigratoriaRepository : Repository<Domain.Entities.CalidadMigratoria>, ICalidadMigratoriaRepository
  {
    #region Constructors

    public CalidadMigratoriaRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    #endregion Constructors

    #region Metodos Others 
    public async Task<List<Domain.Entities.CalidadMigratoria>> GetAllCalidadMigratoria()
    {
      return await _context.CalidadMigratorias.Where(x => x.IsDeleted.Equals(false)).ToListAsync();
    }

    public async Task<CalidadMigratoria> GetCalidadMigratoriaByCodigo(int calidadMigratoriaId)
    {
      return await _context.CalidadMigratorias.FirstOrDefaultAsync(x=>!x.IsDeleted && x.CalidadMigratoriaId == calidadMigratoriaId);
    }

    #endregion
  }

  public class TipoConvenioRepository : Repository<Domain.Entities.TipoConvenio>, ITipoConvenioRepository
  {
    #region Constructors

    public TipoConvenioRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    #endregion Constructors

    #region Metodos Others 
    public async Task<List<Domain.Entities.TipoConvenio>> GetAllTipoConvenio()
    {
      return await _context.TipoConvenios.Where(x => x.IsDeleted.Equals(false)).ToListAsync();
    }

    #endregion
  }


  public class TipoVisaRepository : Repository<Domain.Entities.TipoVisa>, ITipoVisaRepository
  {
    #region Constructors

    public TipoVisaRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    #endregion Constructors

    #region Metodos Others 
    public async Task<List<Domain.Entities.TipoVisa>> GetTipoVisaByConvenioCodigo(string convenioCodigo)
    {
      return await _context.TipoVisas.Where(x => x.IsDeleted.Equals(false)).ToListAsync();
    }

    public async Task<Domain.Entities.TipoVisa> GetTipoVisaByCodigo(string codigo)
    {
      return await _context.TipoVisas.FirstOrDefaultAsync(x => x.IsDeleted.Equals(false) && x.TipoVisaCodigo == codigo);
    }

    #endregion
  }


  public class ActividadDesarrollarRepository : Repository<Domain.Entities.ActividadDesarrollar>, IActividadDesarrollarRepository
  {
    #region Constructors

    public ActividadDesarrollarRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    #endregion Constructors

    #region Metodos Others 
    public async Task<List<Domain.Entities.ActividadDesarrollar>> GetActividadDesarrollarByTipoVisaCodigo(string tipoVisaCodigo)
    {
      return await _context.ActividadDesarrollares.Where(x => x.IsDeleted.Equals(false)).ToListAsync();
    }

    #endregion
  }

  public class ConfiguracionRepository : Repository<Domain.Entities.Configuracion>, IConfiguracionRepository
  {
    #region Constructors

    public ConfiguracionRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    #endregion Constructors

    #region Metodos Others 
    public async Task<Domain.Entities.Configuracion> GetConfiguracion(string tipoConfiguracionCodigo)
    {
      return await _context.Configuraciones.FirstOrDefaultAsync(x => x.ConfiguracionCodigo == tipoConfiguracionCodigo && x.IsDeleted.Equals(false));
    }

    #endregion
  }
}