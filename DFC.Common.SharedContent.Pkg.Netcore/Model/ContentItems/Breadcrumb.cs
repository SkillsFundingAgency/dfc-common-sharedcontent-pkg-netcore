using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class Breadcrumb
    {
        [JsonPropertyName("termContentItems")]
        public List<TermContentItem> TermContentItems { get; set; }
    }
}
