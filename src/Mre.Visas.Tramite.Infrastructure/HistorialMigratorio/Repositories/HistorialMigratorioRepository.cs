using Microsoft.EntityFrameworkCore;
using Mre.Visas.Tramite.Application.HistorialMigratorio.Repositories;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Infrastructure.HistorialMigratorio.Repositories
{
    public class HistorialMigratorioRepository : Repository<Domain.Entities.HistorialMigratorio>, IHistorialMigratorioRepository
    {
        #region Constructors

        public HistorialMigratorioRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        #endregion Constructors

        #region Metodos Others 
        public async Task<List<Domain.Entities.HistorialMigratorio>> GetHistorialMigratorioByTramiteId(Guid tramiteId)
        {
            return await _context.HistorialMigratorios.Where(x => x.TramiteId== tramiteId && x.IsDeleted.Equals(false)).ToListAsync();
        }
        #endregion
    }
}
