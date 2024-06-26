﻿using DFC.Common.SharedContent.Pkg.Netcore.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;

namespace DFC.Common.SharedContent.Pkg.Netcore.RequestHandler
{
    /// <summary>
    /// The GraphQLRequestHandler class.
    /// </summary>
    /// <seealso cref="System.Net.Http.HttpClientHandler" />
    public class CmsRequestHandler : HttpClientHandler
    {
        private IHttpClientFactory httpClientFactory;
        private IConfiguration config;
        private IHttpContextAccessor accessor;
        private IMemoryCache memoryCache;
        private const string OAuthTokenKey = "OAuthToken";

        /// <summary>
        /// Initializes a new instance of the <see cref="CmsRequestHandler"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="accessor">The accessor.</param>
        public CmsRequestHandler(
            IHttpClientFactory httpClientFactory,
            IConfiguration config,
            IHttpContextAccessor accessor,
            IMemoryCache memoryCache)
        {
            this.httpClientFactory = httpClientFactory;
            this.config = config;
            this.accessor = accessor;
            this.memoryCache = memoryCache;
        }

        /// <summary>
        /// Creates an instance of  <see cref="T:System.Net.Http.HttpResponseMessage" /> based on the information provided in the <see cref="T:System.Net.Http.HttpRequestMessage" /> as an operation that will not block.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>
        /// The task object representing the asynchronous operation.
        /// </returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await GetApiToken();
            request.Headers.Add(HeaderNames.Authorization, $"{CmsOpenIdConfig.AuthHeaderBearer} {token}");

            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            // do after call
            return response;
        }

        private async Task<string> GetApiToken()
        {
            if (memoryCache.TryGetValue(OAuthTokenKey, out OAuthTokenModel token))
            {
                if (token != null && token.ExpiryDatetime > DateTime.UtcNow)
                {
                    return token.AccessToken;
                }
            }

            // cache the token response.
            var tokenResponse = await GenerateApiToken<OAuthTokenModel>();
            tokenResponse.ExpiryDatetime = DateTime.UtcNow.AddSeconds(Convert.ToInt32(tokenResponse.ExpiresIn) - 120); // reduce by 120 seconds for time skew tolerance.
            memoryCache.Set(OAuthTokenKey, tokenResponse);
            return tokenResponse.AccessToken;
        }

        private async Task<TResponse> GenerateApiToken<TResponse>()
            where TResponse : class
        {
            try
            {
                var tokenEndpointUrl = config[ConfigKeys.TokenEndPointUrl];
                var clientId = config[ConfigKeys.ClientId];
                var clientSecret = config[ConfigKeys.ClientSecret];
                var client = httpClientFactory.CreateClient();
                var formData = new Dictionary<string, string>
                {
                    { CmsOpenIdConfig.ClientIdTokenRequestParam, clientId },
                    { CmsOpenIdConfig.ClientSecretTokenRequestParam, clientSecret },
                    { CmsOpenIdConfig.GrantTypeTokenRequestParam, CmsOpenIdConfig.GrantTypeTokenRequestParamValue },
                };

                var requestBody = new HttpRequestMessage(HttpMethod.Post, tokenEndpointUrl)
                {
                    Content = new FormUrlEncodedContent(formData),
                };

                using (HttpResponseMessage response = await client.SendAsync(requestBody))
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        // remove client secret from the exception logging
                        formData.Remove(CmsOpenIdConfig.ClientSecretTokenRequestParam);

                        string errorDetail = $"StatusCode:{response.StatusCode},\n ResponsePhrase:{response.ReasonPhrase},\n TokenEndPointUrl:{tokenEndpointUrl}, \n ResponseBody:{responseBody}, \n FormData:{string.Join(Environment.NewLine, formData)}";
                        throw new WebException($"Unable to retrieve token. Response details are : {errorDetail}");
                    }

                    return JsonConvert.DeserializeObject<TResponse>(responseBody);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
