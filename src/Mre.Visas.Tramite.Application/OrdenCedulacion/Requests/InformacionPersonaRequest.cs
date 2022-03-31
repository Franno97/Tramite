using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Requests
{
    public class InformacionPersonaRequest
    {
        public virtual Guid UnidadAdministrativaId { get; set; }

        public virtual Guid ServicioId { get; set; }

        public virtual string NombreRol { get; set; }

    }
}
