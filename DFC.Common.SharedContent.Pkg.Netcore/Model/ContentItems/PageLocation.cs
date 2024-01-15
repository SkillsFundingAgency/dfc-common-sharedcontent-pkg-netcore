using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class PageLocation
    {
        [JsonPropertyName("urlName")]
        public string UrlName { get; set; }

        [JsonPropertyName("fullUrl")]
        public string FullUrl { get; set; }

        [JsonPropertyName("redirectLocations")]
        public string RedirectLocations { get; set; }

        [JsonPropertyName("defaultPageForLocation")]
        public bool DefaultPageForLocation { get; set; }
    }
}
