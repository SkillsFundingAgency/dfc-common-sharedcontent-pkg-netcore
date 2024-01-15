using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class PageBannerQueryStrategy : ISharedContentRedisInterfaceStrategy<PageBanner>
{
    private readonly IGraphQLClient client;

    public PageBannerQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<PageBanner> ExecuteQueryAsync(string key)
    {
        var startIndex = key.IndexOf('/');
        var url = key.Substring(startIndex, key.Length - startIndex);

        string query = @$"
               query PageBanner {{
                  pagebanner(where: {{banner: {{webPageURL: ""{url}""}}}}) {{
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