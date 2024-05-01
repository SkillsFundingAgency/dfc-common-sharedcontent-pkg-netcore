using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DFC.Common.SharedContent.Pkg.Netcore.Model.ContentItems.JobProfiles
{
    public class JobProfileVideo
    {
        [JsonPropertyName("displayText")]
        public string? DisplayText { get; set; }

        [JsonPropertyName("videoType")]
        public string? VideoType { get; set; }

        [JsonPropertyName("videoTitle")]
        public string? VideoTitle { get; set; }

        [JsonPropertyName("videoTranscript")]
        public string? VideoTranscript { get; set; }

        [JsonPropertyName("videoSummary")]
        public VideoSummary? VideoSummary { get; set; }

        [JsonPropertyName("videoThumbail")]
        public VideoThumbnail? VideoThumbnail { get; set; }

        [JsonPropertyName("videoUrl")]
        public string? VideoUrl { get; set; }

        [JsonPropertyName("videoLinkText")]
        public string? VideoLinkText { get; set; }

        [JsonPropertyName("videoFurtherInformation")]
        public VideoFurtherInformation? VideoFurtherInformation { get; set; }

        [JsonPropertyName("videoDuration")]
        public string? VideoDuration { get; set; }
    }

    public partial class VideoSummary
    {
        [JsonPropertyName("html")]
        public string? Html { get; set; }
    }

    public partial class VideoThumbnail
    {
        [JsonPropertyName("mediaText")]
        public List<string>? MediaText { get; set; }

        [JsonPropertyName("urls")]
        public List<string>? Urls { get; set; }
    }

    public partial class VideoFurtherInformation
    {
        [JsonPropertyName("html")]
        public string? Html { get; set; }
    }
}
