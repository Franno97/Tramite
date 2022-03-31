using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos
{
    public class PagoDto
    {
        public virtual Guid Id { get; set; }

        public virtual Guid ServicioId { get; set; }
        
        public virtual Guid TramiteId { get; set; }

        public virtual int FormaPago { get; set; }

        public virtual string Estado { get; set; }

        public virtual string Observacion { get; set; }

        public virtual string DocumentoIdentificacion { get; set; }

        public virtual ICollection<PagoDetalleDto> PagoDetalles { get; set; }

    }
}
