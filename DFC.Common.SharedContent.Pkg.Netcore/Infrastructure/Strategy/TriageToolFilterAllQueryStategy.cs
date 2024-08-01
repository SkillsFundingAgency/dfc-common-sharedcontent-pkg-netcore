using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
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
        string query = @$"
           query MyQuery {{
          triageLevelTwo(status: {filter}) {{
            title,
            ordinal,
    levelOneTitle,
            graphSync {{
              nodeId
            }}
          }}
        }}";

        var response = await client.SendQueryAsync<TraigeLevelTwoResponse>(query);

        return response.Data;
    }

}
public class TriageToolAllQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<TriageToolFilterResponse>
{
    private readonly IGraphQLClient client;
    private readonly ILogger<TriageToolAllQueryStrategy> logger;

    public TriageToolAllQueryStrategy(IGraphQLClient client, ILogger<TriageToolAllQueryStrategy> logger)
    {
        this.client = client;
        this.logger = logger;
    }

    public async Task<TriageToolFilterResponse> ExecuteQueryAsync(string key, string filter, double expire = 4)
    {
        string query = @$"
           query MyQuery {{
          triageToolFilter(status: {filter}) {{
            displayText
            graphSync {{
              nodeId
            }}
          }}
        }}";

        var response = await client.SendQueryAsync<TriageToolFilterResponse>(query);

        return response.Data;
    }
}