
namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IUnidadAdministrativaFuncionalClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaInfoDto> ActualAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<UnidadAdministrativaInfoDto> ActualAsync(System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfFuncionarioInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> FuncionariosAsync(System.Guid unidadAdministrativaId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfFuncionarioInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> FuncionariosAsync(System.Guid unidadAdministrativaId, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<FuncionarioInfoExtendido> FuncionarioAsync(System.Guid usuarioId);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<FuncionarioInfoExtendido> FuncionarioAsync(System.Guid usuarioId, System.Threading.CancellationToken cancellationToken);


        void SetAccessToken(string accessToken);

        void AddHeaders(string name, string value);

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class UnidadAdministrativaInfoDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("paisId")]
        public string PaisId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("siglas")]
        public string Siglas { get; set; }

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfFuncionarioInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<FuncionarioInfoDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class FuncionarioInfoDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("usuarioId")]
        public System.Guid UsuarioId { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class FuncionarioInfoExtendido
    {

        [System.Text.Json.Serialization.JsonPropertyName("usuarioId")]
        public System.Guid UsuarioId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("cargo")]
        public string Cargo { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ciudad")]
        public string Ciudad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaId")]
        public System.Guid UnidadAdministrativaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaNombre")]
        public string UnidadAdministrativaNombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaPaisId")]
        public string UnidadAdministrativaPaisId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unidadAdministrativaSiglas")]
        public string UnidadAdministrativaSiglas { get; set; }

    }

}
