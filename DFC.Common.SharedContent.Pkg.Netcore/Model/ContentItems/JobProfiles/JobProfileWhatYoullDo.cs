﻿using Newtonsoft.Json;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles
{
    public class JobProfileWhatYoullDo
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("daytodaytasks")]
        public Daytodaytasks? Daytodaytasks { get; set; }

        [JsonProperty("relatedLocations")]
        public RelatedLocations? RelatedLocations { get; set; }

        [JsonProperty("relatedEnvironments")]
        public RelatedEnvironments? RelatedEnvironments { get; set; }

        [JsonProperty("relatedUniforms")]
        public RelatedUniforms? RelatedUniforms { get; set; }
    }

    public class ContentItemWYD
    {
        [JsonProperty("description")]
        public string? Description { get; set; }
    }

    public class Daytodaytasks
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class RelatedEnvironments
    {
        [JsonProperty("contentItems")]
        public List<ContentItemWYD>? ContentItems { get; set; }
    }

    public class RelatedLocations
    {
        [JsonProperty("contentItems")]
        public List<ContentItemWYD>? ContentItems { get; set; }
    }

    public class RelatedUniforms
    {
        [JsonProperty("contentItems")]
        public List<ContentItemWYD>? ContentItems { get; set; }
    }
}
