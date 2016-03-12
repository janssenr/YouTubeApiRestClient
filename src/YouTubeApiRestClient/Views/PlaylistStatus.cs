using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    [DataContract]
    public class PlaylistStatus
    {
        //
        // Summary:
        //     The playlist's privacy status.
        [DataMember(Name = "privacyStatus", EmitDefaultValue = false)]
        public string PrivacyStatus { get; set; }
    }
}
