using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Domain.Enums
{
  public class FiltroTipo
  {
    public enum Tipo { Ninguno, NombreBeneficiario, NombreSolicitante, NumeroTramite, FechaEmision }
  }

  public class TipoCiudadano
  {
    public enum TipoCiudadanoEnum { Titular, Conyuge, Hijo }

  }
}
