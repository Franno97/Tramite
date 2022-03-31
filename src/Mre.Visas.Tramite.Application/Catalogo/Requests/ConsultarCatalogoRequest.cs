using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Catalogo.Requests
{
  public class ConsultarCatalogoRequest
  {
    /// <summary>
    /// Codigo
    /// </summary>
    public string Codigo { get; set; }
  }

  public class CalidadMigratoriaRequest
  {
    public Guid UsuarioId { get; set; }
    public int Codigo { get; set; }
    public string Descripcion { get; set; }
  }

  public class TipoConvenioRequest
  {
    public Guid UsuarioId { get; set; }
    public string TipoConvenioCodigo { get; set; }
    public string Descripcion { get; set; }
  }

  public class TipoVisaRequest
  {
    public Guid UsuarioId { get; set; }
    public string TipoConvenioCodigo { get; set; }
    public string Descripcion { get; set; }
    public string TipoVisaCodigo { get; set; }
    public Guid CalidadMigratoriaId { get; set; }
    public string NumeroAdmisiones { get; set; }
    public int DiasValidez { get; set; }
    public bool RequiereAutorizacion { get; set; }
    public string Categoria { get; set; }
    public Guid ServicioVisasId { get; set; }
  }

  public class ActividadDesarrollarRequest
  {
    public Guid UsuarioId { get; set; }
    public string TipoVisaCodigo { get; set; }
    public string ActividadDesarrollarCodigo { get; set; }
    public string Descripcion { get; set; }
  }

}
