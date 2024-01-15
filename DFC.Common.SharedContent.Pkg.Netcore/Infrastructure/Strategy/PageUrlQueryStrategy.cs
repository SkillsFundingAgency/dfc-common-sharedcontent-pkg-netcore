using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class PageUrlQueryStrategy : ISharedContentRedisInterfaceStrategy<IList<PageUrl>>
    {
        private readonly IGraphQLClient client;

        public PageUrlQueryStrategy(IGraphQLClient client)
        {
            this.client = client;
        }

        public async Task<IList<PageUrl>> ExecuteQueryAsync(string key)
        {
            string query = @$"
                query pageurl {{
                    page(status: PUBLISHED) {{
                       displayText
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
                    triageToolFilters {{
                        contentItems {{
                        ... on TriageToolFilter {{
                            displayText
                        }}
                        }}
                    }} 
                    }}
                }}";
            var response = await client.SendQueryAsync<PageUrlReponse>(query);
            return response.Data.Page;
        }
    }
}
