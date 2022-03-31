using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Request
{
  public class GuardarSolicitudVisaRequest
  {
    public string CorreoElectronico { get; set; }
    public string DireccionResidencia { get; set; }
    public int Exoneracion { get; set; }
    public DateTime FechaCaducidadDocumento { get; set; }
    public DateTime FechaEmisionDocumento { get; set; }
    public DateTime FechaFactura { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public DateTime FechaPago { get; set; }
    public DateTime FechaRegistroSolicitud { get; set; }
    public byte[] Foto { get; set; }
    public int IdActividadVisa { get; set; }
    public int IdActoConsularSolicitudVisa { get; set; }
    public int IdActoConsularVisa { get; set; }
    public int IdCalidadMigratoria { get; set; }
    public int IdCentroAdministrativo { get; set; }
    public int IdCiudadNacimiento { get; set; }
    public int IdCiudadResidencia { get; set; }
    public int IdEntidadAuspiciante { get; set; }
    public int IdFormaPago { get; set; }
    public int IdFuncionarioCajero { get; set; }
    public int IdFuncionarioCreacionEsigex { get; set; }
    public string IdFuncionarioNuevoSistema { get; set; }
    public int IdGrupoVisa { get; set; }
    public int IdNacionalidad { get; set; }
    public int IdTipoDocumento { get; set; }
    public string IdTramiteNuevoSistema { get; set; }
    public int LugarEmisionDocumento { get; set; }
    public string NombresExtranjero { get; set; }
    public string NumeroComprobante { get; set; }
    public string NumeroDocumento { get; set; }
    public string NumeroFactura { get; set; }
    public string NumeroVisaNuevoSistema { get; set; }
    public string ObservacionSolicitud { get; set; }
    public string PrimerApellidoExtranjero { get; set; }
    public List<RequisitosVisaRequest> RequisitosVisa { get; set; }
    public string SegundoApellidoExtranjero { get; set; }
    public string Telefono { get; set; }
    
    public class RequisitosVisaRequest
    {
      public int IdActoConsularVisa { get; set; }
      public int IdRequisito { get; set; }
      public string Observacion { get; set; }
      public bool Seleccionado { get; set; }
    }
  }
}
