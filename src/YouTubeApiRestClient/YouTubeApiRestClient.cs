using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using YouTubeApiRestClient.Exceptions;
using YouTubeApiRestClient.Helpers;
using YouTubeApiRestClient.Views;

namespace YouTubeApiRestClient
{
    public class YouTubeApiRestClient
    {
        private readonly string _restApiUrl = "https://www.googleapis.com";
        private readonly string _authUrl = "https://accounts.google.com/o/oauth2/auth";
        private readonly string _tokenUrl = "https://accounts.google.com/o/oauth2/token";
        private readonly string _apiKey;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _accessToken;
        private WebHeaderCollection _responseHeaders;

        public YouTubeApiRestClient(string apiKey, string restApiUrl = null)
        {
            _apiKey = apiKey;
            if (!string.IsNullOrEmpty(restApiUrl))
                _restApiUrl = restApiUrl;
        }

        public YouTubeApiRestClient(string clientId, string clientSecret, string refreshToken = null, string restApiUrl = null)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            if (!string.IsNullOrEmpty(refreshToken))
            {
                _accessToken = RefreshAccessToken(refreshToken).AccessToken;
            }
            if (!string.IsNullOrEmpty(restApiUrl))
                _restApiUrl = restApiUrl;

            if (string.IsNullOrEmpty(_clientId) || string.IsNullOrEmpty(_clientSecret))
                throw new Exception("");
        }

