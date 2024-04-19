using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles
{
    public class JobProfileHowToBecome
    {
        [JsonPropertyName("displayText")]
        public string? DisplayText { get; set; }

        [JsonPropertyName("pageLocation")]
        public PageLocation? PageLocation { get; set; }

        [JsonPropertyName("entryroutes")]
        public Entryroutes? Entryroutes { get; set; }

        [JsonPropertyName("universityrelevantsubjects")]
        public Universityrelevantsubjects? Universityrelevantsubjects { get; set; }

        [JsonPropertyName("universityfurtherrouteinfo")]
        public Universityfurtherrouteinfo? Universityfurtherrouteinfo { get; set; }

        [JsonPropertyName("universityEntryRequirements")]
        public UniversityEntryRequirements? UniversityEntryRequirements { get; set; }

        [JsonPropertyName("relatedUniversityRequirements")]
        public RelatedUniversityRequirements? RelatedUniversityRequirements { get; set; }

        [JsonPropertyName("relatedUniversityLinks")]
        public RelatedUniversityLinks? RelatedUniversityLinks { get; set; }

        [JsonPropertyName("collegerelevantsubjects")]
        public Collegerelevantsubjects? Collegerelevantsubjects { get; set; }

        [JsonPropertyName("collegefurtherrouteinfo")]
        public Collegefurtherrouteinfo? Collegefurtherrouteinfo { get; set; }

        [JsonPropertyName("collegeEntryRequirements")]
        public CollegeEntryRequirements? CollegeEntryRequirements { get; set; }

        [JsonPropertyName("relatedCollegeRequirements")]
        public RelatedCollegeRequirements? RelatedCollegeRequirements { get; set; }

        [JsonPropertyName("relatedCollegeLinks")]
        public RelatedCollegeLinks? RelatedCollegeLinks { get; set; }

        [JsonPropertyName("apprenticeshiprelevantsubjects")]
        public Apprenticeshiprelevantsubjects? Apprenticeshiprelevantsubjects { get; set; }

        [JsonPropertyName("apprenticeshipfurtherroutesinfo")]
        public Apprenticeshipfurtherroutesinfo? Apprenticeshipfurtherroutesinfo { get; set; }

        [JsonPropertyName("apprenticeshipEntryRequirements")]
        public ApprenticeshipEntryRequirements? ApprenticeshipEntryRequirements { get; set; }

        [JsonPropertyName("relatedApprenticeshipRequirements")]
        public RelatedApprenticeshipRequirements? RelatedApprenticeshipRequirements { get; set; }

        [JsonPropertyName("relatedApprenticeshipLinks")]
        public RelatedApprenticeshipLinks? RelatedApprenticeshipLinks { get; set; }

        [JsonPropertyName("work")]
        public Work? Work { get; set; }

        [JsonPropertyName("volunteering")]
        public Volunteering? Volunteering { get; set; }

        [JsonPropertyName("directapplication")]
        public Directapplication? Directapplication { get; set; }

        [JsonPropertyName("otherroutes")]
        public Otherroutes? Otherroutes { get; set; }

        [JsonPropertyName("professionalandindustrybodies")]
        public Professionalandindustrybodies? Professionalandindustrybodies { get; set; }

        [JsonPropertyName("furtherinformation")]
        public Furtherinformation? Furtherinformation { get; set; }

        [JsonPropertyName("careertips")]
        public Careertips? Careertips { get; set; }

        [JsonPropertyName("relatedRegistrations")]
        public RelatedRegistrations? RelatedRegistrations { get; set; }
    }

    public class ContentItem
    {
        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("info")]
        public Info? Info { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("uRL")]
        public string? URL { get; set; }
    }

    public class ApprenticeshipEntryRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItem>? ContentItems { get; set; }
    }

    public class Apprenticeshipfurtherroutesinfo
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Apprenticeshiprelevantsubjects
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Careertips
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class CollegeEntryRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItem>? ContentItems { get; set; }
    }

    public class Collegefurtherrouteinfo
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Collegerelevantsubjects
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Directapplication
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Entryroutes
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Furtherinformation
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Otherroutes
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Professionalandindustrybodies
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class RealStory
    {
        [JsonProperty("contentItems")]
        public List<object>? ContentItems { get; set; }
    }

    public class RelatedApprenticeshipLinks
    {
        [JsonProperty("contentItems")]
        public List<ContentItem>? ContentItems { get; set; }
    }

    public class RelatedApprenticeshipRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItem>? ContentItems { get; set; }
    }

    public class RelatedCollegeLinks
    {
        [JsonProperty("contentItems")]
        public List<ContentItem>? ContentItems { get; set; }
    }

    public class RelatedCollegeRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItem>? ContentItems { get; set; }
    }

    public class RelatedRegistrations
    {
        [JsonProperty("contentItems")]
        public List<ContentItem>? ContentItems { get; set; }
    }

    public class RelatedUniversityLinks
    {
        [JsonProperty("contentItems")]
        public List<ContentItem>? ContentItems { get; set; }
    }

    public class RelatedUniversityRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItem>? ContentItems { get; set; }
    }

    public class UniversityEntryRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItem>? ContentItems { get; set; }
    }

    public class Universityfurtherrouteinfo
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Universityrelevantsubjects
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Volunteering
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Work
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }
}
