using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.CacheRepository;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Pagination;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileOverviewQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfilesResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileOverviewQueryStrategy> logger;
        private readonly ICacheRepository cacheRepository;

        public JobProfileOverviewQueryStrategy(
            IGraphQLClient client, 
            ILogger<JobProfileOverviewQueryStrategy> logger, 
            ICacheRepository cacheRepository)
        {
            this.client = client;
            this.logger = logger;
            this.cacheRepository = cacheRepository;
        }

        public async Task<JobProfilesResponse> ExecuteQueryAsync(string key, string filter)
        {
            logger.LogInformation("JobProfileOverviewQueryStrategy -> ExecuteQueryAsync");

            Func<JobProfilesResponse, List<JobProfile>> recordSelectorFunc = jobProfileList => jobProfileList.JobProfiles;
            Func<List<JobProfile>, JobProfilesResponse> mergerFunc = jobProfileList => new JobProfilesResponse { JobProfiles = jobProfileList };
            var response = await cacheRepository.GetQueryWithPagination(GetQuery(filter), recordSelectorFunc, mergerFunc);

            return await Task.FromResult(response);
        }

        private string GetQuery(string filter)
        {
            string query = @$"query MyQuery {{
                                jobProfile(first: {GraphQLConfig.PaginationCountToken},  skip: {GraphQLConfig.SkipCountToken}, status: {filter}) {{
                                    displayText
                                    overview
                                    salarystarterperyear
                                    salaryexperiencedperyear
                                    pageLocation {{ 
                                        urlName
                                        fullUrl
                                    }}
                                    maximumhours
                                    minimumhours
                                    workingPattern {{
                                        contentItems {{
                                            displayText
                                            }}
                                        }}
                                    workingHoursDetails {{
                                        contentItems {{
                                            displayText
                                        }}
                                    }}
                                    workingPatternDetails {{
                                        contentItems {{
                                            displayText
                                        }}
                                    }}
                                }}
                            }}";

            return query;
        }
    }
}