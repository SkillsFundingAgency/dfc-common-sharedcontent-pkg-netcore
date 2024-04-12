using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfileVideoResponse
    {
        [JsonProperty("jobProfile")]
        public List<JobProfileVideo>? JobProfileVideo { get; set; }
    }
}
