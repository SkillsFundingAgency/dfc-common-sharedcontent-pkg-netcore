﻿using DFC.Common.SharedContent.Pkg.Netcore.Model;

namespace DFC.Common.SharedContent.Pkg.Netcore.Interfaces
{
    /// <summary>
    /// Cache repository for redis cache.
    /// </summary>
    public interface IRedisCacheRepo
    {
        /// <summary>
        /// Retrieve items from cache if not found then call graphql api to retrieve and store in the cache.
        /// </summary>
        /// <typeparam name="TResponse">type of response.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="cacheKey">cache key.</param>
        /// <param name="disableCache">force disable the cache.</param>
        /// <returns>The cache response.</returns>
        Task<CacheRepoResponse<TResponse>> GetGraphQLData<TResponse>(string query, string cacheKey, bool disableCache = false)
            where TResponse : class;

        Task<CacheRepoResponse<TResponse>> GetSqlData<TResponse>(string query, string cacheKey, bool disableCache = false)
            where TResponse : class;
    }
}
