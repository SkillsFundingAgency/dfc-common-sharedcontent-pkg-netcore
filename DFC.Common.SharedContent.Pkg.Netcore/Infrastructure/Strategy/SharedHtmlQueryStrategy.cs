using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class SharedHtmlQueryStrategy : ISharedContentRedisInterfaceStrategy<SharedHtmlContentItem>
{
    public async Task<SharedHtmlContentItem> ExecuteQueryAsync(string key)
    {
        return await Task.FromResult(new SharedHtmlContentItem
        {
            Id = key,
            Content = "TEST SHARED HTML CONTENT"
        });
    }
}