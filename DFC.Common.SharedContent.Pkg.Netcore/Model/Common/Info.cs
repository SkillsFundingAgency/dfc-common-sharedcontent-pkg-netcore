using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public class Info
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }
}
