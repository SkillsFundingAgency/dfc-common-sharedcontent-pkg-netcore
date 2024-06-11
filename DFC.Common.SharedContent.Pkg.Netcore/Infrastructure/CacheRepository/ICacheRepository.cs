namespace DFC.Common.SharedContent.Pkg.Netcore.Infrastructure.CacheRepository
{
    public interface ICacheRepository
    {
        Task<TResponse> GetQueryWithPagination<TResponse, TRecordType>(string query, Func<TResponse, List<TRecordType>> recordSelectorFunc, Func<List<TRecordType>, TResponse> mergerFunc, int paginationCount = 100)
            where TResponse : class;
    }
}
