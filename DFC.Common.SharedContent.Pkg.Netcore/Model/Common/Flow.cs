﻿using System.Text.Json.Serialization;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Common
{
    public class Flow
    {
        [JsonPropertyName("widgets")]
        public List<Widget>? Widgets { get; set; }
    }
}
