using System.Text.Json.Serialization;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

public class TriageResultPage
{
    [JsonPropertyName("displayText")]
    public string? DisplayText { get; set; }

    [JsonPropertyName("description")]
    public object? Description { get; set; }

    [JsonPropertyName("pageLocation")]
    public PageLocation? PageLocation { get; set; }

    [JsonPropertyName("levelOne")]
    public TriageLevelOne? LevelOne { get; set; }

    [JsonPropertyName("levelTwo")]
    public TriageLevelOne? LevelTwo { get; set; }

    [JsonPropertyName("filterAdviceGroup")]
    public FilterAdviceGroup? FilterAdviceGroup { get; set; }

    [JsonPropertyName("triageTileTitle")]
    public string? TriageTileTitle { get; set; }

    [JsonPropertyName("triageTileDescription")]
    public string? TriageTileDescription { get; set; }

    [JsonPropertyName("triageOrdinal")]
    public int? TriageOrdinal { get; set; }

    [JsonPropertyName("triageTileIconName")]
    public string? TriageTileIconName { get; set; }

    [JsonPropertyName("applicationViewLocation")]
    public string? ApplicationViewLocation { get; set; }

    [JsonPropertyName("useInTriageTool")]
    public bool? UseInTriageTool { get; set; }
}
