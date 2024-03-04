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
    }

    public partial class SitemapModel
    {
        [JsonPropertyName("changeFrequency")]
        public string? ChangeFrequency { get; set; }

        [JsonPropertyName("exclude")]
        public bool? Exclude { get; set; }

        [JsonPropertyName("overrideSitemapConfig")]
        public bool? OverrideSitemapConfig { get; set; }

        [JsonPropertyName("priority")]
        public double? Priority { get; set; }
    }
}
