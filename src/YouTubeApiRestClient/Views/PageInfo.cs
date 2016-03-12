using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     Paging details for lists of resources, including total number of items available
    //     and number of resources returned in a single page.
    [DataContract]
    public class PageInfo
    {
        //
        // Summary:
        //     The number of results included in the API response.
        [DataMember(Name="resultsPerPage", EmitDefaultValue = false)]
        public int? ResultsPerPage { get; set; }
        //
        // Summary:
        //     The total number of results in the result set.
        [DataMember(Name="totalResults", EmitDefaultValue = false)]
        public int? TotalResults { get; set; }
    }
}
