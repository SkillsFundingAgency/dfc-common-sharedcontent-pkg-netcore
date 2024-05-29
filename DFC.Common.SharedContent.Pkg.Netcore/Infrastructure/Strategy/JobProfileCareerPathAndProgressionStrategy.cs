using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileCareerPathAndProgressionStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileCareerPathAndProgressionResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileCareerPathAndProgressionStrategy> logger;

        public JobProfileCareerPathAndProgressionStrategy(IGraphQLClient client, ILogger<JobProfileCareerPathAndProgressionStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileCareerPathAndProgressionResponse> ExecuteQueryAsync(string key, string filter, double expire = 24)
        {
            var text = string.Concat("/", key.Substring(key.LastIndexOf("/") + 1));

            logger.LogInformation("JobProfileCareerPathAndProgressionResponse -> ExecuteQueryAsync");
            string query = @$"query JobProfileCareerPathProgression {{
              jobProfile(where: {{pageLocation: {{url: ""{text}""}}}}, status: {filter}) {{
                displayText
                careerpathandprogression {{
                  html
                }}
              }}
            }}";

            var response = await client.SendQueryAsync<JobProfileCareerPathAndProgressionResponse>(query);
            var result = response.Data;
            return result.JobProileCareerPath.Count > 0 ? result : null;
        }
    }
}