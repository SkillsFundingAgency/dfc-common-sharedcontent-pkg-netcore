using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

public class PageBanner
{
    public partial class Pagebanner
    {
   
        public Banner Banner { get; set; }

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("addabanner")]
        public Addabanner Addabanner { get; set; }
    }

    public partial class Addabanner
    {
        [JsonProperty("contentItems")]
        public ContentItem[] ContentItems { get; set; }
    }

    public partial class ContentItem
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("isGlobal")]
        public bool IsGlobal { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("html")]
        public string Html { get; set; }
    }

    public partial class Banner
    {
        [JsonProperty("webPageURL")]
        public string WebPageUrl { get; set; }

        [JsonProperty("webPageName")]
        public string WebPageName { get; set; }
    }
}
