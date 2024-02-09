using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class PersonalityFilteringQuestion
    {
        [JsonProperty("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("sOCSkillsMatrix")]
        public SocSkillsMatrix SocSkillsMatrices { get; set; }

        [JsonProperty("ordinal")]
        public int? Ordinal { get; set; }
    }

    public partial class GraphSync
    {
        [JsonProperty("nodeId")]
        public string NodeId { get; set; }
    }

    public partial class SocSkillsMatrix
    {
        [JsonProperty("contentItems")]
        public SocSkillsMatrixContentItem[] ContentItems { get; set; }
    }
}
