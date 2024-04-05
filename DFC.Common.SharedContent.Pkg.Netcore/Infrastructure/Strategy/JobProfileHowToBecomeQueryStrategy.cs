using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileHowToBecomeQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfileHowToBecomeResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileHowToBecomeQueryStrategy> logger;

        public JobProfileHowToBecomeQueryStrategy(IGraphQLClient client, ILogger<JobProfileHowToBecomeQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileHowToBecomeResponse> ExecuteQueryAsync(string key, string filter)
        {
            logger.LogInformation("JobProfileHowToBecomeQueryStrategy -> ExecuteQueryAsync");

            var urlName = key.Substring(key.IndexOf('/') + 1);

            string query = $@"query JobProfileHowToBecome {{
                  jobProfile(where: {{pageLocation: {{url: ""{urlName}""}}}}, status: {filter}) {{
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
                          description
                        }}
                      }}
                    }}
                    relatedUniversityRequirements {{
                      contentItems {{
                        ... on UniversityEntryRequirements {{
                          displayText
                          description
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
                          description
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
                          description
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
                            paths
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
