using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class Widget
    {
        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; }

        [JsonPropertyName("htmlBody")]
        public HtmlBody? HtmlBody { get; set; }

        [JsonPropertyName("sharedContent")]
        public SharedContent? SharedContent { get; set; }

        [JsonPropertyName("formContent")]
        public string? FormContent { get; set; }

        [JsonProperty("formElement")]
        public FormElement? FormElement { get; set; }

        [JsonPropertyName("form")]
        public Form? Form { get; set; }

        [JsonPropertyName("flow")]
        public Flow? Flow { get; set; }

        [JsonProperty("encType")]
        public string? EncType { get; set; }

        [JsonProperty("method")]
        public string? Method { get; set; }

        [JsonPropertyName("contentType")]
        public string? ContentType { get; set; }

        [JsonPropertyName("widgets")]
        public List<Widget>? ContentItems { get; set; }
    }

    public class FormElement
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
    }

    public class HtmlBody
    {
        [JsonPropertyName("html")]
        public string? Html { get; set; }
    }

    public class Metadata
    {
        [JsonPropertyName("alignment")]
        public string? Alignment { get; set; }

        [JsonPropertyName("size")]
        public int? Size { get; set; }
    }

    public class SharedContent
    {
        [JsonPropertyName("contentItems")]
        public List<ContentItem>? ContentItems { get; set; }
    }
}
