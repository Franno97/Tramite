using System;

namespace Mre.Visas.Tramite.Domain.Entities
{
  public class SoporteGestion : AuditableEntity
  {
    /// <summary>
    /// Id de tramite
    /// </summary>
    public Guid TramiteId { get; set; }

    public Domain.Entities.Tramite Tramite { get; set; }

    /// <summary>
    /// Nombre del archivo con extension
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Descripción del documento que se está adjuntando
    /// </summary>
    public string Descripcion { get; set; }

    /// <summary>
    /// Ruta del archivo de sharepoint
    /// </summary>
    public string Ruta { get; set; }
  }
}