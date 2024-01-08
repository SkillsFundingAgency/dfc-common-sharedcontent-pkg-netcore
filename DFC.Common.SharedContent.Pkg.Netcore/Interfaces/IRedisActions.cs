namespace DFC.Common.SharedContent.Pkg.Netcore.Interfaces
{
    public interface IRedisActions
    {
        Task<bool> InvalidateEntityAsync(string nodeId);

        Task<bool> AddEntityToCacheAsync(string nodeId, string content);
    }
}
