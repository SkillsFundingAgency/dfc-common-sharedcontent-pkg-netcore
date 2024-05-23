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
    public class JobProfileRelatedCareersQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<RelatedCareersResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileRelatedCareersQueryStrategy> logger;

        public JobProfileRelatedCareersQueryStrategy(IGraphQLClient client, ILogger<JobProfileRelatedCareersQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<RelatedCareersResponse> ExecuteQueryAsync(string key, string filter, double expire = 24)
        {
            var url = key.Substring(key.LastIndexOf('/') + 1);

            string query = $@"query MyQuery {{
  jobProfile(where: {{pageLocation: {{url: ""/{url}""}}}}, status: {filter}) {{
    displayText
    pageLocation {{
      urlName
      fullUrl
    }}
    relatedcareerprofiles {{
      contentItems(first: 5) {{
        ... on JobProfile {{
          displayText
          pageLocation {{
            urlName
            fullUrl
          }}
          graphSync {{
            nodeId
          }}
        }}
        contentItemId
      }}
    }}
  }}
}}
";

            var response = await client.SendQueryAsync<RelatedCareersResponse>(query);
            var result = response.Data;
            return result.JobProfileRelatedCareers.Count > 0 ? result : null;
        }
    }
}
