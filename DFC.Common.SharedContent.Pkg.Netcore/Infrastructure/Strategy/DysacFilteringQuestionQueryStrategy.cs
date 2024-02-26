using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac;
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
    public class DysacFilteringQuestionQueryStrategy : ISharedContentRedisInterfaceStrategy<PersonalityFilteringQuestionResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PageUrlQueryStrategy> logger;

        public DysacFilteringQuestionQueryStrategy(IGraphQLClient client, ILogger<PageUrlQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<PersonalityFilteringQuestionResponse> ExecuteQueryAsync(string key)
        {
            logger.LogInformation("DysacFilteringQuestionQueryStrategy -> ExecuteQueryAsync");

            string query = @$"
                query MyQuery {{
                  personalityFilteringQuestion(status: PUBLISHED) {{
                    displayText
                    text
                    ordinal
                    graphSync {{
                          nodeId
                        }}
                    sOCSkillsMatrix {{
                      contentItems {{
                        ... on SOCSkillsMatrix {{
                          displayText
                          modifiedUtc
                          graphSync {{
                                nodeId
                              }}
                          oNetAttributeType
                          oNetRank
                        }}
                      }}
                    }}
                  }}
                }}";
            var response = await client.SendQueryAsync<PersonalityFilteringQuestionResponse>(query);

            foreach (var item in response.Data.PersonalityFilteringQuestion)
            {
                if (item.SOCSkillsMatrix.ContentItems.Count() > 0)
                {
                    int i = 0;
                    foreach (var skill in item.SOCSkillsMatrix.ContentItems)
                    {
                        skill.Ordinal = i;
                        i++;
                    }
                }
            }

            return response.Data;
        }
    }
}