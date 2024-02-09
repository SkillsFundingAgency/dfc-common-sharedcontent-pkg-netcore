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
    public class DysacFilteringQuestionQueryStrategy : ISharedContentRedisInterfaceStrategy<PersonalityFilteringQuestion>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<DysacFilteringQuestionQueryStrategy> logger;

        public DysacFilteringQuestionQueryStrategy(IGraphQLClient client, ILogger<DysacFilteringQuestionQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<PersonalityFilteringQuestion> ExecuteQueryAsync(string key)
        {
            string query = @$"
                    query MyQuery {{
                      personalityFilteringQuestion {{
                        graphSync {{
                          nodeId
                        }}
                        text
                        displayText
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
                        ordinal
                      }}
                    }}
            ";

            var response = await client.SendQueryAsync<PersonalityFilteringQuestion>(query);

            //assign ordinal value to soc skills matrix items
            var returnData = response.Data;
            int i = 0;
            foreach (var item in returnData.SocSkillsMatrices.ContentItems)
            {
                item.Ordinal = i;
                i++;
            }

            return await Task.FromResult(response.Data);
        }
    }
}
