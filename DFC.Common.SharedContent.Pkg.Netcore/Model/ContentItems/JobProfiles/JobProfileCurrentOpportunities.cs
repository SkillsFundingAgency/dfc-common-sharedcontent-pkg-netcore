using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles
{
    public class JobProfileCurrentOpportunities
    {
        [JsonPropertyName("coursekeywords")]
        public string? Coursekeywords { get; set; }

        [JsonPropertyName("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonPropertyName("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }

        [JsonProperty("sOCCode")]
        public SOCCode SOCCode { get; set; }
    }

    public class SOCCode
    {
        [JsonProperty("contentItems")]
        public SOCCodeContentItem[] ContentItems { get; set; }
    }

    public class SOCCodeContentItem
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonPropertyName("apprenticeshipStandards")]
        public ApprenticeshipStandards ApprenticeshipStandards { get; set; }
    }

    public class ApprenticeshipStandards
    {
        [JsonProperty("contentItems")]
        public ApprenticeshipStandardsContentItem[] ContentItems { get; set; }
    }

    public class ApprenticeshipStandardsContentItem
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync? GraphSync { get; set; }

        [JsonProperty("lARScode")]
        public string? LARScode { get; set; }
    }
}
