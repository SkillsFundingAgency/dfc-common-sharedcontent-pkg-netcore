using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class Metadata
    {
        [JsonPropertyName("alignment")]
        public string? Alignment { get; set; }

        [JsonPropertyName("size")]
        public int? Size { get; set; }
    }
}
