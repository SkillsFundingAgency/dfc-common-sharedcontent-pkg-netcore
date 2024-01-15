using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class TriageToolSummary
    {
        [JsonPropertyName("html")]
        public string Html { get; set; }
    }
}
