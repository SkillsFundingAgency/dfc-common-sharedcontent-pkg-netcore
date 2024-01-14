using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
