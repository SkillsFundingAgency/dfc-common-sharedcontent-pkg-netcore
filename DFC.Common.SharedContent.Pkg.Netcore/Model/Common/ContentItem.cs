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
    }

    public partial class Content
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }
}
