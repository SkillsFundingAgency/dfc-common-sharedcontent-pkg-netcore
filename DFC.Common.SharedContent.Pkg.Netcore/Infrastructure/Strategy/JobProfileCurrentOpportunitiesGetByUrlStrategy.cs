using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles;
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
    public class JobProfileCurrentOpportunitiesGetByUrlStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileCurrentOpportunitiesGetbyUrlReponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileCurrentOpportunitiesGetByUrlStrategy> logger;

        public JobProfileCurrentOpportunitiesGetByUrlStrategy(IGraphQLClient client, ILogger<JobProfileCurrentOpportunitiesGetByUrlStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileCurrentOpportunitiesGetbyUrlReponse> ExecuteQueryAsync(string key, string filter, double expire = 24)
        {
            logger.LogInformation("JobProfileCurrentOpportunitiesGetByUrlStrategy -> ExecuteQueryAsync");
            var url = string.Concat("/", key.Substring(key.LastIndexOf("/") + 1));
            string query = @$"query MyQuery {{
                  jobProfile(status: {filter}, where: {{pageLocation: {{url: ""{url}""}}}}) {{
                    displayText
                    coursekeywords
    
                    sOCCode {{
                      contentItems {{
                        ... on SOCCode {{
                          apprenticeshipStandards {{
                            contentItems {{
                              ... on ApprenticeshipStandard {{
                                lARScode
                              }}
                            }}
                          }}
                        }}
                      }}
                    }}
                  }}
                }}";

            var response = await client.SendQueryAsync<JobProfileCurrentOpportunitiesGetbyUrlReponse>(query);
            var result = await Task.FromResult(response.Data);
            return result.JobProfileCurrentOpportunitiesGetByUrl.Count > 0 ? result : null;
        }
    }
}
