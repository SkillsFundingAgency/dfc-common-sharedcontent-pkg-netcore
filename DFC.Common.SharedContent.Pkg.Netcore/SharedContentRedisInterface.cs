using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DfE.NCS.Framework.Cache.Interface;
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
        //get redis cache data from cachekey - use zhaomings function
        try
        {
            var cachedContent = await cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrWhiteSpace(cachedContent))
            {
                //NEED TO UPDATE EXPIRY - SAVEENTITY(key, content, expiry in seconds)
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
