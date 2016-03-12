using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    /// <summary>
    /// Calls to Google Api return StandardResponses as Json with
    /// two properties Data, being the return type of the method called
    /// and Error, being any errors that occure.
    /// </summary>
    [DataContract]
    public sealed class StandardResponse<T>
    {
        /// <summary>May be null if call failed.</summary>
        [DataMember(Name="data", EmitDefaultValue = false)]
        public T Data { get; set; }

        /// <summary>May be null if call succedded.</summary>
        [DataMember(Name="error", EmitDefaultValue = false)]
        public RequestError Error { get; set; }
    }
}
