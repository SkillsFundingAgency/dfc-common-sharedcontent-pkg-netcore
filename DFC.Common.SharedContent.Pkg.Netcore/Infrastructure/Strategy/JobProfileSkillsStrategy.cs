﻿using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileSkillsStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileSkillsResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileSkillsStrategy> logger;

        public JobProfileSkillsStrategy(IGraphQLClient client, ILogger<JobProfileSkillsStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileSkillsResponse> ExecuteQueryAsync(string key, string filter, double expire = 24)
        {
            logger.LogInformation("JobProfileSkillsQueryStrategy -> ExecuteQueryAsync");

            var url = key.Substring(key.LastIndexOf('/') + 1);

            string query = $@"query JobProfileWhatItTakes {{
                  jobProfile(where: {{pageLocation: {{url: ""/{url}""}}}}, status: {filter}) {{
                    displayText
                    pageLocation {{
                      fullUrl
                      urlName
                      defaultPageForLocation
                    }}
                    otherrequirements {{
                      html
                    }}
                    relatedrestrictions {{
                      contentItems {{
                        ... on Restriction {{
                          displayText
                          info {{
                            html
                          }}
                          graphSync {{
                            nodeId
                          }}
                        }}
                      }}
                    }}
                    digitalSkills {{
                      contentItems {{
                        ... on DigitalSkills {{
                          displayText
                          description
                          graphSync {{
                            nodeId
                          }}
                        }}
                      }}
                    }}
                    relatedskills {{
                      contentItems(first:8) {{
                        ... on SOCSkillsMatrix {{
                          displayText
                          graphSync {{
                            nodeId
                          }}
                          oNetAttributeType
                          oNetRank
                          relatedSOCcode
                          relatedSkill
                        }}
                      }}
                    }}
                  }}
                }}
                ";

            var response = await client.SendQueryAsync<JobProfileSkillsResponse>(query);
            var result = response.Data;
            return result.JobProfileSkills.Count > 0 ? result : null;
        }
    }
}
