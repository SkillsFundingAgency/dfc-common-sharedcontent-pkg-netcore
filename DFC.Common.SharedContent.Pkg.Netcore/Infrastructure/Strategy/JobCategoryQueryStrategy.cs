using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
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

        string jobProfileQuery = @"
                query MyQuery {{
                  jobProfile(first: 1000, where: {{jobProfileSimplification: {{jobProfileCategory_contains: ""{0}""}}}}) {{
                    displayText
                    graphSync {{
                      nodeId
                    }}
                    pageLocation {{
                      fullUrl
                    }}
                    relatedskills {{
                        contentItems {{
                        ... on SOCSkillsMatrix {{
                            displayText
                            relatedSkill
                            oNetAttributeType
                            oNetRank
                            graphSync {{
                                nodeId
                                }}
                            }}
                        }}
                    }}
                  }}
                }}
        ";

        var response = await client.SendQueryAsync<JobProfileCategoriesResponse>(jobProfileCategoryQuery);
        var categories = await Task.FromResult(response.Data);

        foreach (var category in categories.JobProfileCategories)
        {
            var jobProfileResponse = await client.SendQueryAsync<JobProfilesResponse>(string.Format(jobProfileQuery, category.ContentItemId));

            category.JobProfiles = await Task.FromResult(jobProfileResponse.Data.JobProfiles);
        }

        return categories;
    }
}