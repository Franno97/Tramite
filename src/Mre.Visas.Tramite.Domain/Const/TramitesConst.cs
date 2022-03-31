using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Domain.Const
{
  public class TramitesConst
  {
    public const string Plantilla = "NOTIFICACION.GENERAL.01";
    public static class ComprobanteRecaudacion
    {
      public const string NombreRecaudacionCedulacion = "RecaudacionCedulacion.pdf";
      public const string NombreRecaudacionVisa = "RecaudacionSolicitudVisa.pdf";
      public const string AsuntoRecaudacion = "Ordenes de recaudación";
      public const string MensajeRecaudacion = "Se adjunta las ordenes de recaudación.";
    }
    public static class GeneracionVisa
    {
      public const string NombreArchivo = "VisaGenerada.pdf";
      public const string PdfMimeType = "application/pdf";
      public const string Asunto = "Generación de visa";
      public const string Mensaje = "Se adjunta la visa generada.";
    }
  }
}
