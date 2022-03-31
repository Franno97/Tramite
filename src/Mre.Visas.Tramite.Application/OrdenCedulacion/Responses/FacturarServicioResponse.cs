using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Responses
{
    public class FacturarServicioResponse
    {
        public virtual string NumeroOrden { get; set; }

        public virtual string CodigoVerificacion { get; set; }

        public virtual string NumeroTransaccion { get; set; }

        public virtual string RutaAlmacenamientoFactura { get; set; }

        public virtual string NumeroFactura { get; set; }

        public virtual int EstadoOrden { get; set; }


    }
}
