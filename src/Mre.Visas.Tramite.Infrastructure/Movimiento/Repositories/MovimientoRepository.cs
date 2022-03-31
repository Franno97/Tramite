using Mre.Visas.Tramite.Application.Movimiento.Repositories;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.Shared.Repositories;

namespace Mre.Visas.Tramite.Infrastructure.Movimiento.Repositories
{
  public class MovimientoRepository : Repository<Domain.Entities.Movimiento>, IMovimientoRepository
  {

    #region Constructors

    public MovimientoRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    #endregion Constructors

    #region Metods Others
    
    #endregion
  }
}
