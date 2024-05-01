using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileHowToBecomeQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileHowToBecomeResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileHowToBecomeQueryStrategy> logger;

        public JobProfileHowToBecomeQueryStrategy(IGraphQLClient client, ILogger<JobProfileHowToBecomeQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileHowToBecomeResponse> ExecuteQueryAsync(string key, string filter, double expire = 24)
        {
            logger.LogInformation("JobProfileHowToBecomeQueryStrategy -> ExecuteQueryAsync");

            var urlName = key.Substring(key.LastIndexOf('/') + 1);

            string query = $@"query JobProfileHowToBecome {{
                  jobProfile(where: {{pageLocation: {{url: ""/{urlName}""}}}}, status: {filter}) {{
                    displayText
                    pageLocation {{
                      fullUrl
                      urlName
                      defaultPageForLocation
                    }}
                    entryroutes {{
                      html
                    }}
                    universityrelevantsubjects {{
                      html
                    }}
                    universityfurtherrouteinfo {{
                      html
                    }}
                    universityEntryRequirements {{
                      contentItems {{
                        ... on UniversityEntryRequirements {{
                          displayText
                        }}
                      }}
                    }}
                    relatedUniversityRequirements {{
                      contentItems {{
                        ... on UniversityRequirements {{
                          displayText
                          info {{
                            html
                          }}
                        }}
                      }}
                    }}
                    relatedUniversityLinks {{
                      contentItems {{
                        ... on UniversityLink {{
                          displayText
                          text
                          uRL
                        }}
                      }}
                    }}
                    collegerelevantsubjects {{
                      html
                    }}
                    collegefurtherrouteinfo {{
                      html
                    }}
                    collegeEntryRequirements {{
                      contentItems {{
                        ... on CollegeEntryRequirements {{
                          displayText
                        }}
                      }}
                    }}
                    relatedCollegeRequirements {{
                      contentItems {{
                        ... on CollegeRequirements {{
                          displayText
                          info {{
                            html
                          }}
                        }}
                      }}
                    }}
                    relatedCollegeLinks {{
                      contentItems {{
                        ... on CollegeLink {{
                          displayText
                          text
                          uRL
                        }}
                      }}
                    }}
                    apprenticeshiprelevantsubjects {{
                      html
                    }}
                    apprenticeshipfurtherroutesinfo {{
                      html
                    }}
                    apprenticeshipEntryRequirements {{
                      contentItems {{
                        ... on ApprenticeshipEntryRequirements {{
                          displayText
                        }}
                      }}
                    }}
                    relatedApprenticeshipRequirements {{
                      contentItems {{
                        ... on ApprenticeshipRequirements {{
                          displayText
                          info {{
                            html
                          }}
                        }}
                      }}
                    }}
                    relatedApprenticeshipLinks {{
                      contentItems {{
                        ... on ApprenticeshipLink {{
                          displayText
                          text
                          uRL
                        }}
                      }}
                    }}
                    work {{
                      html
                    }}
                    volunteering {{
                      html
                    }}
                    directapplication {{
                      html
                    }}
                    otherroutes {{
                      html
                    }}
                    professionalandindustrybodies {{
                      html
                    }}
                    furtherinformation {{
                      html
                    }}
                    careertips {{
                      html
                    }}
                    relatedRegistrations {{
                      contentItems {{
                        ... on Registration {{
                          displayText
                          info {{
                            html
                          }}
                        }}
                      }}
                    }}
                    realStory {{
                      contentItems {{
                        ... on RealStory {{
                          displayText
                          body {{
                            html
                          }}
                          furtherInformation {{
                            html
                          }}
                          thumbnail {{
                            mediaText
                            urls
                          }}
                        }}
                      }}
                    }}
                  }}
                }}";

            var response = await client.SendQueryAsync<JobProfileHowToBecomeResponse>(query);
            return response.Data;
        }
    }
}
