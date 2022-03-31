using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Mre.Visas.Tramite.Application.ConfiguracionFirmaElectronica.Queries;
using Mre.Visas.Tramite.Application.Shared.Handlers;
using Mre.Visas.Tramite.Application.Shared.HttpApiClient;
using Mre.Visas.Tramite.Application.Shared.Interfaces;
using Mre.Visas.Tramite.Application.Shared.Security;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using Mre.Visas.Tramite.Application.Tramite.Requests;
using Mre.Visas.Tramite.Domain.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SignatarioDto = Mre.Visas.Tramite.Application.OrdenCedulacion.Dtos.SignatarioDto;
using Mre.Visas.Tramite.Application.Externos.Responses;
using Mre.Visas.Tramite.Application.Movimiento.Dtos;
using Mre.Visas.Tramite.Application.Movimiento.Request;
using Mre.Visas.Tramite.Application.Movimiento.Responses;
using Mre.Visas.Tramite.Domain.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using ArancelDto = Mre.Visas.Tramite.Application.Movimiento.Dtos.ArancelDto;
using GrabarFacturaResultadoResponse = Mre.Visas.Tramite.Application.Movimiento.Responses.GrabarFacturaResultadoResponse;
using Microsoft.Extensions.Options;
using Mre.Visas.Tramite.Application.Tramite.Dtos;
using Mre.Visas.Tramite.Application.Tramite.Commands;
using Mre.Visas.Tramite.Application.Catalogo.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Mre.Visas.Tramite.Application.Movimiento.Commands
{
  public class CrearMovimientoCommand : CrearMovimientoRequest, IRequest<ApiResponseWrapper>
  {
    public string Token { get; set; }
    public CrearMovimientoCommand(CrearMovimientoRequest request, string tokenAcceso)
    {
      ObservacionDatosPersonales = request.ObservacionDatosPersonales;
      ObservacionDomicilios = request.ObservacionDomicilios;
      ObservacionMovimientoMigratorio = request.ObservacionMovimientoMigratorio;
      ObservacionMultas = request.ObservacionMultas;
      ObservacionSoportesGestion = request.ObservacionSoportesGestion;
      TramiteId = request.TramiteId;
      Estado = request.Estado;
      EstadoOrigen = request.EstadoOrigen;
      CreatorId = request.CreatorId;
      FechaHoraCita = request.FechaHoraCita;
      Token = tokenAcceso;
    }

    public partial class CrearMovimientoCommandHandler : BaseHandler, IRequestHandler<CrearMovimientoCommand, ApiResponseWrapper>
    {
      public CrearMovimientoCommandHandler(IUnitOfWork unitOfWork, IHttpApiAutentificacion httpApiAutentificacion, ILogger<CrearMovimientoCommandHandler> logger,
        IUnidadAdministrativaClient unidadAdministrativaClient,
        IUnidadAdministrativaFuncionalClient unidadAdministrativaFuncionalClient,
        INotificadorClient notificadorClient,
        IConfigurarFirmaElectronicaClient configurarFirmaElectronicaClient,
        IFirmaElectronicaClient firmaElectronicaClient,
        IUsuarioClient usuarioClient,
        IMediator mediator,
        IOptions<VisaVirteConfiguracion> visaVirteConfiguracion,
        IOptions<RemoteServices> remoteServices,
        IVisaElectronicaClient visaElectronicaClient
        )
          : base(unitOfWork)
      {
        HttpApiAutentificacion = httpApiAutentificacion;
        Logger = logger;
        UnidadAdministrativaClient = unidadAdministrativaClient;
        UnidadAdministrativaFuncionalClient = unidadAdministrativaFuncionalClient;
        ConfigurarFirmaElectronicaClient = configurarFirmaElectronicaClient;
        FirmaElectronicaClient = firmaElectronicaClient;
        UsuarioClient = usuarioClient;
        Mediator = mediator;
        VisaElectronicaClient = visaElectronicaClient;
        NotificadorClient = notificadorClient;
        NotificadorClient2 = notificadorClient;
        this.visaVirteConfiguracion = visaVirteConfiguracion.Value;
        this.remoteServices = remoteServices.Value;
      }
      public IHttpApiAutentificacion HttpApiAutentificacion { get; }
      public ILogger<CrearMovimientoCommandHandler> Logger { get; }
      public IUnidadAdministrativaClient UnidadAdministrativaClient { get; }
      public IUnidadAdministrativaFuncionalClient UnidadAdministrativaFuncionalClient { get; }
      public IConfigurarFirmaElectronicaClient ConfigurarFirmaElectronicaClient { get; }
      public IFirmaElectronicaClient FirmaElectronicaClient { get; }
      public IUsuarioClient UsuarioClient { get; }
      public IMediator Mediator { get; }
      public IVisaElectronicaClient VisaElectronicaClient { get; }
      public INotificadorClient NotificadorClient2 { get; }
      private readonly VisaVirteConfiguracion visaVirteConfiguracion;
      private readonly RemoteServices remoteServices;

      [Authorize(Contracts.TramitePermissionDefinition.MovimientoCrear)]
      public async Task<ApiResponseWrapper> Handle(CrearMovimientoCommand command, CancellationToken cancellationToken)
      {
        string resultadoPruebas = string.Empty;

        Guid usuarioId = new Guid();
        Guid unidadAdministrativaId = new Guid();
        var tramite = await UnitOfWork.TramiteRepository.GetByIdTramiteCompleto(command.TramiteId);

        if (tramite == null)
        {
          return new ApiResponseWrapper(HttpStatusCode.NotFound, "No existe el IdTramite");
        }
        else
        {
          #region Obtener Token
          string token = string.Empty;
          try
          {
            token = await HttpApiAutentificacion.GetAccessTokenAsync();
            if (string.IsNullOrEmpty(token))
            {
              return new ApiResponseWrapper(HttpStatusCode.BadRequest, "No es posbile autenticarse en el sistema.");
            }
          }
          catch (Exception ex)
          {
            Logger.LogError(ex, "Error al obtener token ", null);
            return new ApiResponseWrapper(HttpStatusCode.NotFound, "No se logro obtener el token");
          }
          #endregion

          #region UA
          ServicioDto Servicio;
          UnidadAdministrativaDto unidadAdministrativa;
          try
          {
            UnidadAdministrativaClient.SetAccessToken(token);
            Servicio = await UnidadAdministrativaClient.ServicioGetAsync(tramite.ServicioId);
            unidadAdministrativa = await UnidadAdministrativaClient.UnidadAdministrativaGetAsync(tramite.UnidadAdministrativaIdCEV);
            if (unidadAdministrativa == null)
              return new ApiResponseWrapper(HttpStatusCode.BadRequest, "Error al obtener unidades administrativas.");
          }
          catch (Exception ex)
          {
            Logger.LogError(ex, "Error al obtener Servicio o Unidad administrativa", null);
            return new ApiResponseWrapper(HttpStatusCode.NotFound, "Error al obtener unidad administrativa");
          }

        #endregion

        //Proceso goto 
        CambioEstado:

          #region ASIGNACION USUARIO Y UI POR EL ESTADO
          Domain.Entities.RolEstado rolEstado = new Domain.Entities.RolEstado();
          rolEstado = UnitOfWork.RolEstadoRepository.GetRolEstadoByEstado(command.Estado.ToString());
          if (rolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Consultor)) && rolEstado.EsZonal.Equals(false))
          {
            //Se dirigue al consultor asignado al inicio
            var primerMovimiento = tramite.Movimientos.FirstOrDefault(x => x.Orden.Equals(2));
            usuarioId = primerMovimiento.UsuarioId;
            unidadAdministrativaId = primerMovimiento.UnidadAdministrativaId;
          }
          else if (rolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Ciudadano)) && rolEstado.EsZonal.Equals(false))
          {
            //Se dirigue al consultor asignado al inicio
            var primerMovimiento = tramite.Movimientos.FirstOrDefault(x => x.Orden.Equals(2));
            usuarioId = primerMovimiento.UsuarioId;
            unidadAdministrativaId = primerMovimiento.UnidadAdministrativaId;
          }
          else if ((rolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Funcionario)) || rolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Perito))) && rolEstado.EsZonal.Equals(false))
          {
            //primero validamos si existe asignacion anterior o sino se deja en modo de unidad administrativa y sin usuario
            var movimiento = tramite.Movimientos.Where(x => x.NombreRol.Equals(rolEstado.NombreRol)).OrderBy(x => x.Orden).FirstOrDefault();
            if (movimiento == null)
              usuarioId = Guid.Empty;
            else
            {
              //usuarioId = movimiento.UsuarioId;
              usuarioId = Guid.Empty;
            }
            unidadAdministrativaId = tramite.UnidadAdministrativaIdCEV;
          }
          else if ((rolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Funcionario)) || rolEstado.NombreRol.Equals(Enum.GetName(Domain.Enums.FiltroRol.Rol.Perito))) && rolEstado.EsZonal.Equals(true))
          {
            //primero validamos si existe asignacion anterior o sino se deja en modo de unidad administrativa y sin usuario
            var movimiento = tramite.Movimientos.Where(x => x.NombreRol.Equals(rolEstado.NombreRol)).OrderBy(x => x.Orden).FirstOrDefault();
            if (movimiento == null)
              usuarioId = Guid.Empty;
            else
              usuarioId = movimiento.UsuarioId;

            unidadAdministrativaId = tramite.UnidadAdministrativaIdZonal;
          }
          else if (rolEstado.NombreRol.Equals(string.Empty))
          {
            //Se dirigue al consultor asignado al inicio
            var primerMovimiento = tramite.Movimientos.FirstOrDefault(x => x.Orden.Equals(2));
            usuarioId = command.CreatorId;
            unidadAdministrativaId = primerMovimiento.UnidadAdministrativaId;
          }
          else
          {
            //Se dirigue al consultor asignado al inicio
            var primerMovimiento = tramite.Movimientos.FirstOrDefault(x => x.Orden.Equals(2));
            usuarioId = primerMovimiento.UsuarioId;
            unidadAdministrativaId = primerMovimiento.UnidadAdministrativaId;
          }

          #endregion

          if (rolEstado.TieneNotificacion)//notificaciones para el ciudadano
          {
            #region Mensajes
            var datos = new CrearMovimientoSharePointResponse();
            HttpClient Client;
            String Uri = string.Empty;
            string PlacesJson = string.Empty;
            HttpResponseMessage Response;
            Client = new HttpClient();
            Uri = remoteServices.mensajes.BaseUrl + "SharePointMensajes/api/mensaje?modulo=MensajesVisa&pagina=" + rolEstado.NombreEstado + "";
            Response = await Client.GetAsync(Uri);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
              PlacesJson = Response.Content.ReadAsStringAsync().Result;
              datos = JsonConvert.DeserializeObject<CrearMovimientoSharePointResponse>(PlacesJson);
              if (datos.Mensaje.Contains("Error al obtener la lista de mensajes"))
              {
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, "No se logro encontrar mensaje acorde al estado:" + rolEstado.NombreEstado);
              }
            }
            else
            {
              return new ApiResponseWrapper(HttpStatusCode.BadRequest, "No se logro encontrar mensaje acorde al estado:" + rolEstado.NombreEstado);
            }
            #endregion

            #region Notificar
            //en definición proceso de notificación
            string cuerpo = datos.Mensaje;

            if (rolEstado.AgregarObservaciones)
            {
              if (!string.IsNullOrEmpty(command.ObservacionDatosPersonales))
                cuerpo += $"Observaciones de datos personales:{command.ObservacionDatosPersonales}.</br>";

              if (!string.IsNullOrEmpty(command.ObservacionDomicilios))
                cuerpo += $"Observaciones de domicilio: {command.ObservacionDomicilios}.</br>";

              if (!string.IsNullOrEmpty(command.ObservacionMovimientoMigratorio))
                cuerpo += $"Observaciones de movimiento migratorio: {command.ObservacionMovimientoMigratorio}.</br>";

              if (!string.IsNullOrEmpty(command.ObservacionMultas))
                cuerpo += $"Observaciones de multas: {command.ObservacionMultas}.</br>";

              if (!string.IsNullOrEmpty(command.ObservacionSoportesGestion))
                cuerpo += $"Observaciones generales: {command.ObservacionSoportesGestion}.</br>";

              // Si es subsanación, adjunto observaciones de los requisitos
              if (Convert.ToInt32(rolEstado.CodigoEstado) == (int)Domain.Enums.RolEstado.Codigo.SubsanacionInformacion)
                foreach (var item in tramite.Documentos.Where(x => !string.IsNullOrEmpty(x.Observacion)))
                {
                  cuerpo += $"</br>Observaciones de {Shared.Util.Util.ObtenerDescripcion(item.TipoDocumento)}: {item.Observacion}.</br>";
                }

            }

            var salida = new NotificacionMensajeDto
            {
              Codigo = TramitesConst.Plantilla,
              Asunto = $"Notificación - Solicitud de visa: {tramite.Numero} [{rolEstado.NombreEstado.ToUpper()}]",
              Destinatarios = tramite.Solicitante.Correo,
              Model = new Dictionary<string, object>()
            };
            salida.Model.Add("PersonaNombreApellido", tramite.Solicitante.Nombres);
            salida.Model.Add("Fecha", DateTime.Now.ToShortDateString());
            salida.Model.Add("InformacionTramite", tramite.Numero);
            salida.Model.Add("Cuerpo", cuerpo);

            if (NotificadorClient2 != null)
            {
              NotificadorClient2.SetAccessToken(token);
              var re = await NotificadorClient2.NotificadorAsync(salida);
            }
            #endregion
          }

          #region Estado Origen 
          if (command.EstadoOrigen.Equals((int)Domain.Enums.RolEstado.Codigo.GenerarVisa))//para cedulación
          {
            //FACTURAR

            #region Crear tramite de cedulación
            Logger.LogInformation("Empieza Crear tramite de cedulación, tramiteId: {tramiteId}", command.TramiteId);
            var request = new CrearTramiteCedulacionRequest();
            request.TramiteId = command.TramiteId;
            request.UnidadAdministrativaId = unidadAdministrativaId;
            request.UsuarioId = usuarioId;

            var datos2 = new CrearMovimientoSharePointResponse();
            HttpClient Client2 = new HttpClient();
            string PlacesJson2 = string.Empty;

            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var callApiResponse = await Client2.PostAsync(remoteServices.tramite.BaseUrl + "api/Tramite/CrearTramiteCedulacion", data);
            if (callApiResponse.IsSuccessStatusCode)
            {
              var r = await callApiResponse.Content.ReadAsStringAsync();
              //var resultadoComprobante = new Domain.Entities.Dtos.ResultadoComprobante();
              //resultadoComprobante = JsonConvert.DeserializeObject<Domain.Entities.Dtos.ResultadoComprobante>(r);

            }

            #endregion

            #region GenerarVisa
            try
            {
              Logger.LogInformation("Empieza Generar Visa, tramiteId: {tramiteId}", command.TramiteId);

              #region PDF
              HttpClient ClientPdf = new HttpClient();
              var pdfResponse = new GenerarVisaPorTramiteIdResponse();
              var generarSolicitudVisaPorTramiteIdRequest = new GenerarVisaPorTramiteIdRequest
              {
                TramiteId = command.TramiteId
              };
              var jsonPdf = JsonConvert.SerializeObject(generarSolicitudVisaPorTramiteIdRequest);
              var dataPdf = new StringContent(jsonPdf, Encoding.UTF8, "application/json");
              var callApiResponsePdf = await ClientPdf.PostAsync(remoteServices.reporte.BaseUrl + "api/Reporte/GenerarVisaPorTramiteId", dataPdf);
              if (callApiResponsePdf.IsSuccessStatusCode)
              {
                var result = await callApiResponsePdf.Content.ReadAsStringAsync();
                pdfResponse = JsonConvert.DeserializeObject<GenerarVisaPorTramiteIdResponse>(result);
                if (pdfResponse.Estado != "OK")
                {
                  return new ApiResponseWrapper(HttpStatusCode.BadRequest, pdfResponse.Mensaje);
                }
              }
              else
              {
                return new ApiResponseWrapper(HttpStatusCode.NotFound, "No se logro consultar el pdf en base 64.");
              }
              #endregion

              #region Firmar
              Logger.LogInformation("Llamar al servicio de firma electronica, tramiteId: {tramiteId}", command.TramiteId);

              Logger.LogInformation("Obtener informacion del signatario, tramiteId: {tramiteId}", command.TramiteId);
              var obtenerSignatarioResponse = await ObtenerInformacionSignatarioAsync(command.CreatorId);

              if (obtenerSignatarioResponse.HttpStatusCode != HttpStatusCode.OK)
              {
                Logger.LogError("Error al obtener signatarios, tramiteId: {tramiteId}, usuarioId: {usuarioId}, {respuesta}", command.TramiteId, command.CreatorId, obtenerSignatarioResponse.ToStringErrors());
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, "Error al obtener signatarios");
              }
              var signatario = obtenerSignatarioResponse.Result;

              byte[] byteVisaFirmar = System.Convert.FromBase64String(pdfResponse.Base64);
              var visaFirmada = await FirmarVisaAsync(byteVisaFirmar, signatario, tramite.ServicioId, tramite.Id);
              #endregion

              byte[] byteVisa = visaFirmada.DocumentoFirmado;

              #region Grabar

              #region Obtener Numero Visa
              var visaElectronica = VisaElectronicaClient.ConsultarVisaElectronicaPorTramiteIdAsync(new ConsultarVisaElectronicaPorTramiteIdRequest { TramiteId = tramite.Id });
              #endregion

              try
              {
                string Uri = remoteServices.sharePoint.BaseUrl + "SharePointArchivos/api/sharepoint/grabarBiblioteca";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(remoteServices.sharePoint.BaseUrl);
                MultipartFormDataContent formData = new MultipartFormDataContent();
                formData.Add(new StringContent(tramite.Beneficiario.CodigoMDG), "codigoMDG");
                formData.Add(new StringContent("Visa Electronica"), "biblioteca");
                formData.Add(new ByteArrayContent(byteVisa), "archivo", (visaElectronica.Result.Result.NumeroVisa + ".pdf"));
                var responsesharePoint = await client.PostAsync(Uri, formData);
                if (responsesharePoint.IsSuccessStatusCode)
                {
                  var grabarBibliotecaResponse = new GrabarBibliotecaResponse();
                  var resultSharePoint = await responsesharePoint.Content.ReadAsStringAsync();
                  grabarBibliotecaResponse = JsonConvert.DeserializeObject<GrabarBibliotecaResponse>(resultSharePoint);
                  if (grabarBibliotecaResponse.Estado != "OK")
                  {
                    return new ApiResponseWrapper(HttpStatusCode.NotFound, grabarBibliotecaResponse.Mensaje);
                  }
                }
                else
                {
                  return new ApiResponseWrapper(HttpStatusCode.NotFound, "No se logro grabar en el sharepoint la visa firmada");
                }
              }
              catch (Exception ex)
              {
                return new ApiResponseWrapper(HttpStatusCode.NotFound, ex.Message.ToString());
              }
              #endregion

              #region Correo Electronico
              try
              {
                var adjuntos = new List<FileParameter>();
                var archivoAdjunto = new FileParameter(new MemoryStream(byteVisa), Domain.Const.TramitesConst.GeneracionVisa.NombreArchivo, TramitesConst.GeneracionVisa.PdfMimeType);
                adjuntos.Add(archivoAdjunto);

                var nombreCompleto = string.IsNullOrEmpty(tramite.Beneficiario.SegundoApellido) ? $"{tramite.Beneficiario.Nombres} {tramite.Beneficiario.PrimerApellido}" : $"{tramite.Beneficiario.Nombres} {tramite.Beneficiario.PrimerApellido} {tramite.Beneficiario.SegundoApellido}";
                var asunto = TramitesConst.GeneracionVisa.Asunto;
                var mensaje = TramitesConst.GeneracionVisa.Mensaje;

                var model = new Dictionary<string, string>();
                model.Add("PersonaNombreApellido", nombreCompleto);
                model.Add("Cuerpo", mensaje);
                model.Add("Fecha", DateTime.Now.ToShortDateString());
                model.Add("InformacionTramite", tramite.Numero);

                var result = false;
                try
                {
                  NotificadorClient.SetAccessToken(token);
                  result = await NotificadorClient.EnviarConAdjuntosAsync(
                  adjuntos,
                  TramitesConst.Plantilla,
                  asunto,
                  tramite.Solicitante.Correo,
                  model);
                }
                catch (Exception ex)
                {
                  Logger.LogError(ex, "Error enviar por correo, tramiteId: {tramiteId}", command.TramiteId);
                  return new ApiResponseWrapper(HttpStatusCode.NotFound, "Error enviar por correo la visa");
                }
              }
              catch (Exception ex)
              {
                return new ApiResponseWrapper(HttpStatusCode.NotFound, ex.Message.ToString());
              }
              #endregion
            }
            catch (Exception ex)
            {
              Logger.LogTrace(ex, "Error Generar Visa, tramiteId: {tramiteId}", command.TramiteId);
            }
            #endregion
          }
          else if (command.EstadoOrigen.Equals((int)Domain.Enums.RolEstado.Codigo.Facturacion))
          {
            #region Obtener Pago
            var pago = new ObtenerPagosResponse.Pago();
            var pagoDetalle = new ObtenerPagosResponse.PagoDetalle();

            HttpClient Client = new HttpClient();

            var Uri = remoteServices.pago.BaseUrl + "api/Pago/ObtenerPago?idTramite=" + tramite.Id + "&valoresMayoraCero=false&facturarEn=" + command.EstadoOrigen;
            var Response = await Client.PostAsync(Uri, null);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
              var PlacesJson = Response.Content.ReadAsStringAsync().Result;
              var pagoObtenerPagoResponse = JsonConvert.DeserializeObject<ObtenerPagosResponse>(PlacesJson);
              pago = pagoObtenerPagoResponse.result;
              pagoDetalle = pagoObtenerPagoResponse.result.listaPagoDetalle.FirstOrDefault();
            }
            else
            {
              return new ApiResponseWrapper(HttpStatusCode.NotFound, "No existe datos del pago");
            }
            #endregion

            #region Crear Factura
            var grabarFacturaRequest = new Movimiento.Request.GrabarFacturaRequest();
            grabarFacturaRequest = new Movimiento.Request.GrabarFacturaRequest
            {
              factura = new Request.GrabarFacturaRequest.Fac
              {
                CodigoUsuario = "usuariofe",
                CodigoOficina = "C-ZNL9-A",
                Origen = Servicio.Nombre,
                Referencia = Servicio.Nombre,
                DescripcionGeneral = "ninguna",
                TipoIdentificacionComprador = tramite.Solicitante.TipoIdentificacion,
                RazonSocialComprador = tramite.Solicitante.Nombres,
                IdentificacionComprador = tramite.Solicitante.Identificacion,
                DireccionComprador = tramite.Solicitante.Direccion,
                TelefonoComprador = tramite.Solicitante.Telefono,
                CorreoComprador = "leiny.ruiz@grupobusiness.it",//tramite.Solicitante.Correo,
                TotalSinImpuestos = (decimal)pagoDetalle.valorTotal,
                TotalDescuento = (decimal)pagoDetalle.valorDescuento,
                ImporteTotal = (decimal)pagoDetalle.valorTotal,
                Porcentaje = (decimal)pagoDetalle.porcentajeDescuento,
                FechaEmisionLocal = DateTime.Now.ToString("yyyyMMdd"),
                NumeroTramite = tramite.Numero,

              }
            };
            grabarFacturaRequest.factura.FacturaDetalle.Add(new Movimiento.Request.GrabarFacturaRequest.FacDetalles
            {
              Cantidad = 1,
              Descripcion = pagoDetalle.partidaArancelaria,
              CodigoPrincipal = tramite.Numero,
              CodigoAuxiliar = pagoDetalle.numeroPartida,
              Descuento = (decimal)pagoDetalle.valorDescuento,
              CampoAdicional1Nombre = "",
              CampoAdicional1Valor = "",
              CampoAdicional2Nombre = "",
              CampoAdicional2Valor = "",
              CampoAdicional3Nombre = "",
              CampoAdicional3Valor = "",
              IdArancel = pagoDetalle.arancelId,
              OrdenDetalle = 1,
              PrecioTotalSinImpuesto = (decimal)pagoDetalle.valorTotal,
              PrecioUnitario = (decimal)pagoDetalle.valorArancel

            });

            grabarFacturaRequest.factura.FacturaPagos.Add(new Movimiento.Request.GrabarFacturaRequest.FacPagos
            {
              IdPagoDetalle = pagoDetalle.id,
              FormaPago = pago.formaPago,
              Orden = 1,
              Total = (decimal)pagoDetalle.valorTotal

            });

            var grabarFacturaResponse = new GrabarFacturaResultadoResponse();
            HttpClient ClientPago = new HttpClient();
            string PlacesJsonPago = string.Empty;

            var json = JsonConvert.SerializeObject(grabarFacturaRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var callApiResponse = await ClientPago.PostAsync(remoteServices.facturacionElectronica.BaseUrl + "api/FacturaElectronica/GrabarFactura", data);
            if (callApiResponse.IsSuccessStatusCode)
            {
              var result = await callApiResponse.Content.ReadAsStringAsync();
              grabarFacturaResponse = JsonConvert.DeserializeObject<GrabarFacturaResultadoResponse>(result);
              if (grabarFacturaResponse.Estado != "OK")
              {
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, grabarFacturaResponse.Mensaje);
              }
            }
            else
            {
              var r2esult = await callApiResponse.Content.ReadAsStringAsync();
              grabarFacturaResponse = JsonConvert.DeserializeObject<GrabarFacturaResultadoResponse>(r2esult);
              if (grabarFacturaResponse.Estado != "OK")
              {
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, grabarFacturaResponse.Mensaje);
              }
            }
            #endregion

            #region Visa Electrónica
            GrabarVisaElectronicaRequest grabarVisaElectronicaRequest = new();

            // Obtener información Tipo Visa
            TipoVisa tipoVisa = await UnitOfWork.TipoVisaRepository.GetByIdAsync(tramite.TipoVisaId);
            if (tipoVisa == null)
              throw new Exception("Error al obtener los datos de tipo de Visa.");

            // Obtener información de calidad migratoria
            CalidadMigratoria calidadMigratoria = await UnitOfWork.CalidadMigratoriaRepository.GetByIdAsync(tramite.CalidadMigratoriaId);
            if (calidadMigratoria == null)
              throw new Exception("Error al obtener los datos de calidad migratoria.");

            // Obtener información de actividad a desarrollar
            ActividadDesarrollar actividadDesarrollar = await UnitOfWork.ActividadDesarrollarRepository.GetByIdAsync(tramite.ActividadId);
            if (calidadMigratoria == null)
              throw new Exception("Error al obtener los datos de calidad migratoria.");

            // Preparando el objeto requesto de Visa electrónica
            grabarVisaElectronicaRequest.TramiteId = tramite.Id;
            grabarVisaElectronicaRequest.DiasVigencia = tipoVisa.DiasValidez;
            grabarVisaElectronicaRequest.Categoria = tipoVisa.Categoria;
            grabarVisaElectronicaRequest.NumeroAdmisiones = tipoVisa.NumeroAdmisiones;
            grabarVisaElectronicaRequest.FechaEmision = DateTime.Now;
            grabarVisaElectronicaRequest.FechaExpiracion = DateTime.Now.AddDays(tipoVisa.DiasValidez);
            grabarVisaElectronicaRequest.CalidadMigratoria = calidadMigratoria.Descripcion;

            grabarVisaElectronicaRequest.NumeroPasaporte = tramite.Beneficiario.Pasaporte.Numero;
            grabarVisaElectronicaRequest.NombresBeneficiario = tramite.Beneficiario.Nombres;
            grabarVisaElectronicaRequest.ApellidosBeneficiario = $"{tramite.Beneficiario.PrimerApellido} {tramite.Beneficiario.SegundoApellido}";
            grabarVisaElectronicaRequest.FechaNacimiento = tramite.Beneficiario.FechaNacimiento.ToString();
            grabarVisaElectronicaRequest.Genero = tramite.Beneficiario.Genero;
            grabarVisaElectronicaRequest.Nacionalidad = tramite.Beneficiario.Nacionalidad;
            grabarVisaElectronicaRequest.FotoBeneficiario = tramite.Beneficiario.Foto;
            grabarVisaElectronicaRequest.DireccionDomiciliaria = tramite.Beneficiario.Domicilio.Direccion;

            grabarVisaElectronicaRequest.ActividadDesarrollar = actividadDesarrollar.Descripcion;
            //grabarVisaElectronicaRequest.IsDeleted = false;

            grabarVisaElectronicaRequest.UnidadAdministrativaId = tramite.UnidadAdministrativaIdCEV;
            grabarVisaElectronicaRequest.UnidadAdministrativaCiudad = unidadAdministrativa.Ciudad;
            grabarVisaElectronicaRequest.UnidadAdministrativaNombre = unidadAdministrativa.Nombre;

            grabarVisaElectronicaRequest.NombreSignatario = string.Empty;
            grabarVisaElectronicaRequest.RequisitosCumplidos = string.Empty; //TODO: ANALIZAR

            grabarVisaElectronicaRequest.UsuarioId = command.CreatorId;
            //grabarVisaElectronicaRequest.LastModified = DateTime.Now;
            //grabarVisaElectronicaRequest.LastModifierId = command.CreatorId;
            //grabarVisaElectronicaRequest.Created = DateTime.Now;
            //grabarVisaElectronicaRequest.CreatorId = command.CreatorId;

            grabarVisaElectronicaRequest.SecuenciaVisa = 0;
            grabarVisaElectronicaRequest.Observaciones = string.Empty;
            grabarVisaElectronicaRequest.SignatarioId = Guid.Empty;
            grabarVisaElectronicaRequest.NumeroVisa = string.Empty;
            grabarVisaElectronicaRequest.CodigoVerificacion = string.Empty;
            grabarVisaElectronicaRequest.InformacionQR = string.Empty;

            // Invocando al servicio de visa electrónica
            var visaResponse = new GrabarVisaElectronicaResponse();
            HttpClient ClientVisa = new HttpClient();
            var jsonVisa = JsonConvert.SerializeObject(grabarVisaElectronicaRequest);
            var dataVisa = new StringContent(jsonVisa, Encoding.UTF8, "application/json");
            var callApiResponseVisa = await ClientVisa.PostAsync(remoteServices.visaElectronica.BaseUrl + "api/VisaElectronica/CrearVisaElectronica", dataVisa);
            if (callApiResponseVisa.IsSuccessStatusCode)
            {
              var result = await callApiResponseVisa.Content.ReadAsStringAsync();
              visaResponse = JsonConvert.DeserializeObject<GrabarVisaElectronicaResponse>(result);
              if (visaResponse.HttpStatusCode != (int)HttpStatusCode.OK || visaResponse.Result.Estado != "OK")
              {
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, visaResponse.Result.Mensaje);
              }
            }
            else
            {
              var r2esult = callApiResponseVisa.Content.ReadAsStringAsync();
              return new ApiResponseWrapper(HttpStatusCode.NotFound, "No se logro grabar visa electrónica.");
            }

            #endregion

            #region Grabar en sharepoint

            try
            {
              #region PDF
              HttpClient ClientPdf = new HttpClient();
              var pdfResponse = new GenerarSolicitudVisaPorTramiteIdResponse();
              var generarSolicitudVisaPorTramiteIdRequest = new GenerarSolicitudVisaPorTramiteIdRequest
              {
                Id = command.TramiteId
              };
              var jsonPdf = JsonConvert.SerializeObject(generarSolicitudVisaPorTramiteIdRequest);
              var dataPdf = new StringContent(jsonPdf, Encoding.UTF8, "application/json");
              var callApiResponsePdf = await ClientPdf.PostAsync(remoteServices.reporte.BaseUrl + "api/Reporte/GenerarSolicitudVisaPorTramiteId", dataPdf);
              if (callApiResponsePdf.IsSuccessStatusCode)
              {
                var result = await callApiResponsePdf.Content.ReadAsStringAsync();
                pdfResponse = JsonConvert.DeserializeObject<GenerarSolicitudVisaPorTramiteIdResponse>(result);
                if (pdfResponse.Estado != "OK")
                {
                  return new ApiResponseWrapper(HttpStatusCode.BadRequest, pdfResponse.Mensaje);
                }
              }
              else
              {
                return new ApiResponseWrapper(HttpStatusCode.NotFound, "No se logro consultar el pdf en base 64.");
              }
              #endregion

              #region Grabar
              try
              {
                byte[] byteSolicitud = System.Convert.FromBase64String(pdfResponse.Base64);

                Uri = remoteServices.sharePoint.BaseUrl + "SharePointArchivos/api/sharepoint/grabarBiblioteca";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(remoteServices.sharePoint.BaseUrl);
                MultipartFormDataContent formData = new MultipartFormDataContent();
                formData.Add(new StringContent(tramite.Beneficiario.CodigoMDG), "codigoMDG");
                formData.Add(new StringContent("Solicitud Visa"), "biblioteca");
                formData.Add(new ByteArrayContent(byteSolicitud), "archivo", (tramite.Numero + ".pdf"));
                var response = await client.PostAsync(Uri, formData);
              }
              catch (Exception ex)
              {
                return new ApiResponseWrapper(HttpStatusCode.NotFound, ex.Message.ToString());
              }
              #endregion
            }
            catch (Exception ex)
            {
              Logger.LogError(ex.Message.ToString(), null);
            }

            #endregion

            #region Esigex - Solicitud  de visa

            //#region ObtenerCatalogos
            //var consultarCatalogoCabeceraResponses = new ConsultarCatalogoCabeceraResponse();
            //var consultarCatalogoDetalleResponses = new ConsultarCatalogoDetalleResponse();
            ////cabecera
            //HttpClient ClientCatalogocabecera = new HttpClient();
            //var apiCatalogoCabecera = await ClientCatalogocabecera.GetAsync(remoteServices.catalogo.BaseUrl + "api/Catalogo/ConsultarCatalogoCabecera");
            //if (apiCatalogoCabecera.IsSuccessStatusCode)
            //{
            //  var resultCatalogoCabecera = await apiCatalogoCabecera.Content.ReadAsStringAsync();
            //  consultarCatalogoCabeceraResponses = JsonConvert.DeserializeObject<ConsultarCatalogoCabeceraResponse>(resultCatalogoCabecera);
            //  if (consultarCatalogoCabeceraResponses.httpStatusCode != 200)
            //  {
            //    return new ApiResponseWrapper(HttpStatusCode.BadRequest, "Error al ConsultarCatalogoCabecera ");
            //  }
            //}
            ////detalle
            //HttpClient ClientCatalogoDetalle = new HttpClient();
            //var apiCatalogoDetalle = await ClientCatalogoDetalle.GetAsync(remoteServices.catalogo.BaseUrl + "api/Catalogo/ConsultarCatalogoDetalle");
            //if (apiCatalogoDetalle.IsSuccessStatusCode)
            //{
            //  var resultCatalogoDetalle = await apiCatalogoDetalle.Content.ReadAsStringAsync();
            //  consultarCatalogoDetalleResponses = JsonConvert.DeserializeObject<ConsultarCatalogoDetalleResponse>(resultCatalogoDetalle);
            //  if (consultarCatalogoDetalleResponses.httpStatusCode != 200)
            //  {
            //    return new ApiResponseWrapper(HttpStatusCode.BadRequest, "Error al ConsultarCatalogoDetalle ");
            //  }
            //}

            //#endregion

            //#region Grabar Visa

            //var ad = new Domain.Entities.ActividadDesarrollar();
            //ad = await UnitOfWork.ActividadDesarrollarRepository.GetByIdAsync(tramite.ActividadId);

            //var tv = new Domain.Entities.TipoVisa();
            //tv = await UnitOfWork.TipoVisaRepository.GetByIdAsync(tramite.TipoVisaId);

            //var tc = new Domain.Entities.TipoConvenio();
            //tc = await UnitOfWork.TipoConvenioRepository.GetByIdAsync(tramite.TipoConvenioId);

            //var guardarSolicitudVisaRequest = new GuardarSolicitudVisaRequest
            //{
            //  FechaFactura = Convert.ToDateTime(grabarFacturaResponse.FechaEmision),
            //  CorreoElectronico = tramite.Solicitante.Correo,
            //  DireccionResidencia = tramite.Beneficiario.Domicilio.Direccion,
            //  Exoneracion = Convert.ToInt32(ObtenerValorCatalogoDetalle(consultarCatalogoCabeceraResponses.Result.Where(x => x.Codigo.Equals("UnidadAdministrativa")).FirstOrDefault().Id, consultarCatalogoDetalleResponses.result, "TIPO_EXONERACION", pagoDetalle.tipoExoneracionId.ToString())),
            //  FechaNacimiento = tramite.Beneficiario.FechaNacimiento,
            //  FechaPago = pagoDetalle.created,//PAGO DETALLE 1 POSICION
            //  FechaRegistroSolicitud = Convert.ToDateTime(tramite.Fecha),//FECHA DEL TRAMITE
            //  Foto = Convert.FromBase64String(tramite.Beneficiario.Foto),
            //  IdNacionalidad = Convert.ToInt32(ObtenerValorCatalogoDetalle(consultarCatalogoCabeceraResponses.Result.Where(x => x.Codigo.Equals("Nacionalidad")).FirstOrDefault().Id, consultarCatalogoDetalleResponses.result, "CODIGO", tramite.Beneficiario.NacionalidadId)),//de tramite beneficiario nacio_id buscar en catalogo
            //  IdCentroAdministrativo = Convert.ToInt32(ObtenerValorCatalogoDetalle(consultarCatalogoCabeceraResponses.Result.Where(x => x.Codigo.Equals("UnidadAdministrativa")).FirstOrDefault().Id, consultarCatalogoDetalleResponses.result, "CODIGO", tramite.UnidadAdministrativaIdCEV.ToString())),//unidad administrativa de  tramite buscar en catalogo cA
            //  IdActividadVisa = Convert.ToInt32(ad.ActividadDesarrollarCodigo),//codigo del tramite tipovisa codigo tomar de la tabla ctividad a desarrollar
            //  IdEntidadAuspiciante = 0,//no se tiene datos
            //  IdCalidadMigratoria = calidadMigratoria.CalidadMigratoriaId,//codigo del tramite tipovisa codigo tomar de la tabla calidad migratoria
            //  IdCiudadNacimiento = 1,//pendiente DE REVISAR POR CAMBIOS------en la tabla de beneficiario obtener el nombre de la ciduad y mapear con el catalogo por descripcion
            //  FechaCaducidadDocumento = tramite.Beneficiario.Pasaporte.FechaExpiracion,
            //  FechaEmisionDocumento = tramite.Beneficiario.Pasaporte.FechaEmision,
            //  IdActoConsularSolicitudVisa = Convert.ToInt32(ObtenerValorCatalogoDetalle(consultarCatalogoCabeceraResponses.Result.Where(x => x.Codigo.Equals("SERVICIO")).FirstOrDefault().Id, consultarCatalogoDetalleResponses.result, "CODIGO", tramite.ServicioId.ToString())),//el idservicio del tramite
            //  IdActoConsularVisa = Convert.ToInt32(ObtenerValorCatalogoDetalle(consultarCatalogoCabeceraResponses.Result.Where(x => x.Codigo.Equals("ACTO_CONSULTAR")).FirstOrDefault().Id, consultarCatalogoDetalleResponses.result, "CODIGO", tv.ServicioVisasId.ToString())),//acto consultar visa desde tipo de visa de tramites
            //  IdCiudadResidencia = 1,//catalogo 
            //  IdFormaPago = Convert.ToInt32(ObtenerValorCatalogoDetalle(consultarCatalogoCabeceraResponses.Result.Where(x => x.Codigo.Equals("UnidadAdministrativa")).FirstOrDefault().Id, consultarCatalogoDetalleResponses.result, "CODIGO", tramite.UnidadAdministrativaIdCEV.ToString())),//catalogo codigo de pago 
            //  IdFuncionarioCajero = Convert.ToInt32(ObtenerValorCatalogoDetalle(consultarCatalogoCabeceraResponses.Result.Where(x => x.Codigo.Equals("USUARIOS")).FirstOrDefault().Id, consultarCatalogoDetalleResponses.result, "CODIGO", tramite.Movimientos.FirstOrDefault(x => x.Vigente.Equals(true)).UsuarioId.ToString())),
            //  IdFuncionarioCreacionEsigex = Convert.ToInt32(ObtenerValorCatalogoDetalle(consultarCatalogoCabeceraResponses.Result.Where(x => x.Codigo.Equals("USUARIOS")).FirstOrDefault().Id, consultarCatalogoDetalleResponses.result, "CODIGO", tramite.Movimientos.FirstOrDefault(x => x.Vigente.Equals(true)).UsuarioId.ToString())),
            //  IdGrupoVisa = Convert.ToInt32(tv.TipoConvenioCodigo),
            //  IdFuncionarioNuevoSistema = usuarioId.ToString(),
            //  IdTipoDocumento = Convert.ToInt32(ObtenerValorCatalogoDetalle(consultarCatalogoCabeceraResponses.Result.Where(x => x.Codigo.Equals("TIPOS_IDENTIFICACION")).FirstOrDefault().Id, consultarCatalogoDetalleResponses.result, "CODIGO", tramite.Beneficiario.Pasaporte.TipoDocumentoIdentidadId)),//casteo con catalogo
            //  LugarEmisionDocumento = 26774,//con catalogo
            //  IdTramiteNuevoSistema = tramite.Id.ToString(),
            //  NombresExtranjero = tramite.Beneficiario.Nombres,
            //  NumeroComprobante = pagoDetalle.numeroTransaccion,//tabla pago detalle campo numero de transaccion
            //  NumeroDocumento = tramite.Beneficiario.Pasaporte.Numero,//numero de pasaporte
            //  NumeroFactura = grabarFacturaResponse.Numero,//numero de la factura sin guiones
            //  NumeroVisaNuevoSistema = string.Empty,
            //  ObservacionSolicitud = string.Empty,//ultima observacion del tramite
            //  PrimerApellidoExtranjero = tramite.Beneficiario.PrimerApellido,
            //  SegundoApellidoExtranjero = tramite.Beneficiario.SegundoApellido,
            //  Telefono = tramite.Beneficiario.Domicilio.TelefonoCelular
            //};

            ////todos los documentos
            //int i = 1;
            //foreach (var item in tramite.Documentos)
            //{
            //  guardarSolicitudVisaRequest.RequisitosVisa.Add(
            //    new GuardarSolicitudVisaRequest.RequisitosVisaRequest
            //    {
            //      Seleccionado = true,
            //      Observacion = "Ninguno",
            //      IdActoConsularVisa = Convert.ToInt32(ObtenerValorCatalogoDetalle(consultarCatalogoCabeceraResponses.Result.Where(x => x.Codigo.Equals("ACTO_CONSULTAR")).FirstOrDefault().Id, consultarCatalogoDetalleResponses.result, "CODIGO", tv.ServicioVisasId.ToString())),
            //      IdRequisito = i
            //    });
            //  i++;
            //}
            ////consumir
            //HttpClient ClientSolicitudVisa = new HttpClient();
            //var guardarSolicitudVisaResponse = new GuardarSolicitudVisaResponse();

            //var jsonSolicitudVisa = JsonConvert.SerializeObject(guardarSolicitudVisaRequest);
            //var pdfSolicitudVisa = new StringContent(jsonSolicitudVisa, Encoding.UTF8, "application/json");
            //var apiSolicitudVisa = await ClientSolicitudVisa.PostAsync(remoteServices.externos.BaseUrl + "api/asuntosMigratorios/GuardarSolicitudVisa", pdfSolicitudVisa);
            //if (apiSolicitudVisa.IsSuccessStatusCode)
            //{
            //  var result = await apiSolicitudVisa.Content.ReadAsStringAsync();
            //  guardarSolicitudVisaResponse = JsonConvert.DeserializeObject<GuardarSolicitudVisaResponse>(result);
            //  if (guardarSolicitudVisaResponse.Codigo < 0)
            //  {
            //    return new ApiResponseWrapper(HttpStatusCode.BadRequest, guardarSolicitudVisaResponse.CodigoDescripcion);
            //  }
            //}
            //else
            //{
            //  return new ApiResponseWrapper(HttpStatusCode.NotFound, "No se grabar solicitud de visa.");
            //}

            //#endregion

            //#region Actualizar datos
            //// no todavia
            //#endregion

            #endregion
          }
          else if (command.EstadoOrigen.Equals((int)Domain.Enums.RolEstado.Codigo.RealizarPago))
          {
            #region Grabar en sharepoint

            try
            {
              #region PDF
              HttpClient ClientPdf = new HttpClient();
              var pdfResponse = new GenerarPagoPorTramiteIdResponse();
              var generarPagoPorTramiteIdRequest = new GenerarPagoPorTramiteIdRequest
              {
                TramiteId = command.TramiteId
              };
              var jsonPdf = JsonConvert.SerializeObject(generarPagoPorTramiteIdRequest);
              var dataPdf = new StringContent(jsonPdf, Encoding.UTF8, "application/json");
              var callApiResponsePdf = await ClientPdf.PostAsync(remoteServices.reporte.BaseUrl + "api/Reporte/GenerarPagoPorTramiteId", dataPdf);
              if (callApiResponsePdf.IsSuccessStatusCode)
              {
                var result = await callApiResponsePdf.Content.ReadAsStringAsync();
                pdfResponse = JsonConvert.DeserializeObject<GenerarPagoPorTramiteIdResponse>(result);
                if (pdfResponse.Estado != "OK")
                {
                  return new ApiResponseWrapper(HttpStatusCode.BadRequest, pdfResponse.Mensaje);
                }
              }
              else
              {
                return new ApiResponseWrapper(HttpStatusCode.NotFound, "No se logro consultar el pdf en base 64.");
              }
              #endregion

              #region Grabar
              try
              {
                foreach (var item in pdfResponse.Base64)
                {
                  byte[] byteSolicitud = System.Convert.FromBase64String(item);

                  var Uri = remoteServices.sharePoint.BaseUrl + "SharePointArchivos/api/sharepoint/grabarBiblioteca";
                  HttpClient client = new HttpClient();
                  client.BaseAddress = new Uri(remoteServices.sharePoint.BaseUrl);
                  MultipartFormDataContent formData = new MultipartFormDataContent();
                  formData.Add(new StringContent(tramite.Beneficiario.CodigoMDG), "codigoMDG");
                  formData.Add(new StringContent("Solicitud Visa"), "biblioteca");
                  formData.Add(new ByteArrayContent(byteSolicitud), "archivo", (tramite.Numero + ".pdf"));
                  var response = await client.PostAsync(Uri, formData);
                }
              }
              catch (Exception ex)
              {
                return new ApiResponseWrapper(HttpStatusCode.NotFound, ex.Message.ToString());
              }
              #endregion

              #region Enviar Correo
              try
              {
                #region Obtener cuerpo del Mensaje
                var datos1 = new CrearMovimientoSharePointResponse();
                HttpClient Client;
                String Uri = string.Empty;
                string PlacesJson = string.Empty;
                HttpResponseMessage Response;
                Client = new HttpClient();
                Uri = remoteServices.mensajes.BaseUrl + "SharePointMensajes/api/mensaje?modulo=MensajesVisa&pagina=" + rolEstado.NombreEstado + "";
                Response = await Client.GetAsync(Uri);
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                  PlacesJson = Response.Content.ReadAsStringAsync().Result;
                  datos1 = JsonConvert.DeserializeObject<CrearMovimientoSharePointResponse>(PlacesJson);
                  if (datos1.Mensaje.Contains("Error al obtener la lista de mensajes"))
                  {
                    return new ApiResponseWrapper(HttpStatusCode.BadRequest, "No se logro encontrar mensaje acorde al estado:" + rolEstado.NombreEstado);
                  }
                }
                else
                {
                  return new ApiResponseWrapper(HttpStatusCode.BadRequest, "No se logro encontrar mensaje acorde al estado:" + rolEstado.NombreEstado);
                }
                #endregion

                var adjuntos = new List<FileParameter>();
                byte[] byteCeducacion = System.Convert.FromBase64String(pdfResponse.Base64[1]);
                var archivoRecaudacionCedulacion = new FileParameter(new MemoryStream(byteCeducacion), Domain.Const.TramitesConst.ComprobanteRecaudacion.NombreRecaudacionCedulacion, OrdenCedulacionConsts.Notificaciones.PdfMimeType);
                adjuntos.Add(archivoRecaudacionCedulacion);

                byte[] byteVisa = System.Convert.FromBase64String(pdfResponse.Base64[0]);
                var archivoRecaudacionVisa = new FileParameter(new MemoryStream(byteVisa), TramitesConst.ComprobanteRecaudacion.NombreRecaudacionVisa, OrdenCedulacionConsts.Notificaciones.PdfMimeType);
                adjuntos.Add(archivoRecaudacionVisa);


                var nombreCompleto = string.IsNullOrEmpty(tramite.Beneficiario.SegundoApellido) ? $"{tramite.Beneficiario.Nombres} {tramite.Beneficiario.PrimerApellido}" : $"{tramite.Beneficiario.Nombres} {tramite.Beneficiario.PrimerApellido} {tramite.Beneficiario.SegundoApellido}";
                var asunto = TramitesConst.ComprobanteRecaudacion.AsuntoRecaudacion;
                var mensaje = datos1.Mensaje; ;//TramitesConst.ComprobanteRecaudacion.MensajeRecaudacion;

                var model = new Dictionary<string, string>();
                model.Add("PersonaNombreApellido", nombreCompleto);
                model.Add("Cuerpo", mensaje);
                model.Add("Fecha", DateTime.Now.ToShortDateString());
                model.Add("InformacionTramite", tramite.Numero);

                var result = false;
                try
                {
                  NotificadorClient.SetAccessToken(token);
                  result = await NotificadorClient.EnviarConAdjuntosAsync(
                  adjuntos,
                  TramitesConst.Plantilla,
                  asunto,
                  tramite.Solicitante.Correo,
                  model);
                }
                catch
                {
                  throw;
                }
              }
              catch (Exception ex)
              {
                return new ApiResponseWrapper(HttpStatusCode.NotFound, ex.Message.ToString());
              }
              #endregion
            }
            catch (Exception ex)
            {
              Logger.LogError(ex.Message.ToString(), null);
            }

            #endregion
          }
          #endregion

          #region Estado
          if (command.Estado.Equals((int)Domain.Enums.RolEstado.Codigo.RealizarPago))
          {
            #region Obtener Pago
            var pago = new ObtenerPagosResponse.Pago();
            var pagoDetalle = new List<ObtenerPagosResponse.PagoDetalle>();

            HttpClient Client = new HttpClient();

            var Uri = remoteServices.pago.BaseUrl + "api/Pago/ObtenerPago?idTramite=" + tramite.Id + "&valoresMayoraCero=false&facturarEn=0";
            var Response = await Client.PostAsync(Uri, null);
            if (Response.StatusCode == HttpStatusCode.OK)
            {
              var PlacesJson = Response.Content.ReadAsStringAsync().Result;
              var pagoObtenerPagoResponse = JsonConvert.DeserializeObject<ObtenerPagosResponse>(PlacesJson);
              pago = pagoObtenerPagoResponse.result;
              pagoDetalle = pagoObtenerPagoResponse.result.listaPagoDetalle;
            }
            else
            {
              return new ApiResponseWrapper(HttpStatusCode.NotFound, "No existe datos del pago");
            }
            #endregion

            #region Condicion
            if (pagoDetalle.Sum(x => x.valorArancel) == 0)
            {
              command.Estado = (int)Domain.Enums.RolEstado.Codigo.VerificarInformacion;
              goto CambioEstado;
            }
            #endregion
          }
          else if (command.Estado.Equals((int)Domain.Enums.RolEstado.Codigo.RevisarMultasExoneracion))
          {

            #region Calcular Edad
            DateTime now = DateTime.Today;
            int edad = DateTime.Today.Year - tramite.Beneficiario.FechaNacimiento.Year;

            if (DateTime.Today < tramite.Beneficiario.FechaNacimiento.AddYears(edad))
              --edad;
            #endregion

            #region Obtener Token 
            string token2 = await HttpApiAutentificacion.GetAccessTokenAsync();
            if (string.IsNullOrEmpty(token2))
            {
              return new ApiResponseWrapper(HttpStatusCode.Unauthorized, "El usuario no esta autenticado");
            }
            #endregion

            #region ObtenerConfiguracionPago
            var responseObtenerConfiguracionPago = new ObtenerConfiguracionPagoResponse();
            HttpClient ClientConfiguracion = new HttpClient();
            ClientConfiguracion.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token2);
            var callconfiguracionPago = await ClientConfiguracion.GetAsync(remoteServices.pago.BaseUrl + "api/Pago/ObtenerConfiguracionPago?servicioId=" + tramite.ServicioId);
            if (callconfiguracionPago.IsSuccessStatusCode)
            {
              //resultadoPruebas += $"{Environment.NewLine}obtener configuracion de pagos";
              var resultConfiguracionPago = await callconfiguracionPago.Content.ReadAsStringAsync();
              responseObtenerConfiguracionPago = JsonConvert.DeserializeObject<ObtenerConfiguracionPagoResponse>(resultConfiguracionPago);
              if (responseObtenerConfiguracionPago.httpStatusCode != 200)
              {
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, callconfiguracionPago.Content.ReadAsStringAsync());
              }
            }
            else
              resultadoPruebas += $"{Environment.NewLine}NO obtuvo configuracion de pagos   {callconfiguracionPago.RequestMessage}";
            #endregion

            #region Configuración Aranceles
            var detalleAraceles = await ObtenerValoresAPagarAsync(edad, tramite.Beneficiario.PorcentajeDiscapacidad, tramite.ServicioId, remoteServices.unidadAdministrativa.BaseUrl, token2, responseObtenerConfiguracionPago.result);
            if (detalleAraceles.Item2 == null || detalleAraceles.Item2.Count == 0)
            {
              return new ApiResponseWrapper(HttpStatusCode.BadRequest, string.IsNullOrEmpty(detalleAraceles.Item1) ? "No existen aranceles configurados" : detalleAraceles.Item1);
            }
            #endregion

            #region Crear Pago
            var request = new CalcularPagoRequest();
            request = new CalcularPagoRequest
            {
              id = command.TramiteId,
              idUsuario = command.CreatorId,
              edad = edad,
              servicioId = tramite.ServicioId,
              porcentajeDiscapacidad = tramite.Beneficiario.PorcentajeDiscapacidad,
              tieneVisa = tramite.Beneficiario.Visa.PoseeVisa,
              solicitante = tramite.Solicitante.Nombres,
              documentoIdentificacion = tramite.Solicitante.Identificacion,
              banco = "ND",
              numeroCuenta = "ND",
              tipoCuenta = "ND",
              titularCuenta = "ND",
              ConfiguracionAranceles = detalleAraceles.Item2
            };


            var pagoResponse = new CalcularPagoResponse();
            HttpClient ClientPago = new HttpClient();
            string PlacesJsonPago = string.Empty;
            ClientPago.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token2);

            var json = JsonConvert.SerializeObject(request);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var callApiResponse = await ClientPago.PostAsync(remoteServices.pago.BaseUrl + "api/Pago/CalcularPago", data);
            if (callApiResponse.IsSuccessStatusCode)
            {
             // resultadoPruebas += $"{Environment.NewLine}Al invocar a CalcularPagos SIIIII{callApiResponse.IsSuccessStatusCode}";
              var result = await callApiResponse.Content.ReadAsStringAsync();

              pagoResponse = JsonConvert.DeserializeObject<CalcularPagoResponse>(result);
              if (pagoResponse.httpStatusCode != 200)
              {
               // resultadoPruebas += $"{Environment.NewLine}Al invocar a CalcularPagos oops{pagoResponse.httpStatusCode}";
                return new ApiResponseWrapper(HttpStatusCode.BadRequest, pagoResponse.id);
              }
            }
            else
            {
             // resultadoPruebas += $"{Environment.NewLine} Al invocar a CalcularPagos NOOOO{callApiResponse.RequestMessage}";
              return new ApiResponseWrapper(HttpStatusCode.BadRequest, callApiResponse.Content.ReadAsStringAsync());
            }
            #endregion

          }

          #endregion

          #region Anterior Movimiento

          var ultimoMovimiento = tramite.Movimientos.LastOrDefault(x => x.Vigente.Equals(true));
          ultimoMovimiento.Vigente = false;
          ultimoMovimiento.LastModified = System.DateTime.Now;
          ultimoMovimiento.LastModifierId = command.CreatorId;
          var resultado1 = UnitOfWork.MovimientoRepository.Update(ultimoMovimiento);

          #endregion Anterior Movimiento

          var nuevoMovimiento = new Domain.Entities.Movimiento
          {
            Orden = tramite.Movimientos.Count + 1,
            ObservacionDatosPersonales = command.ObservacionDatosPersonales,
            ObservacionDomicilios = command.ObservacionDomicilios,
            ObservacionMovimientoMigratorio = command.ObservacionMovimientoMigratorio,
            ObservacionMultas = command.ObservacionMultas,
            ObservacionSoportesGestion = command.ObservacionSoportesGestion,
            NombreRol = rolEstado.NombreRol,
            Estado = command.Estado.ToString(),
            UnidadAdministrativaId = unidadAdministrativaId,
            Vigente = true,
            DiasTranscurridos = 0,
            NombreEstado = rolEstado.NombreEstado,
            FechaHoraCita = command.FechaHoraCita == null || command.FechaHoraCita.Value.Equals(string.Empty) ? new DateTime(1900, 1, 1) : command.FechaHoraCita.Value,
            UsuarioId = usuarioId,
            Created = System.DateTime.Now,
            CreatorId = command.CreatorId,
            LastModifierId = command.CreatorId,
            LastModified = System.DateTime.Now,
            TramiteId = tramite.Id
          };
          nuevoMovimiento.AssignId();
          var resultado = UnitOfWork.MovimientoRepository.InsertAsync(nuevoMovimiento);
          if (!resultado.Result.Item1)
            return new ApiResponseWrapper(HttpStatusCode.BadRequest, resultado.Result.Item2);

          var resultSave = await UnitOfWork.SaveChangesAsync();
          if (!resultSave.Item1)
            return new ApiResponseWrapper(HttpStatusCode.BadRequest, resultSave.Item2);

          return new ApiResponseWrapper(HttpStatusCode.OK, $"{ nuevoMovimiento.Id } {            resultadoPruebas}");

        }
      }

      private string ObtenerValorCatalogoDetalle(Guid CatalogoCabeceraId, List<ConsultarCatalogoDetalleResponse.CatalogoDetalle> consultarCatalogoDetalleResponses, string filtro, string valor)
      {
        switch (filtro)
        {
          case "CODIGO":
            return consultarCatalogoDetalleResponses.Where(x => x.CatalogoCabeceraId.Equals(CatalogoCabeceraId) && x.Codigo.Equals(valor)).FirstOrDefault().CodigoEsigex;
          case "DESCRIPCION":
            return consultarCatalogoDetalleResponses.Where(x => x.CatalogoCabeceraId.Equals(CatalogoCabeceraId) && x.Codigo.Equals(valor)).FirstOrDefault().CodigoEsigex;
          default:
            return string.Empty;
        }
      }

      /// <summary>
      /// Método que obtiene los valores de los aranceles a pagar
      /// </summary>
      /// <param name="edad"></param>
      /// <param name="porcentajeDiscapacidad"></param>
      /// <param name="servicioId"></param>
      /// <param name="urlUnidadAdministrativa"></param>
      /// <param name="tokenAcceso"></param>
      /// <param name="listaConfiguracion"></param>
      /// <returns></returns>
      private async Task<Tuple<string, List<ArancelDto>>> ObtenerValoresAPagarAsync(int edad, decimal porcentajeDiscapacidad, Guid servicioId, string urlUnidadAdministrativa, string tokenAcceso, List<ConfiguracionPago> listaConfiguracion)
      {
        HttpClient Client = new();
        Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenAcceso);
        String Uri = string.Empty;
        string PlacesJson = string.Empty;

        HttpResponseMessage Response;
        List<ArancelDto> aranceles = new List<ArancelDto>();

        // Verificando que existan configuraciones de pagos a realizar
        if (listaConfiguracion.Count == 0)
          return new Tuple<string, List<ArancelDto>>("Error al obtener configuración de aranceles.", null);

        // Generando los aranceles a cobrar
        foreach (var configuracionPago in listaConfiguracion)
        {
          // Obtener datos del arancel
          #region Obtener Arancel
          Uri = $"{urlUnidadAdministrativa}api/unidad-administrativa/partida-arancelaria-servicio/{configuracionPago.ServicioIdPago}";
          Response = await Client.GetAsync(Uri);
          if (Response.StatusCode != HttpStatusCode.OK)
          {
            return new Tuple<string, List<ArancelDto>>($"Error al obtener la configuración de las partidas arancelarias.{Environment.NewLine}" +
              $"{Response.StatusCode}{Environment.NewLine}{Response.RequestMessage}", null);
          }

          PlacesJson = Response.Content.ReadAsStringAsync().Result;
          ListaPartidaArancelaria listaPartidasArancelarias = new ListaPartidaArancelaria();
          listaPartidasArancelarias = JsonConvert.DeserializeObject<ListaPartidaArancelaria>(PlacesJson);

          if (listaPartidasArancelarias.Items.Count == 0)
          {
            return new Tuple<string, List<ArancelDto>>("No existen partidas arancelarias configuradas, por favor verificar si para todos los servicios a ser facturados se han creado las partidas aranelarias requeridas.", null);
          }

          var arancel = new ArancelDto
          {
            ServicioId = configuracionPago.ServicioIdPago,
            DescripcionArancelaria = configuracionPago.Descripcion,
            PartidaArancelaria = listaPartidasArancelarias.Items[0].PartidaArancelaria,
            ValorArancelario = listaPartidasArancelarias.Items[0].Valor,
            ArancelId = listaPartidasArancelarias.Items[0].ArancelId,
            PartidaArancelariaId = listaPartidasArancelarias.Items[0].PartidaArancelariaId,
            Servicio = listaPartidasArancelarias.Items[0].Servicio,
            NumeroPartida = listaPartidasArancelarias.Items[0].NumeroPartida,
            JerarquiaArancelariaId = listaPartidasArancelarias.Items[0].JerarquiaArancelariaId,
            JerarquiaArancelaria = listaPartidasArancelarias.Items[0].JerarquiaArancelaria,
            Arancel = listaPartidasArancelarias.Items[0].Arancel,
            FacturarEn = configuracionPago.FacturarEn
          };

          #endregion

          #region Obtener Exoneraciones

          Uri = $"{urlUnidadAdministrativa}api/unidad-administrativa/convenio/exoneration/{configuracionPago.ServicioIdPago}";

          Response = await Client.GetAsync(Uri);
          if (Response.StatusCode != HttpStatusCode.OK)
          {
            //return new Tuple<string, List<ArancelDto>>("Error al obtener las configuraciones de exoneraciones.", null);

            PlacesJson = Response.Content.ReadAsStringAsync().Result;
            ListaConvenios listaConvenios = new ListaConvenios();
            listaConvenios = JsonConvert.DeserializeObject<ListaConvenios>(PlacesJson);

            if (listaConvenios.Items.Count > 0)
            {
              var convenioTeceraEdad = listaConvenios.Items.FirstOrDefault(x => edad >= x.EdadInicial && !x.Discapacitado.Value && x.EdadInicial > 0);
              if (convenioTeceraEdad != null)
              {
                arancel.ValorArancelario = convenioTeceraEdad.Valor;
                arancel.ConvenioId = convenioTeceraEdad.ConvenioId;
                arancel.TipoServicio = convenioTeceraEdad.TipoServicio;
                arancel.TipoExoneracionId = convenioTeceraEdad.TipoExoneracionId;
                arancel.TipoExoneracion = convenioTeceraEdad.TipoExoneracion;
              }

              if (porcentajeDiscapacidad >= 30)
              {
                var convenioDiscapacidad = listaConvenios.Items.FirstOrDefault(x => x.Discapacitado.Value);
                if (convenioDiscapacidad != null)
                {
                  arancel.ValorArancelario = convenioDiscapacidad.Valor;
                  arancel.ConvenioId = convenioDiscapacidad.ConvenioId;
                  arancel.TipoServicio = convenioDiscapacidad.TipoServicio;
                  arancel.TipoExoneracionId = convenioDiscapacidad.TipoExoneracionId;
                  arancel.TipoExoneracion = convenioDiscapacidad.TipoExoneracion;

                }
              }

            }
          }

          #endregion

          aranceles.Add(arancel);
        }

        return new Tuple<string, List<ArancelDto>>("", aranceles);
      }
      #region FirmaElectronica

      public async Task<FirmaElectronicaInput> ObtenerFirmaElectronicaInputAsync(byte[] documentoFirmar,
          SignatarioDto signatario,
          Guid servicioId,
          Guid tramiteId)
      {
        //1. Obtener configuacion
        Logger.LogInformation("Obtener configuracion de firma electronica. Usuario {usuario}. TramiteId {tramiteId}", signatario.UsuarioId, tramiteId);

        var token = await HttpApiAutentificacion.GetAccessTokenAsync();
        ConfigurarFirmaElectronicaClient.SetAccessToken(token);
        var configurarFirmaElectronicaDto = await ConfigurarFirmaElectronicaClient.ConfigurarFirmaElectronicaGetAsync(signatario.UsuarioId);

        if (configurarFirmaElectronicaDto == null)
        {
          throw new Exception(TextosConsts.FirmaElectronica.NoExisteConfiguracionFirma);
        }


        //Recuperar configuracion posiciones firma electronica
        var obtenerListaConfiguracionFirmaElectronicaQuery = new ObtenerListaConfiguracionFirmaElectronicaQuery();
        obtenerListaConfiguracionFirmaElectronicaQuery.ServicioId = servicioId;
        obtenerListaConfiguracionFirmaElectronicaQuery.TipoDocumentoCodigo = visaVirteConfiguracion.TipoDocumentoCodigo;

        //2. Obtener configuacion inumos
        Logger.LogInformation("Obtener configurar de insumos firma electronica. ServicioId {servicioId}. TipoDocumentoCodigo {tipoDocumentoCodigo}", servicioId, visaVirteConfiguracion.TipoDocumentoCodigo);


        var firmaElectronicaInsumosRespuesta = await Mediator.Send(obtenerListaConfiguracionFirmaElectronicaQuery);

        if (firmaElectronicaInsumosRespuesta.HttpStatusCode != HttpStatusCode.OK ||
            firmaElectronicaInsumosRespuesta.Result.TotalRegistros != 1)
        {
          throw new Exception(TextosConsts.FirmaElectronica.NoExisteFirmaInsumos);
        }

        var firmaElectronicaInsumo = firmaElectronicaInsumosRespuesta.Result.Items.SingleOrDefault();

        var firmaElectronicaInput = new FirmaElectronicaInput();

        var insumosFirmaDto = new InsumosFirmaDto();
        insumosFirmaDto.Pass = configurarFirmaElectronicaDto.Clave;
        insumosFirmaDto.ModeloFirma = firmaElectronicaInsumo.ModeloFirma;
        insumosFirmaDto.Cargo = signatario.Cargo;
        insumosFirmaDto.TamanoFirma = firmaElectronicaInsumo.TamanioFirma.ToString();
        insumosFirmaDto.PosicionX = firmaElectronicaInsumo.PosicionX.ToString();
        insumosFirmaDto.PosicionY = firmaElectronicaInsumo.PosicionY.ToString();
        insumosFirmaDto.PaginaAFirmar = firmaElectronicaInsumo.NumeroPagina.ToString();

        firmaElectronicaInput.Firma = configurarFirmaElectronicaDto.Data;
        firmaElectronicaInput.Documento = documentoFirmar;
        firmaElectronicaInput.InsumosFirma = insumosFirmaDto;

        return firmaElectronicaInput;
      }

      public async Task<FirmaElectronicaOutput> FirmarVisaAsync(byte[] documentoFirmar,
          SignatarioDto signatario,
          Guid servicioId,
          Guid tramiteId)
      {
        //Obtener valores para la firma
        var firmaElectronicaInput = await ObtenerFirmaElectronicaInputAsync(documentoFirmar, signatario, servicioId, tramiteId);

        Logger.LogInformation("Firmar electronicamente visa. TramiteId {tramiteId}", tramiteId);

        //realizar firma electronica
        return await FirmaElectronicaClient.FirmarAsync(firmaElectronicaInput);
      }


      #endregion FirmaElectronica

      private async Task<ApiResponseWrapper<SignatarioDto>> ObtenerInformacionSignatarioAsync(Guid usuarioId)
      {
        var token = await HttpApiAutentificacion.GetAccessTokenAsync();

        if (string.IsNullOrEmpty(token))
        {
          return new ApiResponseWrapper<SignatarioDto>(HttpStatusCode.Unauthorized, TextosConsts.UsuarioNoAutenticado);
        }

        UsuarioClient.SetAccessToken(token);
        var listaIds = new List<Guid>() { usuarioId };
        var usuarios = await UsuarioClient.UsuarioGetAsync(listaIds);
        var usuario = usuarios.SingleOrDefault();

        UnidadAdministrativaFuncionalClient.SetAccessToken(token);
        var funcionarioInfo = await UnidadAdministrativaFuncionalClient.FuncionarioAsync(usuarioId);

        var respuesta = new SignatarioDto()
        {
          UsuarioId = usuarioId,
          Nombre = usuario.Name,
          Apellido = usuario.Surname,
          Cargo = funcionarioInfo.Cargo,
          Ciudad = funcionarioInfo.Ciudad
        };

        return new ApiResponseWrapper<SignatarioDto>(HttpStatusCode.OK, respuesta);
      }
    }
  }

  public class CrearMovimientoCommandValidator : AbstractValidator<CrearMovimientoCommand>
  {
    public CrearMovimientoCommandValidator()
    {
      RuleFor(e => e.TramiteId)
           .NotEmpty().WithMessage("{PropertyName} es requerido.")
           .NotNull().WithMessage("{PropertyName} no puede ser nulo.");

      RuleFor(e => e.Estado)
           .NotEmpty().WithMessage("{PropertyName} es requerido.")
           .NotNull().WithMessage("{PropertyName} no puede ser nulo.")
           .InclusiveBetween(1, 200);

      RuleFor(e => e.CreatorId)
           .NotEmpty().WithMessage("{PropertyName} es requerido.")
           .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
    }
  }


}