using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using System.Net;
using System;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.SharedHtml;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;


public class SharedHtmlQueryStrategy : ISharedContentRedisInterfaceStrategy<SharedHtml>
{

    private readonly IGraphQLClient client;

    public SharedHtmlQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<SharedHtml> ExecuteQueryAsync(string key)
    {
        var contentId = key.Substring(key.IndexOf('/') + 1);

        string query = $@"
               query sharedContent {{
                  sharedContent(where: {{graphSync: {{nodeId: ""<<contentapiprefix>>/sharedcontent/{contentId}""}}}}) {{
                    content {{
                      html
                    }}
                  }}
                }}
               ";


        var response = await client.SendQueryAsync<SharedHtmlResponse>(query);
        return await Task.FromResult(response.Data.SharedContent.FirstOrDefault().Content);
    }
}