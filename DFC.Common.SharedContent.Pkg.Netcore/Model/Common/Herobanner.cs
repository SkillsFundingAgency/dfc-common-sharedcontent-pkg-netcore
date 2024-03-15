using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public class Herobanner
    {
        [JsonPropertyName("html")]
        public string? Html { get; set; }
    }
}
