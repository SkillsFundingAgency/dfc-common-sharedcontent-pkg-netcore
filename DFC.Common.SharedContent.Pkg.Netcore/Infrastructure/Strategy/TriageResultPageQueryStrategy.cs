using DFC.Common.SharedContent.Pkg.Netcore.Constant;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class TriageResultPageQueryStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<TriageResultPageResponse>
{
    private readonly IGraphQLClient client;
    private readonly ILogger<TriageResultPageQueryStrategy> logger;

    public TriageResultPageQueryStrategy(IGraphQLClient client, ILogger<TriageResultPageQueryStrategy> logger)
    {
        this.client = client;
        this.logger = logger;
    }

    public async Task<TriageResultPageResponse> ExecuteQueryAsync(string key, string filter, double expire = 4)
    {
        logger.LogInformation("TriageResultPageQueryStrategy -> ExecuteQueryAsync");
        string query = @$"query MyQuery($status: Status!, $contentItemId: ID!) {{
            page(status: $status, where: {{pageLocation: {{useInTriageTool: true }}}}) {{
                title: displayText
                contentItemId
                triageLevelOne {{
                    contentItems {{
                        title: displayText
                        contentItemId
                    }}
                }}
                triageLevelTwo {{
                    contentItems {{
                         title: displayText
                         contentItemId
                    }}
                }}
                filterAdviceGroup {{
                    contentItems {{
                        title: displayText
                        contentItemId
                    }}
                }}
                triageTileTitle
                triageTileDescription
                triageTileHtml{{
                        html
                    }}
                triageOrdinal
                pageLocation {{
                    urlName
                    fullUrl
                }}
            }}
            applicationView(status: $status) {{
                title: displayText
                contentItemId
                triageLevelOne {{
                    contentItems {{
                        title: displayText
                        contentItemId
                    }}
                }}
                triageLevelTwo {{
                    contentItems {{
                        title: displayText
                        contentItemId
                    }}
                }}
                filterAdviceGroup {{
                    contentItems {{
                        title: displayText
                        contentItemId
                    }}
                }}
                triageTileTitle
                triageTileDescription
                triageOrdinal
                triageTileHtml{{
                        html
                    }}
                applicationViewLocation:pageLocation
                useInTriageTool
            }}
            apprenticeshipLink(status: $status) {{
                contentItemId
                displayText
                uRL
                triageOrdinal
                useInTriageTool
                triageLevelOne {{
                    contentItems {{
                        title: displayText
                        contentItemId
                    }}
                }}
                triageLevelTwo {{
                    contentItems {{
                        title: displayText
                        contentItemId
                    }}
                }}
                filterAdviceGroup {{
                    contentItems {{
                        title: displayText
                        contentItemId
                    }}
                }}
            }}
            triageResultTile(status: $status) {{
                contentItemId
                displayText
                triageLevelOne {{
                    contentItems {{
                        contentItemId
                    }}
                }}
                triageResult {{
                    contentItems {{
                        resultContentItemId: contentItemId
                    }}
                }}
                triageTileHtml {{
                    html
                }}
            }}
            triageFilterAdviceGroupImage(status: $status) {{
                filterAdviceGroup {{
                    contentItems {{
                        contentItemId
                  }}
                }}
                triageLevelOne {{
                    contentItems {{
                        contentItemId
                  }}
                }}
                imageHtml {{
                    html
                }}
              }}
            sharedContent(status: $status, where: {{contentItemId: $contentItemId}}) {{
                content {{
                  html
                }}
              }}

        }}";
        var sharedHtmlKey = ApplicationKeys.TriageToolSpeakToAnAdviserContentItem.Substring(ApplicationKeys.TriageToolSpeakToAnAdviserContentItem.IndexOf('/') + 1);
        var contentItemId = sharedHtmlKey.Substring(sharedHtmlKey.IndexOf('/') + 1);
        var response = await client.SendQueryAsync<TriageResultPageResponse>(query, new { Status = filter, contentItemId = contentItemId });

        return response.Data;
    }
}