using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;
public class DysacJobProfileCategoriesQueryStrategy : ISharedContentRedisInterfaceStrategy<Model.Common.JobProfileCategoriesResponse>
{
    private readonly IGraphQLClient client;

    public DysacJobProfileCategoriesQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<Model.Common.JobProfileCategoriesResponse> ExecuteQueryAsync(string key, string filter)
    {
        string jobProfileCategoryQuery = $@"
                query MyQuery {{
                  jobProfileCategory(where: {{displayText_not: ""null""}}, status: {filter}) {{
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
                  jobProfile(where: {{jobProfileSimplification: {{jobProfileCategory_contains: ""{0}""}}}}) {{
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
        string jobProfileQuerySecond = @"
                query MyQuery {{
                  jobProfile(first: 100, skip: 100, where: {{jobProfileSimplification: {{jobProfileCategory_contains: ""{0}""}}}}) {{
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
        var response = await client.SendQueryAsync<Model.Common.JobProfileCategoriesResponse>(jobProfileCategoryQuery);
        var categories = await Task.FromResult(response.Data);

        foreach (var category in categories.JobProfileCategories)
        {
            var jobProfileResponse = await client.SendQueryAsync<JobProfileDysacResponse>(string.Format(jobProfileQuery, category.ContentItemId));

            category.JobProfiles = await Task.FromResult(jobProfileResponse.Data.JobProfile);
            if (jobProfileResponse.Data.JobProfile.Count() == 100)
            {
                var jobProfileResponseSecond = await client.SendQueryAsync<JobProfileDysacResponse>(string.Format(jobProfileQuerySecond, category.ContentItemId));
                category.JobProfiles.AddRange(await Task.FromResult(jobProfileResponseSecond.Data.JobProfile));
            }
        }

        return categories;
    }
}