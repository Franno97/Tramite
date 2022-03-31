using Mre.Visas.Tramite.Application.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.HistorialMigratorio.Repositories
{
    public interface IHistorialMigratorioRepository : IRepository<Domain.Entities.HistorialMigratorio>
    {
        Task<List<Domain.Entities.HistorialMigratorio>> GetHistorialMigratorioByTramiteId(Guid tramiteId);
    }
}
