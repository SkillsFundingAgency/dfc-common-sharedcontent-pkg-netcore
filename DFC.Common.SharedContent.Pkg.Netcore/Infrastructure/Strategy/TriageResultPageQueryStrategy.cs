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
        string query = @$"query MyQuery {{
            page(status: {filter}, where: {{pageLocation: {{useInTriageTool: true }}}}) {{
                title: displayText
                triageLevelOne {{
                    contentItems {{
                        title: displayText
                    }}
                }}
                triageLevelTwo {{
                    contentItems {{
                         title: displayText
                    }}
                }}
                filterAdviceGroup {{
                    contentItems {{
                        title: displayText
                    }}
                }}
                triageTileTitle
                triageTileDescription
                triageOrdinal
                pageLocation {{
                    urlName
                    fullUrl
                }}
            }}
            applicationView(status: {filter}) {{
                title: displayText
                triageLevelOne {{
                    contentItems {{
                        title: displayText
                    }}
                }}
                triageLevelTwo {{
                    contentItems {{
                        title: displayText
                    }}
                }}
                filterAdviceGroup {{
                    contentItems {{
                        title: displayText
                    }}
                }}
                triageTileTitle
                triageTileDescription
                triageOrdinal
                applicationViewLocation:pageLocation
                useInTriageTool
            }}

        }}";

        var response = await client.SendQueryAsync<TriageResultPageResponse>(query);

        return response.Data;
    }
}
