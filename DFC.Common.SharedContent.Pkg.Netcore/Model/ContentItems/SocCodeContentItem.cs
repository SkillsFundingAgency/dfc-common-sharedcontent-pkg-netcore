using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class SocCodeContentItem
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("sOC2020")]
        public string? SOC2020 { get; set; }

        [JsonProperty("sOC2020extension")]
        public string? SOC2020extension { get; set; }

        [JsonProperty("onetOccupationCode")]
        public string? OnetOccupationCode { get; set; }
    }
}
