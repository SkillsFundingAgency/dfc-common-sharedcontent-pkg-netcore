using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class SharedContent
    {
        [JsonPropertyName("contentItems")]
        public List<ContentItem> ContentItems { get; set; }
    }
}
