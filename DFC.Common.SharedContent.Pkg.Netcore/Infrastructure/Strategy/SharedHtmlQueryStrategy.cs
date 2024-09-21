using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.SharedHtml;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class SharedHtmlQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<SharedHtml>
{
    private readonly IGraphQLClient client;

    public SharedHtmlQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<SharedHtml> ExecuteQueryAsync(string key, string filter, double expire = 4)
    {
        var contentId = key.Substring(key.IndexOf('/') + 1);
        var nodeId = $@"<<contentapiprefix>>/sharedcontent/{contentId}";

        string query = $@"
        query sharedContent($nodeId: String!, $status: Status!) {{
           sharedContent(where: {{graphSync: {{nodeId: $nodeId}}}}, status: $status ) {{
             content {{
               html
             }}
           }}
         }}
        ";

        var response = await client.SendQueryAsync<SharedHtmlResponse>(query, new { NodeId = nodeId, Status = filter });

        if (response.Data.SharedContent.Count == 0)
        {
            response.Data.SharedContent.Add(new SharedHtmlContent() { Content = new SharedHtml() { Html = string.Empty } });
        }

        return await Task.FromResult(response.Data.SharedContent.FirstOrDefault().Content);
    }
}