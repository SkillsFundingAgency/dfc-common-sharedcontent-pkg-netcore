using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileOverviewProfileSpecificQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfilesOverviewResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileOverviewProfileSpecificQueryStrategy> logger;

        public JobProfileOverviewProfileSpecificQueryStrategy(IGraphQLClient client, ILogger<JobProfileOverviewProfileSpecificQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfilesOverviewResponse> ExecuteQueryAsync(string key, string filter)
        {
            logger.LogInformation("JobProfileOverviewProfileSpecificQueryStrategy -> ExecuteQueryAsync");

            var text = string.Concat("/", key.Substring(key.LastIndexOf("/") + 1));

            string query = @$"query JobProfileOverview {{
                  jobProfile(where: {{pageLocation: {{url: ""{text}""}}}}) {{
                    displayText
                    pageLocation {{
                      fullUrl
                      urlName
                      defaultPageForLocation
                    }}
                    alternativeTitle
                    hiddenAlternativeTitle {{
                      contentItems {{
                        ... on HiddenAlternativeTitle {{
                          displayText
                          graphSync {{
                            nodeId
                          }}
                          description
                        }}
                      }}
                    }}
                    overview
                    salarystarterperyear
                    salaryexperiencedperyear
                    minimumhours
                    maximumhours
                    sOCCode {{
                      contentItems {{
                        ... on SOCCode {{
                          displayText
                          graphSync {{
                            nodeId
                          }}
                          description
                          sOC2020
                          sOC2020extension
                          onetOccupationCode
                          apprenticeshipStandards {{
                            contentItems {{
                              ... on ApprenticeshipStandard {{
                                displayText
                                lARScode
                                description
                                graphSync {{
                                  nodeId
                                }}
                              }}
                            }}
                          }}
                        }}
                      }}
                    }}
                    workingHoursDetails {{
                      contentItems {{
                        ... on WorkingHoursDetail {{
                          displayText
                          graphSync {{
                            nodeId
                          }}
                          description
                        }}
                      }}
                    }}
                    workingPattern {{
                      contentItems {{
                        ... on WorkingPatterns {{
                          displayText
                          graphSync {{
                            nodeId
                          }}
                          description
                        }}
                      }}
                    }}
                    workingPatternDetails {{
                      contentItems {{
                        ... on WorkingPatternDetail {{
                          displayText
                          description
                          graphSync {{
                            nodeId
                          }}
                        }}
                      }}
                    }}
                  }}
                }}
                ";

            var response = await client.SendQueryAsync<JobProfilesOverviewResponse>(query);
            return await Task.FromResult(response.Data);
        }
    }
}
