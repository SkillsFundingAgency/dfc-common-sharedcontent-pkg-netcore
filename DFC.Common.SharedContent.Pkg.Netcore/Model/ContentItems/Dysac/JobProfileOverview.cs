﻿using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class JobProfileOverview
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("salarystarterperyear")]
        public int Salarystarterperyear { get; set; }

        [JsonProperty("salaryexperiencedperyear")]
        public int Salaryexperiencedperyear { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }

        [JsonProperty("maximumhours")]
        public int Maximumhours { get; set; }

        [JsonProperty("minimumhours")]
        public int Minimumhours { get; set; }

        [JsonProperty("workingPattern")]
        public WorkingPattern WorkingPattern { get; set; }

        [JsonProperty("workingHoursDetails")]
        public WorkingHoursDetails WorkingHoursDetails { get; set; }

        [JsonProperty("workingPatternDetails")]
        public WorkingPatternDetails WorkingPatternDetails { get; set; }
    }
}