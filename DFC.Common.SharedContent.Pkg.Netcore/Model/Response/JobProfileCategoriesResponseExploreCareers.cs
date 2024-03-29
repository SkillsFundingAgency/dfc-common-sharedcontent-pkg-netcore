﻿using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfileCategoriesResponseExploreCareers
    {
        [JsonProperty("jobProfileCategory")]
        public JobProfileCategory[] JobProfileCategories { get; set; }
    }
}
