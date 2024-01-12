using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using System.IO;
using System.Runtime.CompilerServices;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class PageQueryStrategy : ISharedContentRedisInterfaceStrategy<Page>
{
    private readonly IGraphQLClient client;

    public PageQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<Page> ExecuteQueryAsync(string key)
    {
        var startIndex = key.IndexOf('/');
        var result = key.Substring(startIndex, key.Length - startIndex);

        //GraphQL or SQL query here
        string query = @$"
               query page {{
                  page(status: PUBLISHED, first: 1 , where: {{pageLocation: {{url: ""{result}""}}}}) {{
                    displayText
                    description
                    pageLocation {{
                      urlName
                      fullUrl
                      redirectLocations
                      defaultPageForLocation
                    }}
                    breadcrumb: pageLocations {{
                          termContentItems {{
                            ... on PageLocation {{
                              displayText
                              modifiedUtc
                              breadcrumbText
                            }}
                          }}
                        }}
                    showBreadcrumb
                    showHeroBanner
                    herobanner {{
                        html
                    }}
                    useInTriageTool
                    triageToolSummary {{
                      html
                    }}
                    triageToolFilters {{
                      contentItems {{
                        ... on TriageToolFilter {{
                          displayText
                        }}
                      }}
                    }}
                    flow {{
                      widgets {{
                        ... on HTML {{
                          metadata {{
                            alignment
                            size
                          }}
                          htmlBody {{
                            html
                          }}
                        }}
                        
                        ... on HTMLShared {{
                          metadata {{
                            alignment
                            size
                          }}
                          sharedContent {{
                            contentItems {{
                              ... on SharedContent {{
                                displayText
                                content {{
                                  html
                                }}
                              }}
                            }}
                          }}
                        }}
                      }}
                    }}
                  }}
                }}
";

        //This will return the result of the query
        var response = await client.SendQueryAsync<PageResponse>(query);
        //return await Task.FromResult(response.Data);
        return await Task.FromResult(response.Data.Page.FirstOrDefault());
    }
}