using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Responses
{
  public class GuardarSolicitudVisaResponse
  {
    public int IdSecuencialActuacion { get; set; }
    public int IdTramiteSolicitud { get; set; }
    public string NumeroTramite { get; set; }
    public string NumeroVisaEsigex { get; set; }
    public double Valor { get; set; }
    public int Codigo { get; set; }
    public string CodigoDescripcion { get; set; }
    public int IdPersona { get; set; }
  }
}
