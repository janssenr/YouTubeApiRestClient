using System;
using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     Basic details about a playlist, including title, description and thumbnails.
    [DataContract]
    public class PlaylistItemSnippet
    {
        //
        // Summary:
        //     The ID that YouTube uses to uniquely identify the user that added the item to
        //     the playlist.
        [DataMember(Name = "channelId", EmitDefaultValue = false)]
        public string ChannelId { get; set; }

        //
        // Summary:
        //     Channel title for the channel that the playlist item belongs to.
        [DataMember(Name = "channelTitle", EmitDefaultValue = false)]
        public string ChannelTitle { get; set; }

        //
        // Summary:
        //     The item's description.
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        //
        // Summary:
        //     The ID that YouTube uses to uniquely identify the playlist that the playlist
        //     item is in.
        [DataMember(Name = "playlistId", EmitDefaultValue = false)]
        public string PlaylistId { get; set; }

        //
        // Summary:
        //     The order in which the item appears in the playlist. The value uses a zero-based
        //     index, so the first item has a position of 0, the second item has a position
        //     of 1, and so forth.
        [DataMember(Name = "position", EmitDefaultValue = false)]
        public long? Position { get; set; }

        //
        // Summary:
        //     System.DateTime representation of Google.Apis.YouTube.v3.Data.PlaylistItemSnippet.PublishedAtRaw.
        public DateTime? PublishedAt { get; set; }

        //
        // Summary:
        //     The date and time that the item was added to the playlist. The value is specified
        //     in ISO 8601 (YYYY-MM-DDThh:mm:ss.sZ) format.
        [DataMember(Name = "publishedAt", EmitDefaultValue = false)]
        public string PublishedAtRaw { get; set; }

        //
        // Summary:
        //     The id object contains information that can be used to uniquely identify the
        //     resource that is included in the playlist as the playlist item.
        [DataMember(Name = "resourceId", EmitDefaultValue = false)]
        public ResourceId ResourceId { get; set; }

        //
        // Summary:
        //     A map of thumbnail images associated with the playlist item. For each object
        //     in the map, the key is the name of the thumbnail image, and the value is an object
        //     that contains other information about the thumbnail.
        //[DataMember(Name="thumbnails", EmitDefaultValue = false)]
        //public  ThumbnailDetails Thumbnails { get; set; }

        //
        // Summary:
        //     The item's title.
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }
    }
}
