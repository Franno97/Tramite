using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application
{
  public class RemoteServicesRoot
  {
    public RemoteServices RemoteServices { get; set; }
  }
  public class RemoteServices
  {
    public Externos externos { get; set; }
    public Documentos documentos { get; set; }
    public Mensajes mensajes { get; set; }
    public UnidadAdministrativa unidadAdministrativa { get; set; }
    public Tramite tramite { get; set; }
    public Reporte reporte { get; set; }
    public VisaElectronica visaElectronica { get; set; }
    public SharePoint sharePoint { get; set; }
    public FacturacionElectronica facturacionElectronica { get; set; }
    public Pago pago { get; set; }
    public Catalogo catalogo { get; set; }
    public class Externos
    {
      public string BaseUrl { get; set; }
    }
    public class Documentos
    {
      public string BaseUrl { get; set; }
    }
    public class Mensajes
    {
      public string BaseUrl { get; set; }
    }
    public class UnidadAdministrativa
    {
      public string BaseUrl { get; set; }
    }
    public class Tramite
    {
      public string BaseUrl { get; set; }
    }
    public class Reporte
    {
      public string BaseUrl { get; set; }
    }
    public class VisaElectronica
    {
      public string BaseUrl { get; set; }
    }
    public class FacturacionElectronica
    {
      public string BaseUrl { get; set; }
    }
    public class Pago
    {
      public string BaseUrl { get; set; }
    }
    public class SharePoint
    {
      public string BaseUrl { get; set; }
    }
    public class Catalogo
    {
      public string BaseUrl { get; set; }
    }
  }
  
}
