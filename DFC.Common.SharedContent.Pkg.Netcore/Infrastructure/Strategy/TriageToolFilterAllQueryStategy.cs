using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class TriageToolAllQueryStrategy : ISharedContentRedisInterfaceStrategy<TriageToolFilter>
{
    private readonly IGraphQLClient client;
    private readonly ILogger<TriageToolAllQueryStrategy> logger;

    public TriageToolAllQueryStrategy(IGraphQLClient client, ILogger<TriageToolAllQueryStrategy> logger)
    {
        this.client = client;
        this.logger = logger;
    }

    public async Task<TriageToolFilter> ExecuteQueryAsync(string key)
    {
        string query = @$"
           query MyQuery {{
  triageToolFilter {{
    displayText
    graphSync {{
      nodeId
    }}
  }}
}}";

        var response = await client.SendQueryAsync<TriageToolFilterResponse>(query);

        //assign ordinal value
        var returnData = response.Data.TriageToolFilter.FirstOrDefault();

        return returnData;

    }
  
}