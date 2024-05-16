using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfileApiSummaryResponse
    {
        [JsonProperty("jobProfile")]
        public List<JobProfileSummary>? JobProfileSummary { get; set; }
    }
}
