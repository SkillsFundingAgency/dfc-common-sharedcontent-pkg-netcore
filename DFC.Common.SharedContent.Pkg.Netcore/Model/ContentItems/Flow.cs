using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class Flow
    {
        [JsonPropertyName("widgets")]
        public List<Widget>? Widgets { get; set; }
    }
}
