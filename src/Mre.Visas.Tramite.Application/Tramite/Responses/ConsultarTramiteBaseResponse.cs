using Mre.Visas.Tramite.Application.Tramite.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Tramite.Responses
{
  public class ConsultarTramiteBaseResponse
  {
    public string Error { get; set; }

    public List<TramiteBaseDto> ListaTramiteBase {get;set;}

    public ConsultarTramiteBaseResponse()
    {
      Error = string.Empty;
      ListaTramiteBase = new List<TramiteBaseDto>();
    }
  }
}
