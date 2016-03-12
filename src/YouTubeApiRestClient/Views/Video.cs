using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     A video resource represents a YouTube video.
    [DataContract]
    public class Video
    {
        //
        // Summary:
        //     The ID that YouTube uses to uniquely identify the video.
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id { get; set; }

        //
        // Summary:
        //     The snippet object contains basic details about the video, such as its title,
        //     description, and category.
        [DataMember(Name = "snippet", EmitDefaultValue = false)]
        public VideoSnippet Snippet { get; set; }

        //
        // Summary:
        //     The status object contains information about the video's uploading, processing,
        //     and privacy statuses.
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public VideoStatus Status { get; set; }
    }
}
