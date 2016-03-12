using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     A playlistItem resource identifies another resource, such as a video, that is
    //     included in a playlist. In addition, the playlistItem resource contains details
    //     about the included resource that pertain specifically to how that resource is
    //     used in that playlist. YouTube uses playlists to identify special collections
    //     of videos for a channel, such as: - uploaded videos - favorite videos - positively
    //     rated (liked) videos - watch history - watch later To be more specific, these
    //     lists are associated with a channel, which is a collection of a person, group,
    //     or company's videos, playlists, and other YouTube information. You can retrieve
    //     the playlist IDs for each of these lists from the channel resource for a given
    //     channel. You can then use the playlistItems.list method to retrieve any of those
    //     lists. You can also add or remove items from those lists by calling the playlistItems.insert
    //     and playlistItems.delete methods. For example, if a user gives a positive rating
    //     to a video, you would insert that video into the liked videos playlist for that
    //     user's channel.
    [DataContract]
    public class PlaylistItem
    {
        //
        // Summary:
        //     The contentDetails object is included in the resource if the included item is
        //     a YouTube video. The object contains additional information about the video.
        [DataMember(Name = "contentDetails", EmitDefaultValue = false)]
        public PlaylistItemContentDetails ContentDetails { get; set; }
        //
        // Summary:
        //     Etag of this resource.
        [DataMember(Name = "etag", EmitDefaultValue = false)]
        public string ETag { get; set; }
        //
        // Summary:
        //     The ID that YouTube uses to uniquely identify the playlist item.
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }
        //
        // Summary:
        //     Identifies what kind of resource this is. Value: the fixed string "youtube#playlistItem".
        [DataMember(Name = "kind", EmitDefaultValue = false)]
        public string Kind { get; set; }
        //
        // Summary:
        //     The snippet object contains basic details about the playlist item, such as its
        //     title and position in the playlist.
        [DataMember(Name = "snippet", EmitDefaultValue = false)]
        public PlaylistItemSnippet Snippet { get; set; }
        //
        // Summary:
        //     The status object contains information about the playlist item's privacy status.
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public PlaylistItemStatus Status { get; set; }
    }
}
