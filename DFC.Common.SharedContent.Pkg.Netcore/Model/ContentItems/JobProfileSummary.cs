using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class JobProfileSummary
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation? PageLocation { get; set; }

        [JsonProperty("publishedUtc")]
        public string? PublishedUtc { get; set; }
    }
}
