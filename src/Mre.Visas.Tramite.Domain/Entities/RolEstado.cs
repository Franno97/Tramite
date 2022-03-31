namespace Mre.Visas.Tramite.Domain.Entities
{
  public class RolEstado : AuditableEntity
  {
    /// <summary>
    /// Nombre del rol
    /// </summary>
    public string NombreRol { get; set; }
    /// <summary>
    /// Si el rol corresponde a un usuario de la Zonal
    /// </summary>
    public bool EsZonal { get; set; }
    /// <summary>
    /// Descripción del estado
    /// </summary>
    public string NombreEstado { get; set; }
    /// <summary>
    /// Código del estado
    /// </summary>
    public string CodigoEstado { get; set; }
    /// <summary>
    /// Códigos de los posibles estados siguientes
    /// </summary>
    public string CodigosEstadoSiguiente { get; set; }
    /// <summary>
    /// Código del estado en caso de que el trámite caiga en desistimiento
    /// </summary>
    public string CodigoDesistir { get; set; }

    /// <summary>
    /// Bandera que indica que el proceso genera una notificación
    /// </summary>
    public bool TieneNotificacion { get; set; }

    /// <summary>
    /// Campo para determinar si las notificaciones del proceso deben ir acompañadas de las observaciones
    /// </summary>
    public bool AgregarObservaciones { get; set; }
  }
}