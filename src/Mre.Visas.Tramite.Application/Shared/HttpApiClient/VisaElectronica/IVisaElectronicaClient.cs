using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IVisaElectronicaClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task CrearVisaElectronicaAsync(CrearVisaElectronicaRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task CrearVisaElectronicaAsync(CrearVisaElectronicaRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ActualizarVisaElectronicaAsync(ActualizarVisaElectronicaRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ActualizarVisaElectronicaAsync(ActualizarVisaElectronicaRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ObtenerCodigoBarrasAsync(string cadena, int? tipoCodigo);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task ObtenerCodigoBarrasAsync(string cadena, int? tipoCodigo, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<VisaElectronica>> ConsultarVisaElectronicaPorTramiteIdAsync(ConsultarVisaElectronicaPorTramiteIdRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<VisaElectronica>> ConsultarVisaElectronicaPorTramiteIdAsync(ConsultarVisaElectronicaPorTramiteIdRequest body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<string> GenerarCodigoQrAsync(string numero);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<string> GenerarCodigoQrAsync(string numero, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<string> GenerarBase64CodigoBarrasAsync(string cadena);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<string> GenerarBase64CodigoBarrasAsync(string cadena, System.Threading.CancellationToken cancellationToken);

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ActualizarVisaElectronicaRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("observaciones")]
        public string Observaciones { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("signatarioId")]
        public System.Guid SignatarioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombreSignatario")]
        public string NombreSignatario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("diasVigencia")]
        public int DiasVigencia { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("usuarioId")]
        public System.Guid UsuarioId { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ConsultarVisaElectronicaPorTramiteIdRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("tramiteId")]
        public System.Guid TramiteId { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearVisaElectronicaRequest
    {

        [System.Text.Json.Serialization.JsonPropertyName("numeroInicial")]
        public long NumeroInicial { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tramiteId")]
        public System.Guid TramiteId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("observaciones")]
        public string Observaciones { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("signatarioId")]
        public System.Guid SignatarioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombreSignatario")]
        public string NombreSignatario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("diasVigencia")]
        public int DiasVigencia { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaEmision")]
        public System.DateTimeOffset FechaEmision { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaExpiracion")]
        public System.DateTimeOffset FechaExpiracion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("secuenciaVisa")]
        public long SecuenciaVisa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroVisa")]
        public string NumeroVisa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("calidadMigratoria")]
        public string CalidadMigratoria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("categoria")]
        public string Categoria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroAdmisiones")]
        public string NumeroAdmisiones { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroPasaporte")]
        public string NumeroPasaporte { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("codigoVerificacion")]
        public string CodigoVerificacion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("informacionQR")]
        public string InformacionQR { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombresBeneficiario")]
        public string NombresBeneficiario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("apellidosBeneficiario")]
        public string ApellidosBeneficiario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("direccionDomiciliaria")]
        public string DireccionDomiciliaria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("actividadDesarrollar")]
        public string ActividadDesarrollar { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("requisitosCumplidos")]
        public string RequisitosCumplidos { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaId")]
        public System.Guid UnidadAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaNombre")]
        public string UnidadAdministrativaNombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaCiudad")]
        public string UnidadAdministrativaCiudad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("usuarioId")]
        public System.Guid UsuarioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaNacimiento")]
        public string FechaNacimiento { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("genero")]
        public string Genero { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nacionalidad")]
        public string Nacionalidad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fotoBeneficiario")]
        public string FotoBeneficiario { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class VisaElectronica
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lastModified")]
        public System.DateTime LastModified { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lastModifierId")]
        public System.Guid LastModifierId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("created")]
        public System.DateTime Created { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creatorId")]
        public System.Guid CreatorId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tramiteId")]
        public System.Guid TramiteId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("observaciones")]
        public string Observaciones { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("signatarioId")]
        public System.Guid SignatarioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombreSignatario")]
        public string NombreSignatario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("diasVigencia")]
        public int DiasVigencia { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaEmision")]
        public System.DateTime FechaEmision { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaExpiracion")]
        public System.DateTime FechaExpiracion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("secuenciaVisa")]
        public long SecuenciaVisa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroVisa")]
        public string NumeroVisa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("calidadMigratoria")]
        public string CalidadMigratoria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("categoria")]
        public string Categoria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroAdmisiones")]
        public string NumeroAdmisiones { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroPasaporte")]
        public string NumeroPasaporte { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("codigoVerificacion")]
        public string CodigoVerificacion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("informacionQR")]
        public string InformacionQR { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombresBeneficiario")]
        public string NombresBeneficiario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("apellidosBeneficiario")]
        public string ApellidosBeneficiario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("direccionDomiciliaria")]
        public string DireccionDomiciliaria { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("actividadDesarrollar")]
        public string ActividadDesarrollar { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("requisitosCumplidos")]
        public string RequisitosCumplidos { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaId")]
        public System.Guid UnidadAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaNombre")]
        public string UnidadAdministrativaNombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaNacimiento")]
        public string FechaNacimiento { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("genero")]
        public string Genero { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nacionalidad")]
        public string Nacionalidad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaCiudad")]
        public string UnidadAdministrativaCiudad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fotoBeneficiario")]
        public string FotoBeneficiario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("usuarioId")]
        public System.Guid UsuarioId { get; set; }

    }

}
