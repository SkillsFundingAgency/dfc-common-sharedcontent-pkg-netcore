using DFC.Common.SharedContent.Pkg.Netcore.Constant;
using DFC.Common.SharedContent.Pkg.Netcore.Extensions;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBreadcrumb;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.SharedHtml;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Response;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.UnitTests
{
    public class RedisCacheRepoTests
    {
        // <summary>
        /// Tests the GetData method when cache is enabled.
        /// </summary>
        /// <returns>Task result.</returns>
        //[Fact]
        //public async Task GetGraphQLData_WithCacheEnabled_CacheHit()
        //{
        //    // Arrange
        //    var mockCache = new Mock<ICacheService>();
        //    var cacheValue = new CacheValue<MockResponse>(3600, new MockResponse() { });
        //    mockCache.Setup(x => x.GetEntity<MockResponse>(It.IsAny<string>())).Returns(cacheValue);

        //    var cacheKey = "true";
        //    var configuration = CreateConfiguration("true");

        //    var redisCacheRepo = new RedisCacheRepo(
        //        mockCache.Object,
        //        configuration,
        //        Mock.Of<IGraphQLClient>(),
        //        Mock.Of<IRestClient>(),
        //        Mock.Of<ILogger<RedisCacheRepo>>()
        //        );

        //    // Act
        //    var result = await redisCacheRepo.GetGraphQLData<MockResponse>("query", cacheKey, false);

        //    // Assert
        //    Assert.NotNull(result);
        //}

        /// <summary>
        /// mock response.
        /// </summary>
        //public class MockResponse
        //{
        //}

        //private IConfiguration CreateConfiguration(string configValue)
        //{
        //    var config = new Dictionary<string, string> { { "true", configValue } };
        //    var initialData = config.Select(x => new KeyValuePair<string, string?>(x.Key, x.Value));
        //    return new ConfigurationBuilder().AddInMemoryCollection(initialData).Build();
        //}

        //[Fact]
        //public async Task packageTestAsync()
        //{
        //    //var logger = new ILogger<RedisCacheRepoTests>();

        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("");
        //        })
        //        .Build();

        //    var sharedContentRedisInterface = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterface.GetDataAsync<PageBanner>("pagebanner/job-profiles/special-educational-needs-(sen)-teacher");
        //}

        //[Fact]
        //public async Task PageQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    //var logger = new ILogger<RedisCacheRepoTests>();

        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("");

        //        })
        //        .Build();

        //    var sharedContentRedisInterface = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterface.GetDataAsync<PageBanner>("pagebanner/job-profiles/special-educational-needs-(sen)-teacher");
        //}

        //[Fact]
        //public async Task DysacQuestionSetQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    //var logger = new ILogger<RedisCacheRepoTests>();

        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("");

        //        })
        //        .Build();

        //    var sharedContentRedisInterface = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterface.GetDataAsync<PersonalityQuestionSet>("QuestionSet", "PUBLISHED");
        //}



        //[Fact]
        //public async Task JobProfileCurrentOpportunitiesStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    //var logger = new ILogger<RedisCacheRepoTests>();

        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("");

        //        })
        //        .Build();

        //    var sharedContentRedisInterface = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterface.GetDataAsyncWithExpiry<JobProfileCurrentOpportunitiesResponse>(ApplicationKeys.JobProfileCurrentOpportunitiesAllJobProfiles, "PUBLISHED");
        //}

        //[Fact]
        //public async Task JobProfileSkillsStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    //var logger = new ILogger<RedisCacheRepoTests>();

        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("");

        //        })
        //        .Build();

        //    var sharedContentRedisInterface = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterface.GetDataAsync<JobProfileSkillsResponse>(ApplicationKeys.JobProfileSkillsSuffix + "/bookmaker", "PUBLISHED");
        //}

        //[Fact]
        //public async Task JobProfileOverviewStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<JobProfilesOverviewResponse>(ApplicationKeys.JobProfilesOverview + "/auditor", "PUBLISHED");
        //}


        //[Fact]
        //public async Task JobProfileCurrentOpportunitiesGetByUrlStrategyy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<JobProfileCurrentOpportunitiesGetbyUrlReponse>(ApplicationKeys.JobProfileCurrentOpportunitiesGetByUrlPrefix + "/auditor", "PUBLISHED");
        //}

        //[Fact]
        //public async Task JobProfileCurrentOpportunitiesWithFirstSkipStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    //1st Request
        //    var sharedContentRedisInterfaceStrategyWithRedisExpiryExpiryAndFirstSkip = host.Services.GetRequiredService<ISharedContentRedisInterface>();
        //    var string3 = await sharedContentRedisInterfaceStrategyWithRedisExpiryExpiryAndFirstSkip.GetDataAsyncWithExpiryAndFirstSkip<JobProfileCurrentOpportunitiesResponse>(ApplicationKeys.JobProfileCurrentOpportunitiesAllJobProfiles, "PUBLISHED", 100, 0);
        //    Console.WriteLine(string3);

        //    //2nd Rquest
        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();
        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<JobProfileCurrentOpportunitiesGetbyUrlReponse>(ApplicationKeys.JobProfileCurrentOpportunities + "/auditor", "PUBLISHED");
        //    Console.WriteLine(string2);
        //    Console.WriteLine(string2);
        //}

        //[Fact]
        //public async Task DysacFilteringQuestionQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<PersonalityFilteringQuestionResponse>(ApplicationKeys.DYSACFilteringQuestion, "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task DysacQuestionSetQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<PersonalityQuestionSet>(ApplicationKeys.DYSACQuestionSet, "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task GetByIdPageApiStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<GetByPageApiResponse>(ApplicationKeys.PageSuffix+ "/fe7065f1-5c50-4656-972a-6a809f854c12", "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task JobCategoryQueryStrategyDysac_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<JobProfileCategoriesResponseDysac>(ApplicationKeys.DYSACJobProfileCategories, "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task JobCategoryQueryStrategyExploreCareers_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<JobProfileCategoriesResponseExploreCareers>(ApplicationKeys.ExploreCareersJobProfileCategories, "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task PageApiStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<PageApiResponse>(ApplicationKeys.PageSuffix, "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task PageBannerQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<PageBanner>(ApplicationKeys.PagesUrlSuffix+ "/https://dev-beta.nationalcareersservice.org.uk/explore-careers", "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task PageBannersAllQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<PageBannerResponse>(ApplicationKeys.AllPageBanners, "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task PageBreadcrumbQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<PageBreadcrumb>("PageBreadcrumb", "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task PageQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<Page>(ApplicationKeys.PageSuffix+ "/about-us/abouts-us", "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task PagesByTriageToolFilterStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<TriagePageResponse>(ApplicationKeys.TriagePages, "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task PageSitemapStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<SitemapResponse>(ApplicationKeys.SitemapPagesAll, "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task PageUrlQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<PageUrlResponse>(ApplicationKeys.PagesUrlSuffix+"/All", "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task SharedHtmlQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<SharedHtml>(ApplicationKeys.SharedContent + "/2f9b6668-1d73-4c49-a82c-ae92f7505f58", "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task SkillsQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<SkillsResponse>(ApplicationKeys.SkillsAll, "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task TraitsQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<PersonalityTraitResponse>(ApplicationKeys.DYSACPersonalityTrait, "PUBLISHED", 4);
        //}

        //[Fact]
        //public async Task TriageToolAllQueryStrategy_ExecuteQueryAsync_TestAsync()
        //{
        //    var host = Host.CreateDefaultBuilder()
        //        .ConfigureServices((context, services) =>
        //        {
        //            services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

        //        })
        //        .Build();

        //    var sharedContentRedisInterfaceStrategyWithRedisExpiry = host.Services.GetRequiredService<ISharedContentRedisInterface>();

        //    var string2 = await sharedContentRedisInterfaceStrategyWithRedisExpiry.GetDataAsyncWithExpiry<TriageToolFilterResponse>(ApplicationKeys.TriageToolFilters, "PUBLISHED", 4);
        //}
    }
}
