using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class JobProfileCategory
    {
        [JsonProperty("contentItemId")]
        public string? ContentItemId { get; set; }

        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync GraphSync { get; set; }

        public List<JobProfile> JobProfiles { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }
    }
}
