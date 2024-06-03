﻿using DFC.Common.SharedContent.Pkg.Netcore.Constant;
using DFC.Common.SharedContent.Pkg.Netcore.Extensions;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
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
    }
}
