using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;

namespace DFC.Common.SharedContent.Pkg.Netcore
{
    internal class RedisActions : IRedisActions
    {
        public async Task<bool> AddEntityToCacheAsync(string nodeId, string content)
        {
            return true;
        }

        public async Task<bool> InvalidateEntityAsync(string nodeId)
        {
            return true;
        }
    }
}
