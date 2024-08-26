using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public class TriageLevelTwo
    {
        [JsonPropertyName("contentItems")]
        public List<TriageLevelTwo>? ContentItems { get; set; }

        [JsonPropertyName("contentItemId")]
        public string? ContentItemId { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("ordinal")]
        public int? Ordinal { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("filterAdviceGroup")]
        public FilterAdviceGroup? FilterAdviceGroup { get; set; }
    }
}
