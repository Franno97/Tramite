using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.HistorialMigratorio.Requests
{
  public class HistorialMigratorioRequest
  {
    public Guid TramiteId { get; set; }
    public Guid UsuarioId { get; set; }

    public List<HistorialMigratorioDetalleRequest> ListaHistorialMigratorio { get; set; }
  }

  public class HistorialMigratorioDetalleRequest
  {
    public string ApellidosNombres { get; set; }
    public string CategoriaMigratoria { get; set; }
    public string CodigoError { get; set; }
    public string FechaHoraMovimiento { get; set; }
    public string FechaNacimiento { get; set; }
    public string Genero { get; set; }
    public string Medio { get; set; }
    public string MotivoViaje { get; set; }
    public string NacionalidadDocumentoMovMigra { get; set; }
    public string NumeroDocumentoMovMigra { get; set; }
    public string PaisDestino { get; set; }
    public string PaisNacimiento { get; set; }
    public string PaisOrigen { get; set; }
    public string PaisResidencia { get; set; }
    public string PuertoRegistro { get; set; }
    public string TarjetaAndina { get; set; }
    public string TiempoDeclarado { get; set; }
    public string TipoDocumentoMovMigra { get; set; }
    public string TipoMovimiento { get; set; }
  }


  public class ConsultarHistorialMigratorioRequest
  {
    public Guid TramiteId { get; set; }
    
  }
}
