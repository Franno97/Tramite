using Mre.Visas.Tramite.Application.SoporteGestion.Repositories;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.Shared.Repositories;

namespace Mre.Visas.Tramite.Infrastructure.SoporteGestion.Repositories
{
  public class SoporteGestionRepository : Repository<Domain.Entities.SoporteGestion>, ISoporteGestionRepository
  {

    #region Constructors

    public SoporteGestionRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    #endregion Constructors

    #region Metods Others

    #endregion
  }
}

