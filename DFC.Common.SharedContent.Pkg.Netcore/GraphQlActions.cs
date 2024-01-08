using DFC.Common.SharedContent.Pkg.Netcore.Interfaces;

namespace DFC.Common.SharedContent.Pkg.Netcore;

public class GraphQlActions : IGraphQlActions
{
    public async Task<string> GetDataAsync(string queryId, List<string> parameters)
    {
        var result = @"{""Data"" : ""Empty""}";

        return result;
    }
}
