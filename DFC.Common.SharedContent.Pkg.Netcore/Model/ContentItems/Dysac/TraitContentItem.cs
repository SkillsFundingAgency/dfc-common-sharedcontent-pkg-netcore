using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class TraitContentItem
    {
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }

        [JsonProperty("jobProfileCategories")]
        public JobProfileCategories JobProfileCategories { get; set; }
    }
}
