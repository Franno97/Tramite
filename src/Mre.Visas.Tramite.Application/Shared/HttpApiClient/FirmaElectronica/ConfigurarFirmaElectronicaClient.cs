using System;
using System.Linq;
using System.Net.Http.Headers;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    public class ConfigurarFirmaElectronicaClient : IConfigurarFirmaElectronicaClient
    {

        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly System.Lazy<System.Text.Json.JsonSerializerOptions> _settings;

        public ConfigurarFirmaElectronicaClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
            _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings);
        }

        private System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
        {
            var settings = new System.Text.Json.JsonSerializerOptions();

            return settings;
        }


        public virtual void SetAccessToken(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public virtual void AddHeaders(string name, string value)
        {
            _httpClient.DefaultRequestHeaders.Add(name, value);
        }

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual System.Threading.Tasks.Task<ConfigurarFirmaElectronicaOutput> ConfigurarFirmaElectronicaGetAsync(System.Guid usuarioId)
        {
            return ConfigurarFirmaElectronicaGetAsync(usuarioId, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public virtual async System.Threading.Tasks.Task<ConfigurarFirmaElectronicaOutput> ConfigurarFirmaElectronicaGetAsync(System.Guid usuarioId, System.Threading.CancellationToken cancellationToken)
        {
            if (usuarioId == Guid.Empty)
                throw new System.ArgumentNullException("usuarioId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append("api/unidad-administrativa/configurar-firma-electronica?");
            urlBuilder_.Append(System.Uri.EscapeDataString("UsuarioId") + "=").Append(System.Uri.EscapeDataString(ConvertToString(usuarioId, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));


                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);


                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }


                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            if (response_.Content == null || response_.Content?.Headers?.ContentLength == null ||
                               response_.Content?.Headers?.ContentLength == 0)
                            {
                                return null;
                            }


                            byte[] bytes = await response_.Content.ReadAsByteArrayAsync();
                            var result = new ConfigurarFirmaElectronicaOutput();
                            result.Data = bytes;
                            result.Clave = headers_["X-MRE-SB-FIRMA-ELECTRONICA-CLAVE"]?.FirstOrDefault();

                            return result;


                        } else if (status_ == 404)
                        {
                            if (response_.Content == null || response_.Content?.Headers?.ContentLength ==null ||
                                response_.Content?.Headers?.ContentLength == 0)
                            {
                                return null;
                            }

                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);

                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }


        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is System.Enum)
            {
                var name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                    return converted == null ? string.Empty : converted;
                }
            }
            else if (value is bool)
            {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[])value);
            }
            else if (value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return result == null ? "" : result;
        }
    }


}
