using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{

    public class PageResponse
    {
        [JsonPropertyName("page")]
        public List<Page> Page { get; set; }
    }
}
