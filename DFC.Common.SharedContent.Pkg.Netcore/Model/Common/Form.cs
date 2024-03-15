using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public class Form
    {
        [JsonProperty("action")]
        public string? Action { get; set; }

        [JsonProperty("method")]
        public string? Method { get; set; }

        [JsonProperty("encType")]
        public string? EncType { get; set; }
    }
}
