﻿using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using System.Runtime.InteropServices;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class PageQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<Page>
{
    private readonly IGraphQLClient client;

    public PageQueryStrategy(IGraphQLClient client)
    {
        this.client = client;
    }

    public async Task<Page> ExecuteQueryAsync(string key, string filter, double expire = 4)
    {
        var url = key.Substring(key.IndexOf('/'));

        string query = @$"
               query page {{
                  page(status: {filter}, first: 1 , where: {{pageLocation: {{url: ""{url}""}}}}) {{
                    displayText
                    useBrowserWidth
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