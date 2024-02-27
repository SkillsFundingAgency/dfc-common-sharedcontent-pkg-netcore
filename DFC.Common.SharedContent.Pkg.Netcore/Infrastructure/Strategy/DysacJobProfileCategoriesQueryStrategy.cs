using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;
public class DysacJobProfileCategoriesQueryStrategy : ISharedContentRedisInterfaceStrategy<Model.ContentItems.JobProfileCategoriesResponse>
{
    private readonly IGraphQLClient client;

    public DysacJobProfileCategoriesQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<Model.ContentItems.JobProfileCategoriesResponse> ExecuteQueryAsync(string key)
    {
        string jobProfileCategoryQuery = $@"
                query MyQuery {{
                  jobProfileCategory(status: PUBLISHED) {{
                    contentItemId
                    graphSync {{
                      nodeId
                    }}
                    displayText
                  }}
                }}
               ";

        string jobProfileQuery = @"
                query MyQuery {{
                  jobProfile(where: {{jobProfileSimplification: {{jobProfileCategory_contains: ""{0}""}}}}, status: PUBLISHED) {{
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

        var response = await client.SendQueryAsync<Model.ContentItems.JobProfileCategoriesResponse>(jobProfileCategoryQuery);
        var categories = await Task.FromResult(response.Data);

        foreach (var category in categories.JobProfileCategories)
        {
            var jobProfileResponse = await client.SendQueryAsync<JobProfileDysacResponse>(string.Format(jobProfileQuery, category.ContentItemId));

            foreach (var jobProfile in jobProfileResponse.Data.JobProfile)
            {
                if (jobProfile.Relatedskills.ContentItems.Count() > 0)
                {
                    int i = 0;
                    foreach (var skill in jobProfile.Relatedskills.ContentItems)
                    {
                        skill.Ordinal = i;
                        i++;
                    }
                }
            }

            category.JobProfiles = await Task.FromResult(jobProfileResponse.Data.JobProfile);
        }

        return categories;
    }
}