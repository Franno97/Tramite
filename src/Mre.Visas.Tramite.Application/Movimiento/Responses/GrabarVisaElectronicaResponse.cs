using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Responses
{
  public class GrabarVisaElectronicaResponse
  {
    public int HttpStatusCode { get; set; }

    public Respuesta Result { get; set; }
  }

  public class Respuesta
  {
    public string Estado { get; set; }

    public string Mensaje { get; set; }

    public string NumeroVisa { get; set; }
  }
}
