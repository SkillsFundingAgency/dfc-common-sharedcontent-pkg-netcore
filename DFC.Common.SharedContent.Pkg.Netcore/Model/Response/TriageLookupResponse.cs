﻿using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class TriageLookupResponse
    {
        [JsonPropertyName("triageLevelTwo")]
        public List<TriageLevelTwo>? TriageLevelTwo { get; set; }

        [JsonPropertyName("triageLevelOne")]
        public List<TriageLevelOne>? TriageLevelOne { get; set; }

        [JsonPropertyName("filterAdviceGroup")]
        public List<FilterAdviceGroup>? FilterAdviceGroup { get; set; }
    }
}