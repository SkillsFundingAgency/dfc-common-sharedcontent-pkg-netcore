using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBreadcrumb;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using RestSharp;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class PageBreadcrumbQueryStrategy : ISharedContentRedisInterfaceStrategy<PageBreadcrumb>
    {
        private readonly IRestClient sqlClient;

        public PageBreadcrumbQueryStrategy(IRestClient client)
        {
            sqlClient = client;
        }

        public async Task<PageBreadcrumb> ExecuteQueryAsync(string key, string filter)
        {
            var request = new RestRequest("PageLocation");
            var response = await sqlClient.GetAsync<BreadcrumbResponse>(request);
            return response.Items.FirstOrDefault();
        }
    }
}
