using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles.JobProfileCategory
{
    public class JobProfile
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("AlternativeTitle")]
        public string AlternativeTitle { get; set; }

        [JsonProperty("Overview")]
        public string Overview { get; set; }

        [JsonProperty("UrlName")]
        public string UrlName { get; set; }
    }
}
