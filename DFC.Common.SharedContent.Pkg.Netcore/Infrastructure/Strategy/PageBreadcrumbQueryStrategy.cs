using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBreadcrumb;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class PageBreadcrumbQueryStrategy : ISharedContentRedisInterfaceStrategy<PageBreadcrumb>
    {
        private readonly IRestClient sqlClient;


        public PageBreadcrumbQueryStrategy(IRestClient client)
        {
            this.sqlClient = client;
        }

        public async Task<PageBreadcrumb> ExecuteQueryAsync(string key)
        {
            //sql shit here

            var request = new RestRequest("PageLocation");
            var response = await sqlClient.GetAsync<BreadcrumbResponse>(request);
            return response.Items.FirstOrDefault();
        }
    }
}
