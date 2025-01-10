using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.CacheRepository;
using DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Middleware;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBreadcrumb;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.SharedHtml;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using DFC.Common.SharedContent.Pkg.Netcore.RequestHandler;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace DFC.Common.SharedContent.Pkg.Netcore.Extensions;

public static class InitialiseExtensions
{
    public static void AddSharedContentRedisInterface(this IServiceCollection services, string redisConnectionString)
    {
        services.AddStackExchangeRedisCache(options => { options.Configuration = redisConnectionString; });
        services.AddHttpClient();
        services.AddMemoryCache();
        services.AddScoped<ICacheRepository, CacheRepository>();

        services.AddScoped<IGraphQLClient>(s =>
        {
            var option = new GraphQLHttpClientOptions()
            {
                EndPoint = new Uri("https://dfc-dev-stax-editor-as.azurewebsites.net/api/GraphQL"),

                HttpMessageHandler = new CmsRequestHandler(
                    s.GetService<IHttpClientFactory>(),
                    s.GetService<IConfiguration>(),
                    s.GetService<IHttpContextAccessor>(),
                    s.GetService<IMemoryCache>()),
            };
            var client = new GraphQLHttpClient(option, new NewtonsoftJsonSerializer());
            return client;
        });

        services.AddScoped<IRestClient>(s =>
        {
            var option = new RestClientOptions()
            {
                BaseUrl = new Uri("https://dfc-dev-stax-editor-as.azurewebsites.net/api/queries"),
                ConfigureMessageHandler = handler => new CmsRequestHandler(
                    s.GetService<IHttpClientFactory>(),
                    s.GetService<IConfiguration>(),
                    s.GetService<IHttpContextAccessor>(),
                    s.GetService<IMemoryCache>()),
            };

            JsonSerializerSettings defaultSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DefaultValueHandling = DefaultValueHandling.Include,
                TypeNameHandling = TypeNameHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.None,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            };

            var client = new RestClient(option);
            return client;
        });

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<Page>, PageQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<SitemapResponse>, PageSitemapStrategy>();


        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<SharedHtml>, SharedHtmlQueryStrategy>();

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<PageBanner>, PageBannerQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<PageApiResponse>, PageApiStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<GetByPageApiResponse>, GetByIdPageApiStrategy>();

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<PageUrlResponse>, PageUrlQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<TriageLookupResponse>, TriageLookupQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<TriageResultPageResponse>, TriageResultPageQueryStrategy>();

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<PageBreadcrumb>, PageBreadcrumbQueryStrategy>();

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfilesResponseExploreCareers>, JobProfilesByCategoryQueryStrategy>();

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileCategoriesResponseExploreCareers>, JobCategoryQueryStrategyExploreCareers>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileCategoriesResponseDysac>, JobCategoryQueryStrategyDysac>();

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<PersonalityQuestionSet>, DysacQuestionSetQueryStrategy>();

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<PersonalityFilteringQuestionResponse>, DysacFilteringQuestionQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<PersonalityTraitResponse>, TraitsQueryStrategy>();

        services.AddSingleton<ISharedContentRedisInterfaceStrategyFactory, SharedContentRedisStrategyFactory>();

        services.AddScoped<ISharedContentRedisInterface, SharedContentRedis>();

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileCurrentOpportunitiesResponse>, JobProfileCurrentOpportunitiesStrategy>();

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileSkillsResponse>, JobProfileSkillsStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileCareerPathAndProgressionResponse>, JobProfileCareerPathAndProgressionStrategy>();

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<RelatedCareersResponse>, JobProfileRelatedCareersQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileHowToBecomeResponse>, JobProfileHowToBecomeQueryStrategy>();

        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfilesOverviewResponse>, JobProfileOverviewProfileSpecificQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileWhatYoullDoResponse>, JobProfileWhatYoullDoQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileVideoResponse>, JobProfileVideoQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileCurrentOpportunitiesGetbyUrlReponse>, JobProfileCurrentOpportunitiesGetByUrlStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<SkillsResponse>, SkillsQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfileApiSummaryResponse>, JobProfileApiSummaryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfilesResponse>, JobProfileOverviewQueryStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<PageBannerResponse>, PageBannersAllQueryStrategy>();
        services.AddSingleton<IFunctionContextAccessor, FunctionContextAccessor>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiryAndFirstSkip<JobProfileCurrentOpportunitiesResponse>, JobProfileCurrentOpportunitiesWithFirstSkipStrategy>();
        services.AddScoped<ISharedContentRedisInterfaceStrategyWithRedisExpiry<JobProfilesResponse>, JobProfileOverviewQueryStrategy>();
    }
}
