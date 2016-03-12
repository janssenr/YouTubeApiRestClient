using System;
using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     Basic details about a search result, including title, description and thumbnails
    //     of the item referenced by the search result.
    [DataContract]
    public class SearchResultSnippet
    {
        //
        // Summary:
        //     The value that YouTube uses to uniquely identify the channel that published the
        //     resource that the search result identifies.
        [DataMember(Name="channelId", EmitDefaultValue = false)]
        public  string ChannelId { get; set; }

        //
        // Summary:
        //     The title of the channel that published the resource that the search result identifies.
        [DataMember(Name="channelTitle", EmitDefaultValue = false)]
        public  string ChannelTitle { get; set; }
        
        //
        // Summary:
        //     A description of the search result.
        [DataMember(Name="description", EmitDefaultValue = false)]
        public  string Description { get; set; }
        
        //
        // Summary:
        //     It indicates if the resource (video or channel) has upcoming/active live broadcast
        //     content. Or it's "none" if there is not any upcoming/active live broadcasts.
        [DataMember(Name="liveBroadcastContent", EmitDefaultValue = false)]
        public  string LiveBroadcastContent { get; set; }
        
        //
        // Summary:
        //     System.DateTime representation of Google.Apis.YouTube.v3.Data.SearchResultSnippet.PublishedAtRaw.
        public  DateTime? PublishedAt { get; set; }

        //
        // Summary:
        //     The creation date and time of the resource that the search result identifies.
        //     The value is specified in ISO 8601 (YYYY-MM-DDThh:mm:ss.sZ) format.
        [DataMember(Name="publishedAt", EmitDefaultValue = false)]
        public  string PublishedAtRaw { get; set; }
        
        //
        // Summary:
        //     The title of the search result.
        [DataMember(Name="title", EmitDefaultValue = false)]
        public  string Title { get; set; }
    }
}
