using System;

namespace Mre.Visas.Tramite.Domain.Entities
{
  public class CalidadMigratoria : AuditableEntity
  {
    public int CalidadMigratoriaId { get; set; }
    public string Descripcion { get; set; }
  }

  public class TipoConvenio : AuditableEntity
  {
    public string TipoConvenioCodigo { get; set; }
    public string Descripcion { get; set; }
  }

  public class TipoVisa : AuditableEntity
  {
    public Guid ServicioVisasId { get; set; }
    public string TipoConvenioCodigo { get; set; }
    public string TipoVisaCodigo { get; set; }
    public string Descripcion { get; set; }
    public string Categoria { get; set; }
    public Guid CalidadMigratoriaId { get; set; }
    public string NumeroAdmisiones { get; set; }
    public int DiasValidez { get; set; }
    public bool RequiereAutorizacion { get; set; }
  }

  public class ActividadDesarrollar : AuditableEntity
  {
    public string TipoVisaCodigo { get; set; }
    public string ActividadDesarrollarCodigo { get; set; }
    public string Descripcion { get; set; }
  }

  public class Configuracion : AuditableEntity
  {
    public string ConfiguracionCodigo { get; set; }
    public string ValorCadena { get; set; }
    public DateTime ValorFecha { get; set; }
    public int ValorEntero { get; set; }
    public string Descripcion { get; set; }
  }


}
