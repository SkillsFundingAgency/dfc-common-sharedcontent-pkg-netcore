using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;

namespace DFC.Common.SharedContent.Pkg.Netcore
{
    public class RedisActions : IRedisActions
    {
        public async Task<bool> AddEntityToCacheAsync(string nodeId, string content)
        {
            return true;
        }

        public async Task<bool> InvalidateEntityAsync(string cachekey)
        {
            //delete cachekey
            return true;
        }
    }
}
