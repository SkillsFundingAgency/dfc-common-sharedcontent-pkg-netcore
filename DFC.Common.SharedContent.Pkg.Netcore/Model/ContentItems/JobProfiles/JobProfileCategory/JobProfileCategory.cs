using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles.JobProfileCategory
{
    public class JobProfileCategory
    {

            [JsonProperty("displayText")]
            public string DisplayText { get; set; }

            [JsonProperty("pageLocation")]
            public PageLocation PageLocation { get; set; }
    }
}
