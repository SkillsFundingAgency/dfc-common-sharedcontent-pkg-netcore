namespace DFC.Common.SharedContent.Pkg.Netcore.Interfaces
{
    public interface ISharedContentRedisInterface
    {
        Task<T?> GetDataAsync<T>(string cacheKey, string filter, double expire = 4);

        Task<T?> GetDataAsyncWithExpire<T>(string cacheKey, string filter, double expire = 4);

        Task<bool> InvalidateEntityAsync(string cachekey, string filter);

        Task<bool> InvalidateEntityAsync(string cachekey);
    }
}
