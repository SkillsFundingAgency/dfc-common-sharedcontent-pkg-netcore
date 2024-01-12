using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class Herobanner
    {
        [JsonPropertyName("html")]
        public string Html { get; set; }
    }
}
