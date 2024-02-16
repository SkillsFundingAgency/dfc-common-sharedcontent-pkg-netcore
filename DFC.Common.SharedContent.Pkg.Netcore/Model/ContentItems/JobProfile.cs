using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class JobProfile
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync GraphSync { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }
    }
}
