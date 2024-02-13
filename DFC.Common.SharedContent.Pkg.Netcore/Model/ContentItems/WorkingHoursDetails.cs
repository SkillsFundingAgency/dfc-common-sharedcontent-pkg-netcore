using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class WorkingHoursDetails
    {
        [JsonProperty("contentItems")]
        public List<ContentItem> ContentItems { get; set; }
    }
}