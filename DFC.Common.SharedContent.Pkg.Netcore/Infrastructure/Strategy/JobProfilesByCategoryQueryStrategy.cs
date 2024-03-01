using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
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
    public class JobProfilesByCategoryQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfilesResponse>
    {
        private readonly IGraphQLClient client;

        public JobProfilesByCategoryQueryStrategy(IGraphQLClient client)
        {
            this.client = client;
        }

        public async Task<JobProfilesResponse> ExecuteQueryAsync(string key)
        {
            var filter = key.Substring(key.LastIndexOf("/") + 1);

            string categoryQuery = $@"query MyQuery {{
                jobProfileCategory(where: {{ displayText: ""{filter}""}}) {{
                    contentItemId
                }}
            }}";

            var responseCategory = await client.SendQueryAsync<Model.ContentItems.JobProfileCategoriesResponse>(categoryQuery);

            var categoryId = responseCategory.Data.JobProfileCategories.FirstOrDefault()?.ContentItemId;

            string profileQuery = $@"query MyQuery {{
              jobProfile(
                where: {{jobProfileSimplification: {{jobProfileCategory_contains: ""{categoryId}""}}}}
              ) {{
                displayText
                overview
                alternativeTitle
                pageLocation {{
                  urlName
                }}
              }}
            }}
            ";

            var responseProfiles = await client.SendQueryAsync<JobProfilesResponse>(profileQuery);
            return responseProfiles.Data;
        }
    }
}
