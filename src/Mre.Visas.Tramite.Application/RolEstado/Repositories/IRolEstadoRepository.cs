using Mre.Visas.Tramite.Application.Shared.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.RolEstado.Repositories
{
  public interface IRolEstadoRepository : IRepository<Domain.Entities.RolEstado>
  {
    Task<List<Domain.Entities.RolEstado>> GetRolEstadoByNombreRol(string nombreRol);

    Task<List<Domain.Entities.RolEstado>> GetRolEstadoByEstadoActual(string estado);

    Domain.Entities.RolEstado GetRolEstadoByEstado(string codigoEstado);
  }
}