using System.Text.Json.Serialization;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public class Breadcrumb
    {
        [JsonPropertyName("termContentItems")]
        public List<TermContentItem>? TermContentItems { get; set; }
    }

    public class TermContentItem
    {
        [JsonPropertyName("displayText")]
        public string? DisplayText { get; set; }

        [JsonPropertyName("modifiedUtc")]
        public DateTime? ModifiedUtc { get; set; }

        [JsonPropertyName("breadcrumbText")]
        public string? BreadcrumbText { get; set; }
    }
}
