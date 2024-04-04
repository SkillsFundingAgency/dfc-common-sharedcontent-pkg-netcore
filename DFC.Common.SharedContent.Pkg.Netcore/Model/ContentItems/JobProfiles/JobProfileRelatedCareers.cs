using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles
{
    public class JobProfileRelatedCareers
    {
        [JsonPropertyName("displaytext")]
        public string? DisplayText { get; set; }

        [JsonPropertyName("pageLocation")]
        public PageLocation? PageLocation { get; set; }

        [JsonPropertyName("relatedcareerprofiles")]
        public RelatedCareers? RelatedCareerProfiles { get; set; }

    }

    public partial class RelatedCareers
    {
        [JsonPropertyName("contentItems")]
        public List<RelatedCareersContentItems>? ContentItems { get; set; }
    }

    public partial class RelatedCareersContentItems
    {
        [JsonPropertyName("displayText")]
        public string? DisplayText { get; set; }

        [JsonPropertyName("pageLocation")]
        public PageLocation? PageLocation { get; set; }
        
        [JsonPropertyName("graphSync")]
        public GraphSync? GraphSync { get; set; }

        [JsonPropertyName("contentItemId")]
        public string? ContentItemId { get; set; }
    }
}
