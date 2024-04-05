using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileCareerPathAndProgressionStrategy : ISharedContentRedisInterfaceStrategy<JobProfileCareerPathAndProgressionResponse>
    {
        private readonly IGraphQLClient _client;

        public JobProfileCareerPathAndProgressionStrategy(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<JobProfileCareerPathAndProgressionResponse> ExecuteQueryAsync(string key, string filter)
        {
            var displayText = key.Substring(key.LastIndexOf("/") + 1);

            string query = @$"query JobProfileCareerPathProgression{{
              jobProfile(where: {{displayText: ""{displayText}""}}) {{
                displayText
                careerpathandprogression {{
                  html
                }}
              }}
            }}
            ";

            var response = await _client.SendQueryAsync<JobProfileCareerPathAndProgressionResponse>(query);
            return response.Data;
        }
    }
}
