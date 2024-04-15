using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfileCareerPathAndProgressionResponse
    {
        [JsonProperty("jobProfile")]
        public List<JobProfileCareerPathAndProgression>? JobProileCareerPath { get; set; }
    }

    public class JobProfileCareerPathAndProgression
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("careerpathandprogression")]
        public JobProileCareerPath? Content { get; set; }
    }

    public partial class JobProileCareerPath
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }
}