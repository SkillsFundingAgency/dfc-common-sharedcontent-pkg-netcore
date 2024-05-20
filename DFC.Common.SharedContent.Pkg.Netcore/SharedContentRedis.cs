using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore;

public class SharedContentRedis : ISharedContentRedisInterface
{
    private ISharedContentRedisInterfaceStrategyFactory sharedContentRedisInterfaceStrategyFactory;
    private readonly IDistributedCache cache;
    private readonly double defaultexpired = 4;

    public SharedContentRedis(IDistributedCache cache, ISharedContentRedisInterfaceStrategyFactory sharedContentRedisInterfaceStrategyFactory)
    {
        this.cache = cache;
        this.sharedContentRedisInterfaceStrategyFactory = sharedContentRedisInterfaceStrategyFactory;
    }

    public async Task<T?> GetDataAsync<T>(string cacheKey, string filter, double expire = 4)
    {
        try
        {
            //get redis cache data from cachekey - use zhaomings function
            var cachedContent = await cache.GetStringAsync(cacheKey + "/" + filter);

            if (!string.IsNullOrWhiteSpace(cachedContent))
            {
                return JsonConvert.DeserializeObject<T>(cachedContent);
            }

            var strategy = sharedContentRedisInterfaceStrategyFactory.GetStrategy<T>();

            var staxContent = await ReturnDataFromStrategyAsync(strategy, cacheKey, filter, expire);

            return staxContent;
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            throw;
        }
    }

    public async Task<T?> GetDataAsyncWithExpiry<T>(string cacheKey, string filter, double expire = 24)
    {
        try
        {
            //get redis cache data from cachekey - use zhaomings function
            var cachedContent = await cache.GetStringAsync(cacheKey + "/" + filter);

            if (!string.IsNullOrWhiteSpace(cachedContent))
            {
                return JsonConvert.DeserializeObject<T>(cachedContent);
            }

            var strategy = sharedContentRedisInterfaceStrategyFactory.GetStrategyWithRedisExpiry<T>();

            var staxContent = await ReturnDataFromStrategyWithExpireAsync(strategy, cacheKey, filter, expire);

            return staxContent;
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            throw;
        }
    }

    public async Task<bool> SetCurrentOpportunitiesData<T>(T currentOpportunitiesContent, string cacheKey, double expire = 24)
    {
        try
        {
            await cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(currentOpportunitiesContent), new DistributedCacheEntryOptions
            {
                //sliding expiration time for cachekey. Resets when accessed
                SlidingExpiration = TimeSpan.FromHours(expire),
            });
            return true;
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            throw;
        }
    }

    public async Task<T?> GetCurrentOpportunitiesData<T>(string cacheKey)
    {
        try
        {
            var cachedContent = await cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrWhiteSpace(cachedContent))
            {
                return JsonConvert.DeserializeObject<T>(cachedContent);
            }

            return default(T);
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            throw;
        }
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

    private async Task<T?> ReturnDataFromStrategyWithExpireAsync<T>(ISharedContentRedisInterfaceStrategyWithRedisExpiry<T> strategy, string cacheKey, string filter, double expire)
    {
        var staxContent = await strategy.ExecuteQueryAsync(cacheKey, filter);

        return await SaveContentToCache(staxContent, cacheKey, filter, expire);
    }

    private async Task<T?> ReturnDataFromStrategyAsync<T>(ISharedContentRedisInterfaceStrategy<T> strategy, string cacheKey, string filter, double expire)
    {
        var staxContent = await strategy.ExecuteQueryAsync(cacheKey, filter);

        return await SaveContentToCache(staxContent, cacheKey, filter, expire);
    }

    private async Task<T?> ReturnDataFromStrategyWithExpiryAndFirstSkipAsync<T>(ISharedContentRedisInterfaceStrategyWithRedisExpiryAndFirstSkip<T> strategy, string cacheKey, string filter, int first, int skip, double expire)
    {
        var staxContent = await strategy.ExecuteQueryAsync(cacheKey, filter, first, skip, expire);

        return await SaveContentToCache(staxContent, cacheKey, filter, expire);
    }

    private async Task<T?> SaveContentToCache<T>(T? staxContent, string cacheKey, string filter, double expire)
    {
        if (staxContent == null)
        {
            return staxContent;
        }

        await cache.SetStringAsync(cacheKey + "/" + filter, JsonConvert.SerializeObject(staxContent), new DistributedCacheEntryOptions
        {
            //sliding expiration time for cachekey. Resets when accessed
            SlidingExpiration = TimeSpan.FromHours(expire),
        });
        return staxContent;
    }

    public async Task<T?> GetDataAsyncWithExpiryAndFirstSkip<T>(string cacheKey, string filter, int first, int skip, double expire = 24)
    {
        try
        {
            //get redis cache data from cachekey - use zhaomings function
            var cachedContent = await cache.GetStringAsync(cacheKey + "/" + filter);

            if (!string.IsNullOrWhiteSpace(cachedContent))
            {
                return JsonConvert.DeserializeObject<T>(cachedContent);
            }

            var strategy = sharedContentRedisInterfaceStrategyFactory.GetDataAsyncWithExpiryAndFirstSkip<T>();

            var staxContent = await ReturnDataFromStrategyWithExpiryAndFirstSkipAsync(strategy, cacheKey, filter, first, skip, expire);

            return staxContent;
        }
        catch (Exception error)
        {
            Console.WriteLine(error);
            throw;
        }
    }
}
