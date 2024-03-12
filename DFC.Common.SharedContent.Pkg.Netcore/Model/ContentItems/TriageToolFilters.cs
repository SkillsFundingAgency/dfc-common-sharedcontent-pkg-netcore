using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class TriageToolFilters
    {
        [JsonPropertyName("contentItems")]
        public List<TriageToolFilters>? ContentItems { get; set; }

        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync? GraphSync { get; set; }

        [JsonProperty("contentType")]
        public string? ContentType { get; set; }
    }

    public partial class GraphSync
    {
        [JsonProperty("nodeId")]
        public string? NodeId { get; set; }
    }
}
