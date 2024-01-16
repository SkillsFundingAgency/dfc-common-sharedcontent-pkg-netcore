using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class PageBannerResponse
    {
        [JsonPropertyName("pagebanner")]
        public List<PageBanner> PageBanner { get; set; }
    }
}
