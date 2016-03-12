using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace YouTubeApiRestClient.Views
{
    /// <summary>
    /// Collection of server errors
    /// </summary>
    [DataContract]
    public class RequestError
    {
        /// <summary>
        /// Enumeration of known error codes which may occur during a request.
        /// </summary>
        public enum ErrorCodes
        {
            /// <summary>
            /// The ETag condition specified caused the ETag verification to fail. 
            /// Depending on the ETagAction of the request this either means that a change to the object has been
            /// made on the server, or that the object in question is still the same and has not been changed.
            /// </summary>
            ETagConditionFailed = 412
        }

        /// <summary>
        /// Contains a list of all errors
        /// </summary>
        [DataMember(Name= "errors", EmitDefaultValue = false)]
        public IList<SingleError> Errors { get; set; }

        /// <summary>
        /// The error code returned
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public int Code { get; set; }

        /// <summary>
        /// The error message returned
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetType().FullName).Append(Message).AppendFormat(" [{0}]", Code).AppendLine();
            if (Errors == null || !Errors.Any())
            {
                sb.AppendLine("No individual errors");
            }
            else
            {
                sb.AppendLine("Errors [");
                foreach (SingleError err in Errors)
                {
                    sb.Append('\t').AppendLine(err.ToString());
                }
                sb.AppendLine("]");
            }

            return sb.ToString();
        }
    }
}
