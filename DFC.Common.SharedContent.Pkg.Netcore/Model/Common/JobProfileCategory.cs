﻿using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public class JobProfileCategory
    {
        [JsonProperty("contentItemId")]
        public string? ContentItemId { get; set; }

        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("graphSync")]
        public GraphSync GraphSync { get; set; }

        public List<JobProfile> JobProfiles { get; set; }

        [JsonProperty("pageLocation")]
        public PageLocation PageLocation { get; set; }

        [JsonProperty("imagePathDesktop")]
        public string? ImagePathDesktop { get; set; }

        [JsonProperty("imagePathMobile")]
        public string? ImagePathMobile { get; set; }

        [JsonProperty("imagePathTitle")]
        public string? ImagePathTitle { get; set; }
    }
}
