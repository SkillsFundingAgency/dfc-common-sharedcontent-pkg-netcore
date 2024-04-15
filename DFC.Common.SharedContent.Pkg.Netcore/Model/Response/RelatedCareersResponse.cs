using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class RelatedCareersResponse
    {
        [JsonProperty("jobProfile")]
        public List<JobProfileRelatedCareers>? JobProfileRelatedCareers { get; set; }
    }
}
