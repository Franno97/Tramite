using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Requests
{
  public class ConsultarTramitesBaseRequest
  {
    public Guid ServicioId { get; set; }
    public Guid UnidadAdministrativaId { get; set; }
    public Guid UsuarioId { get; set; }
  }
}

