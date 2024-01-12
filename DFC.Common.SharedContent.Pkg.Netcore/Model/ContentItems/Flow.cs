using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class Flow
    {
        [JsonPropertyName("widgets")]
        public List<Widget> Widgets { get; set; }
    }
}
