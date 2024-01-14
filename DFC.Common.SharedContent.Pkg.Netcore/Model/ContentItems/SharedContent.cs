using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems
{
    public class SharedContent
    {
        [JsonPropertyName("contentItems")]
        public List<ContentItem> ContentItems { get; set; }
    }
}
