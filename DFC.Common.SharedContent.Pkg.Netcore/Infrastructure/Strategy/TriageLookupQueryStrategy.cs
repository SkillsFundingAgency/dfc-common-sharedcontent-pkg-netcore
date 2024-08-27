using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;
public class TriageLookupQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<TriageLookupResponse>
{
    private readonly IGraphQLClient client;
    private readonly ILogger<TriageLookupQueryStrategy> logger;

    public TriageLookupQueryStrategy(IGraphQLClient client, ILogger<TriageLookupQueryStrategy> logger)
    {
        this.client = client;
        this.logger = logger;
    }

    public async Task<TriageLookupResponse> ExecuteQueryAsync(string key, string filter, double expire = 4)
    {
        logger.LogInformation("TriageLookupQueryStrategy -> ExecuteQueryAsync");
        string query = @$"query MyQuery {{
                triageLevelTwo(status: {filter}) {{ 
                    title: displayText
                    value
                    contentItemId
                    filterAdviceGroup {{
                        contentItems {{
                            ... on FilterAdviceGroup {{
                                contentItemId
                            }}
                        }}
                    }}
                }}
                triageLevelOne(status: {filter}) {{
                    contentItemId
                    title: displayText
                    ordinal
                    value
                    levelTwo {{
                        contentItems {{
                            ... on TriageLevelTwo {{
                                contentItemId
                            }}
                        }}
                    }}
                }}
                filterAdviceGroup {{
                    title: displayText
                    triageTileImage
                    contentItemId
                }}
        }}";

        var response = await client.SendQueryAsync<TriageLookupResponse>(query);

        return response.Data;
    }
}
