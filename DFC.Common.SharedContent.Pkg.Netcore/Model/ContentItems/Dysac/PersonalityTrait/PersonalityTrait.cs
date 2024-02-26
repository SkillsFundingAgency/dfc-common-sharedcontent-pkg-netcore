using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Model;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac.PersonalityTrait
{
    public class PersonalityTrait
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonProperty("jobProfileCategories")]
        public JobProfileCategories JobProfileCategories { get; set; }
    }

    public partial class GraphSync
    {
        [JsonProperty("nodeId")]
        public string? NodeId { get; set; }
    }

    public partial class JobProfileCategories
    {
        [JsonProperty("contentItems")]
        public JobProfileCategory[] ContentItems { get; set; }
    }
}
