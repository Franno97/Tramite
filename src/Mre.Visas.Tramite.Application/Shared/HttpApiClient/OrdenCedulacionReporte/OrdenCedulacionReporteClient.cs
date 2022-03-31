using Mre.Visas.Tramite.Application.OrdenCedulacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{

    public class OrdenCedulacionReporteClient: IOrdenCedulacionReporteClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly System.Lazy<System.Text.Json.JsonSerializerOptions> _settings;

        public OrdenCedulacionReporteClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
            _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings);
        }

        private System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
        {
            var settings = new System.Text.Json.JsonSerializerOptions();
            settings.PropertyNameCaseInsensitive = true;
            settings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            return settings;
        }


        public virtual Task<OrdenCedulacionReporteResponse> GenerarAsync(OrdenCedulacionReporteRequest input)
        {
            return GenerarAsync(input, System.Threading.CancellationToken.None);
        }

        public virtual async Task<OrdenCedulacionReporteResponse> GenerarAsync(OrdenCedulacionReporteRequest input, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append("api/OrdenCedulacionReporte");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(input, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");

                 
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
                            if (response_.Content == null)
                            {
                                return null;
                            }


                            byte[] bytes = await response_.Content.ReadAsByteArrayAsync();
                            var result = new OrdenCedulacionReporteResponse();
                            result.Reporte = bytes;

                            return result;

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
 
    }
}
