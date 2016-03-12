using System;
using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    [DataContract]
    public class TokenResponse
    {
        //
        // Summary:
        //     Gets or sets the access token issued by the authorization server.
        [DataMember(Name = "access_token", EmitDefaultValue = false)]
        public string AccessToken { get; set; }

        //
        // Summary:
        //     Gets or sets the lifetime in seconds of the access token.
        [DataMember(Name = "expires_in", EmitDefaultValue = false)]
        public long? ExpiresInSeconds { get; set; }
        
        //
        // Summary:
        //     The date and time that this token was issued. It should be set by the CLIENT
        //     after the token was received from the server.
        public DateTime Issued { get; set; }
        
        //
        // Summary:
        //     Gets or sets the refresh token which can be used to obtain a new access token.
        //     For example, the value "3600" denotes that the access token will expire in one
        //     hour from the time the response was generated.
        [DataMember(Name = "refresh_token", EmitDefaultValue = false)]
        public string RefreshToken { get; set; }
        
        //
        // Summary:
        //     Gets or sets the scope of the access token as specified in http://tools.ietf.org/html/rfc6749#section-3.3.
        [DataMember(Name = "scope", EmitDefaultValue = false)]
        public string Scope { get; set; }
        
        //
        // Summary:
        //     Gets or sets the token type as specified in http://tools.ietf.org/html/rfc6749#section-7.1.
        [DataMember(Name = "token_type", EmitDefaultValue = false)]
        public string TokenType { get; set; }
    }
}
