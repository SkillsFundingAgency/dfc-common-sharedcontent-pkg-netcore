using AutoMapper;
using DFC.Common.SharedContent.Pkg.Netcore;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.RequestHandler;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.WebRequestMethods;

namespace DfE.NCS.ContentApi.Extensions;

public static class InitialiseExtensions
{
    public static void AddSharedContentRedisInterface(this IServiceCollection services, string redisConnectionString)
    {
        services.AddStackExchangeRedisCache(options => { options.Configuration = redisConnectionString; });

        services.AddHttpClient();
        services.AddScoped<IGraphQLClient>(s =>
        {
            var option = new GraphQLHttpClientOptions()
            {
                EndPoint = new Uri("https://dfc-dev-stax-editor-as.azurewebsites.net/api/GraphQL"),

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