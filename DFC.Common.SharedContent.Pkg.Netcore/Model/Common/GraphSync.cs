﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public partial class GraphSync
    {
        [JsonProperty("nodeId")]
        public string? NodeId { get; set; }
    }
}
