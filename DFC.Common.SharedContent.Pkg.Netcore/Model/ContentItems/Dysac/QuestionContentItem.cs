using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class QuestionContentItem
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("impact")]
        public string? Impact { get; set; }

        [JsonProperty("contentItemId")]
        public string? ContentItemId { get; set; }

        [JsonPropertyName("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonProperty("trait")]
        public Trait Trait { get; set; }

        public int? Ordinal { get; set; }
    }
}
