using Mre.Visas.Tramite.Application.Movimiento.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Responses
{
  public class ObtenerConfiguracionPagoResponse
  {
    public int httpStatusCode { get; set; }
    public List<ConfiguracionPago> result { get; set; }
  }
}
