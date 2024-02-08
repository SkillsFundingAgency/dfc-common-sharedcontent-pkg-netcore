using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class JobProfileOverview
    {
        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("contentItemId")]
        public string ContentItemId { get; set; }
    }
}
