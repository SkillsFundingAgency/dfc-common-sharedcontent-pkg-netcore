using DFC.Common.SharedContent.Pkg.Netcore.Model;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using static DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class JobCategoryQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfileCategoriesResponse>
{
    private readonly IGraphQLClient client;

    public JobCategoryQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<JobProfileCategoriesResponse> ExecuteQueryAsync(string key)
    {
        string query = $@"
                query JobProfileCategories {{
                  jobProfileCategory {{
                    displayText
                    pageLocation {{
                      fullUrl
                    }}
                  }}
                }}
               ";

        var response = await client.SendQueryAsync<JobProfileCategoriesResponse>(query);
        return await Task.FromResult(response.Data);
    }
}