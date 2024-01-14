using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class Breadcrumb
    {
        [JsonPropertyName("termContentItems")]
        public List<TermContentItem> TermContentItems { get; set; }
    }
}
