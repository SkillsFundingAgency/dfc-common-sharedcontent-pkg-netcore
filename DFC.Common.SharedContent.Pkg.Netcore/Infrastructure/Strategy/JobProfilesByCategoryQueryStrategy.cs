using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBreadcrumb;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfilesByCategoryQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfilesResponse>
    {
        private readonly IRestClient sqlClient;

        public JobProfilesByCategoryQueryStrategy(IRestClient client)
        {
            this.sqlClient = client;
        }

        public async Task<JobProfilesResponse> ExecuteQueryAsync(string key)
        {
            var filter = key.Substring(key.IndexOf("/") + 1);
            var request = new RestRequest("JobProfilesByCategory?parameters={ urlName: \"" + filter + "\"}");
            var response = await sqlClient.GetAsync<JobProfilesResponse>(request);
            return response;
        }
    }
}
