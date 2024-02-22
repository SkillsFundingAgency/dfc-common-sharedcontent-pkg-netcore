using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Net.NetworkInformation;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

    public class PagesByTriageToolFilterStrategy : ISharedContentRedisInterfaceStrategy<TriagePageResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PagesByTriageToolFilterStrategy> logger;

        public PagesByTriageToolFilterStrategy(IGraphQLClient client, ILogger<PagesByTriageToolFilterStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }
  

    public async Task<TriagePageResponse> ExecuteQueryAsync(string key)
        {
        string query = @$"
         query page {{
                  page(where: {{pageLocation: {{useInTriageTool: true }}}}) {{
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
                          graphSync {{
                                nodeId
                      }}
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
        var response = await client.SendQueryAsync<TriagePageResponse>(query);
        return response.Data;
    }
}

