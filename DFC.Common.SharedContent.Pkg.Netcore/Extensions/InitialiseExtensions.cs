using DFC.Common.SharedContent.Pkg.Netcore;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;
using Microsoft.Extensions.DependencyInjection;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using Microsoft.Extensions.Configuration;
using DFC.Common.SharedContent.Pkg.Netcore.RequestHandler;
using Microsoft.AspNetCore.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using DFC.Common.SharedContent.Pkg.Netcore.Constant;

namespace DfE.NCS.ContentApi.Extensions;

public static class InitialiseExtensions
{


    public static void AddSharedContentRedisInterface(this IServiceCollection services, string redisConnectionString)
    {
        services.AddStackExchangeRedisCache(options => { options.Configuration = redisConnectionString; });

        services.AddScoped<IGraphQLClient>(s =>
        {
            var option = new GraphQLHttpClientOptions()
            {
                EndPoint = new Uri("https://localhost:44376/api/GraphQL"),

                HttpMessageHandler = new CmsRequestHandler(s.GetService<IHttpClientFactory>(), s.GetService<IConfiguration>(), s.GetService<IHttpContextAccessor>()),
            };
            var client = new GraphQLHttpClient(option, new NewtonsoftJsonSerializer());
            return client;
        });

        services.AddScoped<ISharedContentRedisInterfaceStrategy<Page>, PageQueryStrategy>();

        services.AddScoped<ISharedContentRedisInterfaceStrategy<SharedHtml>, SharedHtmlQueryStrategy>();

        services.AddSingleton<ISharedContentRedisInterfaceStrategyFactory, SharedContentRedisInterfaceStrategyFactory>();

        services.AddScoped<ISharedContentRedisInterface, SharedContentRedisInterface>();
    }
}