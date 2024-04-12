using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfilesOverviewResponse
    {
        [JsonProperty("jobProfile")]
        public List<JobProfileOverview>? JobProfileOverview { get; set; }
    }
}
