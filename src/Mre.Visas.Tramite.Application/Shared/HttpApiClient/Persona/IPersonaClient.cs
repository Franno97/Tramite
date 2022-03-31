using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IPersonaClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfPersonaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PersonaGetAsync(string filtro, string sorting, int? skipCount, int? maxResultCount);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PagedResultDto_1OfOfPersonaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PersonaGetAsync(string filtro, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PersonaDto> PersonaPostAsync(CrearActualizarPersonaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PersonaDto> PersonaPostAsync(CrearActualizarPersonaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PersonaDto> PersonaGetAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PersonaDto> PersonaGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PersonaDto> PersonaPutAsync(System.Guid id, CrearActualizarPersonaDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PersonaDto> PersonaPutAsync(System.Guid id, CrearActualizarPersonaDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task PersonaDeleteAsync(System.Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task PersonaDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PersonaDto> UsuarioAsync(string nombreUsuario);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PersonaDto> UsuarioAsync(string nombreUsuario, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PersonaDto> ActualAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<PersonaDto> ActualAsync(System.Threading.CancellationToken cancellationToken);

        void SetAccessToken(string accessToken);

        void AddHeaders(string name, string value);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PersonaDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("primerApellido")]
        public string PrimerApellido { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("segundoApellido")]
        public string SegundoApellido { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaNacimiento")]
        public System.DateTimeOffset FechaNacimiento { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("paisNacimientoId")]
        public string PaisNacimientoId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("paisNacimiento")]
        public string PaisNacimiento { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nacionalidadesId")]
        public System.Collections.Generic.ICollection<string> NacionalidadesId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nacionalidadesNombre")]
        public System.Collections.Generic.ICollection<string> NacionalidadesNombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("correoElectronico")]
        public string CorreoElectronico { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("poseeDocumentoIdentidad")]
        public bool PoseeDocumentoIdentidad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("poseeDocumentoIdentidadTexto")]
        public string PoseeDocumentoIdentidadTexto { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoDocumentoIdentidadId")]
        public string TipoDocumentoIdentidadId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoDocumentoIdentidad")]
        public string TipoDocumentoIdentidad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroDocumentoIdentidad")]
        public string NumeroDocumentoIdentidad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("documentoIdentidadPaisEmision")]
        public string DocumentoIdentidadPaisEmision { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("documentoIdentidadPaisEmisionNombre")]
        public string DocumentoIdentidadPaisEmisionNombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("documentoIdentidadFechaEmision")]
        public System.DateTimeOffset? DocumentoIdentidadFechaEmision { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("documentoIdentidadFechaExpiracion")]
        public System.DateTimeOffset? DocumentoIdentidadFechaExpiracion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("genero")]
        public string Genero { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("estadoCivilId")]
        public string EstadoCivilId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("estadoCivil")]
        public string EstadoCivil { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("telefono")]
        public string Telefono { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("direccion")]
        public string Direccion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("regionId")]
        public string RegionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("region")]
        public string Region { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ciudad")]
        public string Ciudad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroVisa")]
        public string NumeroVisa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoVisa")]
        public string TipoVisa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoVisaId")]
        public string TipoVisaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("visaFechaEmision")]
        public System.DateTimeOffset? VisaFechaEmision { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("visaFechaExpiracion")]
        public System.DateTimeOffset? VisaFechaExpiracion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nivelEducativoId")]
        public string NivelEducativoId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nivelEducativo")]
        public string NivelEducativo { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("profesionId")]
        public string ProfesionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("profesion")]
        public string Profesion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ocupacionId")]
        public string OcupacionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ocupacion")]
        public string Ocupacion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fotografia")]
        public byte[] Fotografia { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fotografiaBase64")]
        public string FotografiaBase64 { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroRegistroPermanencia")]
        public string NumeroRegistroPermanencia { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("huellasDactilares")]
        public byte[] HuellasDactilares { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("huellasDactilaresBase64")]
        public string HuellasDactilaresBase64 { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaIngresoPais")]
        public System.DateTimeOffset? FechaIngresoPais { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ingresoPuntoRegular")]
        public bool IngresoPuntoRegular { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ingresoPuntoRegularTexto")]
        public string IngresoPuntoRegularTexto { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("paisResidenciaPrevia")]
        public string PaisResidenciaPrevia { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("paisResidenciaPreviaTexto")]
        public string PaisResidenciaPreviaTexto { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombreUsuario")]
        public string NombreUsuario { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("origen")]
        public string Origen { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("origenId")]
        public string OrigenId { get; set; }

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class CrearActualizarPersonaDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("nombre")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string Nombre { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("primerApellido")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string PrimerApellido { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("segundoApellido")]
        [System.ComponentModel.DataAnnotations.StringLength(80)]
        public string SegundoApellido { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaNacimiento")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset FechaNacimiento { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("paisNacimientoId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string PaisNacimientoId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nacionalidades")]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<string> Nacionalidades { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        [System.Text.Json.Serialization.JsonPropertyName("correoElectronico")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string CorreoElectronico { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tieneDocumentoIdentidad")]
        public bool TieneDocumentoIdentidad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoDocumentoIdentidadId")]
        public string TipoDocumentoIdentidadId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroDocumentoIdentidad")]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        public string NumeroDocumentoIdentidad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("paisEmisionDocumentoIdentidad")]
        public string PaisEmisionDocumentoIdentidad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaEmisionDocumentoIdentidad")]
        public System.DateTimeOffset? FechaEmisionDocumentoIdentidad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaExpiracionDocumentoIdentidad")]
        public System.DateTimeOffset? FechaExpiracionDocumentoIdentidad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("genero")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(1)]
        public string Genero { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("estadoCivilId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string EstadoCivilId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("telefono")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(32)]
        public string Telefono { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("direccion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public string Direccion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("regionId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string RegionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ciudad")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Ciudad { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroVisa")]
        public string NumeroVisa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tipoVisaId")]
        public string TipoVisaId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaEmisionVisa")]
        public System.DateTimeOffset? FechaEmisionVisa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaExpiracionVisa")]
        public System.DateTimeOffset? FechaExpiracionVisa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nivelEducativoId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string NivelEducativoId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("profesionId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string ProfesionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ocupacionId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string OcupacionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fotografia")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] Fotografia { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("numeroRegistroPermanencia")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(16)]
        public string NumeroRegistroPermanencia { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("huellaDactilar")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] HuellaDactilar { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fechaIngresoPais")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset FechaIngresoPais { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("puntoAccesoRegular")]
        public bool PuntoAccesoRegular { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("paisResidenciaPrevia")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(512)]
        public string PaisResidenciaPrevia { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("origen")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(3)]
        public string Origen { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("origenId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(16)]
        public string OrigenId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nombreUsuario")]
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public string NombreUsuario { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class PagedResultDto_1OfOfPersonaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
    {

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public System.Collections.Generic.ICollection<PersonaDto> Items { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
        public long TotalCount { get; set; }

    }

}
