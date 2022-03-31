using System;
using System.Collections.Generic;

namespace Mre.Visas.Tramite.Application.Tramite.Requests
{
  public class ActualizarMovimientoReasignacionRequest
  {
    public Guid UsuarioIdAsignado { get; set; }

    public Guid UsuarioIdCreaTransaccion { get; set; }

    public List<Guid> ListaMovimientos { get; set; }
  }

}
