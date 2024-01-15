using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class TriageToolFilters
    {
        [JsonPropertyName("contentItems")]
        public List<object> ContentItems { get; set; }
    }
}
