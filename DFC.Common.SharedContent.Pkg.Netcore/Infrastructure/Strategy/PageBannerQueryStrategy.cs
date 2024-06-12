using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class PageBannerQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<PageBanner>
{
    private readonly IGraphQLClient client;
    private readonly ILogger<PageBannerQueryStrategy> logger;

    public PageBannerQueryStrategy(IGraphQLClient client, ILogger<PageBannerQueryStrategy> logger)
    {
        this.client = client;
        this.logger = logger;
    }

    public async Task<PageBanner> ExecuteQueryAsync(string key, string filter, double expire = 4)
    {
        var startIndex = key.IndexOf('/') + 1;
        var url = key.Substring(startIndex, key.Length - startIndex);
        logger.LogInformation("PageBannerQueryStrategy -> ExecuteQueryAsync ->  url=" + url);
        string query = @$"
               query PageBanner {{
                  pagebanner(where: {{banner: {{webPageURL: ""{url}""}}}}, status: {filter}) {{
                    banner {{
                      webPageURL
                      webPageName
                    }}
                    graphSync {{
                      nodeId
                      }}
                    addabanner {{
                      contentItems {{
                        ... on Banner {{
                          graphSync {{
                            nodeId
                          }}
                          displayText
                          isGlobal
                          isActive
                          content {{
                            html
                          }}
                        }}
                      }}
                    }}
                  }}
                }}
            ";

        var response = await client.SendQueryAsync<PageBannerResponse>(query);
        return await Task.FromResult(response.Data.PageBanner.FirstOrDefault());
    }
}