using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Responses
{
  public class GrabarBibliotecaResponse
  {
    /// <summary>
    /// estado del resultado
    /// OK = POSITIVO
    /// ERROR = NEGATIVO
    /// </summary>
    public string Estado { get; set; }

    /// <summary>
    /// MENSAJE 
    /// RESULTADO VACIO SI ESTA CORRECTO Y SY CONTIENE ES EL ERROR
    /// </summary>
    public string Mensaje { get; set; }

    /// <summary>
    /// EL RESULTADO DE LA RUTA
    /// </summary>
    public string Ruta { get; set; }

    /// <summary>
    /// Ruta del archivo en el Sharepoint
    /// </summary>
    public string RutaSp { get; set; }

    /// <summary>
    /// Lista del Sharepoint
    /// </summary>
    public string ListaSp { get; set; }

    /// <summary>
    /// Sitio del Sharepoint
    /// </summary>
    public string SitioSp { get; set; }

    /// <summary>
    /// Carpeta del Sharepoint
    /// </summary>
    public string CarpetaSp { get; set; }

    /// <summary>
    /// Nombre del fichero
    /// </summary>
    public string NombreFichero { get; set; }
  }
}
