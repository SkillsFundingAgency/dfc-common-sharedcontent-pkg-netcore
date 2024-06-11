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
    public class PageApiStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<PageApiResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PageApiStrategy> logger;
        private int pageLimit = 200;

        public PageApiStrategy(IGraphQLClient client, ILogger<PageApiStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<PageApiResponse> ExecuteQueryAsync(string key, string filter, double expire = 4)
        {
            string query = @$"query MyQuery {{
              page(first: {pageLimit}) {{
                displayText
                graphSync {{
                  nodeId
                }}
                contentItemId
                pageLocation {{
                  fullUrl
                }}
              }}
            }}
            ";

            var response = await client.SendQueryAsync<PageApiResponse>(query);
            return response.Data;
        }
    }
}