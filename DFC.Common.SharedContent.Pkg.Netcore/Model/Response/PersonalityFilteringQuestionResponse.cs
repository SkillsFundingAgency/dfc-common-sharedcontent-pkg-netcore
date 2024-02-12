using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.Response
{
    public class PersonalityFilteringQuestionResponse
    {
        [JsonPropertyName("personalityFilteringQuestion")]
        public List<PersonalityFilteringQuestion> PersonalityFilteringQuestion { get; set; }
    }
}
