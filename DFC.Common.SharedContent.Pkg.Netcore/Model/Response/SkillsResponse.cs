using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class SkillsResponse
    {
        [JsonProperty("skill")]
        public List<Skills>? Skill { get; set; }
    }
}
