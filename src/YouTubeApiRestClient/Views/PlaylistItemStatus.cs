using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     Information about the playlist item's privacy status.
    [DataContract]
    public class PlaylistItemStatus
    {
        //
        // Summary:
        //     This resource's privacy status.
        [DataMember(Name="privacyStatus", EmitDefaultValue = false)]
        public string PrivacyStatus { get; set; }
    }
}
