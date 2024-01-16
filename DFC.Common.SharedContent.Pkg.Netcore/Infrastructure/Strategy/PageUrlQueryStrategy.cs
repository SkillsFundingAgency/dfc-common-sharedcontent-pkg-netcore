using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using DFC.Common.SharedContent.Pkg.Netcore.Repo;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class PageUrlQueryStrategy : ISharedContentRedisInterfaceStrategy<PageUrlReponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PageUrlQueryStrategy> logger;

        public PageUrlQueryStrategy(IGraphQLClient client, ILogger<PageUrlQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<PageUrlReponse> ExecuteQueryAsync(string key)
        {
            var index = key.IndexOf("url/") + 4;
            var status = key.Substring(index);//    page/url/PUBLISHED page/url/DRAFT
            logger.LogInformation("PageUrlQueryStrategy -> ExecuteQueryAsync ->  status="+status);
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
