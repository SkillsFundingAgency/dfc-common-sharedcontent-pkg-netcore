using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure;

public class SharedContentRedistrategyFactory : ISharedContentRedisInterfaceStrategyFactory
{
    private readonly IServiceProvider _serviceProvider;

    public SharedContentRedistrategyFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ISharedContentRedisInterfaceStrategy<T> GetStrategy<T>()
    {
        return _serviceProvider.GetRequiredService<ISharedContentRedisInterfaceStrategy<T>>();
    }
}