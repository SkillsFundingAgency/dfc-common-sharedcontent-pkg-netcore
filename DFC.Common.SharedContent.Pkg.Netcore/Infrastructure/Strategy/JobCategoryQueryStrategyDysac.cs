using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using System.Text;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class JobCategoryQueryStrategyDysac : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileCategoriesResponseDysac>
{
    private readonly IGraphQLClient client;

    public JobCategoryQueryStrategyDysac(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<JobProfileCategoriesResponseDysac> ExecuteQueryAsync(string key, string filter, double expire = 4)
    {
        string jobProfileCategoryQuery = $@"
                query MyQuery {{
                  jobProfileCategory(where: {{displayText_not: ""null""}}, status: {filter}) {{
                    contentItemId
                    graphSync {{
                      nodeId
                    }}
                    displayText
                    imagePathDesktop
                    imagePathMobile
                    pageLocation {{
                      fullUrl
                      urlName
                    }}
                  }}
                }}
               ";

        var response = await client.SendQueryAsync<JobProfileCategoriesResponseDysac>(jobProfileCategoryQuery);
        var categories = await Task.FromResult(response.Data);

        foreach (var category in categories.JobProfileCategories)
        {
            int skip = 0;
            var jobProfileResponse = await client.SendQueryAsync<JobProfilesResponse>(string.Format(GetJobProfileQuery(skip), category.ContentItemId));
            category.JobProfiles = await Task.FromResult(jobProfileResponse.Data.JobProfiles);

            skip += 100;
            if (category.JobProfiles.Count() == skip)
            {
                jobProfileResponse = await client.SendQueryAsync<JobProfilesResponse>(string.Format(GetJobProfileQuery(skip), category.ContentItemId));
                category.JobProfiles.AddRange(await Task.FromResult(jobProfileResponse.Data.JobProfiles));
            }
        }

        return categories;
    }

    private string GetJobProfileQuery(int skip)
    {
        StringBuilder sb = new StringBuilder(@"
                query MyQuery {{
                  jobProfile(first: 100, skip: ");
        sb.Append(skip.ToString());
        sb.Append(@", where: {{jobProfileSimplification: {{jobProfileCategory_contains: ""{0}""}}}}) {{
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
        ");
        return sb.ToString();
    }
}