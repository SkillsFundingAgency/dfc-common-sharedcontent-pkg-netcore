using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class ContentItem
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }
    }
}
