using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class TermContentItem
    {
        [JsonPropertyName("displayText")]
        public string DisplayText { get; set; }

        [JsonPropertyName("modifiedUtc")]
        public DateTime ModifiedUtc { get; set; }

        [JsonPropertyName("breadcrumbText")]
        public string BreadcrumbText { get; set; }
    }
}
