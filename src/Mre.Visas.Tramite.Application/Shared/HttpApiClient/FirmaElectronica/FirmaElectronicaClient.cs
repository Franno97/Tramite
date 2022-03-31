using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
    public class FirmaElectronicaClient : IFirmaElectronicaClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly System.Lazy<System.Text.Json.JsonSerializerOptions> _settings;

        public FirmaElectronicaClient(System.Net.Http.HttpClient httpClient)
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


        public virtual Task<FirmaElectronicaOutput> FirmarAsync(FirmaElectronicaInput input)
        {
            return FirmarAsync(input, System.Threading.CancellationToken.None);
        }

        public virtual async Task<FirmaElectronicaOutput> FirmarAsync(FirmaElectronicaInput input, CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append("/mremh.firmadigital-web/rest/firmarelectronicamente/generico");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {

                    var content_ = new MultipartFormDataContent();

                    var documentoContent_ = new ByteArrayContent(input.Documento);
                    documentoContent_.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    documentoContent_.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        FileName = "documento.pdf",
                        Name = "documento",
                    };

                    content_.Add(documentoContent_, "documento");

                    var firmaContent_ = new ByteArrayContent(input.Firma);
                    firmaContent_.Headers.ContentType = new MediaTypeHeaderValue("application/x-pkcs12");
                    firmaContent_.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        FileName = "firma.pdf",
                        Name = "firma",
                    };

                    content_.Add(firmaContent_, "firma");


                    var insumosFirma_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(input.InsumosFirma, _settings.Value));
                    content_.Add(insumosFirma_, "insumosFirma");


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
                            var result = new FirmaElectronicaOutput();
                            result.DocumentoFirmado = bytes;

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
