using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner
{
    public class PageBanner
    {
        [JsonProperty("banner")]
        public Banner Banner { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonProperty("addabanner")]
        public AddABanner AddABanner { get; set; }
    }

    public partial class AddABanner
    {
        [JsonProperty("contentItems")]
        public ContentItem[] ContentItems { get; set; }
    }

    public partial class Banner
    {
        [JsonProperty("webPageURL")]
        public string? WebPageUrl { get; set; }

        [JsonProperty("webPageName")]
        public string? WebPageName { get; set; }
    }
}
