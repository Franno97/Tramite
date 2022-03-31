using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Movimiento.Request
{
  public class ActualizarMovimientoRequest
  {
    /// <summary>
    /// Numero de Orden como ingresa el proceso
    /// </summary>
    public Guid TramiteId { get; set; }

    /// <summary>
    /// codigo de Movimiento
    /// </summary>
    public Guid MovimientoId { get; set; }
    /// <summary>
    /// Usuario que va a gestionar el tramite 
    /// Ejemplo puede ser Consultor, Funcionario, Perito, otros
    /// </summary>
    public Guid UsuarioId { get; set; }


  }
}

