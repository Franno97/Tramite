using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Responses
{
  public class ConsultarCatalogoCabeceraResponse
  {
    public int httpStatusCode { get; set; }
    public List<CatalogoCabecera> Result { get; set; }
    public class CatalogoCabecera
    {
      public Guid Id { get; set; }
      public string Codigo { get; set; }

      public string Descripcion { get; set; }
    }
  }
}
