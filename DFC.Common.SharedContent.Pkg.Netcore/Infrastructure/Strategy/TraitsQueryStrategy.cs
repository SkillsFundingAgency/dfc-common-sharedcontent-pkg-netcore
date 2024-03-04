using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac.PersonalityTrait;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class TraitsQueryStrategy : ISharedContentRedisInterfaceStrategy<PersonalityTraitResponse>
{
    private readonly IGraphQLClient client;

    public TraitsQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<PersonalityTraitResponse> ExecuteQueryAsync(string key, string filter)
    {
        string traitsQuery = $@"
                query MyQuery {{
                  personalityTrait(status: {filter}) {{
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
        var traits = await Task.FromResult(response.Data);

        if (traits is not null)
        {
            foreach (var trait in traits.PersonalityTraits)
            {
                foreach (JobProfileCategory category in trait.JobProfileCategories.ContentItems)
                {
                    var jobProfileResponse = await client.SendQueryAsync<JobProfileDysacResponse>(string.Format(jobProfileQuery, category.ContentItemId));
                    category.JobProfiles = await Task.FromResult(jobProfileResponse.Data.JobProfile);
                }
            }
        }

        return traits;
    }
}