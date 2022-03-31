using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Responses
{
    public class GenerarOrdenCedulacionResponse
    {
        public virtual string NumeroOrden { get; set; }

        public virtual string CodigoVerificacion { get; set; }

        public virtual string NumeroTransaccion { get; set; }

        /// <summary>
        /// Documento PDF de orden de cedulacíon en formato base64
        /// </summary>
        public virtual string OrdenCedulacion { get; set; }

    }
}
