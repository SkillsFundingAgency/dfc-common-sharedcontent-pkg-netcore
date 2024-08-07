using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public class TriageLevelTwo
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("ordinal")]
        public int? Ordinal { get; set; }

        [JsonPropertyName("levelOne")]
        public TriageLevelOne? LevelOne { get; set; }
    }
}
