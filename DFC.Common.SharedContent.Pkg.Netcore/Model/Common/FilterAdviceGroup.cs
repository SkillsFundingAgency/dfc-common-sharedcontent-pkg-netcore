using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public class FilterAdviceGroup
    {
        [JsonPropertyName("contentItems")]
        public List<FilterAdviceGroup>? ContentItems { get; set; }

        [JsonPropertyName("contentItemId")]
        public string? ContentItemId { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("triageTileImage")]
        public string? triageTileImage { get; set; }
    }
}
