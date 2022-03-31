using Mre.Visas.Tramite.Application.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Repositories
{
    public interface IOrdenCedulacionRepository : IRepository<Domain.Entities.OrdenCedulacion>
    {
        Domain.Entities.OrdenCedulacion ObtenerPorTramiteId(Guid tramiteId);

    }
}
