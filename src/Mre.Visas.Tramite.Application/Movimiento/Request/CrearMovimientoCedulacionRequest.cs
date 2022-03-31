using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Request
{
  public class CrearMovimientoCedulacionRequest
  {
    /// <summary>
    /// Numero de Orden como ingresa el proceso
    /// </summary
    public Guid TramiteId { get; set; }

    /// <summary>
    /// El estado del flujo de proceso siguiente
    /// </summary>
    public int Estado { get; set; }

    /// <summary>
    /// Usuario que esta creando
    /// </summary>
    public Guid CreatorId { get; set; }

  }
}
