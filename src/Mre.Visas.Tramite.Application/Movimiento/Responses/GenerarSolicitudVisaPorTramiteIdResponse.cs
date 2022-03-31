using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Responses
{
  public class GenerarSolicitudVisaPorTramiteIdResponse
  {
    public string Estado { get; set; }
    public string Mensaje { get; set; }
    public string Base64 { get; set; }
  }
}
