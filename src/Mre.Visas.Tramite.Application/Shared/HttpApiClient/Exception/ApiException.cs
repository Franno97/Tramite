using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ApiException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class RemoteServiceErrorResponse
    {

        [System.Text.Json.Serialization.JsonPropertyName("error")]
        public RemoteServiceErrorInfo Error { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class RemoteServiceErrorInfo
    {

        [System.Text.Json.Serialization.JsonPropertyName("code")]
        public string Code { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("message")]
        public string Message { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("details")]
        public string Details { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("data")]
        public System.Collections.Generic.IDictionary<string, object> Data { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("validationErrors")]
        public System.Collections.Generic.ICollection<RemoteServiceValidationErrorInfo> ValidationErrors { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.5.0 (NJsonSchema v10.6.6.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class RemoteServiceValidationErrorInfo
    {

        [System.Text.Json.Serialization.JsonPropertyName("message")]
        public string Message { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("members")]
        public System.Collections.Generic.ICollection<string> Members { get; set; }

    }
}
