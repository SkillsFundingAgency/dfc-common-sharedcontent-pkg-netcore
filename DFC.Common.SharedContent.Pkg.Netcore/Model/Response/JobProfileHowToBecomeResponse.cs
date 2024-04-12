using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfileHowToBecomeResponse
    {
        [JsonProperty("jobProfile")]
        public List<JobProfileHowToBecome>? JobProfileHowToBecome { get; set; }
    }
}
