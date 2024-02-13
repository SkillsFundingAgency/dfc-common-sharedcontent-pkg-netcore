using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;
using System;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

    public class PagesByTriageToolFilterStrategy : ISharedContentRedisInterfaceStrategy<TriagePage>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PagesByTriageToolFilterStrategy> logger;

        public PagesByTriageToolFilterStrategy(IGraphQLClient client, ILogger<PagesByTriageToolFilterStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }
  

    public async Task<TriagePage> ExecuteQueryAsync(string key)
        {

       
        string query = @$"
          query MyQuery {{
  page(orderBy: {{displayText: ASC}}) {{
    displayText
    triageToolFilters {{
      contentItems {{
        displayText
       }}
    }}
    graphSync {{
      nodeId
    }}
    useInTriageTool
  }}
}}
    
";
        var response = await client.SendQueryAsync<TriagePageResponse>(query);
        return response.Data.Page.FirstOrDefault();
        }
}

