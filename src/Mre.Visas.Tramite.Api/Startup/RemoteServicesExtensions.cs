using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using System;

namespace Mre.Visas.Tramite.Api
{
  public static class RemoteServicesExtensions
  {

    public static void ConfigureHttpClient(
        IServiceCollection services,
        IConfiguration configuration)
    {

      //Cliente para consulta de usuarios
      var urlBase = configuration["RemoteServices:Base:BaseUrl"];

      services.AddHttpClient<IUsuarioClient, UsuarioClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlBase);
          })
        ;

      //Cliente para consulta de funcionarios
      var urlServicioUnidadAdministrativaFuncional = configuration["RemoteServices:UnidadAdministrativa:BaseUrl"];

      services.AddHttpClient<IUnidadAdministrativaFuncionalClient, UnidadAdministrativaFuncionalClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlServicioUnidadAdministrativaFuncional);
          })
        ;

      //Cliente para consulta de funcionarios
      var urlServicioUnidadAdministrativa = configuration["RemoteServices:UnidadAdministrativa:BaseUrl"];

      services.AddHttpClient<IUnidadAdministrativaClient, UnidadAdministrativaClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlServicioUnidadAdministrativa);
          })
        ;


      //Cliente para envio de notificaciones
      var urlServicioNotificacion = configuration["RemoteServices:Notificacion:BaseUrl"];

      services.AddHttpClient<INotificadorClient, NotificadorClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlServicioNotificacion);
          })
        ;

      //Cliente para consulta de pagos
      var urlServicioPago = configuration["RemoteServices:Pago:BaseUrl"];

      services.AddHttpClient<IPagoClient, PagoClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlServicioPago);
          })
        ;
            
      //Cliente para consulta de pagos
      var urlServicioCatalogo = configuration["RemoteServices:Catalogo:BaseUrl"];

      services.AddHttpClient<ICatalogoClient, CatalogoClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlServicioCatalogo);
          })
        ;

      //Cliente para consulta de personas
      var urlServicioRegistroPersona = configuration["RemoteServices:RegistroPersona:BaseUrl"];

      services.AddHttpClient<IPersonaClient, PersonaClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlServicioRegistroPersona);
          })
        ;

      //Cliente para facturacion electronica
      var urlServicioFacturaElectronica = configuration["RemoteServices:FacturacionElectronica:BaseUrl"];

      services.AddHttpClient<IFacturaElectronicaClient, FacturaElectronicaClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlServicioFacturaElectronica);
          })
        ;


      //Cliente para Configurar Visa Electronica 
      var urlBaseConfigurarVisaElectronica = configuration["RemoteServices:VisaElectronica:BaseUrl"];

      services.AddHttpClient<IVisaElectronicaClient, VisaElectronicaClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlBaseConfigurarVisaElectronica);
          })
        ;


      //Cliente para Sharepoint
      var urlServicioSharepoint = configuration["RemoteServices:SharePoint:BaseUrl"];

      services.AddHttpClient<ISharepointClient, SharepointClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlServicioSharepoint);
          })
        ;

      //Cliente para firma electronica
      var urlBaseFirmaElectronica = configuration["RemoteServices:FirmaElectronica:BaseUrl"];

      services.AddHttpClient<IFirmaElectronicaClient, FirmaElectronicaClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlBaseFirmaElectronica);
          })
        ;


      //Cliente para Configurar Firma Electronica 
      var urlBaseConfigurarFirmaElectronica = configuration["RemoteServices:UnidadAdministrativa:BaseUrl"];

      services.AddHttpClient<IConfigurarFirmaElectronicaClient, ConfigurarFirmaElectronicaClient>(
          c =>
          {
            c.BaseAddress = new Uri(urlBaseConfigurarFirmaElectronica);
          })
        ;

            //Cliente para generar PDF Orden  OrdenCedulacionReporte
            var urlBaseOrdenCedulacionReporte = configuration["RemoteServices:Reporte:BaseUrl"];

    services.AddHttpClient<IOrdenCedulacionReporteClient, OrdenCedulacionReporteClient>(
        c =>
        {
            c.BaseAddress = new Uri(urlBaseOrdenCedulacionReporte);
        })
        ;

        }

    }


  //   public static class JsonSerializerExtensions
  //   {

  //       public static void ConfigureJsonSerializer(
  //           IServiceCollection services,
  //           IConfiguration configuration)
  //       {

  //           services
  //.AddJsonOptions(options =>
  //{
  //    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
  //});
  //           JsonConvert.DefaultSettings = () => new JsonSerializerSettings();

  //       }

  //   }

}
