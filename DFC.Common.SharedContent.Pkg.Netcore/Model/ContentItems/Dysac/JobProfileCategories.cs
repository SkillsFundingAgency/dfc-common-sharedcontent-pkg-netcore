using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class JobProfileCategories
    {
        [JsonProperty("contentItems")]
        public JobProfileCategoriesContentItem[] ContentItems { get; set; }
    }
}
