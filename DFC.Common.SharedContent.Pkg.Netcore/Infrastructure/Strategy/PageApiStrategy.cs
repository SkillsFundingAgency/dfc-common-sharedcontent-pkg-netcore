using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.CacheRepository;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Pagination;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class PageApiStrategy : ISharedContentRedisInterfaceStrategy<PageApiResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PageApiStrategy> logger;
        private readonly ICacheRepository cacheRepository;

        public PageApiStrategy(IGraphQLClient client, ILogger<PageApiStrategy> logger, ICacheRepository cacheRepository)
        {
            this.client = client;
            this.logger = logger;
            this.cacheRepository = cacheRepository;
        }

        public async Task<PageApiResponse> ExecuteQueryAsync(string key, string filter)
        {
            logger.LogInformation("PageApiStrategy -> ExecuteQueryAsync");

            Func<PageApiResponse, List<PageApi>> recordSelectorFunc = pageApiList => pageApiList.Page;
            Func<List<PageApi>, PageApiResponse> mergerFunc = pageApiList => new PageApiResponse { Page = pageApiList };

            var response = await cacheRepository.GetQueryWithPagination(GetQuery(filter), recordSelectorFunc, mergerFunc);

            return response;
        }

        private string GetQuery(string filter)
        {
            string query = @$"query MyQuery {{
              page(first: {GraphQLConfig.PaginationCountToken},  skip: {GraphQLConfig.SkipCountToken}, status: {filter}) {{
                displayText
                graphSync {{
                  nodeId
                }}
                contentItemId
                pageLocation {{
                  fullUrl
                }}
              }}
            }}";

            return query;
        }
    }
}
