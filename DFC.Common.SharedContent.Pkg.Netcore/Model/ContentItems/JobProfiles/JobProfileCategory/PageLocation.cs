using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles.JobProfileCategory
{
    public class PageLocation
    {
        [JsonProperty("fullUrl")]
        public string FullUrl { get; set; }
    }
}
