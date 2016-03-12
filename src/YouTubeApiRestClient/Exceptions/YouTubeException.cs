using System.Runtime.Serialization;
using YouTubeApiRestClient.Views;

namespace YouTubeApiRestClient.Exceptions
{
    [DataContract]
    public class YouTubeException
    {
        [DataMember(Name = "error", EmitDefaultValue = false)]
        public RequestError Error { get; set; }
    }
}
