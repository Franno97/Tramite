using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.SoporteGestion.Requests
{
  public class CrearSoporteGestionRequest
  {
    /// <summary>
    /// Numero de Orden como ingresa el proceso
    /// </summary>
    public Guid TramiteId { get; set; }

    /// <summary>
    /// Nombre del archivo con extension
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Ruta del archivo de sharepoint
    /// </summary>
    public string Ruta { get; set; }

    /// <summary>
    /// Descripción del documento que se está adjuntando
    /// </summary>
    public string Descripcion { get; set; }

    /// <summary>
    /// Usuario que esta creando
    /// </summary>
    public Guid CreatorId { get; set; }

  }
}
