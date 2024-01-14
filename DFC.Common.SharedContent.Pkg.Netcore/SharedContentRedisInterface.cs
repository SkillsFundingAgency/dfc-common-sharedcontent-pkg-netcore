using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DfE.NCS.Framework.Cache.Interface;
using GraphQL;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Threading;

namespace DFC.Common.SharedContent.Pkg.Netcore;

public class SharedContentRedisInterface : ISharedContentRedisInterface
{
    private readonly ISharedContentRedisInterfaceStrategyFactory sharedContentRedisInterfaceStrategyFactory;
    private readonly IDistributedCache cache;


    public SharedContentRedisInterface(IDistributedCache cache, ISharedContentRedisInterfaceStrategyFactory sharedContentRedisInterfaceStrategyFactory)
    {
        this.cache = cache;
        this.sharedContentRedisInterfaceStrategyFactory = sharedContentRedisInterfaceStrategyFactory;
    }

    public async Task<T?> GetDataAsync<T>(string cacheKey)
    {
        try
        {
            //get redis cache data from cachekey - use zhaomings function
            var cachedContent = await cache.GetStringAsync(cacheKey);
            //var cacheResponse = cache.GetEntity<TResponse>(cacheKey);

            if (!string.IsNullOrWhiteSpace(cachedContent))
            {
                return JsonConvert.DeserializeObject<T>(cachedContent);
            }

            var strategy = sharedContentRedisInterfaceStrategyFactory.GetStrategy<T>();
            var staxContent = await strategy.ExecuteQueryAsync(cacheKey);
            if (staxContent == null)
            {
                return staxContent;
            }

            //set new item in redis as content from gathered function - use zhaomings function
            await cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(staxContent));

            //cache.SaveEntity(cacheKey, graphQLResponse);

            return staxContent;
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            throw;
        }
    }

    public async Task<bool> InvalidateEntityAsync(string cacheKey)
    {
        await cache.RemoveAsync(cacheKey);
        return true;
    }
}
