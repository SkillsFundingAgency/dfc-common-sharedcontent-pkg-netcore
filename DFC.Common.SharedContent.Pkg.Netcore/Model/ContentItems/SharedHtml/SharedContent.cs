using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.SharedHtml
{
    public partial class SharedHtmlContent
    {
        [JsonProperty("content")]
        public SharedHtml Content { get; set; }
    }
}
