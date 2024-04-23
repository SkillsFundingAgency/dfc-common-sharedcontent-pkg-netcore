using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Extensions;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.SharedHtml;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DFC.Common.SharedContent.Pkg.Netcore.UnitTests
{
    public class CurrentOpportunitiesGetterSetterTests
    {
        [Fact]
        public async Task JobProfileCurrentOpportunitiesSetAndGetTest()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

                })
                .Build();

            var sharedContentRedisInterface = host.Services.GetRequiredService<ISharedContentRedisInterface>();

            var cacheKey = "JobProfileCurrentOpportunitiesSetAndGetTest/CacheKey";
            var testHtmlString = "JobProfileCurrentOpportunitiesSetAndGetTest";

            var testSharedHtmlObject = new SharedHtmlContent
            {
                Content = new SharedHtml
                {
                    Html = testHtmlString,
                },
            };

            await sharedContentRedisInterface.SetCurrentOpportunitiesData(testSharedHtmlObject, cacheKey, 0.5);
            var result = await sharedContentRedisInterface.GetCurrentOpportunitiesData<SharedHtmlContent>(cacheKey);

            Assert.IsType<SharedHtmlContent>(result);
            Assert.Equal(testHtmlString, result.Content.Html);
        }

        [Fact]
        public async Task JobProfileCurrentOpportunitiesGetNullTest()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSharedContentRedisInterface("dfc-dev-shared-rdc.redis.cache.windows.net:6380,password=Nuzqmeax2bVwFYQQ7YCbDcxexbtBNUuyyAzCaOtGPLo=,ssl=True,abortConnect=False");

                })
                .Build();

            var sharedContentRedisInterface = host.Services.GetRequiredService<ISharedContentRedisInterface>();

            var cacheKey = "JobProfileCurrentOpportunitiesGetNullTest/CacheKey";

            var result = await sharedContentRedisInterface.GetCurrentOpportunitiesData<string>(cacheKey);

            Assert.Null(result);
        }
    }
}
