using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class PageApiResponse
    {
        [JsonPropertyName("page")]
        public List<PageApi> Page { get; set; }
    }
}
