using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Requests
{
    public class GenerarOrdenCedulacionEsigexResponse
    {

        public virtual string SecuencialActuacion { get; set; }

        public virtual string CodigoVerificacion { get; set;}

        public virtual string IdTramiteOrdenCedulacion { get; set; }

        public virtual string NumeroTramite { get; set; }

    }
}
