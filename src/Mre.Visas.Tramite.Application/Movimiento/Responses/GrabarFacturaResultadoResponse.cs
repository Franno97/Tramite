using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Responses
{
  public class GrabarFacturaResultadoResponse
  {
    public string Estado { get; set; }
    public string Mensaje { get; set; }
    public string ClaveAcceso { get; set; }
    public string Numero { get; set; }
    public string FechaEmision { get; set; }
    public string FechaAutorizacion { get; set; }
  }
}
