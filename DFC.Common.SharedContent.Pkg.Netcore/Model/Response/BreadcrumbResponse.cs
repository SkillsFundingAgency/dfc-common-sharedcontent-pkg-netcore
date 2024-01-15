using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBreadcrumb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    internal class BreadcrumbResponse
    {
        [JsonPropertyName("items")]

        public List<PageBreadcrumb> Items { get; set; }
    }
}
