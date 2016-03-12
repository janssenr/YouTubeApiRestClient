using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    [DataContract]
    public class PlaylistSnippet
    {
        //
        // Summary:
        //     The ID that YouTube uses to uniquely identify the channel that published the
        //     playlist.
        [DataMember(Name = "channelId", EmitDefaultValue = false)]
        public string ChannelId { get; set; }
        
        //
        // Summary:
        //     The channel title of the channel that the video belongs to.
        [DataMember(Name = "channelTitle", EmitDefaultValue = false)]
        public string ChannelTitle { get; set; }
        
        //
        // Summary:
        //     The playlist's description.
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        //
        // Summary:
        //     System.DateTime representation of Google.Apis.YouTube.v3.Data.PlaylistSnippet.PublishedAtRaw.
        public DateTime? PublishedAt { get; set; }

        //
        // Summary:
        //     The date and time that the playlist was created. The value is specified in ISO
        //     8601 (YYYY-MM-DDThh:mm:ss.sZ) format.
        [DataMember(Name = "publishedAt", EmitDefaultValue = false)]
        public string PublishedAtRaw { get; set; }
        
        //
        // Summary:
        //     Keyword tags associated with the playlist.
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public IList<string> Tags { get; set; }
        
        //
        // Summary:
        //     A map of thumbnail images associated with the playlist. For each object in the
        //     map, the key is the name of the thumbnail image, and the value is an object that
        //     contains other information about the thumbnail.
        //[DataMember(Name = "thumbnails", EmitDefaultValue = false)]
        //public ThumbnailDetails Thumbnails { get; set; }
        
        //
        // Summary:
        //     The playlist's title.
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }
    }
}
