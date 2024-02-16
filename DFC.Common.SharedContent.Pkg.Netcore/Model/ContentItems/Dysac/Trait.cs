using DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac.PersonalityTrait;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.Dysac
{
    public class Trait
    {
        [JsonProperty("contentItems")]
        public List<PersonalityTrait.PersonalityTrait> ContentItems { get; set; }
    }
}
