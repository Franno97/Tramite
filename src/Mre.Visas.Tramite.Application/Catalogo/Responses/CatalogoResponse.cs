using Mre.Visas.Tramite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Catalogo.Responses
{
  public class CalidadMigratoriaResponse
  {
    public string Error { get; set; }

    public CalidadMigratoria CalidadMigratoria { get; set; }

    public CalidadMigratoriaResponse()
    {
      Error = "OK";
      CalidadMigratoria = new CalidadMigratoria();
    }
  }

  public class TipoConvenioResponse
  {
    public string Error { get; set; }

    public TipoConvenio TipoConvenio { get; set; }

    public TipoConvenioResponse()
    {
      Error = "OK";
      TipoConvenio = new TipoConvenio();
    }
  }

  public class TipoVisaResponse
  {
    public string Error { get; set; }

    public TipoVisa TipoVisa { get; set; }

    public TipoVisaResponse()
    {
      Error = "OK";
      TipoVisa = new TipoVisa();
    }
  }

  public class ActividadDesarrollarResponse
  {
    public string Error { get; set; }

    public ActividadDesarrollar ActividadDesarrollar { get; set; }

    public ActividadDesarrollarResponse()
    {
      Error = "OK";
      ActividadDesarrollar = new ActividadDesarrollar();
    }
  }

}
