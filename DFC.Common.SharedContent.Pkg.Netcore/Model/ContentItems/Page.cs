using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

public class Page
{
    [JsonPropertyName("displayText")]
    public string DisplayText { get; set; }

    [JsonPropertyName("description")]
    public object Description { get; set; }

    [JsonPropertyName("pageLocation")]
    public PageLocation PageLocation { get; set; }

    [JsonPropertyName("breadcrumb")]
    public Breadcrumb Breadcrumb { get; set; }

    [JsonPropertyName("useBrowserWidth")]
    public bool? UseBrowserWidth { get; set; }

    [JsonPropertyName("showBreadcrumb")]
    public bool ShowBreadcrumb { get; set; }

    [JsonPropertyName("showHeroBanner")]
    public bool ShowHeroBanner { get; set; }

    [JsonPropertyName("herobanner")]
    public Herobanner Herobanner { get; set; }

    [JsonPropertyName("useInTriageTool")]
    public bool UseInTriageTool { get; set; }

    [JsonPropertyName("triageToolSummary")]
    public TriageToolSummary TriageToolSummary { get; set; }

    [JsonPropertyName("triageToolFilters")]
    public TriageToolFilters TriageToolFilters { get; set; }

    [JsonPropertyName("flow")]
    public Flow Flow { get; set; }
}