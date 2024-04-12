﻿using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class JobProfileOverview
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation? PageLocation { get; set; }

        [JsonProperty("alternativeTitle")]
        public string? AlternativeTitle { get; set; }

        [JsonProperty("hiddenAlternativeTitle")]
        public HiddenAlternativeTitle? HiddenAlternativeTitle { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }

        [JsonProperty("salarystarterperyear")]
        public string? Salarystarterperyear { get; set; }

        [JsonProperty("salaryexperiencedperyear")]
        public string? Salaryexperiencedperyear { get; set; }

        [JsonProperty("minimumhours")]
        public string? Minimumhours { get; set; }

        [JsonProperty("maximumhours")]
        public string? Maximumhours { get; set; }

        [JsonProperty("workingHoursDetails")]
        public WorkingHoursDetails? WorkingHoursDetails { get; set; }

        [JsonProperty("workingPattern")]
        public WorkingPattern? WorkingPattern { get; set; }

        [JsonProperty("workingPatternDetails")]
        public WorkingPatternDetails? WorkingPatternDetails { get; set; }
    }
}