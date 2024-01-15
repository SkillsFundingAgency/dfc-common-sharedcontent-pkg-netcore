using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class Form
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }
    }
}
