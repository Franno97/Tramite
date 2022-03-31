using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface ISharepointClient
    {
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<string> LoginAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<string> LoginAsync(System.Threading.CancellationToken cancellationToken);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Resultado> GrabarDocumentoAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Resultado> GrabarDocumentoAsync(System.Threading.CancellationToken cancellationToken);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Resultado> GrabarSoporteGestionAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Resultado> GrabarSoporteGestionAsync(System.Threading.CancellationToken cancellationToken);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Resultado> GrabarBibliotecaAsync(GrabarBibliotecaRequest request);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Resultado> GrabarBibliotecaAsync(GrabarBibliotecaRequest request, System.Threading.CancellationToken cancellationToken);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ResultadoObtenerArchivo> ObtenerArchivoBase64PorUrlAsync(SolicitudObtenerArchivoPorUrl solicitud);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ResultadoObtenerArchivo> ObtenerArchivoBase64PorUrlAsync(SolicitudObtenerArchivoPorUrl solicitud, System.Threading.CancellationToken cancellationToken);

        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Resultado> GrabarDocumentoZipAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<Resultado> GrabarDocumentoZipAsync(System.Threading.CancellationToken cancellationToken);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class Resultado
    {

        [System.Text.Json.Serialization.JsonPropertyName("Estado")]
        public string Estado { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("Mensaje")]
        public string Mensaje { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("Ruta")]
        public string Ruta { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("RutaSp")]
        public string RutaSp { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ListaSp")]
        public string ListaSp { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("SitioSp")]
        public string SitioSp { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("CarpetaSp")]
        public string CarpetaSp { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("NombreFichero")]
        public string NombreFichero { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class SolicitudObtenerArchivoPorUrl
    {

        [System.Text.Json.Serialization.JsonPropertyName("UrlArchivo")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string UrlArchivo { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ResultadoObtenerArchivo
    {

        [System.Text.Json.Serialization.JsonPropertyName("ArchivoBase64")]
        public string ArchivoBase64 { get; set; }

    }

    public class GrabarBibliotecaRequest
    {
        public string CodigoMdg { get; set; }

        public string Biblioteca { get; set; }

        public byte[] Archivo { get; set; }

        public string NombreArchivo { get; set; }

    }

}
