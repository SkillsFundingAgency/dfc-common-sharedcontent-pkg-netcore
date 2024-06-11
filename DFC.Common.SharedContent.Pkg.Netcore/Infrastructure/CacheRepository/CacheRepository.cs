using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Pagination;
using DFC.Common.SharedContent.Pkg.Netcore.Model;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.CacheRepository
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IGraphQLClient client;

        public CacheRepository(IGraphQLClient client)
        {
            this.client = client;
        }

        public async Task<TResponse> GetQueryWithPagination<TResponse, TRecordType>(
            string query,
            Func<TResponse, List<TRecordType>> recordSelectorFunc,
            Func<List<TRecordType>, TResponse> mergerFunc,
            int paginationCount = 100)
            where TResponse : class
        {
            var response = await GetDataWithPagination(query, recordSelectorFunc, mergerFunc, paginationCount);

            return response.Data;
        }

        private async Task<CacheRepoResponse<TResponse>> GetDataWithPagination<TResponse, TRecordType>(
            string query,
            Func<TResponse, List<TRecordType>> recordSelectorFunc,
            Func<List<TRecordType>,
            TResponse> mergerFunc,
            int paginationCount = 100)
                where TResponse : class
        {
            var results = new List<TRecordType>();
            Func<string, int, int, Task<int>> queryFunc = async (query, paginationCount, skipCount) =>
            {
                var graphQLResponse = await ExecuteGraphQL<TResponse>(query);
                var records = recordSelectorFunc(graphQLResponse);
                results.AddRange(records);
                return records.Count;
            };

            await ExecutePaginatedQueryAsync(query, queryFunc, paginationCount);

            var response = CacheResponse(mergerFunc(results));

            return response;
        }

        private async Task<TResponse> ExecuteGraphQL<TResponse>(string query)
        {
            var response = await client.SendQueryAsync<TResponse>(query);
            return response.Data;
        }

        private async Task ExecutePaginatedQueryAsync(string query, Func<string, int, int, Task<int>> queryFunc, int paginationCount = 100)
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
                MetaData = new CacheMetaData(),
            };

            return response;
        }
    }
}
