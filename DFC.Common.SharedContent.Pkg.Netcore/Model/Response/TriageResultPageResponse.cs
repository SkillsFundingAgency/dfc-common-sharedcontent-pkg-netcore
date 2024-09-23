using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.SharedHtml;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class TriageResultPageResponse
    {
        [JsonPropertyName("page")]
        public List<TriageResultPage>? Page { get; set; }

        [JsonPropertyName("applicationView")]
        public List<TriageResultPage>? ApplicationView { get; set; }

        [JsonPropertyName("apprenticeshipLink")]
        public List<TriageResultPage>? ApprenticeshipLink { get; set; }

        [JsonPropertyName("triageResultTile")]
        public List<TriageResultTile>? TriageResultTile { get; set; }

        [JsonPropertyName("triageFilterAdviceGroupImage")]
        public List<TriageFilterAdviceGroupImage>? TriageFilterAdviceGroupImage { get; set; }

        [JsonPropertyName("sharedContent")]
        public List<SharedHtmlContent>? SharedContent { get; set; }
    }
}