using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class SOCSkillsMatrix
    {
        [JsonProperty("contentItems")]
        public SOCSkillsMatrixContentItem[] ContentItems { get; set; }
    }
}
