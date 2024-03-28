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
    public class JobProfilesByCategoryQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfilesResponseExploreCareers>
    {
        private readonly IGraphQLClient client;

        public JobProfilesByCategoryQueryStrategy(IGraphQLClient client)
        {
            this.client = client;
        }

        public async Task<JobProfilesResponseExploreCareers> ExecuteQueryAsync(string key, string status)
        {
            var filter = key.Substring(key.LastIndexOf("/") + 1);
            filter = filter.Replace('-', ' ');

            string categoryQuery = $@"query MyQuery {{
                jobProfileCategory(status: {status}, where: {{ displayText: ""{filter}""}}) {{
                    contentItemId
                }}
            }}";

            var responseCategory = await client.SendQueryAsync<JobProfileCategoriesResponseExploreCareers>(categoryQuery);

            var categoryId = responseCategory.Data.JobProfileCategories.FirstOrDefault()?.ContentItemId;

            string profileQuery = $@"query MyQuery {{
              jobProfile(status: {status}, 
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

            var responseProfiles = await client.SendQueryAsync<JobProfilesResponseExploreCareers>(profileQuery);
            return responseProfiles.Data;
        }
    }
}
