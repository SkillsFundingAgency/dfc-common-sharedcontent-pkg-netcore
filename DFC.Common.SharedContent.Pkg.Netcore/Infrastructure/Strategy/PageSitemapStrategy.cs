using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.CacheRepository;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Pagination;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Sitemap;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class PageSitemapStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<SitemapResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PageSitemapStrategy> logger;
        private readonly ICacheRepository cacheRepository;

        public PageSitemapStrategy(IGraphQLClient client, ILogger<PageSitemapStrategy> logger, ICacheRepository cacheRepository)
        {
            this.client = client;
            this.logger = logger;
            this.cacheRepository = cacheRepository;
        }

        public async Task<SitemapResponse> ExecuteQueryAsync(string key, string filter, double expire = 4)
        {
            logger.LogInformation(" -> ExecuteQueryAsync");

            Func<SitemapResponse, List<PageSitemapModel>> recordSelectorFunc = pageSitemapModelList => pageSitemapModelList.Page;
            Func<List<PageSitemapModel>, SitemapResponse> mergerFunc = pageSitemapModelList => new SitemapResponse { Page = pageSitemapModelList };

            var response = await cacheRepository.GetQueryWithPagination(GetQuery(filter), recordSelectorFunc, mergerFunc);

            return response;
        }

        private string GetQuery(string filter)
        {
            string query = $@"query MyQuery {{
              page(first: {GraphQLConfig.PaginationCountToken},  skip: {GraphQLConfig.SkipCountToken}, status: {filter}) {{
                sitemap {{
                  changeFrequency
                  exclude
                  priority
                }}
                pageLocation {{
                  fullUrl
                  urlName
                  defaultPageForLocation
                }}
              }}
            }}";

            return query;
        }
    }
}
