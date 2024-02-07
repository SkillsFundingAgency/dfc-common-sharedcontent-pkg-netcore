using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using System.Runtime.InteropServices;

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
        var status = key.Substring(key.LastIndexOf('/') + 1);
        var url = key.Substring(key.IndexOf('/'), key.Length - status.Length - key.IndexOf('/') - 1);

        string query = @$"
               query page {{
                  page(status: {status}, first: 1 , where: {{pageLocation: {{url: ""{url}""}}}}) {{
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
                        contentType
                        ... on Form {{
                            metadata {{
                                alignment
                                size
                               }}
                            form {{
                                method
                                action
                                }}
                            flow {{
                            widgets {{
                            ... on HTML {{
                            htmlBody {{
                                html
                                    }}
                                    }}
                                }}
                              }}
                            }}
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

        var response = await client.SendQueryAsync<PageResponse>(query);
        return await Task.FromResult(response.Data.Page.FirstOrDefault());
    }
}