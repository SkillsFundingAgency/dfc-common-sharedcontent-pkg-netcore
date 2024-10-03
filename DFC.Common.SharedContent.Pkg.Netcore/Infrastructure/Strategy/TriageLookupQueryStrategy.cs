using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL;
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

    public async Task<TriageLookupResponse> ExecuteQueryAsync(string key, string status, double expire = 4)
    {
        logger.LogInformation("TriageLookupQueryStrategy -> ExecuteQueryAsync");

        string query = @$"query MyQuery($status: Status!) {{
                triageLevelTwo(status: $status) {{ 
                    title: levelTwoTitle
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
                triageLevelOne(status: $status) {{
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
                filterAdviceGroup(status: $status) {{
                    title: filterGroupTitle
                    contentItemId
                }}
        }}";

        var response = await client.SendQueryAsync<TriageLookupResponse>(query, new { Status = status });

        return response.Data;
    }
}