        protected string DoRestCall(string url, string method, WebHeaderCollection headers = null, string contentType = null, byte[] data = null)
        {
            var req = WebRequest.Create(url);
            req.Method = method;
            if (headers != null)
            {
                foreach (var key in headers.AllKeys)
                {
                    req.Headers.Add(key, headers[key]);
                }
            }
            if (method.ToUpper() != "GET" && data != null)
            {
                req.ContentType = contentType;
                req.ContentLength = data.Length;
                using (Stream stream = req.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    //int chunkSize = 256 * 1024 * 4 * 10; // 256 * 1024 * 4 = 1MB
                    //int totalContentLength = data.Length;
                    //int firstByte = 0;
                    //int totalChunks = (int)Math.Ceiling((double)totalContentLength / chunkSize);
                    //for (int i = 0; i < totalChunks; i++)
                    //{
                    //    int lastByte = firstByte + chunkSize > totalContentLength
                    //        ? totalContentLength
                    //        : firstByte + chunkSize;
                    //    int length = lastByte - firstByte;
                    //    var chunk = data.Skip(firstByte).Take(length).ToArray();
                    //    stream.Write(chunk, 0, chunk.Length);
                    //    //response = DoRestCall(location, "PUT", headers, contentType, data.Skip(firstByte).Take(length).ToArray());
                    //    firstByte += length;
                    //}
                }
            }

            string responseValue = string.Empty;
            try
            {
                using (var response = (HttpWebResponse)req.GetResponse())
                {
                    _responseHeaders = response.Headers;
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                                reader.Close();
                            }
                            responseStream.Close();
                        }
                    }
                    response.Close();
                }
            }
            catch (WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;
                _responseHeaders = response.Headers;
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                            reader.Close();
                        }
                        responseStream.Close();
                    }
                }
                response.Close();
                var exception = JsonHelper.Deserialize<YouTubeException>(responseValue);

                switch ((int)response.StatusCode)
                {
                    case 308: //Resume Incomplete
                        break;
                    case (int)HttpStatusCode.NotFound: //404
                    case (int)HttpStatusCode.Unauthorized: //401
                    case (int)HttpStatusCode.Forbidden: //403
                    case (int)HttpStatusCode.BadRequest: //400
                    case (int)HttpStatusCode.InternalServerError: //500
                    default:
                        throw new YouTubeApiRestClientException(exception.Error.ToString());
                }
            }
            return responseValue;
        }

        public string RequestAccessToken(string redirectUri, IEnumerable<string> scopes)
        {
            var queryStringData = new NameValueCollection
            {
                {"client_id", _clientId},
                {"redirect_uri", redirectUri},
                {"response_type", "code"},
                {"scope", string.Join(" ", scopes)},
                {"access_type", "offline"}
            };
            var queryString = string.Join("&", queryStringData.AllKeys.Select(k => k + "=" + HttpUtility.UrlEncode(queryStringData[k])));
            var url = _authUrl + "?" + queryString;
            return url;
        }

        public TokenResponse GetAccessToken(string code, string redirectUri)
        {
            var postData = new NameValueCollection
            {
                {"code", code},
                {"client_id", _clientId},
                {"client_secret", _clientSecret},
                {"redirect_uri", redirectUri},
                {"grant_type", "authorization_code"}
            };
            var data = Encoding.UTF8.GetBytes(string.Join("&", postData.AllKeys.Select(k => k + "=" + HttpUtility.UrlEncode(postData[k]))));
            var response = DoRestCall(_tokenUrl, "POST", null, "application/x-www-form-urlencoded", data);
            return JsonHelper.Deserialize<TokenResponse>(response);
        }

        public TokenResponse RefreshAccessToken(string refreshToken)
        {
            var postData = new NameValueCollection
            {
                {"client_id", _clientId},
                {"client_secret", _clientSecret},
                {"refresh_token", refreshToken},
                {"grant_type", "refresh_token"}
            };
            var data = Encoding.UTF8.GetBytes(string.Join("&", postData.AllKeys.Select(k => k + "=" + HttpUtility.UrlEncode(postData[k]))));
            var response = DoRestCall(_tokenUrl, "POST", null, "application/x-www-form-urlencoded", data);
            return JsonHelper.Deserialize<TokenResponse>(response);
        }

        public SearchListResponse Search(string part, string q, long? maxResults = null)
        {
            var queryStringData = new NameValueCollection
            {
                {"part", part},
                {"maxResults", maxResults.ToString()},
                {"q", q},
                {"key", _apiKey}
            };
            var queryString = string.Join("&", queryStringData.AllKeys.Select(k => k + "=" + HttpUtility.UrlEncode(queryStringData[k])));
            var url = _restApiUrl + "/youtube/v3/search?" + queryString;
            var response = DoRestCall(url, "GET");
            return JsonHelper.Deserialize<SearchListResponse>(response);
        }

        public Playlist InsertPlaylist(Playlist body, string part)
        {
            var url = _restApiUrl + "/youtube/v3/playlists?part=" + part;
            var headers = new WebHeaderCollection
            {
                {HttpRequestHeader.Authorization, "Bearer " + _accessToken},
            };
            byte[] data = Encoding.UTF8.GetBytes(JsonHelper.Serialize(body));
            var response = DoRestCall(url, "POST", headers, "application/json; charset=utf-8", data);
            return JsonHelper.Deserialize<Playlist>(response);
        }

        public PlaylistItem InsertPlaylistItem(PlaylistItem body, string part)
        {
            var url = _restApiUrl + "/youtube/v3/playlistItems?part=" + part;
            var headers = new WebHeaderCollection
            {
                {HttpRequestHeader.Authorization, "Bearer " + _accessToken},
            };
            byte[] data = Encoding.UTF8.GetBytes(JsonHelper.Serialize(body));
            var response = DoRestCall(url, "POST", headers, "application/json; charset=utf-8", data);
            return JsonHelper.Deserialize<PlaylistItem>(response);
        }

        public Video UploadVideo(string title, string description, List<string> tags, string categoryId, string privacyStatus, string videoFilePath, int chunkSize = 0)
        {
            var video = new Video
            {
                Snippet = new VideoSnippet
                {
                    Title = title,
                    Description = description,
                    Tags = tags,
                    CategoryId = categoryId
                },
                Status = new VideoStatus
                {
                    PrivacyStatus = privacyStatus
                }
            };
            using (var fileStream = new FileStream(videoFilePath, FileMode.Open))
            {
                return UploadVideo(video, "snippet, status", fileStream, "video/*", chunkSize);
            }
        }

        public Video UploadVideo(Video video, string part, Stream stream, string contentType, int chunkSize = 0)
        {
            var url = _restApiUrl + "/upload/youtube/v3/videos?uploadType=resumable&part=" + part;
            var headers = new WebHeaderCollection
            {
                {HttpRequestHeader.Authorization, "Bearer " + _accessToken},
                {"X-Upload-Content-Length", stream.Length.ToString()},
                {"X-Upload-Content-Type", contentType}
            };
            byte[] data = Encoding.UTF8.GetBytes(JsonHelper.Serialize(video));
            DoRestCall(url, "POST", headers, "application/json; charset=utf-8", data);
            var location = _responseHeaders["Location"];

            data = ConvertToByteArray(stream);
            string response = string.Empty;

            if (chunkSize > 0)
            {
                int totalContentLength = data.Length;
                int firstByte = 0;
                int totalChunks = (int)Math.Ceiling((double)totalContentLength / chunkSize);
                for (int i = 0; i < totalChunks; i++)
                {
                    int lastByte = firstByte + chunkSize > totalContentLength
                        ? totalContentLength
                        : firstByte + chunkSize;
                    int length = lastByte - firstByte;
                    headers = new WebHeaderCollection
                    {
                        {HttpRequestHeader.Authorization, "Bearer " + _accessToken},
                        {"Content-Range",string.Format("bytes {0}-{1}/{2}", firstByte, lastByte - 1, totalContentLength)}
                    };
                    response = DoRestCall(location, "PUT", headers, contentType, data.Skip(firstByte).Take(length).ToArray());
                    firstByte += length;

                    //Check the status of an upload
                    //headers = new WebHeaderCollection
                    //{
                    //    {HttpRequestHeader.Authorization, "Bearer " + _accessToken},
                    //    {"Content-Range",string.Format("bytes */{0}", totalContentLength)}
                    //};
                    //response = DoRestCall(location, "PUT", headers, contentType, new byte[0]);
                }
            }
            else
            {
                headers = new WebHeaderCollection
                {
                    {HttpRequestHeader.Authorization, "Bearer " + _accessToken},
                };
                response = DoRestCall(location, "PUT", headers, contentType, data);
            }
            return JsonHelper.Deserialize<Video>(response);
        }

        private byte[] ConvertToByteArray(Stream stream)
        {
            byte[] buffer = new byte[4 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
