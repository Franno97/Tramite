using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Responses
{
  public class CrearTramiteCedulacionResponse
  {
    public Guid Id { get; set; }
    public string Numero { get; set; }
    public string Mensaje { get; set; }

    public CrearTramiteCedulacionResponse()
    {
      Id = Guid.Empty;
      Numero = "00000000-0000";
      Mensaje = string.Empty;
    }
  }
}
