using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos
{
    public class VisaDto
    {
        public String TipoVisaCodigo { get; set; }

        public string TipoVisa { get; set; }

        public string CategoriaVisa { get; set; }

        public string Numero { get; set; }

        public DateTime FechaOtorgamiento { get; set; }
        
        public int TiempoVigencia { get; set; }

    }
}
