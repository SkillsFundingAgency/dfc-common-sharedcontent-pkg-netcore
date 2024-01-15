﻿using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles.JobProfileCategory;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfileCategoriesResponse
    {
        [JsonProperty("jobProfileCategory")]
        public JobProfileCategory[] JobProfileCategories { get; set; }
    }
}