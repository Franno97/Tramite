using Mre.Visas.Tramite.Application.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface ICatalogoClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<List<Catalogo>>> ConsultarCatalogoPorCatalogoCabeceraCodigoAsync(string codigoCatalogo);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<List<Catalogo>>> ConsultarCatalogoPorCatalogoCabeceraCodigoAsync(string codigoCatalogo, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<Catalogo>> ConsultarCatalogoPorCodigoAsync(string codigoCatalogo, string codigo);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<Catalogo>> ConsultarCatalogoPorCodigoAsync(string codigoCatalogo, string codigo, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<Catalogo>> ConsultarCatalogoPorCodigoMdgAsync(string codigoCatalogo, string codigoMdg);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<Catalogo>> ConsultarCatalogoPorCodigoMdgAsync(string codigoCatalogo, string codigoMdg, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<Catalogo>> ConsultarCatalogoPorCodigoEsigexAsync(string codigoCatalogo, string codigoEsigex);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<Catalogo>> ConsultarCatalogoPorCodigoEsigexAsync(string codigoCatalogo, string codigoEsigex, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<Catalogo>> ConsultarCatalogoPorCodigoOtroAsync(string codigoCatalogo, string codigoOtro);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<ApiResponseWrapper<Catalogo>> ConsultarCatalogoPorCodigoOtroAsync(string codigoCatalogo, string codigoOtro, System.Threading.CancellationToken cancellationToken);

    }


    public class Catalogo
    {
        public Guid CatalogoCabeceraId { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public string Descripcion2 { get; set; }

        public string CodigoEsigex { get; set; }

        public string CodigoMdg { get; set; }

        public string CodigoOtro { get; set; }

    }

}
