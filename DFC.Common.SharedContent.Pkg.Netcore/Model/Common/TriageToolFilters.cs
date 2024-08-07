using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
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
}
