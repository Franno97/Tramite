using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Responses
{
  public class ConsultarCatalogoDetalleResponse
  {
    public int httpStatusCode { get; set; }
    public List<CatalogoDetalle> result { get; set; }


    public class CatalogoDetalle
    {
      public Guid Id { get; set; }
      public Guid CatalogoCabeceraId { get; set; }
      public string Codigo { get; set; }
      public string Descripcion { get; set; }
      public string CodigoEsigex { get; set; }
      public string CodigoMdg { get; set; }
      public string CodigoOtro { get; set; }
    }
  
  }
}
