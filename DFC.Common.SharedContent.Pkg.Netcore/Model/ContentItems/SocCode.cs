using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class SocCode
    {
        [JsonProperty("contentItems")]
        public List<SocCodeContentItem>? ContentItems { get; set; }
    }
}
