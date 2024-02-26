using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class TriageToolFilter
    {
        [JsonPropertyName("contentItems")]
        public List<object> ContentItems { get; set; }
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }
        [JsonProperty("graphSync")]
        public GraphSync GraphSync { get; set; }
    }
}
