namespace DFC.Common.SharedContent.Pkg.Netcore.Interfaces;

public interface ISharedContentRedisInterfaceStrategyFactory
{
    ISharedContentRedisInterfaceStrategy<T> GetStrategy<T>();

    ISharedContentRedisInterfaceStrategyWithRedisExpire<T> GetStrategyWithRedisExpire<T>();
}

public interface ISharedContentRedisInterfaceStrategy<T>
{
    Task<T> ExecuteQueryAsync(string key, string filter);
}

public interface ISharedContentRedisInterfaceStrategyWithRedisExpire<T>
{
    Task<T> ExecuteQueryAsync(string key, string filter, double expire = 4);
}