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
    public class JobProfileVideoQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileVideoResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileVideoQueryStrategy> logger;

        public JobProfileVideoQueryStrategy(IGraphQLClient client, ILogger<JobProfileVideoQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileVideoResponse> ExecuteQueryAsync(string key, string filter, double expire = 24)
        {
            var url = key.Substring(key.LastIndexOf('/') + 1);
            string query = $@"query JobProfileVideoQuery {{
  jobProfile(where: {{pageLocation: {{url: ""/{url}""}}}}, status: {filter}) {{
    displayText
    videoType
    videoTitle
    videoTranscript
    videoSummary {{
      html
    }}
    videoThumbnail {{
      paths
      urls
    }}
    videoUrl
    videoLinkText
    videoFurtherInformation {{
      html
    }}
    videoDuration
  }}
}}
";

            var response = await client.SendQueryAsync<JobProfileVideoResponse>(query);
            return response.Data;
        }
    }
}
