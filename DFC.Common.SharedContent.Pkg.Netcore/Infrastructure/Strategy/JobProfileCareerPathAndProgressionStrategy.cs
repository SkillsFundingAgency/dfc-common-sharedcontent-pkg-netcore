using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileCareerPathAndProgressionStrategy : ISharedContentRedisInterfaceStrategy<JobProfileCareerPathAndProgressionResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileCareerPathAndProgressionStrategy> logger;

        public JobProfileCareerPathAndProgressionStrategy(IGraphQLClient client, ILogger<JobProfileCareerPathAndProgressionStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileCareerPathAndProgressionResponse> ExecuteQueryAsync(string key, string filter)
        {
            var text = string.Concat("/", key.Substring(key.LastIndexOf("/") + 1));

            logger.LogInformation("JobProfileCareerPathAndProgressionResponse -> ExecuteQueryAsync");
            string query = @$"query JobProfileCareerPathProgression {{
              jobProfile(where: {{pageLocation: {{url: ""{text}""}}}}) {{
                displayText
                careerpathandprogression {{
                  html
                }}
              }}
            }}";

            var response = await client.SendQueryAsync<JobProfileCareerPathAndProgressionResponse>(query);
            return response.Data;
        }
    }
}