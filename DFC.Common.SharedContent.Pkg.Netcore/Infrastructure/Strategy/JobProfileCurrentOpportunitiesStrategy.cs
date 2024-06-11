using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.CacheRepository;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Pagination;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileCurrentOpportunitiesStrategy : ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileCurrentOpportunitiesResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileCurrentOpportunitiesStrategy> logger;
        private readonly ICacheRepository cacheRepository;

        public JobProfileCurrentOpportunitiesStrategy(IGraphQLClient client, ILogger<JobProfileCurrentOpportunitiesStrategy> logger, ICacheRepository cacheRepository)
        {
            this.client = client;
            this.logger = logger;
            this.cacheRepository = cacheRepository;
        }

        public async Task<JobProfileCurrentOpportunitiesResponse> ExecuteQueryAsync(string key, string filter, double expire = 4)
        {
            logger.LogInformation("JobProfileCurrentOpportunitiesStrategy -> ExecuteQueryAsync");

            Func<JobProfileCurrentOpportunitiesResponse, List<JobProfileCurrentOpportunities>> recordSelectorFunc = jobProfileCurrentOpportunitiesList => jobProfileCurrentOpportunitiesList.JobProfileCurrentOpportunities;
            Func<List<JobProfileCurrentOpportunities>, JobProfileCurrentOpportunitiesResponse> mergerFunc = jobProfileCurrentOpportunitiesList => new JobProfileCurrentOpportunitiesResponse { JobProfileCurrentOpportunities = jobProfileCurrentOpportunitiesList };

            var response = await cacheRepository.GetQueryWithPagination(GetQuery(filter), recordSelectorFunc, mergerFunc);

            return await Task.FromResult(response);
        }

        private string GetQuery(string filter)
        {
            string query = @$"query MyQuery {{
                  jobProfile(first: {GraphQLConfig.PaginationCountToken},  skip: {GraphQLConfig.SkipCountToken}, status: {filter}) {{
                    coursekeywords
                    graphSync {{
                      nodeId
                    }}
                    displayText
                    pageLocation {{
                      urlName
                    }}
                    sOCCode {{
                      contentItems {{
                        displayText
                        ... on SOCCode {{
                          apprenticeshipStandards {{
                            contentItems {{
                              displayText
                              ... on ApprenticeshipStandard {{
                                graphSync {{
                                  nodeId
                                }}
                                lARScode
                              }}
                            }}
                          }}
                        }}
                      }}
                    }}
                  }}
                }}";

            return query;
        }
    }
}