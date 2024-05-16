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
    public class JobProfileApiSummaryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileApiSummaryResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileApiSummaryStrategy> logger;

        public JobProfileApiSummaryStrategy (IGraphQLClient client, ILogger<JobProfileApiSummaryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileApiSummaryResponse> ExecuteQueryAsync(string key, string filter, double expire = 24)
        {
            logger.LogInformation("JobProfileApiSummaryResponse -> ExecuteQueryAsync");

            string query = @$"query MyQuery {{
  jobProfile(first: 1000, status: PUBLISHED) {{
    displayText
    publishedUtc
    pageLocation {{
      urlName
      fullUrl
    }}
  }}
}}
";

            var response = await client.SendQueryAsync<JobProfileApiSummaryResponse>(query);
            return response.Data;
        }
    }
}
