using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class PageUrl
    {
        [JsonPropertyName("displayText")]
        public string DisplayText { get; set; }

        [JsonPropertyName("pageLocation")]
        public PageLocation PageLocation { get; set; }

        [JsonPropertyName("breadcrumb")]
        public Breadcrumb Breadcrumb { get; set; }

        [JsonPropertyName("triageToolFilters")]
        public TriageToolFilters TriageToolFilters { get; set; }
    }
}
