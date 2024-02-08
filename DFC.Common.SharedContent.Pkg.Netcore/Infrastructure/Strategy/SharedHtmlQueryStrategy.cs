using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.SharedHtml;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;

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
                  sharedContent(where: {{graphSync: {{nodeId: ""<<contentapiprefix>>/sharedcontent/{contentId}""}}}}, status: PUBLISHED) {{
                    content {{
                      html
                    }}
                  }}
                }}
               ";

        var response = await client.SendQueryAsync<SharedHtmlResponse>(query);

        if (response.Data.SharedContent.Count == 0)
        {
            response.Data.SharedContent.Add(new SharedHtmlContent() { Content = new SharedHtml() { Html = string.Empty } });
        }

        return await Task.FromResult(response.Data.SharedContent.FirstOrDefault().Content);
    }
}