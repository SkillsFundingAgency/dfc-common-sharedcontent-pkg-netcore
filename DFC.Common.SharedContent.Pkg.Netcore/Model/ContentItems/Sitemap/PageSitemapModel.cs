using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Sitemap
{
    public class PageSitemapModel
    {
        [JsonPropertyName("sitemap")]
        public SitemapModel? Sitemap { get; set; }

        [JsonPropertyName("pageLocation")]
        public PageLocation? PageLocation { get; set; }
    }

    public partial class SitemapModel
    {
        [JsonPropertyName("changeFrequency")]
        public string? ChangeFrequency { get; set; }

        [JsonPropertyName("exclude")]
        public bool? Exclude { get; set; }

        [JsonPropertyName("priority")]
        public double? Priority { get; set; }
    }

    public partial class PageLocation
    {
        [JsonPropertyName("fullUrl")]
        public string? FullUrl { get; set; }

        [JsonPropertyName("urlName")]
        public string? urlName { get; set; }

        [JsonPropertyName("defaultPageForLocation")]
        public bool? DefaultPageForLocation { get; set; }
    }
}
