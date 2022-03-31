using Microsoft.EntityFrameworkCore;
using Mre.Visas.Tramite.Application.RolEstado.Repositories;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.Shared.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Infrastructure.RolEstado.Repositories
{
  public class RolEstadoRepository : Repository<Domain.Entities.RolEstado>, IRolEstadoRepository
  {
    #region Constructors

    public RolEstadoRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    #endregion Constructors

    #region Metodos Others 
    public async Task<List<Domain.Entities.RolEstado>> GetRolEstadoByNombreRol(string nombreRol)
    {
      return await _context.RolEstados.Where(x => x.NombreRol == nombreRol && x.IsDeleted.Equals(false)).ToListAsync();
    }

    public async Task<List<Domain.Entities.RolEstado>> GetRolEstadoByEstadoActual(string estado)
    {
      var Estado = _context.RolEstados.Where(x => x.CodigoEstado == estado).FirstOrDefault();
      string[] estadoSiguientes = Estado.CodigosEstadoSiguiente.Split(',');

      return await _context.RolEstados.Where(x => x.IsDeleted.Equals(false)
                                  && estadoSiguientes.Select(y => y.ToString()).Contains(x.CodigoEstado)).ToListAsync();
    }

    public Domain.Entities.RolEstado GetRolEstadoByEstado(string codigoEstado)
    {
      var valor = _context.RolEstados.Where(x => x.CodigoEstado == codigoEstado).FirstOrDefault();
      return valor;
    }
    #endregion
  }
}