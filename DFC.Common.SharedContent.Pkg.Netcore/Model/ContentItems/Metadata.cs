using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class Metadata
    {
        [JsonPropertyName("alignment")]
        public string Alignment { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }
    }
}
