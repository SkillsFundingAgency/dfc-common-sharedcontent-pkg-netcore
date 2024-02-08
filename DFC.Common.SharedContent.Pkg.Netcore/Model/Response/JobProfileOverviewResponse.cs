using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfileOverviewResponse
    {
        [JsonPropertyName("jobProfile")]
        public List<JobProfileOverview> JobProfile { get; set; }
    }
}
