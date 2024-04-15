﻿using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac.PersonalityTrait;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class JobProfileCurrentOpportunitiesResponse
    {
        [JsonProperty("jobProfile")]
        public List<JobProfileCurrentOpportunities> JobProfileCurrentOpportunities { get; set; }
    }
}
