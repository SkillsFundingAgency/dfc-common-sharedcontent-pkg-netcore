using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac.PersonalityTrait;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class TraitsQueryStrategy : ISharedContentRedisInterfaceStrategy<PersonalityTrait>
{
    private readonly IGraphQLClient client;

    public TraitsQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<PersonalityTrait> ExecuteQueryAsync(string key)
    {
        var filter = key.Substring(key.LastIndexOf("/") + 1);
        string traitsQuery = $@"
                query MyQuery {{
                  personalityTrait(where: {{displayText: ""{filter}""}}, status: PUBLISHED) {{
                    displayText
                    description
                    graphSync {{
                      nodeId
                    }}
                    jobProfileCategories {{
                      contentItems {{
                        contentItemId
                        displayText
                        ... on JobProfileCategory {{
                          graphSync {{
                            nodeId
                          }}
                        }}
                      }}
                    }}
                  }}
                }}
               ";

        string jobProfileQuery = @"
                query MyQuery {{
                  jobProfile(
                    where: {{jobProfileSimplification: {{jobProfileCategory_contains: ""{0}""}}}}, status: PUBLISHED
                  ) {{
                    displayText
                    graphSync {{
                      nodeId
                    }}
                    pageLocation {{
                      fullUrl
                    }}
                  }}
                }}
        ";

        var response = await client.SendQueryAsync<PersonalityTraitResponse>(traitsQuery);
        var trait = await Task.FromResult(response.Data.PersonalityTraits.FirstOrDefault());

        foreach (JobProfileCategory category in trait.JobProfileCategories.ContentItems)
        {
            var jobProfileResponse = await client.SendQueryAsync<JobProfileDysacResponse>(string.Format(jobProfileQuery, category.ContentItemId));
            category.JobProfiles = await Task.FromResult(jobProfileResponse.Data.JobProfile);
        }
        return trait;
    }
}