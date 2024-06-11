using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class SkillsQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<SkillsResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<SkillsQueryStrategy> logger;

        public SkillsQueryStrategy(IGraphQLClient client, ILogger<SkillsQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<SkillsResponse> ExecuteQueryAsync(string key, string filter, double expire = 24)
        {
            string query = $@"query MyQuery {{
              skill (first: 200, status: {filter}) {{
                displayText
                oNetElementId
                description
                graphSync {{
                  nodeId
                }}
              }}
            }}
            ";

            var response = await client.SendQueryAsync<SkillsResponse>(query);
            return response.Data;
        }
    }
}
