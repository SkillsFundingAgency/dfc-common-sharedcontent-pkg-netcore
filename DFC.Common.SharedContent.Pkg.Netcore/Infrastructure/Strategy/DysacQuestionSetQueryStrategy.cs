using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
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
    public class DysacQuestionSetQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<PersonalityQuestionSet>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<PageUrlQueryStrategy> logger;

        public DysacQuestionSetQueryStrategy(IGraphQLClient client, ILogger<PageUrlQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<PersonalityQuestionSet> ExecuteQueryAsync(string key, string filter, double expire = 4)
        {
            logger.LogInformation("DysacQuestionSetQueryStrategy -> ExecuteQueryAsync");
            string query = @$"
                query MyQuery {{
                  personalityQuestionSet(first: 1, status: {filter}) {{
                    displayText
                    questions {{
                      contentItems {{
                        ... on PersonalityShortQuestion {{
                          displayText
                          impact
                          contentItemId
                          graphSync {{nodeId}}
                          trait {{
                            contentItems {{
                              displayText
                              ... on PersonalityTrait {{
                                displayText
                                graphSync {{nodeId}}
                                jobProfileCategories {{
                                  contentItems {{
                                     ... on JobProfileCategory {{
                                        displayText
                                        graphSync {{
                                            nodeId
                                        }}
                                    }}
                                  }}
                                }}
                              }}
                            }}
                          }}
                        }}
                      }}
                    }}
                  }}
                }}";
            var response = await client.SendQueryAsync<DysacQuestionSetResponse>(query);

            //assign ordinal value
            var returnData = response.Data.PersonalityQuestionSet.FirstOrDefault();
            int i = 0;
            foreach (var item in returnData.Questions.ContentItems)
            {
                item.Ordinal = i;
                i++;
            }

            return returnData;
        }
    }
}
