using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class GetByIdPageApiStrategy : ISharedContentRedisInterfaceStrategy<GetByPageApiResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<GetByIdPageApiStrategy> logger;

        public GetByIdPageApiStrategy(IGraphQLClient client, ILogger<GetByIdPageApiStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<GetByPageApiResponse> ExecuteQueryAsync(string key, string filter)
        {
            var nodeId = key.Substring(key.IndexOf('/') + 1);
            string query = $@"query MyQuery {{
  page(where: {{graphSync: {{nodeId_contains: ""{nodeId}""}}}}) {{
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

            var response = await client.SendQueryAsync<GetByPageApiResponse>(query);
            return response.Data;
        }
    }
}
