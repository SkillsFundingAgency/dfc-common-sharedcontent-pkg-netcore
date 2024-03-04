using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class JobCategoryQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfileCategoriesResponse>
{
    private readonly IGraphQLClient client;

    public JobCategoryQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<JobProfileCategoriesResponse> ExecuteQueryAsync(string key, string filter)
    {
        string query = $@"
                query JobProfileCategories {{
                  jobProfileCategory(status: {filter}) {{
                    displayText
                    pageLocation {{
                      fullUrl
                      urlName
                    }}
                  }}
                }}
               ";

        var response = await client.SendQueryAsync<JobProfileCategoriesResponse>(query);
        return await Task.FromResult(response.Data);
    }
}