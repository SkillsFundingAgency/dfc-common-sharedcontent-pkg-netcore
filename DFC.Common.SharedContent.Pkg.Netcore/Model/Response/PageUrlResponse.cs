using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class PageUrlResponse
    {
        [JsonPropertyName("page")]
        public List<PageUrl> Page { get; set; }
    }
}
