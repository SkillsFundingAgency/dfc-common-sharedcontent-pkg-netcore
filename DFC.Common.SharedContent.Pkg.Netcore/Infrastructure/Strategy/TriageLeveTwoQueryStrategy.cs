using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class TriageLeveTwoQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<TraigeLevelTwoResponse>
{
    private readonly IGraphQLClient client;
    private readonly ILogger<TriageLeveTwoQueryStrategy> logger;

    public TriageLeveTwoQueryStrategy(IGraphQLClient client, ILogger<TriageLeveTwoQueryStrategy> logger)
    {
        this.client = client;
        this.logger = logger;
    }

    public async Task<TraigeLevelTwoResponse> ExecuteQueryAsync(string key, string filter, double expire = 4)
    {
        logger.LogInformation("TriageLeveTwoQueryStrategy -> ExecuteQueryAsync");
        string query = @$"
           query MyQuery {{
          triageLevelTwo(status: {filter}) {{
            title: displayText
            ordinal
            value
            levelOne   {{
             contentItems {{
                ... on TriageLevelOne {{
                    title: displayText
          
                     }}
             }}
            }}
            graphSync {{
              nodeId
            }}
          }}
        }}";

        var response = await client.SendQueryAsync<TraigeLevelTwoResponse>(query);

        return response.Data;
    }
}
