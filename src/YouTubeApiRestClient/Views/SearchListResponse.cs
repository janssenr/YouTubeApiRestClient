using System.Collections.Generic;
using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    [DataContract]
    public class SearchListResponse
    {
        //
        // Summary:
        //     Etag of this resource.
        [DataMember(Name="etag", EmitDefaultValue = false)]
        public string ETag { get; set; }
        
        //
        // Summary:
        //     Serialized EventId of the request which produced this response.
        [DataMember(Name="eventId", EmitDefaultValue = false)]
        public string EventId { get; set; }

        //
        // Summary:
        //     A list of results that match the search criteria.
        [DataMember(Name="items", EmitDefaultValue = false)]
        public IList<SearchResult> Items { get; set; }
        
        //
        // Summary:
        //     Identifies what kind of resource this is. Value: the fixed string "youtube#searchListResponse".
        [DataMember(Name="kind", EmitDefaultValue = false)]
        public string Kind { get; set; }
        
        //
        // Summary:
        //     The token that can be used as the value of the pageToken parameter to retrieve
        //     the next page in the result set.
        [DataMember(Name="nextPageToken", EmitDefaultValue = false)]
        public string NextPageToken { get; set; }

        [DataMember(Name="pageInfo", EmitDefaultValue = false)]
        public PageInfo PageInfo { get; set; }
        
        //
        // Summary:
        //     The token that can be used as the value of the pageToken parameter to retrieve
        //     the previous page in the result set.
        [DataMember(Name="prevPageToken", EmitDefaultValue = false)]
        public string PrevPageToken { get; set; }

        //
        // Summary:
        //     The visitorId identifies the visitor.
        [DataMember(Name="visitorId", EmitDefaultValue = false)]
        public string VisitorId { get; set; }
    }
}
