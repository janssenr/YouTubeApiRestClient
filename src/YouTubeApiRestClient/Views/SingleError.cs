using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    /// <summary>
    /// A single server error
    /// </summary>
    [DataContract]
    public class SingleError
    {
        /// <summary>
        /// The domain in which the error occured
        /// </summary>
        [DataMember(Name="domain", EmitDefaultValue = false)]
        public string Domain { get; set; }

        /// <summary>
        /// The reason the error was thrown
        /// </summary>
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public string Reason { get; set; }

        /// <summary>
        /// The error message
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// Type of the location
        /// </summary>
        [DataMember(Name = "locationType", EmitDefaultValue = false)]
        public string LocationType { get; set; }

        /// <summary>
        /// Location where the error was thrown
        /// </summary>
        [DataMember(Name = "location", EmitDefaultValue = false)]
        public string Location { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Message[{0}] Location[{1} - {2}] Reason[{3}] Domain[{4}]", Message, Location, LocationType, Reason,
                Domain);
        }
    }
}
