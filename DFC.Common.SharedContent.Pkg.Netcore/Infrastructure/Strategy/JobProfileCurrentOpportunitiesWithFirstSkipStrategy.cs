using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileCurrentOpportunitiesWithFirstSkipStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiryAndFirstSkip<JobProfileCurrentOpportunitiesResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileCurrentOpportunitiesStrategy> logger;

        public JobProfileCurrentOpportunitiesWithFirstSkipStrategy(IGraphQLClient client, ILogger<JobProfileCurrentOpportunitiesStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileCurrentOpportunitiesResponse> ExecuteQueryAsync(string key, string filter, int first, int skip, double expire = 24)
        {
            logger.LogInformation("JobProfileCurrentOpportunitiesStrategy -> ExecuteQueryAsync");
            string query = @$"query MyQuery {{
                  jobProfile(status: {filter}, first: {first}, skip: {skip}) {{
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