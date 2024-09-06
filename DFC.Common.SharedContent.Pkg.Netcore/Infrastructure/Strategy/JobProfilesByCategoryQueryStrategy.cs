using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfilesByCategoryQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfilesResponseExploreCareers>
    {
        private readonly IGraphQLClient client;

        public JobProfilesByCategoryQueryStrategy(IGraphQLClient client)
        {
            this.client = client;
        }

        public async Task<JobProfilesResponseExploreCareers> ExecuteQueryAsync(string key, string status, double expire = 4)
        {
            var filter = key.Substring(key.LastIndexOf("/") + 1);

            string categoryQuery = $@"query MyQuery {{
                jobProfileCategory(status: {status}, where: {{ pageLocation:{{ url: ""/{filter}""}}}}) {{
                    contentItemId
                }}
            }}";

            var responseCategory = await client.SendQueryAsync<JobProfileCategoriesResponseExploreCareers>(categoryQuery);

            var categoryId = responseCategory.Data.JobProfileCategories.FirstOrDefault()?.ContentItemId;

            string profileQuery = $@"query MyQuery {{
              jobProfile(status: {status}, 
                where: {{jobProfileSimplification: {{jobProfileCategory: ""{categoryId}""}}}}
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
