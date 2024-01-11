using DFC.Common.SharedContent.Pkg.Netcore;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;
using Microsoft.Extensions.DependencyInjection;

namespace DfE.NCS.ContentApi.Extensions;

public static class InitialiseExtensions
{
    public static void AddSharedContentRedisInterface(this IServiceCollection services, string redisConnectionString)
    {
        services.AddStackExchangeRedisCache(options => { options.Configuration = redisConnectionString; });

        services.AddScoped<ISharedContentRedisInterfaceStrategy<PagesContentItem>, PageQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategy<SharedHtmlContentItem>, SharedHtmlQueryStrategy>();

        services.AddSingleton<ISharedContentRedisInterfaceStrategyFactory, SharedContentRedisInterfaceStrategyFactory>();

        services.AddScoped<ISharedContentRedisInterface, SharedContentRedisInterface>();
    }
}