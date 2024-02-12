using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class Questions
    {
        [JsonProperty("contentItems")]
        public QuestionContentItem[] ContentItems { get; set; }
    }
}
