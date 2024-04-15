using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfileWhatYoullDoResponse
    {
        [JsonProperty("jobProfile")]
        public List<JobProfileWhatYoullDo>? JobProfileWhatYoullDo { get; set; }
    }
}
