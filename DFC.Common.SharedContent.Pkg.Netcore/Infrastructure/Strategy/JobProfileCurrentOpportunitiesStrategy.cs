using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;
using System;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileCurrentOpportunitiesStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileCurrentOpportunitiesResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PageUrlQueryStrategy> logger;

        public JobProfileCurrentOpportunitiesStrategy(IGraphQLClient client, ILogger<PageUrlQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileCurrentOpportunitiesResponse> ExecuteQueryAsync(string key, string filter, double expire = 4)
        {
            logger.LogInformation("JobProfileCurrentOpportunitiesStrategy -> ExecuteQueryAsync");
            string query = @$"query MyQuery {{
                  jobProfile(status: {filter}, first: 1000) {{
                    coursekeywords
                    graphSync {{
                      nodeId
                    }}
                    displayText
                    pageLocation {{
                      urlName
                    }}
                    sOCCode {{
                      contentItems {{
                        displayText
                        ... on SOCCode {{
                          apprenticeshipStandards {{
                            contentItems {{
                              displayText
                              ... on ApprenticeshipStandard {{
                                graphSync {{
                                  nodeId
                                }}
                                lARScode
                              }}
                            }}
                          }}
                        }}
                      }}
                    }}
                  }}
                }}";

            var response = await client.SendQueryAsync<JobProfileCurrentOpportunitiesResponse>(query);
            return await Task.FromResult(response.Data);
        }
    }
}