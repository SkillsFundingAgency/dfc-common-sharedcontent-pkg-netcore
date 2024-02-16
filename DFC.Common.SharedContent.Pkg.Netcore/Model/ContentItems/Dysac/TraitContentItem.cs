using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class TraitContentItem
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonPropertyName("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonProperty("jobProfileCategories")]
        public JobProfileCategories JobProfileCategories { get; set; }
    }
}
