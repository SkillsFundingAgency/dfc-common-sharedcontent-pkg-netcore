using DFC.Common.SharedContent.Pkg.Netcore.Model;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class PageQueryStrategy : ISharedContentRedisInterfaceStrategy<PagesContentItem>
{
    public async Task<PagesContentItem> ExecuteQueryAsync(string key)
    {
        return await Task.FromResult(new PagesContentItem
        {
            Id = key,
            Content = "TEST PAGE"
        });
    }
}