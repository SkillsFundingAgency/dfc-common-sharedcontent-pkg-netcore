using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

public class TriageResult
{
    [JsonPropertyName("contentItems")]
    public List<TriageResult>? ContentItems { get; set; }

    [JsonPropertyName("resultContentItemId")]
    public string? ResultContentItemId { get; set; }
}
