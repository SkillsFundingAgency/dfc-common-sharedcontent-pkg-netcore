using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;
using System;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileOverviewQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfileDysacResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PageUrlQueryStrategy> logger;

        public JobProfileOverviewQueryStrategy(IGraphQLClient client, ILogger<PageUrlQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileDysacResponse> ExecuteQueryAsync(string key)
        {
            var startIndex = key.IndexOf('/') + 1;
            var jobProfile = key.Substring(startIndex, key.Length - startIndex);
            logger.LogInformation("JobProfileOverviewQueryStrategy -> ExecuteQueryAsync");
            string query = @$"query MyQuery {{
                                jobProfile(where: {{displayText: ""{jobProfile}""}}) {{
                                    displayText
                                    overview
                                    salarystarterperyear
                                    salaryexperiencedperyear
                                    pageLocation {{
                                        urlName
                                        fullUrl
                                    }}
                                    maximumhours
                                    minimumhours
                                    workingPattern {{
                                        contentItems {{
                                            displayText
                                            }}
                                        }}
                                    workingHoursDetails {{
                                        contentItems {{
                                            displayText
                                        }}
                                    }}
                                    workingPatternDetails {{
                                        contentItems {{
                                            displayText
                                        }}
                                    }}
                                }}
                            }}";

            var response = await client.SendQueryAsync<JobProfileDysacResponse>(query);
            return await Task.FromResult(response.Data);
        }
    }
}