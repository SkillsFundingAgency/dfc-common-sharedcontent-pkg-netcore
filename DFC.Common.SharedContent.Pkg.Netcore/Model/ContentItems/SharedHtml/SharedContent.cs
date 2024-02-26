using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.SharedHtml
{
    public partial class SharedHtmlContent
    {
        [JsonProperty("content")]
        public SharedHtml Content { get; set; }
    }

    public partial class SharedHtml
    {
        [JsonPropertyName("html")]
        public string? Html { get; set; }
    }
}
