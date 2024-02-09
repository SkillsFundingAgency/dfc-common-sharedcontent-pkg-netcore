using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.PageBanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class DysacFilteringQuestionResponse
    {
        [JsonPropertyName("personalityFilteringQuestion")]
        public List<PersonalityFilteringQuestion> PersonalityFilteringQuestion { get; set; }
    }
}
