using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore;

public class SharedContentRedis : ISharedContentRedisInterface
{
    private readonly ISharedContentRedisInterfaceStrategyFactory sharedContentRedisInterfaceStrategyFactory;
    private readonly IDistributedCache cache;

    public SharedContentRedis(IDistributedCache cache, ISharedContentRedisInterfaceStrategyFactory sharedContentRedisInterfaceStrategyFactory)
    {
        this.cache = cache;
        this.sharedContentRedisInterfaceStrategyFactory = sharedContentRedisInterfaceStrategyFactory;
    }

    public async Task<T?> GetDataAsync<T>(string cacheKey, string filter)
    {
        try
        {
            //get redis cache data from cachekey - use zhaomings function
            var cachedContent = await cache.GetStringAsync(cacheKey + "/" + filter);
            //var cacheResponse = cache.GetEntity<TResponse>(cacheKey);

            if (!string.IsNullOrWhiteSpace(cachedContent))
            {
                return JsonConvert.DeserializeObject<T>(cachedContent);
            }

            var strategy = sharedContentRedisInterfaceStrategyFactory.GetStrategy<T>();
            var staxContent = await strategy.ExecuteQueryAsync(cacheKey, filter);
            if (staxContent == null)
            {
                return staxContent;
            }

            await cache.SetStringAsync(cacheKey + "/" + filter, JsonConvert.SerializeObject(staxContent), new DistributedCacheEntryOptions
            {
                //sliding expiration time for cachekey. Resets when accessed
                SlidingExpiration = TimeSpan.FromHours(4),
            });

            return staxContent;
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            throw;
        }
    }

    public Task<T?> GetDataAsync<T>(string cacheKey)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> InvalidateEntityAsync(string cacheKey, string filter)
    {
        await cache.RemoveAsync(cacheKey + "/" + filter);
        return true;
    }

    public async Task<bool> InvalidateEntityAsync(string cacheKey)
    {
        await cache.RemoveAsync(cacheKey);
        return true;
    }
}
