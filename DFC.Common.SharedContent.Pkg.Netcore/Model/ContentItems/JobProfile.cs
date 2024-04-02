using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class JobProfile
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync? GraphSync { get; set; }

        [JsonProperty("alternativeTitle")]
        public string? AlternativeTitle { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation? PageLocation { get; set; }

        [JsonProperty("relatedskills")]
        public Relatedskills? Relatedskills { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }

        [JsonProperty("salarystarterperyear")]
        public string? Salarystarterperyear { get; set; }

        [JsonProperty("salaryexperiencedperyear")]
        public string? Salaryexperiencedperyear { get; set; }

        [JsonProperty("maximumhours")]
        public string? Maximumhours { get; set; }

        [JsonProperty("minimumhours")]
        public string? Minimumhours { get; set; }

        [JsonProperty("workingPattern")]
        public WorkingPattern? WorkingPattern { get; set; }

        [JsonProperty("workingHoursDetails")]
        public WorkingHoursDetails? WorkingHoursDetails { get; set; }

        [JsonProperty("workingPatternDetails")]
        public WorkingPatternDetails? WorkingPatternDetails { get; set; }
    }

    public partial class Relatedskills
    {
        [JsonProperty("contentItems")]
        public RelatedSkill[]? ContentItems { get; set; }
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

    public class WorkingPattern
    {
        [JsonProperty("contentItems")]
        public List<ContentItem> ContentItems { get; set; }
    }

    public class WorkingHoursDetails
    {
        [JsonProperty("contentItems")]
        public List<ContentItem> ContentItems { get; set; }
    }

    public class WorkingPatternDetails
    {
        [JsonProperty("contentItems")]
        public List<ContentItem> ContentItems { get; set; }
    }
}
