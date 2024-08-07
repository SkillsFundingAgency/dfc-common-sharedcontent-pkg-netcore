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
    }
}
