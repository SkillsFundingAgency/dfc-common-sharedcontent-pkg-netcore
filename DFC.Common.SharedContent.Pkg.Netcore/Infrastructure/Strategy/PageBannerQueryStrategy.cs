using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class PageBannerQueryStrategy : ISharedContentRedisInterfaceStrategy<PageBanner>
{
    public async Task<PageBanner> ExecuteQueryAsync(string key)
    {
        return await Task.FromResult(new PageBanner
        {
        });
    }
}