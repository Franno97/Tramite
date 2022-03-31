using Mre.Visas.Tramite.Application.OrdenCedulacion.Repositories;
using Mre.Visas.Tramite.Infrastructure.Persistence.Contexts;
using Mre.Visas.Tramite.Infrastructure.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Infrastructure.OrdenCedulacion.Repositories
{
    public class OrdenCedulacionRepository : Repository<Domain.Entities.OrdenCedulacion>, IOrdenCedulacionRepository
    {

        #region Constructors
        public OrdenCedulacionRepository(ApplicationDbContext context)
            : base(context)
        {
        }
        #endregion Constructors


        #region IOrdenCedulacionRepository
        public Domain.Entities.OrdenCedulacion ObtenerPorTramiteId(Guid tramiteId)
        {
            var ordenCedulacion = _context.OrdenCedulaciones.SingleOrDefault(x => x.TramiteId == tramiteId);
            return ordenCedulacion;
        }

        #endregion IOrdenCedulacionRepository



        #region Metods Others

        #endregion
    }
}
