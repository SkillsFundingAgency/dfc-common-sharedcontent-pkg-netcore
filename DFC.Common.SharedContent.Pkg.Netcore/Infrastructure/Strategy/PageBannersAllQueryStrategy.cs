using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class PageBannersAllQueryStrategy : ISharedContentRedisInterfaceStrategy<PageBannerResponse>
{
    private readonly IGraphQLClient client;
    private readonly ILogger<PageBannerQueryStrategy> logger;

    public PageBannersAllQueryStrategy(IGraphQLClient client, ILogger<PageBannerQueryStrategy> logger)
    {
        this.client = client;
        this.logger = logger;
    }

    public async Task<PageBannerResponse> ExecuteQueryAsync(string key)
    {
        string query = @$"
               query PageBanner {{
                  pagebanner(status: PUBLISHED) {{
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
        return await Task.FromResult(response.Data);
    }
}