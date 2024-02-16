using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfileDysacResponse
    {
        [JsonPropertyName("jobProfile")]
        public List<JobProfile> JobProfile { get; set; }
    }
}
