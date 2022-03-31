using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Requests
{
  public class ConsultarTramitePorRolFiltrosRequest
  {
    /// <summary>
    /// El Nombre del rol
    /// </summary>
    public string NombreRol { get; set; }

    /// <summary>
    /// Usuario Id
    /// </summary>
    public Guid UsuarioId { get; set; }

    /// <summary>
    /// Numero de registro
    /// </summary>
    public int NumeroRegistros { get; set; }
    
    /// <summary>
    /// PaginActual
    /// </summary>
    public int PaginaActual { get; set; }
    
    /// <summary>
    /// OrdenColumna
    /// </summary>
    public string OrdenColumna { get; set; }

    /// <summary>
    /// OrdenForma
    /// </summary>
    public string OrdenForma { get; set; }

    /// <summary>
    /// Filtro
    /// </summary>
    public string Filtro { get; set; }

  }
}
