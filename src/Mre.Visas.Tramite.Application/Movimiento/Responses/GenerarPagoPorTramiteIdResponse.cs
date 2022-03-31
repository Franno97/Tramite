using System.Collections.Generic;

namespace Mre.Visas.Tramite.Application.Movimiento.Responses
{
  public class GenerarPagoPorTramiteIdResponse
  {
    public string Estado { get; set; }
    public string Mensaje { get; set; }
    public List<string> Base64 { get; set; }
  }
}
