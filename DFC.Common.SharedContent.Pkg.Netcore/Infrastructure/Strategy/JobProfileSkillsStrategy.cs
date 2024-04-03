using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileSkillsStrategy : ISharedContentRedisInterfaceStrategy<JobProfileSkillsResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileSkillsStrategy> logger;

        public JobProfileSkillsStrategy(IGraphQLClient client, ILogger<JobProfileSkillsStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfileSkillsResponse> ExecuteQueryAsync(string key, string filter)
        {
            var url = key.Substring(key.IndexOf('/') + 1);
            string query = $@"query JobProfileWhatItTakes {{
                  jobProfile(where: {{pageLocation: {{url: ""/{url}""}}}}) {{
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
            return response.Data;
        }
    }
}
