using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class Form
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }
    }
}
