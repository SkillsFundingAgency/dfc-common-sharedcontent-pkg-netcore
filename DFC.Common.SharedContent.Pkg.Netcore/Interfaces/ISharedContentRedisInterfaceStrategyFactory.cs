namespace DFC.Common.SharedContent.Pkg.Netcore.Interfaces;

public interface ISharedContentRedisInterfaceStrategyFactory
{
    ISharedContentRedisInterfaceStrategy<T> GetStrategy<T>();

    ISharedContentRedisInterfaceStrategyWithRedisExpiry<T> GetStrategyWithRedisExpiry<T>();

    ISharedContentRedisInterfaceStrategyWithRedisExpiryAndFirstSkip<T> GetDataAsyncWithExpiryAndFirstSkip<T>();
}

public interface ISharedContentRedisInterfaceStrategy<T>
{
    Task<T> ExecuteQueryAsync(string key, string filter);
}

public interface ISharedContentRedisInterfaceStrategyWithRedisExpiry<T>
{
    Task<T> ExecuteQueryAsync(string key, string filter, double expire = 24);
}

public interface ISharedContentRedisInterfaceStrategyWithRedisExpiryAndFirstSkip<T>
{
    Task<T> ExecuteQueryAsync(string key, string filter, int first, int skip, double expire = 24);
}