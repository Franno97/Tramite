using Mre.Visas.Tramite.Application.Movimiento.Request;
using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IPagoClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task CalcularPagoAsync(CalcularPagoRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task CalcularPagoAsync(CalcularPagoRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<ObtenerPagoResponse>> ObtenerPagoAsync(string idTramite, bool? valoresMayoraCero, string facturarEn);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<ObtenerPagoResponse>> ObtenerPagoAsync(string idTramite, bool? valoresMayoraCero, string facturarEn, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task GuardarFormaPagoAsync(GuardarFormaPagoRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task GuardarFormaPagoAsync(GuardarFormaPagoRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task RegistrarPagoAsync(RegistrarPagoRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task RegistrarPagoAsync(RegistrarPagoRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ActualizarPagoAsync(ActualizarPagoRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ActualizarPagoAsync(ActualizarPagoRequest body, System.Threading.CancellationToken cancellationToken);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ActualizarPagoRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("idPagoDetalle")]
        public System.Guid IdPagoDetalle { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("claveAcceso")]
        public string ClaveAcceso { get; set; }

    }

    //[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    //public partial class CalcularPagoRequest
    //{

    //    [System.Text.Json.Serialization.JsonPropertyName("id")]
    //    public string Id { get; set; }

    //    [System.Text.Json.Serialization.JsonPropertyName("servicioId")]
    //    public System.Guid ServicioId { get; set; }

    //    [System.Text.Json.Serialization.JsonPropertyName("solicitante")]
    //    public string Solicitante { get; set; }

    //    [System.Text.Json.Serialization.JsonPropertyName("documentoIdentificacion")]
    //    public string DocumentoIdentificacion { get; set; }

    //    [System.Text.Json.Serialization.JsonPropertyName("tieneVisa")]
    //    public bool TieneVisa { get; set; }

    //    [System.Text.Json.Serialization.JsonPropertyName("edad")]
    //    public int Edad { get; set; }

    //    [System.Text.Json.Serialization.JsonPropertyName("porcentajeDiscapacidad")]
    //    public double PorcentajeDiscapacidad { get; set; }

    //    [System.Text.Json.Serialization.JsonPropertyName("idUsuario")]
    //    public string IdUsuario { get; set; }

    //}

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class GuardarFormaPagoDetalle
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("valorTotal")]
        public double ValorTotal { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class GuardarFormaPagoRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("formaPago")]
        public int FormaPago { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("idUsuario")]
        public System.Guid IdUsuario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("listaDetalle")]
        public System.Collections.Generic.ICollection<GuardarFormaPagoDetalle> ListaDetalle { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ObtenerPagoResponse
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("idTramite")]
        public System.Guid IdTramite { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("formaPago")]
        public int FormaPago { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("solicitante")]
        public string Solicitante { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("documentoIdentificacion")]
        public string DocumentoIdentificacion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("servicioId")]
        public System.Guid ServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("observacion")]
        public string Observacion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("estado")]
        public string Estado { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("listaPagoDetalle")]
        public System.Collections.Generic.ICollection<PagoDetalle> ListaPagoDetalle { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagoDetalle
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lastModified")]
        public System.DateTimeOffset LastModified { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lastModifierId")]
        public System.Guid LastModifierId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("created")]
        public System.DateTimeOffset Created { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creatorId")]
        public System.Guid CreatorId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("idTramite")]
        public System.Guid IdTramite { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("idPago")]
        public System.Guid IdPago { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("orden")]
        public int Orden { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("valorArancel")]
        public double ValorArancel { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("porcentajeDescuento")]
        public double PorcentajeDescuento { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("valorDescuento")]
        public double ValorDescuento { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("valorTotal")]
        public double ValorTotal { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("estado")]
        public string Estado { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ordenPago")]
        public string OrdenPago { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroTransaccion")]
        public string NumeroTransaccion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("estaFacturado")]
        public bool EstaFacturado { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("claveAcceso")]
        public string ClaveAcceso { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comprobantePago")]
        public string ComprobantePago { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("partidaArancelariaId")]
        public System.Guid PartidaArancelariaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("servicioId")]
        public System.Guid ServicioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("servicio")]
        public string Servicio { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("partidaArancelaria")]
        public string PartidaArancelaria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroPartida")]
        public string NumeroPartida { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("jerarquiaArancelariaId")]
        public System.Guid JerarquiaArancelariaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("jerarquiaArancelaria")]
        public string JerarquiaArancelaria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("arancelId")]
        public System.Guid ArancelId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("arancel")]
        public string Arancel { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("convenioId")]
        public System.Guid ConvenioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoServicio")]
        public string TipoServicio { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoExoneracionId")]
        public string TipoExoneracionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoExoneracion")]
        public string TipoExoneracion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("facturarEn")]
        public string FacturarEn { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class RegistrarPagoRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("idTramite")]
        public System.Guid IdTramite { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("idUsuario")]
        public System.Guid IdUsuario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("listaRegistroPagoDetalle")]
        public System.Collections.Generic.ICollection<RegistroPagoDetalleRequest> ListaRegistroPagoDetalle { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class RegistroPagoDetalleRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroTransaccion")]
        public string NumeroTransaccion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comprobantePago")]
        public string ComprobantePago { get; set; }

    }


    
}
