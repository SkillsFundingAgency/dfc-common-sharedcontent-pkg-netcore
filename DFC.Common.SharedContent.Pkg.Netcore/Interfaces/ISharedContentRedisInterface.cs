using System.Net.Http.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Interfaces
{
    public interface ISharedContentRedisInterface
    {
        Task<T?> GetDataAsync<T>(string cacheKey, string filter);

        Task<bool> InvalidateEntityAsync(string cachekey, string filter);
        Task<bool> InvalidateEntityAsync(string cachekey);
    }
}
