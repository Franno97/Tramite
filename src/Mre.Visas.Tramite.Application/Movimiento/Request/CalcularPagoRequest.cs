using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Request
{
  public class CalcularPagoRequest
  {
    /// <summary>
    /// id de tramite
    /// </summary>
    public Guid id { get; set; }
    public Guid servicioId { get; set; }
    public bool tieneVisa { get; set; }
    public int edad { get; set; }
    public int porcentajeDiscapacidad { get; set; }
    public Guid idUsuario { get; set; }
    public string solicitante { get; set; }
    public string documentoIdentificacion { get; set; }
    public string banco { get; set; }
    public string numeroCuenta { get; set; }
    public string tipoCuenta { get; set; }
    public string titularCuenta { get; set; }
    public List<Dtos.ArancelDto> ConfiguracionAranceles { get; set; }
  }
}
