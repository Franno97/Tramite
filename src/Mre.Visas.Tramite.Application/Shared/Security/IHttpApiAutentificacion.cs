using Tramite.Abp.Replica;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Application.Shared.Security
{
    public interface IHttpApiAutentificacion
    {
        Task<bool> TryAuthenticateAsync(HttpClient client, string identityClientName = null, CancellationToken token = default(CancellationToken));

        Task<string> GetAccessTokenAsync(string identityClientName = null, CancellationToken token = default);
    }

    /// <summary>
    /// Basado en Volo.Abp.IdentityModel.IdentityModelAuthenticationService
    /// </summary>
    public class HttpApiAutentificacion : IHttpApiAutentificacion
    {
        public const string HttpClientName = "IdentityModelAuthenticationServiceHttpClientName";

        private readonly AbpIdentityClientOptions ClientOptions;
        private readonly IDistributedCache distributedCache;
        private readonly IDistributedCacheSerializer serializadorCache;
        private readonly ILogger<HttpApiAutentificacion> logger;

        public IHttpClientFactory HttpClientFactory { get; }

        public HttpApiAutentificacion(
            IOptions<AbpIdentityClientOptions> options,
            IDistributedCache distributedCache,
            IDistributedCacheSerializer serializadorCache,
            IHttpClientFactory httpClientFactory,
            ILogger<HttpApiAutentificacion> logger)
        {
            this.ClientOptions = options.Value;
            this.distributedCache = distributedCache;
            this.serializadorCache = serializadorCache;
            HttpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<bool> TryAuthenticateAsync(
                HttpClient client,
               string identityClientName = null,
               CancellationToken token = default(CancellationToken))
        {
            var accessToken = await GetAccessTokenOrNullAsync(identityClientName, token);
            if (accessToken == null)
            {
                return false;
            }

            SetAccessToken(client, accessToken);
            return true;

        }

        public async Task<string> GetAccessTokenAsync(string identityClientName = null, CancellationToken token = default)
        {
            var configuration = ClientOptions.GetClientConfiguration(identityClientName);
            if (configuration == null)
            {
                logger.LogWarning($"Could not find {nameof(IdentityClientConfiguration)} for {identityClientName}. Either define a configuration for {identityClientName} or set a default configuration.");
                return null;
            }

            return await GetAccessTokenAsync(configuration, token);
        }

        protected virtual async Task<string> GetAccessTokenOrNullAsync(string identityClientName, CancellationToken token = default(CancellationToken))
        {
            var configuration = ClientOptions.GetClientConfiguration(identityClientName);
            if (configuration == null)
            {
                logger.LogWarning($"Could not find {nameof(IdentityClientConfiguration)} for {identityClientName}. Either define a configuration for {identityClientName} or set a default configuration.");
                return null;
            }

            return await GetAccessTokenAsync(configuration, token);
        }


        protected virtual async Task<string> GetAccessTokenAsync(IdentityClientConfiguration configuration, CancellationToken token = default(CancellationToken))
        {
            var cacheKey = CalculateTokenCacheKey(configuration);
            var tokenCacheItem = await distributedCache.GetAsync(cacheKey);
            if (tokenCacheItem == null)
            {
                var tokenResponse = await GetTokenResponse(configuration, token);

                if (tokenResponse.IsError)
                {
                    if (tokenResponse.ErrorDescription != null)
                    {
                        throw new Exception($"Could not get token from the OpenId Connect server! ErrorType: {tokenResponse.ErrorType}. " +
                                               $"Error: {tokenResponse.Error}. ErrorDescription: {tokenResponse.ErrorDescription}. HttpStatusCode: {tokenResponse.HttpStatusCode}");
                    }

                    var rawError = tokenResponse.Raw;
                    var withoutInnerException = rawError.Split(new string[] { "<eof/>" }, StringSplitOptions.RemoveEmptyEntries);
                    throw new Exception(withoutInnerException[0]);
                }

                var identityModelTokenNew = new IdentityModelTokenCacheItem(tokenResponse.AccessToken);
                await distributedCache.SetAsync(cacheKey, serializadorCache.Serialize(identityModelTokenNew),
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(configuration.CacheAbsoluteExpiration)
                    });

                return identityModelTokenNew.AccessToken;
            }

            var identityModelToken = serializadorCache.Deserialize<IdentityModelTokenCacheItem>(tokenCacheItem);

            return identityModelToken.AccessToken;
        }

        protected virtual void SetAccessToken(HttpClient client, string accessToken)
        {
            //TODO: "Bearer" should be configurable
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        protected virtual async Task<IdentityModelDiscoveryDocumentCacheItem> GetDiscoveryResponse(IdentityClientConfiguration configuration)
        {
            var tokenEndpointUrlCacheKey = CalculateDiscoveryDocumentCacheKey(configuration);
            var discoveryDocumentCacheItem = await distributedCache.GetAsync(tokenEndpointUrlCacheKey);
            if (discoveryDocumentCacheItem == null)
            {
                DiscoveryDocumentResponse discoveryResponse;
                using (var httpClient = HttpClientFactory.CreateClient(HttpClientName))
                {
                    var request = new DiscoveryDocumentRequest
                    {
                        Address = configuration.Authority,
                        Policy =
                    {
                        RequireHttps = configuration.RequireHttps
                    }
                    };

                    discoveryResponse = await httpClient.GetDiscoveryDocumentAsync(request);
                }

                if (discoveryResponse.IsError)
                {
                    throw new Exception($"Could not retrieve the OpenId Connect discovery document! " +
                                           $"ErrorType: {discoveryResponse.ErrorType}. Error: {discoveryResponse.Error}");
                }

                var identityModelDiscoveryDocument = new IdentityModelDiscoveryDocumentCacheItem(discoveryResponse.TokenEndpoint, discoveryResponse.DeviceAuthorizationEndpoint);


                await distributedCache.SetAsync(tokenEndpointUrlCacheKey, serializadorCache.Serialize(identityModelDiscoveryDocument),
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(configuration.CacheAbsoluteExpiration)
                    });

                return identityModelDiscoveryDocument;
            }

            return serializadorCache.Deserialize<IdentityModelDiscoveryDocumentCacheItem>(discoveryDocumentCacheItem);
        }

        protected virtual async Task<TokenResponse> GetTokenResponse(IdentityClientConfiguration configuration, CancellationToken token = default(CancellationToken))
        {
            using (var httpClient = HttpClientFactory.CreateClient(HttpClientName))
            {
                AddHeaders(httpClient);

                switch (configuration.GrantType)
                {
                    case OidcConstants.GrantTypes.ClientCredentials:
                        return await httpClient.RequestClientCredentialsTokenAsync(
                            await CreateClientCredentialsTokenRequestAsync(configuration),
                            token
                        );
                    case OidcConstants.GrantTypes.Password:
                        return await httpClient.RequestPasswordTokenAsync(
                            await CreatePasswordTokenRequestAsync(configuration),
                            token
                        );

                    case OidcConstants.GrantTypes.DeviceCode:
                        return await RequestDeviceAuthorizationAsync(httpClient, configuration);

                    default:
                        throw new Exception("Grant type was not implemented: " + configuration.GrantType);
                }
            }
        }

        protected virtual async Task<PasswordTokenRequest> CreatePasswordTokenRequestAsync(IdentityClientConfiguration configuration)
        {
            var discoveryResponse = await GetDiscoveryResponse(configuration);
            var request = new PasswordTokenRequest
            {
                Address = discoveryResponse.TokenEndpoint,
                Scope = configuration.Scope,
                ClientId = configuration.ClientId,
                ClientSecret = configuration.ClientSecret,
                UserName = configuration.UserName,
                Password = configuration.UserPassword
            };


            await AddParametersToRequestAsync(configuration, request);

            return request;
        }

        protected virtual async Task<ClientCredentialsTokenRequest> CreateClientCredentialsTokenRequestAsync(IdentityClientConfiguration configuration)
        {
            var discoveryResponse = await GetDiscoveryResponse(configuration);
            var request = new ClientCredentialsTokenRequest
            {
                Address = discoveryResponse.TokenEndpoint,
                Scope = configuration.Scope,
                ClientId = configuration.ClientId,
                ClientSecret = configuration.ClientSecret
            };

            await AddParametersToRequestAsync(configuration, request);

            return request;
        }

        protected virtual async Task<TokenResponse> RequestDeviceAuthorizationAsync(HttpClient httpClient, IdentityClientConfiguration configuration)
        {
            var discoveryResponse = await GetDiscoveryResponse(configuration);
            var request = new DeviceAuthorizationRequest()
            {
                Address = discoveryResponse.DeviceAuthorizationEndpoint,
                Scope = configuration.Scope,
                ClientId = configuration.ClientId,
                ClientSecret = configuration.ClientSecret,
            };


            await AddParametersToRequestAsync(configuration, request);

            var response = await httpClient.RequestDeviceAuthorizationAsync(request);
            if (response.IsError)
            {
                throw new Exception(response.ErrorDescription);
            }

            logger.LogInformation($"First copy your one-time code: {response.UserCode}");
            logger.LogInformation($"Open {response.VerificationUri} in your browser...");

            for (var i = 0; i < ((response.ExpiresIn ?? 300) / response.Interval + 1); i++)
            {
                await Task.Delay(response.Interval * 1000);

                var tokenResponse = await httpClient.RequestDeviceTokenAsync(new DeviceTokenRequest
                {
                    Address = discoveryResponse.TokenEndpoint,
                    ClientId = configuration.ClientId,
                    ClientSecret = configuration.ClientSecret,
                    DeviceCode = response.DeviceCode
                });

                if (tokenResponse.IsError)
                {
                    switch (tokenResponse.Error)
                    {
                        case "slow_down":
                        case "authorization_pending":
                            break;

                        case "expired_token":
                            throw new Exception("This 'device_code' has expired. (expired_token)");

                        case "access_denied":
                            throw new Exception("User denies the request(access_denied)");
                    }
                }

                if (!tokenResponse.IsError)
                {
                    return tokenResponse;
                }
            }

            throw new Exception("Timeout!");
        }


        protected virtual Task AddParametersToRequestAsync(IdentityClientConfiguration configuration, ProtocolRequest request)
        {
            foreach (var pair in configuration.Where(p => p.Key.StartsWith("[o]", StringComparison.OrdinalIgnoreCase)))
            {
                request.Parameters.Add(pair);
            }

            return Task.CompletedTask;
        }

        protected virtual void AddHeaders(HttpClient client)
        {

        }

        protected virtual string CalculateDiscoveryDocumentCacheKey(IdentityClientConfiguration configuration)
        {
            return IdentityModelDiscoveryDocumentCacheItem.CalculateCacheKey(configuration);
        }

        protected virtual string CalculateTokenCacheKey(IdentityClientConfiguration configuration)
        {

            return IdentityModelTokenCacheItem.CalculateCacheKey(configuration);
        }
    }
}
