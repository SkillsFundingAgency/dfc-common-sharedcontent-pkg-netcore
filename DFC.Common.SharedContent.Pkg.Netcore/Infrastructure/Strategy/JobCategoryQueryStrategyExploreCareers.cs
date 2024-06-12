using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class JobCategoryQueryStrategyExploreCareers : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileCategoriesResponseExploreCareers>
{
    private readonly IGraphQLClient client;

    public JobCategoryQueryStrategyExploreCareers(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<JobProfileCategoriesResponseExploreCareers> ExecuteQueryAsync(string key, string filter, double expire = 4)
    {
        string jobProfileCategoryQuery = $@"
                query MyQuery {{
                  jobProfileCategory(where: {{displayText_not: ""null""}}, status: {filter}) {{
                    contentItemId
                    graphSync {{
                      nodeId
                    }}
                    displayText
                    pageLocation {{
                      fullUrl
                      urlName
                    }}
                  }}
                }}
               ";

        var response = await client.SendQueryAsync<JobProfileCategoriesResponseExploreCareers>(jobProfileCategoryQuery);
        var categories = await Task.FromResult(response.Data);

        return categories;
    }
}