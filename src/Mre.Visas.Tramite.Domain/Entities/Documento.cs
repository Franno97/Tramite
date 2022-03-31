using System;

namespace Mre.Visas.Tramite.Domain.Entities
{
  public class Documento : AuditableEntity
  {
    /// <summary>
    /// Id
    /// </summary>
    public Guid TramiteId { get; set; }

    public Domain.Entities.Tramite Tramite { get; set; }

    /// <summary>
    /// Nombre del archivo
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Ruta del documentoa almancenado el sharepoint
    /// </summary>
    public string Ruta { get; set; }

    /// <summary>
    /// Observacion del documento
    /// </summary>
    public string Observacion { get; set; }

    /// <summary>
    /// Campo para el Tipo de Documento
    /// </summary>
    public string TipoDocumento { get; set; }

    /// <summary>
    /// IconoNombre
    /// </summary>
    public string IconoNombre { get; set; }

    /// <summary>
    /// ImagenNombre
    /// </summary>
    public string ImagenNombre { get; set; }

    /// <summary>
    /// DescripcionDocumento
    /// </summary>
    public string DescripcionDocumento { get; set; }

    /// <summary>
    /// Estado del proceso cuando pasa por datacap
    /// </summary>
    public string EstadoProceso { get; set; }

  }
}