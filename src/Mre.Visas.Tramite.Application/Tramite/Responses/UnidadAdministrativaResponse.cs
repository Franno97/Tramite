using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Responses
{
  public class UnidadAdministrativaResponse
  {
    public string nombre { get; set; }
    public string paisId { get; set; }
    public string siglas { get; set; }
    public Guid id { get; set; }
  }
  public class UnidadAdministrativaListaResponse
  {
    public List<UnidadAdministrativaResponse> items { get; set; }
  }

}
