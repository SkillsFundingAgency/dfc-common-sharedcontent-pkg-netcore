using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles
{
    public class Skills
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("oNetElementId")]
        public string? ONetElementId { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync? GraphSync { get; set; }
    }
}
