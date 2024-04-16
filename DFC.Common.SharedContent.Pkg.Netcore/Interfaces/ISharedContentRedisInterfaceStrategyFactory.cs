namespace DFC.Common.SharedContent.Pkg.Netcore.Interfaces;

public interface ISharedContentRedisInterfaceStrategyFactory
{
    ISharedContentRedisInterfaceStrategy<T> GetStrategy<T>();

    ISharedContentRedisInterfaceStrategyWithRedisExpiry<T> GetStrategyWithRedisExpiry<T>();
}

public interface ISharedContentRedisInterfaceStrategy<T>
{
    Task<T> ExecuteQueryAsync(string key, string filter);
}

public interface ISharedContentRedisInterfaceStrategyWithRedisExpiry<T>
{
    Task<T> ExecuteQueryAsync(string key, string filter, double expire = 24);
}