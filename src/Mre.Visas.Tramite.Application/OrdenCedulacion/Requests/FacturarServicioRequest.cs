using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Requests
{
    public class FacturarServicioRequest
    {
        public virtual Guid TramiteId { get; set; }

        public virtual Guid PagoId { get; set; }

    }
}
