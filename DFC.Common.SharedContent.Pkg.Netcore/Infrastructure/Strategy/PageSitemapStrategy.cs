using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class PageSitemapStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<SitemapResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PageSitemapStrategy> logger;
        private readonly int sitemapLimit = 150;

        public PageSitemapStrategy(IGraphQLClient client, ILogger<PageSitemapStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<SitemapResponse> ExecuteQueryAsync(string key, string filter, double expire = 4)
        {
            string query = $@"query MyQuery {{
              page(first: {sitemapLimit}, status: {filter}) {{
                sitemap {{
                  changeFrequency
                  exclude
                  priority
                }}
                pageLocation {{
                  fullUrl
                  urlName
                  defaultPageForLocation
                }}
              }}
            }}

            ";

            var response = await client.SendQueryAsync<SitemapResponse>(query);
            return response.Data;
        }
    }
}
