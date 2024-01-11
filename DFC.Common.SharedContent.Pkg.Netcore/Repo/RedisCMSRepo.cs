using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Repo
{
    public class RedisCMSRepo : IRedisCMSRepo
    {
        private readonly IConfiguration config;
        private readonly IGraphQLClient client;
        private readonly IRestClient sqlClient;
        private readonly IRedisCacheRepo cacheRepo;

        public RedisCMSRepo(IGraphQLClient client, IConfiguration config, IRestClient sqlClient, IRedisCacheRepo cacheRepo)
        {
            this.config = config;
            this.client = client;
            this.sqlClient = sqlClient;
            this.cacheRepo = cacheRepo;
        }

        public async Task<TResponse> GetGraphQLData<TResponse>(string query, string cacheKey, bool disableCache = false) where TResponse : class
        {
            var response = await cacheRepo.GetGraphQLData<TResponse>(query, cacheKey, disableCache);

            return response.Data;
        }

        //Test again
        public async Task<TResponse> GetSqlData<TResponse>(string query, string cacheKey, bool disableCache = false)
        {
            var request = new RestRequest(query);
            var response = await this.sqlClient.GetAsync<TResponse>(request);
            return response;
        }
    }
}
