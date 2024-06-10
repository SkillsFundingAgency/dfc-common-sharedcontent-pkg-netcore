using DFC.Common.SharedContent.Pkg.Netcore.Constant;
using DFC.Common.SharedContent.Pkg.Netcore.Enum;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Pagination;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;
using System;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class JobProfileOverviewQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfilesResponse>
    {
        private readonly IGraphQLClient client;
        private readonly ILogger<JobProfileOverviewQueryStrategy> logger;

        public JobProfileOverviewQueryStrategy(IGraphQLClient client, ILogger<JobProfileOverviewQueryStrategy> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public async Task<JobProfilesResponse> ExecuteQueryAsync(string key, string filter)
        {
            logger.LogInformation("JobProfileOverviewQueryStrategy -> ExecuteQueryAsync");

            var query = GetQuery(filter);

            Func<JobProfilesResponse, List<JobProfile>> recordSelectorFunc = jobProfileList => jobProfileList.JobProfiles;
            Func<List<JobProfile>, JobProfilesResponse> mergerFunc = jobProfileList => new JobProfilesResponse { JobProfiles = jobProfileList };
            var responseNew = await GetQueryWithPagination(GetQuery(filter), recordSelectorFunc, mergerFunc);

            var response = await client.SendQueryAsync<JobProfilesResponse>(GetQueryOld(filter));
            return await Task.FromResult(response.Data);
        }

        public async Task<TResponse> GetQueryWithPagination<TResponse, TRecordType>(string query, Func<TResponse, List<TRecordType>> recordSelectorFunc, Func<List<TRecordType>, TResponse> mergerFunc, int paginationCount = 100)
            where TResponse : class
        {
            var response = await GetDataWithPagination(query, cacheKey, recordSelectorFunc, mergerFunc, paginationCount);

            return response.Data;
        }

        public async Task<CacheRepoResponse<TResponse>> GetDataWithPagination<TResponse, TRecordType>(
            string query,
            Func<TResponse, List<TRecordType>> recordSelectorFunc,
            Func<List<TRecordType>,
            TResponse> mergerFunc,
            int paginationCount = 100)
            where TResponse : class
        {
            //var cacheResult = GetFromCacheIfExists<TResponse>(BuildCacheKey(cacheKey), disableCache);
            //if (cacheResult != null)
            //{
            //    return cacheResult;
            //}

            //if not available in the cache get it from the graph ql api in batches
            var results = new List<TRecordType>();
            Func<string, int, int, Task<int>> queryFunc = async (query, paginationCount, skipCount) =>
            {
                var graphQLResponse = await ExecuteGraphQL<TResponse>(query);
                var records = recordSelectorFunc(graphQLResponse);
                results.AddRange(records);
                return records.Count;
            };

            await ExecutePaginatedQueryAsync(query, queryFunc, paginationCount);

            CacheRepoResponse<TResponse> response = CacheResponse(mergerFunc(results));

            return response;
        }

        private async Task<TResponse> ExecuteGraphQL<TResponse>(string query)
        {
            //var status = preview.IsInPreviewMode ? config[ConfigKeys.GraphQLStatusPreview] : config[ConfigKeys.GraphQLStatusDefault];
            //var tokenisedQuery = query.Replace(GraphQLConfig.GraphQLStatusToken, status);
            var response = await client.SendQueryAsync<TResponse>(query);
            return response.Data;
        }

        public async Task ExecutePaginatedQueryAsync(string query, Func<string, int, int, Task<int>> queryFunc, int paginationCount = 100)
        {
            //if (paginationCount < 1 || paginationCount > maxItemCount)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(paginationCount));
            //}

            //if (!query.Contains(GraphQLConfig.SkipCountToken) || !query.Contains(GraphQLConfig.PaginationCountToken))
            //{
            //    throw new ArgumentException("SkipCount or PaginationCount token missing from query");
            //}

            int skipCount = 0;
            bool moreResultsExist = true;

            while (moreResultsExist)
            {
                string formattedQuery = query
                                        .Replace(GraphQLConfig.SkipCountToken, skipCount.ToString())
                                        .Replace(GraphQLConfig.PaginationCountToken, paginationCount.ToString());

                int resultsCount = await queryFunc(formattedQuery, paginationCount, skipCount);

                if (resultsCount < paginationCount)
                {
                    moreResultsExist = false;
                }
                else
                {
                    skipCount += paginationCount;
                }
            }
        }

        private CacheRepoResponse<TResponse> CacheResponse<TResponse>(TResponse graphQLResponse) where TResponse : class
        {
            var response = new CacheRepoResponse<TResponse>()
            {
                Data = graphQLResponse,
                //MetaData = new CacheMetaData(),
            };

            //if (!preview.IsInPreviewMode && isCacheEnabled)
            //{
            //    var cacheResponse = cache.SaveEntity<TResponse>(cacheKey, graphQLResponse);
            //    if (cacheResponse?.Value == null)
            //    {
            //        logger.LogError("Unable to store data in the cache. Please see exception log for detail.");
            //    }
            //    else
            //    {
            //        response.MetaData.Expires = cacheResponse.Expires;
            //        response.MetaData.IsCacheEnabled = true;
            //        response.MetaData.CacheAction = CacheActionEnum.Add;
            //    }
            //}

            return response;
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

        private string GetQueryOld(string filter)
        {
            string query = @$"query MyQuery {{
                                jobProfile(first: 1000, status: {filter}) {{
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