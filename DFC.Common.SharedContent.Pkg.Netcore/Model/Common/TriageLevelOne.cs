using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public class TriageLevelOne
    {
        [JsonPropertyName("contentItems")]
        public List<TriageLevelOne>? ContentItems { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("ordinal")]
        public int Ordinal { get; set; }

        [JsonPropertyName("levelTwo")]
        public TriageLevelTwo? LevelTwo { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("filterAdviceGroup")]
        public FilterAdviceGroup? FilterAdviceGroup { get; set; }
    }
}
