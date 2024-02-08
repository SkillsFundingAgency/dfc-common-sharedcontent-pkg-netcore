using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileOverviewQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfileOverviewResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PageUrlQueryStrategy> logger;

        public JobProfileOverviewQueryStrategy(IGraphQLClient client, ILogger<PageUrlQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileOverviewResponse> ExecuteQueryAsync(string key)
        {
            logger.LogInformation("JobProfileOverviewQueryStrategy -> ExecuteQueryAsync");
            string query = @$"query MyQuery {{
                    jobProfile {{
                        overview
                        contentItemId
                    }}
                }}";

            var response = await client.SendQueryAsync<JobProfileOverviewResponse>(query);
            return await Task.FromResult(response.Data);
        }
    }
}