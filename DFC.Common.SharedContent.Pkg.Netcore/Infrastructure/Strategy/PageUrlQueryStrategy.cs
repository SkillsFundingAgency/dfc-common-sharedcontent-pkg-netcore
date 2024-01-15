using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using GraphQL.Client.Abstractions;

namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.Strategy
{
    public class PageUrlQueryStrategy : ISharedContentRedisInterfaceStrategy<PageUrl>
    {
        private readonly IGraphQLClient client;

        public PageUrlQueryStrategy(IGraphQLClient client)
        {
        }

        public Task<PageUrl> ExecuteQueryAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
