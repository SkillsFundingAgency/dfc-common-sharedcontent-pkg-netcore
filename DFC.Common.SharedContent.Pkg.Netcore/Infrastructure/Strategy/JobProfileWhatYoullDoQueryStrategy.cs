using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileWhatYoullDoQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfileWhatYoullDoResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileWhatYoullDoQueryStrategy> logger;

        public JobProfileWhatYoullDoQueryStrategy(IGraphQLClient client, ILogger<JobProfileWhatYoullDoQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileWhatYoullDoResponse> ExecuteQueryAsync(string key, string filter)
        {
            logger.LogInformation($"{nameof(JobProfileWhatYoullDoQueryStrategy)} -> ExecuteQueryAsync");

            var urlName = key.Substring(key.LastIndexOf('/') + 1);

            string query = $@"query JobProfileWhatYoullDo {{
              jobProfile(where: {{pageLocation: {{url: ""/{urlName}""}}}}, status: {filter}) {{
                displayText
                daytodaytasks {{
                  html
                }}
                relatedLocations {{
                  contentItems {{
                    ... on Location {{
                      description
                    }}
                  }}
                }}
                relatedEnvironments {{
                  contentItems {{
                    ... on Environment {{
                      description
                    }}
                  }}
                }}
                relatedUniforms {{
                  contentItems {{
                    ... on Uniform {{
                      description
                    }}
                  }}
                }}
              }}
            }}";

            var response = await client.SendQueryAsync<JobProfileWhatYoullDoResponse>(query);
            return response.Data;
        }
    }
}
