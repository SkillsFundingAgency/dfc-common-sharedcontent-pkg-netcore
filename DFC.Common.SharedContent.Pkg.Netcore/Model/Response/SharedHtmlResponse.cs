using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.SharedHtml;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class SharedHtmlResponse
    {
        [JsonPropertyName("sharedContent")]
        public List<SharedHtmlContent> SharedContent { get; set; }
    }
}
