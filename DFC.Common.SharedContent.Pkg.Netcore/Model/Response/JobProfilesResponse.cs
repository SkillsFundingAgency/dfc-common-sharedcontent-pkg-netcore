using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles.JobProfileCategory;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBreadcrumb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfilesResponse
    {
        [JsonPropertyName("items")]

        public List<JobProfile> Items { get; set; }
    }
}
