using System.Net.Http.Headers;

namespace Mre.Visas.Tramite.Application.Shared.HttpApiClient
{
  [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class UnidadAdministrativaClient : IUnidadAdministrativaClient
  {
    private System.Net.Http.HttpClient _httpClient;
    private System.Lazy<System.Text.Json.JsonSerializerOptions> _settings;

    public virtual void SetAccessToken(string accessToken)
    {
      _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    public virtual void AddHeaders(string name, string value)
    {
      _httpClient.DefaultRequestHeaders.Add(name, value);
    }

    public UnidadAdministrativaClient(System.Net.Http.HttpClient httpClient)
    {
      _httpClient = httpClient;
      _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings);
    }

    private System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
    {
      var settings = new System.Text.Json.JsonSerializerOptions();
      UpdateJsonSerializerSettings(settings);
      return settings;
    }

    protected System.Text.Json.JsonSerializerOptions JsonSerializerSettings { get { return _settings.Value; } }

    partial void UpdateJsonSerializerSettings(System.Text.Json.JsonSerializerOptions settings);

    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
    partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ArancelGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount)
    {
      return ArancelGetAsync(filter, sorting, skipCount, maxResultCount, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ArancelGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel?");
      if (filter != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Filter") + "=").Append(System.Uri.EscapeDataString(ConvertToString(filter, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ArancelDto> ArancelPostAsync(CrearActualizarArancelDto body)
    {
      return ArancelPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ArancelDto> ArancelPostAsync(CrearActualizarArancelDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ArancelDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ArancelDto> ArancelGetAsync(System.Guid id)
    {
      return ArancelGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ArancelDto> ArancelGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ArancelDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ArancelDto> ArancelPutAsync(System.Guid id, CrearActualizarArancelDto body)
    {
      return ArancelPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ArancelDto> ArancelPutAsync(System.Guid id, CrearActualizarArancelDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ArancelDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task ArancelDeleteAsync(System.Guid id)
    {
      return ArancelDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task ArancelDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfBancoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> BancoGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return BancoGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfBancoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> BancoGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/banco?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfBancoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<BancoDto> BancoPostAsync(BancoDto body)
    {
      return BancoPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<BancoDto> BancoPostAsync(BancoDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/banco");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<BancoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<BancoDto> BancoGetAsync(string id)
    {
      return BancoGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<BancoDto> BancoGetAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/banco/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<BancoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<BancoDto> BancoPutAsync(string id, BancoDto body)
    {
      return BancoPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<BancoDto> BancoPutAsync(string id, BancoDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/banco/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<BancoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task BancoDeleteAsync(string id)
    {
      return BancoDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task BancoDeleteAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/banco/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task ConfigurarFirmaElectronicaGetAsync(System.Guid usuarioId)
    {
      return ConfigurarFirmaElectronicaGetAsync(usuarioId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task ConfigurarFirmaElectronicaGetAsync(System.Guid usuarioId, System.Threading.CancellationToken cancellationToken)
    {
      if (usuarioId == null)
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

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<bool> ConfigurarFirmaElectronicaPutAsync(FileParameter archivoFirma, string claveFirma)
    {
      return ConfigurarFirmaElectronicaPutAsync(archivoFirma, claveFirma, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<bool> ConfigurarFirmaElectronicaPutAsync(FileParameter archivoFirma, string claveFirma, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/configurar-firma-electronica");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var boundary_ = System.Guid.NewGuid().ToString();
          var content_ = new System.Net.Http.MultipartFormDataContent(boundary_);
          content_.Headers.Remove("Content-Type");
          content_.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary_);

          if (archivoFirma == null)
            throw new System.ArgumentNullException("archivoFirma");
          else
          {
            var content_archivoFirma_ = new System.Net.Http.StreamContent(archivoFirma.Data);
            if (!string.IsNullOrEmpty(archivoFirma.ContentType))
              content_archivoFirma_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(archivoFirma.ContentType);
            content_.Add(content_archivoFirma_, "archivoFirma", archivoFirma.FileName ?? "archivoFirma");
          }

          if (claveFirma == null)
            throw new System.ArgumentNullException("claveFirma");
          else
          {
            content_.Add(new System.Net.Http.StringContent(ConvertToString(claveFirma, System.Globalization.CultureInfo.InvariantCulture)), "claveFirma");
          }
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<bool>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<bool> ConfigurarFirmaElectronicaDeleteAsync()
    {
      return ConfigurarFirmaElectronicaDeleteAsync(System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<bool> ConfigurarFirmaElectronicaDeleteAsync(System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/configurar-firma-electronica");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<bool>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfConvenioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ConvenioGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount)
    {
      return ConvenioGetAsync(filter, sorting, skipCount, maxResultCount, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfConvenioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ConvenioGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/convenio?");
      if (filter != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Filter") + "=").Append(System.Uri.EscapeDataString(ConvertToString(filter, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfConvenioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ConvenioDto> ConvenioPostAsync(CrearActualizarConvenioDto body)
    {
      return ConvenioPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ConvenioDto> ConvenioPostAsync(CrearActualizarConvenioDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/convenio");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ConvenioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ConvenioDto> ConvenioGetAsync(System.Guid id)
    {
      return ConvenioGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ConvenioDto> ConvenioGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/convenio/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ConvenioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ConvenioDto> ConvenioPutAsync(System.Guid id, CrearActualizarConvenioDto body)
    {
      return ConvenioPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ConvenioDto> ConvenioPutAsync(System.Guid id, CrearActualizarConvenioDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/convenio/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ConvenioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task ConvenioDeleteAsync(System.Guid id)
    {
      return ConvenioDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task ConvenioDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/convenio/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfEntidadAuspicianteDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> EntidadAuspicianteGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return EntidadAuspicianteGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfEntidadAuspicianteDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> EntidadAuspicianteGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/entidad-auspiciante?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfEntidadAuspicianteDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspiciantePostAsync(EntidadAuspicianteDto body)
    {
      return EntidadAuspiciantePostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspiciantePostAsync(EntidadAuspicianteDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/entidad-auspiciante");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<EntidadAuspicianteDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspicianteGetAsync(string id)
    {
      return EntidadAuspicianteGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspicianteGetAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/entidad-auspiciante/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<EntidadAuspicianteDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspiciantePutAsync(string id, EntidadAuspicianteDto body)
    {
      return EntidadAuspiciantePutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<EntidadAuspicianteDto> EntidadAuspiciantePutAsync(string id, EntidadAuspicianteDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/entidad-auspiciante/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<EntidadAuspicianteDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task EntidadAuspicianteDeleteAsync(string id)
    {
      return EntidadAuspicianteDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task EntidadAuspicianteDeleteAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/entidad-auspiciante/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfJerarquiaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JerarquiaArancelariaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount)
    {
      return JerarquiaArancelariaGetAsync(filter, sorting, skipCount, maxResultCount, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfJerarquiaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JerarquiaArancelariaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/jerarquia-arancelaria?");
      if (filter != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Filter") + "=").Append(System.Uri.EscapeDataString(ConvertToString(filter, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfJerarquiaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaPostAsync(CrearActualizarJerarquiaArancelariaDto body)
    {
      return JerarquiaArancelariaPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaPostAsync(CrearActualizarJerarquiaArancelariaDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/jerarquia-arancelaria");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<JerarquiaArancelariaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaGetAsync(System.Guid id)
    {
      return JerarquiaArancelariaGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/jerarquia-arancelaria/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<JerarquiaArancelariaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaPutAsync(System.Guid id, CrearActualizarJerarquiaArancelariaDto body)
    {
      return JerarquiaArancelariaPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaArancelariaPutAsync(System.Guid id, CrearActualizarJerarquiaArancelariaDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/jerarquia-arancelaria/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<JerarquiaArancelariaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task JerarquiaArancelariaDeleteAsync(System.Guid id)
    {
      return JerarquiaArancelariaDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task JerarquiaArancelariaDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/jerarquia-arancelaria/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LibroGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return LibroGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LibroGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/libro?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<LibroDto> LibroPostAsync(LibroDto body)
    {
      return LibroPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<LibroDto> LibroPostAsync(LibroDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/libro");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<LibroDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<LibroDto> LibroGetAsync(string id)
    {
      return LibroGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<LibroDto> LibroGetAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/libro/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<LibroDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<LibroDto> LibroPutAsync(string id, LibroDto body)
    {
      return LibroPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<LibroDto> LibroPutAsync(string id, LibroDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/libro/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<LibroDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task LibroDeleteAsync(string id)
    {
      return LibroDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task LibroDeleteAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/libro/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfMonedaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> MonedaGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return MonedaGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfMonedaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> MonedaGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/moneda?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfMonedaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<MonedaDto> MonedaPostAsync(MonedaDto body)
    {
      return MonedaPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<MonedaDto> MonedaPostAsync(MonedaDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/moneda");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<MonedaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<MonedaDto> MonedaGetAsync(string id)
    {
      return MonedaGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<MonedaDto> MonedaGetAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/moneda/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<MonedaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<MonedaDto> MonedaPutAsync(string id, MonedaDto body)
    {
      return MonedaPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<MonedaDto> MonedaPutAsync(string id, MonedaDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/moneda/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<MonedaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task MonedaDeleteAsync(string id)
    {
      return MonedaDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task MonedaDeleteAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/moneda/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfNivelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> NivelGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return NivelGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfNivelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> NivelGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/nivel?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfNivelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<NivelDto> NivelPostAsync(NivelDto body)
    {
      return NivelPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<NivelDto> NivelPostAsync(NivelDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/nivel");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<NivelDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<NivelDto> NivelGetAsync(string id)
    {
      return NivelGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<NivelDto> NivelGetAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/nivel/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<NivelDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<NivelDto> NivelPutAsync(string id, NivelDto body)
    {
      return NivelPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<NivelDto> NivelPutAsync(string id, NivelDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/nivel/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<NivelDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task NivelDeleteAsync(string id)
    {
      return NivelDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task NivelDeleteAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/nivel/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfPartidaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PartidaArancelariaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount)
    {
      return PartidaArancelariaGetAsync(filter, sorting, skipCount, maxResultCount, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfPartidaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PartidaArancelariaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/partida-arancelaria?");
      if (filter != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Filter") + "=").Append(System.Uri.EscapeDataString(ConvertToString(filter, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfPartidaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaPostAsync(CrearActualizarPartidaArancelariaDto body)
    {
      return PartidaArancelariaPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaPostAsync(CrearActualizarPartidaArancelariaDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/partida-arancelaria");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PartidaArancelariaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaGetAsync(System.Guid id)
    {
      return PartidaArancelariaGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/partida-arancelaria/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PartidaArancelariaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaPutAsync(System.Guid id, CrearActualizarPartidaArancelariaDto body)
    {
      return PartidaArancelariaPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PartidaArancelariaDto> PartidaArancelariaPutAsync(System.Guid id, CrearActualizarPartidaArancelariaDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/partida-arancelaria/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PartidaArancelariaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task PartidaArancelariaDeleteAsync(System.Guid id)
    {
      return PartidaArancelariaDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task PartidaArancelariaDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/partida-arancelaria/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ListResultDto_1OfOfPartidaArancelariaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PartidaArancelariaServicioAsync(System.Guid servicioId)
    {
      return PartidaArancelariaServicioAsync(servicioId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ListResultDto_1OfOfPartidaArancelariaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PartidaArancelariaServicioAsync(System.Guid servicioId, System.Threading.CancellationToken cancellationToken)
    {
      if (servicioId == null)
        throw new System.ArgumentNullException("servicioId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/partida-arancelaria-servicio/{servicioId}");
      urlBuilder_.Replace("{servicioId}", System.Uri.EscapeDataString(ConvertToString(servicioId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ListResultDto_1OfOfPartidaArancelariaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfSecuencialLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> SecuencialLibroGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return SecuencialLibroGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfSecuencialLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> SecuencialLibroGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/secuencial-libro?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfSecuencialLibroDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroPostAsync(CrearActualizarSecuencialLibroDto body)
    {
      return SecuencialLibroPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroPostAsync(CrearActualizarSecuencialLibroDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/secuencial-libro");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<SecuencialLibroDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroGetAsync(System.Guid id)
    {
      return SecuencialLibroGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/secuencial-libro/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<SecuencialLibroDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroPutAsync(System.Guid id, CrearActualizarSecuencialLibroDto body)
    {
      return SecuencialLibroPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<SecuencialLibroDto> SecuencialLibroPutAsync(System.Guid id, CrearActualizarSecuencialLibroDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/secuencial-libro/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<SecuencialLibroDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task SecuencialLibroDeleteAsync(System.Guid id)
    {
      return SecuencialLibroDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task SecuencialLibroDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/secuencial-libro/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount)
    {
      return ServicioGetAsync(filter, sorting, skipCount, maxResultCount, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/servicio?");
      if (filter != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Filter") + "=").Append(System.Uri.EscapeDataString(ConvertToString(filter, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ServicioDto> ServicioPostAsync(CrearActualizarServicioDto body)
    {
      return ServicioPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ServicioDto> ServicioPostAsync(CrearActualizarServicioDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/servicio");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ServicioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ServicioDto> ServicioGetAsync(System.Guid id)
    {
      return ServicioGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ServicioDto> ServicioGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/servicio/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ServicioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ServicioDto> ServicioPutAsync(System.Guid id, CrearActualizarServicioDto body)
    {
      return ServicioPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ServicioDto> ServicioPutAsync(System.Guid id, CrearActualizarServicioDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/servicio/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ServicioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task ServicioDeleteAsync(System.Guid id)
    {
      return ServicioDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task ServicioDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/servicio/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoArancelGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return TipoArancelGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoArancelGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-arancel?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfTipoArancelDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoArancelDto> TipoArancelPostAsync(TipoArancelDto body)
    {
      return TipoArancelPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoArancelDto> TipoArancelPostAsync(TipoArancelDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-arancel");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoArancelDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoArancelDto> TipoArancelGetAsync(string id)
    {
      return TipoArancelGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoArancelDto> TipoArancelGetAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-arancel/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoArancelDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoArancelDto> TipoArancelPutAsync(string id, TipoArancelDto body)
    {
      return TipoArancelPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoArancelDto> TipoArancelPutAsync(string id, TipoArancelDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-arancel/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoArancelDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task TipoArancelDeleteAsync(string id)
    {
      return TipoArancelDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task TipoArancelDeleteAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-arancel/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoExoneracionDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoExoneracionGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return TipoExoneracionGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoExoneracionDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoExoneracionGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-exoneracion?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfTipoExoneracionDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionPostAsync(TipoExoneracionDto body)
    {
      return TipoExoneracionPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionPostAsync(TipoExoneracionDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-exoneracion");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoExoneracionDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionGetAsync(string id)
    {
      return TipoExoneracionGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionGetAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-exoneracion/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoExoneracionDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionPutAsync(string id, TipoExoneracionDto body)
    {
      return TipoExoneracionPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoExoneracionDto> TipoExoneracionPutAsync(string id, TipoExoneracionDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-exoneracion/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoExoneracionDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task TipoExoneracionDeleteAsync(string id)
    {
      return TipoExoneracionDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task TipoExoneracionDeleteAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-exoneracion/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoPagoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoPagoGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return TipoPagoGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoPagoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TipoPagoGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-pago?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfTipoPagoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoPagoDto> TipoPagoPostAsync(TipoPagoDto body)
    {
      return TipoPagoPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoPagoDto> TipoPagoPostAsync(TipoPagoDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-pago");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoPagoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoPagoDto> TipoPagoGetAsync(string id)
    {
      return TipoPagoGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoPagoDto> TipoPagoGetAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-pago/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoPagoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoPagoDto> TipoPagoPutAsync(string id, TipoPagoDto body)
    {
      return TipoPagoPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoPagoDto> TipoPagoPutAsync(string id, TipoPagoDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-pago/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoPagoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task TipoPagoDeleteAsync(string id)
    {
      return TipoPagoDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task TipoPagoDeleteAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/tipo-pago/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioTipoGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return ServicioTipoGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfTipoServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioTipoGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/servicio-tipo?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfTipoServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoPostAsync(TipoServicioDto body)
    {
      return ServicioTipoPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoPostAsync(TipoServicioDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/servicio-tipo");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoServicioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoGetAsync(string id)
    {
      return ServicioTipoGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoGetAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/servicio-tipo/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoServicioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoPutAsync(string id, TipoServicioDto body)
    {
      return ServicioTipoPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<TipoServicioDto> ServicioTipoPutAsync(string id, TipoServicioDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/servicio-tipo/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<TipoServicioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task ServicioTipoDeleteAsync(string id)
    {
      return ServicioTipoDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task ServicioTipoDeleteAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/servicio-tipo/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaPostAsync(CrearActualizarUnidadAdministrativaDto body)
    {
      return UnidadAdministrativaPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaPostAsync(CrearActualizarUnidadAdministrativaDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<UnidadAdministrativaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> UnidadAdministrativaGetAsync(string filter, string tipoUnidadAdministrativaId, string sorting, int? skipCount, int? maxResultCount)
    {
      return UnidadAdministrativaGetAsync(filter, tipoUnidadAdministrativaId, sorting, skipCount, maxResultCount, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> UnidadAdministrativaGetAsync(string filter, string tipoUnidadAdministrativaId, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa?");
      if (filter != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Filter") + "=").Append(System.Uri.EscapeDataString(ConvertToString(filter, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (tipoUnidadAdministrativaId != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("TipoUnidadAdministrativaId") + "=").Append(System.Uri.EscapeDataString(ConvertToString(tipoUnidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfUnidadAdministrativaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaGetAsync(System.Guid id)
    {
      return UnidadAdministrativaGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<UnidadAdministrativaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaPutAsync(System.Guid id, CrearActualizarUnidadAdministrativaDto body)
    {
      return UnidadAdministrativaPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<UnidadAdministrativaDto> UnidadAdministrativaPutAsync(System.Guid id, CrearActualizarUnidadAdministrativaDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<UnidadAdministrativaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task UnidadAdministrativaDeleteAsync(System.Guid id)
    {
      return UnidadAdministrativaDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task UnidadAdministrativaDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync()
    {
      return LookupAsync(System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync(System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/lookup");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

   
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ListaIdsAsync(System.Collections.Generic.IEnumerable<System.Guid> ids)
    {
      return ListaIdsAsync(ids, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ListaIdsAsync(System.Collections.Generic.IEnumerable<System.Guid> ids, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/listaIds?");
      if (ids != null)
      {
        foreach (var item_ in ids) { urlBuilder_.Append(System.Uri.EscapeDataString("ids") + "=").Append(System.Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PaisAsync(string codigoPais)
    {
      return PaisAsync(codigoPais, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> PaisAsync(string codigoPais, System.Threading.CancellationToken cancellationToken)
    {
      if (codigoPais == null)
        throw new System.ArgumentNullException("codigoPais");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/pais/{codigoPais}");
      urlBuilder_.Replace("{codigoPais}", System.Uri.EscapeDataString(ConvertToString(codigoPais, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JurisdiccionAsync(string ciudad)
    {
      return JurisdiccionAsync(ciudad, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JurisdiccionAsync(string ciudad, System.Threading.CancellationToken cancellationToken)
    {
      if (ciudad == null)
        throw new System.ArgumentNullException("ciudad");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/jurisdiccion/{ciudad}");
      urlBuilder_.Replace("{ciudad}", System.Uri.EscapeDataString(ConvertToString(ciudad, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ListResultDto_1OfOfUnidadAdministrativaInfoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TiposervicioAsync(System.Guid administrativeUnitId, string tipoServicioId)
    {
      return TiposervicioAsync(administrativeUnitId, tipoServicioId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> TiposervicioAsync(System.Guid administrativeUnitId, string tipoServicioId, System.Threading.CancellationToken cancellationToken)
    {
      if (administrativeUnitId == null)
        throw new System.ArgumentNullException("administrativeUnitId");

      if (tipoServicioId == null)
        throw new System.ArgumentNullException("tipoServicioId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{administrativeUnitId}/tiposervicio/{tipoServicioId}");
      urlBuilder_.Replace("{administrativeUnitId}", System.Uri.EscapeDataString(ConvertToString(administrativeUnitId, System.Globalization.CultureInfo.InvariantCulture)));
      urlBuilder_.Replace("{tipoServicioId}", System.Uri.EscapeDataString(ConvertToString(tipoServicioId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task StateAsync(System.Guid unidadAdministrativaId, bool isActive)
    {
      return StateAsync(unidadAdministrativaId, isActive, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task StateAsync(System.Guid unidadAdministrativaId, bool isActive, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      if (isActive == null)
        throw new System.ArgumentNullException("isActive");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/state/{isActive}");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));
      urlBuilder_.Replace("{isActive}", System.Uri.EscapeDataString(ConvertToString(isActive, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
          request_.Method = new System.Net.Http.HttpMethod("PATCH");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task FuncionarioPostAsync(System.Guid unidadAdministrativaId, AgregarFuncionarioDto body)
    {
      return FuncionarioPostAsync(unidadAdministrativaId, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task FuncionarioPostAsync(System.Guid unidadAdministrativaId, AgregarFuncionarioDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/funcionario");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaFuncionalDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> FuncionarioGetAsync(System.Guid unidadAdministrativaId)
    {
      return FuncionarioGetAsync(unidadAdministrativaId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaFuncionalDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> FuncionarioGetAsync(System.Guid unidadAdministrativaId, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/funcionario");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfUnidadAdministrativaFuncionalDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task FuncionarioDeleteAsync(System.Guid unidadAdministrativaId, System.Guid userId)
    {
      return FuncionarioDeleteAsync(unidadAdministrativaId, userId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task FuncionarioDeleteAsync(System.Guid unidadAdministrativaId, System.Guid userId, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      if (userId == null)
        throw new System.ArgumentNullException("userId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/funcionario/{userId}");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));
      urlBuilder_.Replace("{userId}", System.Uri.EscapeDataString(ConvertToString(userId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task UnidadAdministrativaPutAsync(System.Guid unidadAdministrativaId, System.Guid userId)
    {
      return UnidadAdministrativaPutAsync(unidadAdministrativaId, userId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task UnidadAdministrativaPutAsync(System.Guid unidadAdministrativaId, System.Guid userId, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      if (userId == null)
        throw new System.ArgumentNullException("userId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/{userId}");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));
      urlBuilder_.Replace("{userId}", System.Uri.EscapeDataString(ConvertToString(userId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
          request_.Method = new System.Net.Http.HttpMethod("PUT");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioGetAsync(System.Guid unidadAdministrativaId, bool? activo, string sorting, int? skipCount, int? maxResultCount)
    {
      return ServicioGetAsync(unidadAdministrativaId, activo, sorting, skipCount, maxResultCount, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioGetAsync(System.Guid unidadAdministrativaId, bool? activo, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/servicio?");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));
      if (activo != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Activo") + "=").Append(System.Uri.EscapeDataString(ConvertToString(activo, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfUnidadAdministrativaServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioPostAsync(System.Guid unidadAdministrativaId, CrearUnidadAdministrativaServicioDto body)
    {
      return ServicioPostAsync(unidadAdministrativaId, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioPostAsync(System.Guid unidadAdministrativaId, CrearUnidadAdministrativaServicioDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/servicio");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<UnidadAdministrativaServicioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioGetAsync(System.Guid unidadAdministrativaId, System.Guid servicioId)
    {
      return ServicioGetAsync(unidadAdministrativaId, servicioId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioGetAsync(System.Guid unidadAdministrativaId, System.Guid servicioId, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      if (servicioId == null)
        throw new System.ArgumentNullException("servicioId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/servicio/{servicioId}");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));
      urlBuilder_.Replace("{servicioId}", System.Uri.EscapeDataString(ConvertToString(servicioId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<UnidadAdministrativaServicioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioPutAsync(System.Guid unidadAdministrativaId, System.Guid servicioId, ActualizarUnidadAdministrativaServicioDto body)
    {
      return ServicioPutAsync(unidadAdministrativaId, servicioId, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<UnidadAdministrativaServicioDto> ServicioPutAsync(System.Guid unidadAdministrativaId, System.Guid servicioId, ActualizarUnidadAdministrativaServicioDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      if (servicioId == null)
        throw new System.ArgumentNullException("servicioId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/servicio/{servicioId}");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));
      urlBuilder_.Replace("{servicioId}", System.Uri.EscapeDataString(ConvertToString(servicioId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<UnidadAdministrativaServicioDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task ServicioDeleteAsync(System.Guid unidadAdministrativaId, System.Guid servicioId)
    {
      return ServicioDeleteAsync(unidadAdministrativaId, servicioId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task ServicioDeleteAsync(System.Guid unidadAdministrativaId, System.Guid servicioId, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      if (servicioId == null)
        throw new System.ArgumentNullException("servicioId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/servicio/{servicioId}");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));
      urlBuilder_.Replace("{servicioId}", System.Uri.EscapeDataString(ConvertToString(servicioId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioTodoAsync(System.Guid unidadAdministrativaId)
    {
      return ServicioTodoAsync(unidadAdministrativaId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> ServicioTodoAsync(System.Guid unidadAdministrativaId, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/servicio-todo");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> RouteAsync(System.Guid unidadAdministrativaId)
    {
      return RouteAsync(unidadAdministrativaId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> RouteAsync(System.Guid unidadAdministrativaId, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/route");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ListResultDto_1OfOfServicioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfSignatarioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> SignatarioGetAsync(System.Guid unidadAdministrativaId)
    {
      return SignatarioGetAsync(unidadAdministrativaId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfSignatarioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> SignatarioGetAsync(System.Guid unidadAdministrativaId, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/signatario");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfSignatarioDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task SignatarioPostAsync(System.Guid unidadAdministrativaId, CrearSignatarioDto body)
    {
      return SignatarioPostAsync(unidadAdministrativaId, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task SignatarioPostAsync(System.Guid unidadAdministrativaId, CrearSignatarioDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (unidadAdministrativaId == null)
        throw new System.ArgumentNullException("unidadAdministrativaId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa/{unidadAdministrativaId}/signatario");
      urlBuilder_.Replace("{unidadAdministrativaId}", System.Uri.EscapeDataString(ConvertToString(unidadAdministrativaId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<UnidadAdministrativaInfoDto> UnidadAdministrativaFuncionalAsync(System.Guid? usuarioId)
    {
      return UnidadAdministrativaFuncionalAsync(usuarioId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<UnidadAdministrativaInfoDto> UnidadAdministrativaFuncionalAsync(System.Guid? usuarioId, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa-funcional?");
      if (usuarioId != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("usuarioId") + "=").Append(System.Uri.EscapeDataString(ConvertToString(usuarioId, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<UnidadAdministrativaInfoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaTipoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> UnidadAdministrativaTipoGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return UnidadAdministrativaTipoGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfUnidadAdministrativaTipoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> UnidadAdministrativaTipoGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa-tipo?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfUnidadAdministrativaTipoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoPostAsync(UnidadAdministrativaTipoDto body)
    {
      return UnidadAdministrativaTipoPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoPostAsync(UnidadAdministrativaTipoDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa-tipo");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<UnidadAdministrativaTipoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoGetAsync(string id)
    {
      return UnidadAdministrativaTipoGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoGetAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa-tipo/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<UnidadAdministrativaTipoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoPutAsync(string id, UnidadAdministrativaTipoDto body)
    {
      return UnidadAdministrativaTipoPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<UnidadAdministrativaTipoDto> UnidadAdministrativaTipoPutAsync(string id, UnidadAdministrativaTipoDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa-tipo/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<UnidadAdministrativaTipoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task UnidadAdministrativaTipoDeleteAsync(string id)
    {
      return UnidadAdministrativaTipoDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task UnidadAdministrativaTipoDeleteAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/unidad-administrativa-tipo/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfVentanillaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> VentanillaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount)
    {
      return VentanillaGetAsync(filter, sorting, skipCount, maxResultCount, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfVentanillaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> VentanillaGetAsync(string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/ventanilla?");
      if (filter != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Filter") + "=").Append(System.Uri.EscapeDataString(ConvertToString(filter, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfVentanillaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<VentanillaDto> VentanillaPostAsync(CrearActualizarVentanillaDto body)
    {
      return VentanillaPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<VentanillaDto> VentanillaPostAsync(CrearActualizarVentanillaDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/ventanilla");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<VentanillaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<VentanillaDto> VentanillaGetAsync(System.Guid id)
    {
      return VentanillaGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<VentanillaDto> VentanillaGetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/ventanilla/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<VentanillaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<VentanillaDto> VentanillaPutAsync(System.Guid id, CrearActualizarVentanillaDto body)
    {
      return VentanillaPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<VentanillaDto> VentanillaPutAsync(System.Guid id, CrearActualizarVentanillaDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/ventanilla/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<VentanillaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task VentanillaDeleteAsync(System.Guid id)
    {
      return VentanillaDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task VentanillaDeleteAsync(System.Guid id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/ventanilla/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    protected struct ObjectResponseResult<T>
    {
      public ObjectResponseResult(T responseObject, string responseText)
      {
        this.Object = responseObject;
        this.Text = responseText;
      }

      public T Object { get; }

      public string Text { get; }
    }

    public bool ReadResponseAsString { get; set; }

    protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
    {
      if (response == null || response.Content == null)
      {
        return new ObjectResponseResult<T>(default(T), string.Empty);
      }

      if (ReadResponseAsString)
      {
        var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        try
        {
          var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, JsonSerializerSettings);
          return new ObjectResponseResult<T>(typedBody, responseText);
        }
        catch (System.Text.Json.JsonException exception)
        {
          var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
          throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
        }
      }
      else
      {
        try
        {
          using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
          {
            var typedBody = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream, JsonSerializerSettings, cancellationToken).ConfigureAwait(false);
            return new ObjectResponseResult<T>(typedBody, string.Empty);
          }
        }
        catch (System.Text.Json.JsonException exception)
        {
          var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
          throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
        }
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

  [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial interface IArancelClient
  {
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<ListResultDto_1OfOfArancelLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync();

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<ListResultDto_1OfOfArancelLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync(System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task StateAsync(System.Guid id, bool isActive);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task StateAsync(System.Guid id, bool isActive, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<PagedResultDto_1OfOfJerarquiaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JerarquiaarancelariaGetAsync(System.Guid arancelId, string filter, string sorting, int? skipCount, int? maxResultCount);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<PagedResultDto_1OfOfJerarquiaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JerarquiaarancelariaGetAsync(System.Guid arancelId, string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaPostAsync(System.Guid arancelId, CrearActualizarJerarquiaArancelariaDto body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaPostAsync(System.Guid arancelId, CrearActualizarJerarquiaArancelariaDto body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaGetAsync(System.Guid arancelId, System.Guid jerarquiaId);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaGetAsync(System.Guid arancelId, System.Guid jerarquiaId, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaPutAsync(System.Guid arancelId, System.Guid jerarquiaId, CrearActualizarJerarquiaArancelariaDto body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaPutAsync(System.Guid arancelId, System.Guid jerarquiaId, CrearActualizarJerarquiaArancelariaDto body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task JerarquiaarancelariaDeleteAsync(System.Guid arancelId, System.Guid jerarquiaId);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task JerarquiaarancelariaDeleteAsync(System.Guid arancelId, System.Guid jerarquiaId, System.Threading.CancellationToken cancellationToken);

  }

  [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class ArancelClient : IArancelClient
  {
    private System.Net.Http.HttpClient _httpClient;
    private System.Lazy<System.Text.Json.JsonSerializerOptions> _settings;

    public ArancelClient(System.Net.Http.HttpClient httpClient)
    {
      _httpClient = httpClient;
      _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings);
    }

    private System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
    {
      var settings = new System.Text.Json.JsonSerializerOptions();
      UpdateJsonSerializerSettings(settings);
      return settings;
    }

    protected System.Text.Json.JsonSerializerOptions JsonSerializerSettings { get { return _settings.Value; } }

    partial void UpdateJsonSerializerSettings(System.Text.Json.JsonSerializerOptions settings);

    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
    partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ListResultDto_1OfOfArancelLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync()
    {
      return LookupAsync(System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ListResultDto_1OfOfArancelLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync(System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel/lookup");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ListResultDto_1OfOfArancelLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task StateAsync(System.Guid id, bool isActive)
    {
      return StateAsync(id, isActive, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task StateAsync(System.Guid id, bool isActive, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      if (isActive == null)
        throw new System.ArgumentNullException("isActive");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel/{id}/state/{isActive}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));
      urlBuilder_.Replace("{isActive}", System.Uri.EscapeDataString(ConvertToString(isActive, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json");
          request_.Method = new System.Net.Http.HttpMethod("PUT");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfJerarquiaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JerarquiaarancelariaGetAsync(System.Guid arancelId, string filter, string sorting, int? skipCount, int? maxResultCount)
    {
      return JerarquiaarancelariaGetAsync(arancelId, filter, sorting, skipCount, maxResultCount, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfJerarquiaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> JerarquiaarancelariaGetAsync(System.Guid arancelId, string filter, string sorting, int? skipCount, int? maxResultCount, System.Threading.CancellationToken cancellationToken)
    {
      if (arancelId == null)
        throw new System.ArgumentNullException("arancelId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel/{arancelId}/jerarquiaarancelaria?");
      urlBuilder_.Replace("{arancelId}", System.Uri.EscapeDataString(ConvertToString(arancelId, System.Globalization.CultureInfo.InvariantCulture)));
      if (filter != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Filter") + "=").Append(System.Uri.EscapeDataString(ConvertToString(filter, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfJerarquiaArancelariaDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaPostAsync(System.Guid arancelId, CrearActualizarJerarquiaArancelariaDto body)
    {
      return JerarquiaarancelariaPostAsync(arancelId, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaPostAsync(System.Guid arancelId, CrearActualizarJerarquiaArancelariaDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (arancelId == null)
        throw new System.ArgumentNullException("arancelId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel/{arancelId}/jerarquiaarancelaria");
      urlBuilder_.Replace("{arancelId}", System.Uri.EscapeDataString(ConvertToString(arancelId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<JerarquiaArancelariaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaGetAsync(System.Guid arancelId, System.Guid jerarquiaId)
    {
      return JerarquiaarancelariaGetAsync(arancelId, jerarquiaId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaGetAsync(System.Guid arancelId, System.Guid jerarquiaId, System.Threading.CancellationToken cancellationToken)
    {
      if (arancelId == null)
        throw new System.ArgumentNullException("arancelId");

      if (jerarquiaId == null)
        throw new System.ArgumentNullException("jerarquiaId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel/{arancelId}/jerarquiaarancelaria/{jerarquiaId}");
      urlBuilder_.Replace("{arancelId}", System.Uri.EscapeDataString(ConvertToString(arancelId, System.Globalization.CultureInfo.InvariantCulture)));
      urlBuilder_.Replace("{jerarquiaId}", System.Uri.EscapeDataString(ConvertToString(jerarquiaId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<JerarquiaArancelariaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaPutAsync(System.Guid arancelId, System.Guid jerarquiaId, CrearActualizarJerarquiaArancelariaDto body)
    {
      return JerarquiaarancelariaPutAsync(arancelId, jerarquiaId, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<JerarquiaArancelariaDto> JerarquiaarancelariaPutAsync(System.Guid arancelId, System.Guid jerarquiaId, CrearActualizarJerarquiaArancelariaDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (arancelId == null)
        throw new System.ArgumentNullException("arancelId");

      if (jerarquiaId == null)
        throw new System.ArgumentNullException("jerarquiaId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel/{arancelId}/jerarquiaarancelaria/{jerarquiaId}");
      urlBuilder_.Replace("{arancelId}", System.Uri.EscapeDataString(ConvertToString(arancelId, System.Globalization.CultureInfo.InvariantCulture)));
      urlBuilder_.Replace("{jerarquiaId}", System.Uri.EscapeDataString(ConvertToString(jerarquiaId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<JerarquiaArancelariaDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task JerarquiaarancelariaDeleteAsync(System.Guid arancelId, System.Guid jerarquiaId)
    {
      return JerarquiaarancelariaDeleteAsync(arancelId, jerarquiaId, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task JerarquiaarancelariaDeleteAsync(System.Guid arancelId, System.Guid jerarquiaId, System.Threading.CancellationToken cancellationToken)
    {
      if (arancelId == null)
        throw new System.ArgumentNullException("arancelId");

      if (jerarquiaId == null)
        throw new System.ArgumentNullException("jerarquiaId");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/arancel/{arancelId}/jerarquiaarancelaria/{jerarquiaId}");
      urlBuilder_.Replace("{arancelId}", System.Uri.EscapeDataString(ConvertToString(arancelId, System.Globalization.CultureInfo.InvariantCulture)));
      urlBuilder_.Replace("{jerarquiaId}", System.Uri.EscapeDataString(ConvertToString(jerarquiaId, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    protected struct ObjectResponseResult<T>
    {
      public ObjectResponseResult(T responseObject, string responseText)
      {
        this.Object = responseObject;
        this.Text = responseText;
      }

      public T Object { get; }

      public string Text { get; }
    }

    public bool ReadResponseAsString { get; set; }

    protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
    {
      if (response == null || response.Content == null)
      {
        return new ObjectResponseResult<T>(default(T), string.Empty);
      }

      if (ReadResponseAsString)
      {
        var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        try
        {
          var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, JsonSerializerSettings);
          return new ObjectResponseResult<T>(typedBody, responseText);
        }
        catch (System.Text.Json.JsonException exception)
        {
          var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
          throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
        }
      }
      else
      {
        try
        {
          using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
          {
            var typedBody = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream, JsonSerializerSettings, cancellationToken).ConfigureAwait(false);
            return new ObjectResponseResult<T>(typedBody, string.Empty);
          }
        }
        catch (System.Text.Json.JsonException exception)
        {
          var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
          throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
        }
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

  [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial interface IBancoClient
  {
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<ListResultDto_1OfOfBancoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync();

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<ListResultDto_1OfOfBancoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync(System.Threading.CancellationToken cancellationToken);

  }

  [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class BancoClient : IBancoClient
  {
    private System.Net.Http.HttpClient _httpClient;
    private System.Lazy<System.Text.Json.JsonSerializerOptions> _settings;

    public BancoClient(System.Net.Http.HttpClient httpClient)
    {
      _httpClient = httpClient;
      _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings);
    }

    private System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
    {
      var settings = new System.Text.Json.JsonSerializerOptions();
      UpdateJsonSerializerSettings(settings);
      return settings;
    }

    protected System.Text.Json.JsonSerializerOptions JsonSerializerSettings { get { return _settings.Value; } }

    partial void UpdateJsonSerializerSettings(System.Text.Json.JsonSerializerOptions settings);

    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
    partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ListResultDto_1OfOfBancoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync()
    {
      return LookupAsync(System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ListResultDto_1OfOfBancoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync(System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/unidad-administrativa/banco/lookup");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ListResultDto_1OfOfBancoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    protected struct ObjectResponseResult<T>
    {
      public ObjectResponseResult(T responseObject, string responseText)
      {
        this.Object = responseObject;
        this.Text = responseText;
      }

      public T Object { get; }

      public string Text { get; }
    }

    public bool ReadResponseAsString { get; set; }

    protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
    {
      if (response == null || response.Content == null)
      {
        return new ObjectResponseResult<T>(default(T), string.Empty);
      }

      if (ReadResponseAsString)
      {
        var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        try
        {
          var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, JsonSerializerSettings);
          return new ObjectResponseResult<T>(typedBody, responseText);
        }
        catch (System.Text.Json.JsonException exception)
        {
          var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
          throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
        }
      }
      else
      {
        try
        {
          using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
          {
            var typedBody = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream, JsonSerializerSettings, cancellationToken).ConfigureAwait(false);
            return new ObjectResponseResult<T>(typedBody, string.Empty);
          }
        }
        catch (System.Text.Json.JsonException exception)
        {
          var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
          throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
        }
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

  [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial interface IAdministrativeUnitClient
  {
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<PagedResultDto_1OfOfCargoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> CargoGetAsync(int? skipCount, int? maxResultCount, string sorting);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<PagedResultDto_1OfOfCargoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> CargoGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<CargoDto> CargoPostAsync(CargoDto body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<CargoDto> CargoPostAsync(CargoDto body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<CargoDto> CargoGetAsync(string id);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<CargoDto> CargoGetAsync(string id, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<CargoDto> CargoPutAsync(string id, CargoDto body);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<CargoDto> CargoPutAsync(string id, CargoDto body, System.Threading.CancellationToken cancellationToken);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task CargoDeleteAsync(string id);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task CargoDeleteAsync(string id, System.Threading.CancellationToken cancellationToken);

  }

  [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class AdministrativeUnitClient : IAdministrativeUnitClient
  {
    private System.Net.Http.HttpClient _httpClient;
    private System.Lazy<System.Text.Json.JsonSerializerOptions> _settings;

    public AdministrativeUnitClient(System.Net.Http.HttpClient httpClient)
    {
      _httpClient = httpClient;
      _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings);
    }

    private System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
    {
      var settings = new System.Text.Json.JsonSerializerOptions();
      UpdateJsonSerializerSettings(settings);
      return settings;
    }

    protected System.Text.Json.JsonSerializerOptions JsonSerializerSettings { get { return _settings.Value; } }

    partial void UpdateJsonSerializerSettings(System.Text.Json.JsonSerializerOptions settings);

    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
    partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<PagedResultDto_1OfOfCargoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> CargoGetAsync(int? skipCount, int? maxResultCount, string sorting)
    {
      return CargoGetAsync(skipCount, maxResultCount, sorting, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<PagedResultDto_1OfOfCargoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> CargoGetAsync(int? skipCount, int? maxResultCount, string sorting, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/AdministrativeUnit/cargo?");
      if (skipCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("SkipCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(skipCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (maxResultCount != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("MaxResultCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(maxResultCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      if (sorting != null)
      {
        urlBuilder_.Append(System.Uri.EscapeDataString("Sorting") + "=").Append(System.Uri.EscapeDataString(ConvertToString(sorting, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
      }
      urlBuilder_.Length--;

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<PagedResultDto_1OfOfCargoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<CargoDto> CargoPostAsync(CargoDto body)
    {
      return CargoPostAsync(body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<CargoDto> CargoPostAsync(CargoDto body, System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/AdministrativeUnit/cargo");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("POST");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<CargoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<CargoDto> CargoGetAsync(string id)
    {
      return CargoGetAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<CargoDto> CargoGetAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/AdministrativeUnit/cargo/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<CargoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<CargoDto> CargoPutAsync(string id, CargoDto body)
    {
      return CargoPutAsync(id, body, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<CargoDto> CargoPutAsync(string id, CargoDto body, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/AdministrativeUnit/cargo/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          var content_ = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(body, _settings.Value));
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod("PUT");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<CargoDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task CargoDeleteAsync(string id)
    {
      return CargoDeleteAsync(id, System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task CargoDeleteAsync(string id, System.Threading.CancellationToken cancellationToken)
    {
      if (id == null)
        throw new System.ArgumentNullException("id");

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/AdministrativeUnit/cargo/{id}");
      urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("DELETE");

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              return;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    protected struct ObjectResponseResult<T>
    {
      public ObjectResponseResult(T responseObject, string responseText)
      {
        this.Object = responseObject;
        this.Text = responseText;
      }

      public T Object { get; }

      public string Text { get; }
    }

    public bool ReadResponseAsString { get; set; }

    protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
    {
      if (response == null || response.Content == null)
      {
        return new ObjectResponseResult<T>(default(T), string.Empty);
      }

      if (ReadResponseAsString)
      {
        var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        try
        {
          var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, JsonSerializerSettings);
          return new ObjectResponseResult<T>(typedBody, responseText);
        }
        catch (System.Text.Json.JsonException exception)
        {
          var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
          throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
        }
      }
      else
      {
        try
        {
          using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
          {
            var typedBody = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream, JsonSerializerSettings, cancellationToken).ConfigureAwait(false);
            return new ObjectResponseResult<T>(typedBody, string.Empty);
          }
        }
        catch (System.Text.Json.JsonException exception)
        {
          var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
          throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
        }
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

  [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial interface ICargoClient
  {
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<ListResultDto_1OfOfCargoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync();

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<ListResultDto_1OfOfCargoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync(System.Threading.CancellationToken cancellationToken);

  }

  [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class CargoClient : ICargoClient
  {
    private System.Net.Http.HttpClient _httpClient;
    private System.Lazy<System.Text.Json.JsonSerializerOptions> _settings;

    public CargoClient(System.Net.Http.HttpClient httpClient)
    {
      _httpClient = httpClient;
      _settings = new System.Lazy<System.Text.Json.JsonSerializerOptions>(CreateSerializerSettings);
    }

    private System.Text.Json.JsonSerializerOptions CreateSerializerSettings()
    {
      var settings = new System.Text.Json.JsonSerializerOptions();
      UpdateJsonSerializerSettings(settings);
      return settings;
    }

    protected System.Text.Json.JsonSerializerOptions JsonSerializerSettings { get { return _settings.Value; } }

    partial void UpdateJsonSerializerSettings(System.Text.Json.JsonSerializerOptions settings);

    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
    partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
    partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual System.Threading.Tasks.Task<ListResultDto_1OfOfCargoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync()
    {
      return LookupAsync(System.Threading.CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Success</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async System.Threading.Tasks.Task<ListResultDto_1OfOfCargoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null> LookupAsync(System.Threading.CancellationToken cancellationToken)
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append("api/AdministrativeUnit/cargo/lookup");

      var client_ = _httpClient;
      var disposeClient_ = false;
      try
      {
        using (var request_ = new System.Net.Http.HttpRequestMessage())
        {
          request_.Method = new System.Net.Http.HttpMethod("GET");
          request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

          PrepareRequest(client_, request_, urlBuilder_);

          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

          PrepareRequest(client_, request_, url_);

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

            ProcessResponse(client_, response_);

            var status_ = (int)response_.StatusCode;
            if (status_ == 200)
            {
              var objectResponse_ = await ReadObjectResponseAsync<ListResultDto_1OfOfCargoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              return objectResponse_.Object;
            }
            else
            if (status_ == 403)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Forbidden", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 401)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Unauthorized", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 400)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Bad Request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 404)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Not Found", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 501)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
              var objectResponse_ = await ReadObjectResponseAsync<RemoteServiceErrorResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
              if (objectResponse_.Object == null)
              {
                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
              }
              throw new ApiException<RemoteServiceErrorResponse>("Server Error", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
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

    protected struct ObjectResponseResult<T>
    {
      public ObjectResponseResult(T responseObject, string responseText)
      {
        this.Object = responseObject;
        this.Text = responseText;
      }

      public T Object { get; }

      public string Text { get; }
    }

    public bool ReadResponseAsString { get; set; }

    protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
    {
      if (response == null || response.Content == null)
      {
        return new ObjectResponseResult<T>(default(T), string.Empty);
      }

      if (ReadResponseAsString)
      {
        var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        try
        {
          var typedBody = System.Text.Json.JsonSerializer.Deserialize<T>(responseText, JsonSerializerSettings);
          return new ObjectResponseResult<T>(typedBody, responseText);
        }
        catch (System.Text.Json.JsonException exception)
        {
          var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
          throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
        }
      }
      else
      {
        try
        {
          using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
          {
            var typedBody = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream, JsonSerializerSettings, cancellationToken).ConfigureAwait(false);
            return new ObjectResponseResult<T>(typedBody, string.Empty);
          }
        }
        catch (System.Text.Json.JsonException exception)
        {
          var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
          throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
        }
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

  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class ListResultDto_1OfOfArancelLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
  {

    [System.Text.Json.Serialization.JsonPropertyName("items")]
    public System.Collections.Generic.ICollection<ArancelLookupDto> Items { get; set; }

  }

  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class ListResultDto_1OfOfBancoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
  {

    [System.Text.Json.Serialization.JsonPropertyName("items")]
    public System.Collections.Generic.ICollection<BancoLookupDto> Items { get; set; }

  }
  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class ArancelLookupDto
  {

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public System.Guid Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("descripcion")]
    public string Descripcion { get; set; }

  }

  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class PagedResultDto_1OfOfCargoDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
  {

    [System.Text.Json.Serialization.JsonPropertyName("items")]
    public System.Collections.Generic.ICollection<CargoDto> Items { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("totalCount")]
    public long TotalCount { get; set; }

  }

  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class CargoDto
  {

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(8)]
    [System.ComponentModel.DataAnnotations.RegularExpression(@"^\w+$")]
    public string Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nombre")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(80)]
    public string Nombre { get; set; }

  }

  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class CargoLookupDto
  {

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public string Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("nombre")]
    public string Nombre { get; set; }

  }

  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v12.0.0.0))")]
  public partial class ListResultDto_1OfOfCargoLookupDtoAndContractsAnd_0AndCulture_neutralAndPublicKeyToken_null
  {

    [System.Text.Json.Serialization.JsonPropertyName("items")]
    public System.Collections.Generic.ICollection<CargoLookupDto> Items { get; set; }

  }
}
