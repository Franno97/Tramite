using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Domain.Entities
{
  public class SolicitudVisaEsigex : AuditableEntity
  {

    public int IdSecuencialActuacion { get; set; }
    public int IdTramiteSolicitud { get; set; }
    public string NumeroTramite { get; set; }
    public string NumeroVisaEsigex { get; set; }
    public double Valor { get; set; }
    public int Codigo { get; set; }
    public string CodigoDescripcion { get; set; }
    public int IdPersona { get; set; }
    public Guid TramiteId { get; set; }
  }

  public class VisaEsigex : AuditableEntity
  {

    public int IdTramiteVisa { get; set; }
    public string NumeroTramite { get; set; }
    public double Valor { get; set; }
    public int Codigo { get; set; }
    public string CodigoDescripcion { get; set; }
    public Guid TramiteId { get; set; }
  }

}
