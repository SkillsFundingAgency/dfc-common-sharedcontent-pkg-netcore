using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

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