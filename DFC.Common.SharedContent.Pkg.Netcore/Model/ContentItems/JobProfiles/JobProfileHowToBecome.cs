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
        public EntryRoutes? EntryRoutes { get; set; }

        [JsonPropertyName("universityrelevantsubjects")]
        public UniversityRelevantSubjects? UniversityRelevantSubjects { get; set; }

        [JsonPropertyName("universityfurtherrouteinfo")]
        public UniversityFurtherRouteInfo? UniversityFurtherRouteInfo { get; set; }

        [JsonPropertyName("universityEntryRequirements")]
        public UniversityEntryRequirements? UniversityEntryRequirements { get; set; }

        [JsonPropertyName("relatedUniversityRequirements")]
        public RelatedUniversityRequirements? RelatedUniversityRequirements { get; set; }

        [JsonPropertyName("relatedUniversityLinks")]
        public RelatedUniversityLinks? RelatedUniversityLinks { get; set; }

        [JsonPropertyName("collegerelevantsubjects")]
        public CollegeRelevantSubjects? CollegeRelevantSubjects { get; set; }

        [JsonPropertyName("collegefurtherrouteinfo")]
        public CollegeFurtherRouteInfo? CollegeFurtherRouteInfo { get; set; }

        [JsonPropertyName("collegeEntryRequirements")]
        public CollegeEntryRequirements? CollegeEntryRequirements { get; set; }

        [JsonPropertyName("relatedCollegeRequirements")]
        public RelatedCollegeRequirements? RelatedCollegeRequirements { get; set; }

        [JsonPropertyName("relatedCollegeLinks")]
        public RelatedCollegeLinks? RelatedCollegeLinks { get; set; }

        [JsonPropertyName("apprenticeshiprelevantsubjects")]
        public ApprenticeshipRelevantSubjects? ApprenticeshipRelevantSubjects { get; set; }

        [JsonPropertyName("apprenticeshipfurtherroutesinfo")]
        public ApprenticeshipFurtherRoutesInfo? ApprenticeshipFurtherRoutesInfo { get; set; }

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
        public DirectApplication? DirectApplication { get; set; }

        [JsonPropertyName("otherroutes")]
        public Otherroutes? OtherRoutes { get; set; }

        [JsonPropertyName("professionalandindustrybodies")]
        public ProfessionalAndIndustryBodies? ProfessionalAndIndustryBodies { get; set; }

        [JsonPropertyName("furtherinformation")]
        public FurtherInformation? FurtherInformation { get; set; }

        [JsonPropertyName("careertips")]
        public CareerTips? CareerTips { get; set; }

        [JsonPropertyName("relatedRegistrations")]
        public RelatedRegistrations? RelatedRegistrations { get; set; }

        [JsonPropertyName("realStory")]
        public RealStory? RealStory { get; set; }
    }

    public class ContentItemHTB
    {
        [JsonProperty("body")]
        public Body? Body { get; set; }

        [JsonProperty("displayText")]
        public string? DisplayText { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("furtherInformation")]
        public FurtherInformation? FurtherInformation { get; set; }

        [JsonProperty("info")]
        public Info? Info { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail? Thumbnail { get; set; }

        [JsonProperty("uRL")]
        public string? URL { get; set; }
    }

    public class ApprenticeshipEntryRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItemHTB>? ContentItems { get; set; }
    }

    public class ApprenticeshipFurtherRoutesInfo
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class ApprenticeshipRelevantSubjects
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Body
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class CareerTips
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class CollegeEntryRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItemHTB>? ContentItems { get; set; }
    }

    public class CollegeFurtherRouteInfo
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class CollegeRelevantSubjects
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class DirectApplication
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class EntryRoutes
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class FurtherInformation
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class Otherroutes
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class ProfessionalAndIndustryBodies
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class RealStory
    {
        [JsonProperty("contentItems")]
        public List<ContentItemHTB>? ContentItems { get; set; }
    }

    public class RelatedApprenticeshipLinks
    {
        [JsonProperty("contentItems")]
        public List<ContentItemHTB>? ContentItems { get; set; }
    }

    public class RelatedApprenticeshipRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItemHTB>? ContentItems { get; set; }
    }

    public class RelatedCollegeLinks
    {
        [JsonProperty("contentItems")]
        public List<ContentItemHTB>? ContentItems { get; set; }
    }

    public class RelatedCollegeRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItemHTB>? ContentItems { get; set; }
    }

    public class RelatedRegistrations
    {
        [JsonProperty("contentItems")]
        public List<ContentItemHTB>? ContentItems { get; set; }
    }

    public class RelatedUniversityLinks
    {
        [JsonProperty("contentItems")]
        public List<ContentItemHTB>? ContentItems { get; set; }
    }

    public class RelatedUniversityRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItemHTB>? ContentItems { get; set; }
    }

    public class Thumbnail
    {
        [JsonProperty("mediaText")]
        public List<string?> MediaText { get; set; }

        [JsonProperty("urls")]
        public List<string?> Urls { get; set; }
    }

    public class UniversityEntryRequirements
    {
        [JsonProperty("contentItems")]
        public List<ContentItemHTB>? ContentItems { get; set; }
    }

    public class UniversityFurtherRouteInfo
    {
        [JsonProperty("html")]
        public string? Html { get; set; }
    }

    public class UniversityRelevantSubjects
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
