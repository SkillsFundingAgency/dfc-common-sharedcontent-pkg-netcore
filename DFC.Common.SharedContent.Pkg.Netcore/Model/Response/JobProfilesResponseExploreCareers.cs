using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfilesResponseExploreCareers
    {
        [JsonProperty("jobProfile")]
        public List<JobProfile>? JobProfiles { get; set; }
    }
}
