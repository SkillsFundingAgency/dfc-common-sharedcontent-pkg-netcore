using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems;
using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class DysacQuestionSetResponse
    {
        [JsonPropertyName("personalityQuestionSet")]
        public List<PersonalityQuestionSet> PersonalityQuestionSet { get; set; }
    }
}
