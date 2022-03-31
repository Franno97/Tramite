using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Responses
{
  public class CrearTramiteResponse
  {
    public Guid Id { get; set; }
    public string Numero { get; set; }
    public string Mensaje { get; set; }

    public CrearTramiteResponse()
    {
      Id = Guid.Empty;
      Numero = "00000000-0000";
      Mensaje = string.Empty;
    }
  }
}
