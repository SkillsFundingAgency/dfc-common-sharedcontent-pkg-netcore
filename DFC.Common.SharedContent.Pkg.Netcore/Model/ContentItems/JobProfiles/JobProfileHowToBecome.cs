using DFC.Common.SharedContent.Pkg.Netcore.Model.Common;
using System.Text.Json.Serialization;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles
{
    public class JobProfileHowToBecome
    {
        public class JobProfile
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

        public class ApprenticeshipEntryRequirements
        {
            [JsonPropertyName("contentItems")]
            public List<object> ContentItems { get; set; }
        }

        public class Apprenticeshipfurtherroutesinfo
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class Apprenticeshiprelevantsubjects
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class Careertips
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class CollegeEntryRequirements
        {
            [JsonPropertyName("contentItems")]
            public List<object> ContentItems { get; set; }
        }

        public class Collegefurtherrouteinfo
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class Collegerelevantsubjects
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class Directapplication
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class Entryroutes
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class Furtherinformation
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class Otherroutes
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class Professionalandindustrybodies
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class RelatedApprenticeshipLinks
        {
            [JsonPropertyName("contentItems")]
            public List<object> ContentItems { get; set; }
        }

        public class RelatedApprenticeshipRequirements
        {
            [JsonPropertyName("contentItems")]
            public List<object> ContentItems { get; set; }
        }

        public class RelatedCollegeLinks
        {
            [JsonPropertyName("contentItems")]
            public List<object> ContentItems { get; set; }
        }

        public class RelatedCollegeRequirements
        {
            [JsonPropertyName("contentItems")]
            public List<object> ContentItems { get; set; }
        }

        public class RelatedRegistrations
        {
            [JsonPropertyName("contentItems")]
            public List<object> ContentItems { get; set; }
        }

        public class RelatedUniversityLinks
        {
            [JsonPropertyName("contentItems")]
            public List<object> ContentItems { get; set; }
        }

        public class RelatedUniversityRequirements
        {
            [JsonPropertyName("contentItems")]
            public List<object> ContentItems { get; set; }
        }

        public class UniversityEntryRequirements
        {
            [JsonPropertyName("contentItems")]
            public List<object> ContentItems { get; set; }
        }

        public class Universityfurtherrouteinfo
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class Universityrelevantsubjects
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class Volunteering
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }

        public class Work
        {
            [JsonPropertyName("html")]
            public string Html { get; set; }
        }
    }
}
