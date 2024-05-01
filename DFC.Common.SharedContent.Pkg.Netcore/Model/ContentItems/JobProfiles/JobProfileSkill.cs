using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles
{
    public class JobProfileSkill
    {
        [JsonPropertyName("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation? PageLocation { get; set; }

        [JsonProperty("otherrequirements")]
        public Otherrequirements? Otherrequirements { get; set; }

        [JsonProperty("relatedrestrictions")]
        public Relatedrestrictions? Relatedrestrictions { get; set; }

        [JsonProperty("digitalSkills")]
        public DigitalSkills? DigitalSkills { get; set; }

        [JsonProperty("relatedskills")]
        public Relatedskills? Relatedskills { get; set; }
    }

    public class Otherrequirements
    {
        [JsonPropertyName("html")]
        public string? Html { get; set; }
    }

    public class Relatedrestrictions
    {
        [JsonProperty("contentItems")]
        public List<RelatedrestrictionsContentItem>? ContentItems { get; set; }
    }

    public class RelatedrestrictionsContentItem
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonPropertyName("info")]
        public Info? Info { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync? GraphSync { get; set; }
    }

    public class DigitalSkills
    {
        [JsonProperty("contentItems")]
        public List<DigitalSkillsContentItem>? ContentItems { get; set; }
    }

    public class DigitalSkillsContentItem
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync? GraphSync { get; set; }
    }

    public partial class Relatedskills
    {
        [JsonProperty("contentItems")]
        public List<RelatedSkill>? ContentItems { get; set; }
    }

    public partial class RelatedSkill
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("oNetAttributeType")]
        public string? ONetAttributeType { get; set; }

        [JsonProperty("oNetRank")]
        public string? ONetRank { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync? GraphSync { get; set; }

        public int? Ordinal { get; set; }

        [JsonProperty("relatedSkill")]
        public string? RelatedSkillDesc { get; set; }

        [JsonProperty("relatedSOCcode")]
        public string? RelatedSOCcode { get; set; }
    }
}
