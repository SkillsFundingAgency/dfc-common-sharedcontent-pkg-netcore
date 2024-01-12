namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

public class Page
{
    public string? FullUrl { get; set; }

    public string? UrlName { get; set; }

    public bool? DefaultPageForLocation { get; set; }

    public string? RedirectLocations { get; set; }

    public string? ChangeFrequency { get; set; }

    public bool? Exclude { get; set; }

    public bool? OverrideSitemapConfig { get; set; }

    public int? Priority { get; set; }
}