using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     A resource id is a generic reference that points to another YouTube resource.
    [DataContract]
    public class ResourceId
    {
        //
        // Summary:
        //     The ID that YouTube uses to uniquely identify the referred resource, if that
        //     resource is a channel. This property is only present if the resourceId.kind value
        //     is youtube#channel.
        [DataMember(Name="channelId", EmitDefaultValue = false)]
        public string ChannelId { get; set; }

        //
        // Summary:
        //     The ETag of the item.
        public string ETag { get; set; }

        //
        // Summary:
        //     The type of the API resource.
        [DataMember(Name="kind", EmitDefaultValue = false)]
        public string Kind { get; set; }

        //
        // Summary:
        //     The ID that YouTube uses to uniquely identify the referred resource, if that
        //     resource is a playlist. This property is only present if the resourceId.kind
        //     value is youtube#playlist.
        [DataMember(Name="playlistId", EmitDefaultValue = false)]
        public string PlaylistId { get; set; }
        
        //
        // Summary:
        //     The ID that YouTube uses to uniquely identify the referred resource, if that
        //     resource is a video. This property is only present if the resourceId.kind value
        //     is youtube#video.
        [DataMember(Name="videoId", EmitDefaultValue = false)]
        public string VideoId { get; set; }
    }
}
