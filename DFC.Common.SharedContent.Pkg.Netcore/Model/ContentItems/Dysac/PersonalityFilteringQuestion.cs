using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
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
    public class PersonalityFilteringQuestion
    {
        [JsonPropertyName("displayText")]
        public string? DisplayText { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("ordinal")]
        public int? Ordinal { get; set; }

        [JsonPropertyName("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonPropertyName("sOCSkillsMatrix")]
        public SOCSkillsMatrix SOCSkillsMatrix { get; set; }
    }

    public class SOCSkillsMatrix
    {
        [JsonProperty("contentItems")]
        public SOCSkillsMatrixContentItem[] ContentItems { get; set; }
    }

    public class SOCSkillsMatrixContentItem
    {
        [JsonPropertyName("displayText")]
        public string? DisplayText { get; set; }

        [JsonPropertyName("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonPropertyName("modifiedUtc")]
        public string? ModifiedUtc { get; set; }

        [JsonPropertyName("oNetAttributeType")]
        public string? ONetAttributeType { get; set; }

        [JsonPropertyName("oNetRank")]
        public string? ONetRank { get; set; }

        public int? Ordinal { get; set; }

        [JsonPropertyName("relatedSkill")]
        public string? RelatedSkill { get; set; }
    }
}
