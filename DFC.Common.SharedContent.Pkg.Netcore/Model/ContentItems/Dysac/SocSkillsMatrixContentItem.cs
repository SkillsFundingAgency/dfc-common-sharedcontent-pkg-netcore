using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class SocSkillsMatrixContentItem
    {
        [JsonProperty("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("ordinal")]
        public int? Ordinal { get; set; }

        [JsonProperty("oNetAttributeType")]
        public string ONetAttributeType { get; set; }

        [JsonProperty("oNetRank")]
        public decimal? ONetRank { get; set; }
    }
}
