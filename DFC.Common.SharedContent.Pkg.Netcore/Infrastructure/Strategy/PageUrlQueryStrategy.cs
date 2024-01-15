using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class PageUrlQueryStrategy : ISharedContentRedisInterfaceStrategy<PageUrlReponse>
    {
        private readonly IGraphQLClient client;

        public PageUrlQueryStrategy(IGraphQLClient client)
        {
            this.client = client;
        }

        public async Task<PageUrlReponse> ExecuteQueryAsync(string key)
        {
            var index = key.IndexOf("url/") + 4;
            var status = key.Substring(index);//    page/url/PUBLISHED page/url/DRAFT
            string query = @$"
                query pageurl {{
                    page(status: {status}) {{
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
            return response.Data;
        }
    }
}
