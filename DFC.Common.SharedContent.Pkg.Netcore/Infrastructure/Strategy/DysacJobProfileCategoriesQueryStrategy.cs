using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac.PersonalityTrait;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;
public class DysacJobProfileCategoriesQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfileCategory>
{
    private readonly IGraphQLClient client;

    public DysacJobProfileCategoriesQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<JobProfileCategory> ExecuteQueryAsync(string key)
    {
        var filter = key.Substring(key.LastIndexOf("/") + 1);
        string jobProfileCategoryQuery = $@"
                query MyQuery {{
                  jobProfileCategory(where: {{displayText: ""{filter}""}}, status: PUBLISHED) {{
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
        var category = await Task.FromResult(response.Data.JobProfileCategories.FirstOrDefault());

        var jobProfileResponse = await client.SendQueryAsync<JobProfileDysacResponse>(string.Format(jobProfileQuery, category.ContentItemId));
        category.JobProfiles = await Task.FromResult(jobProfileResponse.Data.JobProfile);

        return category;
    }
}