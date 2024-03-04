namespace DFC.Common.SharedContent.Pkg.Netcore.Interfaces;

public interface ISharedContentRedisInterfaceStrategyFactory
{
    ISharedContentRedisInterfaceStrategy<T> GetStrategy<T>();
}

public interface ISharedContentRedisInterfaceStrategy<T>
{
    Task<T> ExecuteQueryAsync(string key, string filter);
}