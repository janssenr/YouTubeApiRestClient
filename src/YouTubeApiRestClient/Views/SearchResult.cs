using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     A search result contains information about a YouTube video, channel, or playlist
    //     that matches the search parameters specified in an API request. While a search
    //     result points to a uniquely identifiable resource, like a video, it does not
    //     have its own persistent data.
    [DataContract]
    public class SearchResult
    {
        //
        // Summary:
        //     Etag of this resource.
        [DataMember(Name="etag", EmitDefaultValue = false)]
        public string ETag { get; set; }

        //
        // Summary:
        //     The id object contains information that can be used to uniquely identify the
        //     resource that matches the search request.
        [DataMember(Name="id", EmitDefaultValue = false)]
        public ResourceId Id { get; set; }

        //
        // Summary:
        //     Identifies what kind of resource this is. Value: the fixed string "youtube#searchResult".
        [DataMember(Name="kind", EmitDefaultValue = false)]
        public string Kind { get; set; }

        //
        // Summary:
        //     The snippet object contains basic details about a search result, such as its
        //     title or description. For example, if the search result is a video, then the
        //     title will be the video's title and the description will be the video's description.
        [DataMember(Name="snippet", EmitDefaultValue = false)]
        public SearchResultSnippet Snippet { get; set; }
    }
}
