using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class PersonalityQuestionSet
    {

        [JsonPropertyName("displayText")]
        public string DisplayText { get; set; }

        [JsonPropertyName("questions")]
        public Questions Questions { get; set; }
    }
}
