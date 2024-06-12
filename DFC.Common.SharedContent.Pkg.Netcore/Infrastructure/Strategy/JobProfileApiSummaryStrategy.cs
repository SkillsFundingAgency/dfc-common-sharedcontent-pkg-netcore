using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.CacheRepository;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Pagination;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileApiSummaryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileApiSummaryResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileApiSummaryStrategy> logger;
        private readonly ICacheRepository cacheRepository;

        public JobProfileApiSummaryStrategy(IGraphQLClient client, ILogger<JobProfileApiSummaryStrategy> logger, ICacheRepository cacheRepository)
        {
            this.client = client;
            this.logger = logger;
            this.cacheRepository = cacheRepository;
        }

        public async Task<JobProfileApiSummaryResponse> ExecuteQueryAsync(string key, string filter, double expire = 24)
        {
            logger.LogInformation("JobProfileApiSummaryResponse -> ExecuteQueryAsync");

            Func<JobProfileApiSummaryResponse, List<JobProfileSummary>> recordSelectorFunc = jobProfileApiSummaryList => jobProfileApiSummaryList.JobProfileSummary;
            Func<List<JobProfileSummary>, JobProfileApiSummaryResponse> mergerFunc = jobProfileApiSummaryList => new JobProfileApiSummaryResponse { JobProfileSummary = jobProfileApiSummaryList };

            var response = await cacheRepository.GetQueryWithPagination(GetQuery(filter), recordSelectorFunc, mergerFunc);

            return response;
        }

        private string GetQuery(string filter)
        {
            string query = @$"query MyQuery {{
              jobProfile(first: {GraphQLConfig.PaginationCountToken},  skip: {GraphQLConfig.SkipCountToken}, status: {filter}) {{
                displayText
                publishedUtc
                pageLocation {{
                  urlName
                  fullUrl
                }}
              }}
            }}
            ";

            return query;
        }
    }
}
