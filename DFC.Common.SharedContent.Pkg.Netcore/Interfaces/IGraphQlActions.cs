using System.Net.Http.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Interfaces
{
    public interface IGraphQlActions
    {
        Task<string> GetDataAsync(string queryId, List<string> parameters);
    }
}
