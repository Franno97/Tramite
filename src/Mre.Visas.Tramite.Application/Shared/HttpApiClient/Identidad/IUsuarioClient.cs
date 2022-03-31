using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IUsuarioClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<IdentityUserDto> UsuarioPostAsync(UsuarioCrearDto body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<IdentityUserDto> UsuarioPostAsync(UsuarioCrearDto body, System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<IdentityUserDto>> UsuarioGetAsync(System.Collections.Generic.IEnumerable<System.Guid> input);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<IdentityUserDto>> UsuarioGetAsync(System.Collections.Generic.IEnumerable<System.Guid> input, System.Threading.CancellationToken cancellationToken);


        void SetAccessToken(string accessToken);

        void AddHeaders(string name, string value);
    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class IdentityUserDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("extraProperties")]
        public System.Collections.Generic.IDictionary<string, object> ExtraProperties { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public System.Guid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creationTime")]
        public System.DateTimeOffset CreationTime { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creatorId")]
        public System.Guid? CreatorId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lastModificationTime")]
        public System.DateTimeOffset? LastModificationTime { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lastModifierId")]
        public System.Guid? LastModifierId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deleterId")]
        public System.Guid? DeleterId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deletionTime")]
        public System.DateTimeOffset? DeletionTime { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("tenantId")]
        public System.Guid? TenantId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("userName")]
        public string UserName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("surname")]
        public string Surname { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public string Email { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("emailConfirmed")]
        public bool EmailConfirmed { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("phoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("userType")]
        public UserType UserType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("code")]
        public string Code { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lockoutEnd")]
        public System.DateTimeOffset? LockoutEnd { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("concurrencyStamp")]
        public string ConcurrencyStamp { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public enum UserType
    {

        _1 = 1,

        _2 = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class UsuarioCrearDto
    {

        [System.Text.Json.Serialization.JsonPropertyName("extraProperties")]
        public System.Collections.Generic.IDictionary<string, object> ExtraProperties { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("userName")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public string UserName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("surname")]
        [System.ComponentModel.DataAnnotations.StringLength(64)]
        public string Surname { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(256)]
        public string Email { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("phoneNumber")]
        [System.ComponentModel.DataAnnotations.StringLength(16)]
        public string PhoneNumber { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("roleNames")]
        public System.Collections.Generic.ICollection<string> RoleNames { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("userType")]
        public UserType UserType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("code")]
        [System.ComponentModel.DataAnnotations.StringLength(30)]
        public string Code { get; set; }

    }

}
