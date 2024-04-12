using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{

    public class WorkingPatternDetails
    {
        [JsonProperty("contentItems")]
        public List<ContentItem> ContentItems { get; set; }
    }
}
