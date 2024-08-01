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

    public class TriageLevelOne
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("ordinal")]
        public int Ordinal { get; set; }

    }
    public class TriageLevelTwo
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("ordinal")]
        public int? Ordinal { get; set; }

        [JsonPropertyName("levelOneTitle")]
        public string LevelOneTitle { get; set; }

        [JsonPropertyName("levelOne")]
        public TriageLevelOne LevelOne { get; set; }
        

    }
}
