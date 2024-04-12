using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure;

public class SharedContentRedisStrategyFactory : ISharedContentRedisInterfaceStrategyFactory
{
    private readonly IServiceProvider _serviceProvider;

    public SharedContentRedisStrategyFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ISharedContentRedisInterfaceStrategy<T> GetStrategy<T>()
    {
        return _serviceProvider.GetRequiredService<ISharedContentRedisInterfaceStrategy<T>>();
    }

    public ISharedContentRedisInterfaceStrategyWithRedisExpire<T> GetStrategyWithRedisExpire<T>()
    {
        return _serviceProvider.GetRequiredService<ISharedContentRedisInterfaceStrategyWithRedisExpire<T>>();
    }
}