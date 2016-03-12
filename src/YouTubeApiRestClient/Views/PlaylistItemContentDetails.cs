using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    [DataContract]
    public class PlaylistItemContentDetails
    {
        //
        // Summary:
        //     The time, measured in seconds from the start of the video, when the video should
        //     stop playing. (The playlist owner can specify the times when the video should
        //     start and stop playing when the video is played in the context of the playlist.)
        //     By default, assume that the video.endTime is the end of the video.
        [DataMember(Name = "endAt", EmitDefaultValue = false)]
        public string EndAt { get; set; }

        //
        // Summary:
        //     A user-generated note for this item.
        [DataMember(Name = "note", EmitDefaultValue = false)]
        public string Note { get; set; }
        
        //
        // Summary:
        //     The time, measured in seconds from the start of the video, when the video should
        //     start playing. (The playlist owner can specify the times when the video should
        //     start and stop playing when the video is played in the context of the playlist.)
        //     The default value is 0.
        [DataMember(Name = "startAt", EmitDefaultValue = false)]
        public string StartAt { get; set; }
        
        //
        // Summary:
        //     The ID that YouTube uses to uniquely identify a video. To retrieve the video
        //     resource, set the id query parameter to this value in your API request.
        [DataMember(Name = "videoId", EmitDefaultValue = false)]
        public string VideoId { get; set; }
    }
}
