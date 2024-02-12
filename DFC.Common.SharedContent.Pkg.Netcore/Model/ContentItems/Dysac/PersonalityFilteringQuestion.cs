using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class PersonalityFilteringQuestion
    {
        [JsonPropertyName("displayText")]
        public string DisplayText { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("ordinal")]
        public int? Ordinal { get; set; }

        [JsonPropertyName("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonPropertyName("sOCSkillsMatrix")]
        public SOCSkillsMatrix SOCSkillsMatrix { get; set; }
    }
}
