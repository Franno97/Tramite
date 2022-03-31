using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IFacturaElectronicaClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<GrabarFacturaResultadoResponse> GrabarFacturaAsync(GrabarFacturaRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<GrabarFacturaResultadoResponse> GrabarFacturaAsync(GrabarFacturaRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<CrearPDFResultadoResponse> CrearPDFAsync(ConsultarFacturaPorClaveAccesoRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<CrearPDFResultadoResponse> CrearPDFAsync(ConsultarFacturaPorClaveAccesoRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<Factura>> ObtenerFacturaPorClaveAccesoAsync(ConsultarFacturaPorClaveAccesoRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<Factura>> ObtenerFacturaPorClaveAccesoAsync(ConsultarFacturaPorClaveAccesoRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ObtenerFacturaPorIdAsync(ConsultarFacturaPorIdRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ObtenerFacturaPorIdAsync(ConsultarFacturaPorIdRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ObtenerFacturaPorNumeroTramiteAsync(ConsultarFacturaPorNumeroTramiteRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ObtenerFacturaPorNumeroTramiteAsync(ConsultarFacturaPorNumeroTramiteRequest body, System.Threading.CancellationToken cancellationToken);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class GrabarFacturaRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("factura")]
        public Factura Factura { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class Factura
    {

        [System.Text.Json.Serialization.JsonPropertyName("codigoUsuario")]
        public string CodigoUsuario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("codigoOficina")]
        public string CodigoOficina { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoIdentificacionComprador")]
        public string TipoIdentificacionComprador { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("razonSocialComprador")]
        public string RazonSocialComprador { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("identificacionComprador")]
        public string IdentificacionComprador { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("direccionComprador")]
        public string DireccionComprador { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("telefonoComprador")]
        public string TelefonoComprador { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("correoComprador")]
        public string CorreoComprador { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalSinImpuestos")]
        public double TotalSinImpuestos { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalDescuento")]
        public double TotalDescuento { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("importeTotal")]
        public double ImporteTotal { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("porcentaje")]
        public double Porcentaje { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaEmisionLocal")]
        public string FechaEmisionLocal { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("referencia")]
        public string Referencia { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("origen")]
        public string Origen { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroTramite")]
        public string NumeroTramite { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("descripcionGeneral")]
        public string DescripcionGeneral { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("facturaDetalle")]
        public System.Collections.Generic.ICollection<FacturaDetalle> FacturaDetalle { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("facturaPagos")]
        public System.Collections.Generic.ICollection<FacturaPagos> FacturaPagos { get; set; }

        //
        public string Numero { get; set; }

        public string ClaveAcceso { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class FacturaDetalle
    {

        [System.Text.Json.Serialization.JsonPropertyName("ordenDetalle")]
        public int OrdenDetalle { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("codigoPrincipal")]
        public string CodigoPrincipal { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("codigoAuxiliar")]
        public string CodigoAuxiliar { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("cantidad")]
        public double Cantidad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("precioUnitario")]
        public double PrecioUnitario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("descuento")]
        public double Descuento { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("precioTotalSinImpuesto")]
        public double PrecioTotalSinImpuesto { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("campoAdicional1Nombre")]
        public string CampoAdicional1Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("campoAdicional1Valor")]
        public string CampoAdicional1Valor { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("campoAdicional2Nombre")]
        public string CampoAdicional2Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("campoAdicional2Valor")]
        public string CampoAdicional2Valor { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("campoAdicional3Nombre")]
        public string CampoAdicional3Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("campoAdicional3Valor")]
        public string CampoAdicional3Valor { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("idArancel")]
        public System.Guid IdArancel { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class FacturaPagos
    {

        [System.Text.Json.Serialization.JsonPropertyName("orden")]
        public int Orden { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("formaPago")]
        public int FormaPago { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("total")]
        public double Total { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("idPagoDetalle")]
        public System.Guid IdPagoDetalle { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ConsultarFacturaPorClaveAccesoRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("claveAcceso")]
        public string ClaveAcceso { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ConsultarFacturaPorIdRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ConsultarFacturaPorNumeroTramiteRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("numeroTramite")]
        public string NumeroTramite { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("idArancel")]
        public System.Guid IdArancel { get; set; }

    }


    public class GrabarFacturaResultadoResponse
    {
        public string Estado { get; set; }
        public string Mensaje { get; set; }
        public string ClaveAcceso { get; set; }

    }

    public class CrearPDFResultadoResponse
    {
        public string Estado { get; set; }
        public string Mensaje { get; set; }
        public string Pdf { get; set; }
    }

}
