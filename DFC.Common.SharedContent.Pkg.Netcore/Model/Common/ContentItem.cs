using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public class ContentItem
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("isGlobal")]
        public bool? IsGlobal { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("content")]
        public Content? Content { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync? GraphSync { get; set; }

        [JsonProperty("description")]
        public object? Description { get; set; }

        [JsonProperty("info")]
        public Info? Info { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("uRL")]
        public string? URL { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }
}
