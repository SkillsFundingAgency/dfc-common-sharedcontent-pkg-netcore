using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.CacheRepository;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Pagination;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class SkillsQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<SkillsResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<SkillsQueryStrategy> logger;
        private readonly ICacheRepository cacheRepository;

        public SkillsQueryStrategy(IGraphQLClient client, ILogger<SkillsQueryStrategy> logger, ICacheRepository cacheRepository)
        {
            this.client = client;
            this.logger = logger;
            this.cacheRepository = cacheRepository;
        }

        public async Task<SkillsResponse> ExecuteQueryAsync(string key, string filter, double expire = 24)
        {
            logger.LogInformation("SkillsQueryStrategy -> ExecuteQueryAsync");

            Func<SkillsResponse, List<Skills>> recordSelectorFunc = skillsList => skillsList.Skill;
            Func<List<Skills>, SkillsResponse> mergerFunc = skillsList => new SkillsResponse { Skill = skillsList };

            var response = await cacheRepository.GetQueryWithPagination(GetQuery(filter), recordSelectorFunc, mergerFunc);

            return response;
        }

        private string GetQuery(string filter)
        {
            string query = $@"query MyQuery {{
              skill (first: {GraphQLConfig.PaginationCountToken},  skip: {GraphQLConfig.SkipCountToken}, status: {filter}) {{
                displayText
                oNetElementId
                description
                graphSync {{
                  nodeId
                }}
              }}
            }}";

            return query;
        }
    }
}
