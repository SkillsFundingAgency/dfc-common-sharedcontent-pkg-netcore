using DFC.Common.SharedContent.Pkg.Netcore;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;
using Microsoft.Extensions.DependencyInjection;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

namespace DfE.NCS.ContentApi.Extensions;

public static class InitialiseExtensions
{
    public static void AddSharedContentRedisInterface(this IServiceCollection services, string redisConnectionString)
    {
        services.AddStackExchangeRedisCache(options => { options.Configuration = redisConnectionString; });

        services.AddScoped<ISharedContentRedisInterfaceStrategy<Page>, PageQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategy<SharedHtml>, SharedHtmlQueryStrategy>();

        services.AddSingleton<ISharedContentRedisInterfaceStrategyFactory, SharedContentRedisInterfaceStrategyFactory>();

        services.AddScoped<ISharedContentRedisInterface, SharedContentRedisInterface>();
    }
}