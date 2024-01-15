using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class TermContentItem
    {
        [JsonPropertyName("displayText")]
        public string DisplayText { get; set; }

        [JsonPropertyName("modifiedUtc")]
        public DateTime ModifiedUtc { get; set; }

        [JsonPropertyName("breadcrumbText")]
        public string BreadcrumbText { get; set; }
    }
}
