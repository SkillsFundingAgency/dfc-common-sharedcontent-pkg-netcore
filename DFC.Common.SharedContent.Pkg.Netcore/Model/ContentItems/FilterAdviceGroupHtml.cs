using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

public class FilterAdviceGroupHtml
{
    [JsonPropertyName("html")]
    public string? Html { get; set; }
}
