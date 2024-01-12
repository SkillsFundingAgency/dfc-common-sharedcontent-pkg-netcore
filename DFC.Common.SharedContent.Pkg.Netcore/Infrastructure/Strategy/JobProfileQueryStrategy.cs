using DFC.Common.SharedContent.Pkg.Netcore.Model;
using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy;

public class JobProfileQueryStrategy : ISharedContentRedisInterfaceStrategy<JobProfileCategoryList>
{
    public async Task<JobProfileCategoryList> ExecuteQueryAsync(string key)
    {
        return await Task.FromResult(new JobProfileCategoryList
        {
            Categories = new List<JobProfileCategory>()
        });
    }
}