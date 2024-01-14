using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.SharedHtml;

public class SharedHtml
{
    [JsonPropertyName("html")]
    public string Html { get; set; }
}
