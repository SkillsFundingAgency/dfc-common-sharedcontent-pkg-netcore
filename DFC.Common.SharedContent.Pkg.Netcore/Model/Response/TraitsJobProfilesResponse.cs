using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac.PersonalityTrait;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class TraitsJobProfilesResponse
    {

        [JsonProperty("jobProfile")]
        public List<JobProfile> TraitsJobProfiles { get; set; }
    }
}
