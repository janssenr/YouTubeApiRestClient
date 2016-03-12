# YouTube API REST Client

A ASP.Net 4.5.1+ class, which offers methods to directly talk with the [YouTube Data API](https://developers.google.com/youtube/v3/) through the REST endpoint offered.
You need a [Google Account] (https://www.google.com/accounts/NewAccount) to access the Google Developers Console, request an API key, and register your application.

## License

All source code is licensed under the [GNU Lesser General Public License](http://www.gnu.org/licenses/lgpl.html)

## Installation

The easiest way to get started with the YouTube API REST Client is to use the NuGet package

	Install-Package YouTubeApiRestClient

Or download the source from my GitHub page: https://github.com/janssenr/YouTubeApiRestClient

## Samples

### Insert Playlist

Include the class in your ASP.Net project, instantiate the ASP.Net class with your authentication details and call the 'InsertPlaylist' method.
You can handle errors by catching the defined Exception classes.

* See [Playlists API method documentation](https://developers.google.com/youtube/v3/docs/playlists/insert) for the possible fields

```
        var youTubeApiRestClient = new YouTubeApiRestClient.YouTubeApiRestClient(clientId: "<your clientId>", clientSecret: "<your clientSecret>", refreshToken: "<your refreshToken>");

        //Create a new, private playlist in the authorized user's channel.
        var newPlaylist = new Playlist
        {
            Snippet = new PlaylistSnippet
            {
                Title = "Test Playlist",
                Description = "A playlist created with the YouTube API v3"
            },
            Status = new PlaylistStatus
            {
                PrivacyStatus = "public"
            }
        };
        newPlaylist = youTubeApiRestClient.InsertPlaylist(newPlaylist, "snippet,status");

        // Add a video to the newly created playlist.
        var newPlaylistItem = new PlaylistItem
        {
            Snippet = new PlaylistItemSnippet
            {
                PlaylistId = newPlaylist.Id,
                ResourceId = new ResourceId
                {
                    Kind = "youtube#video",
                    VideoId = "GNRMeaz6QRI"
                }
            }
        };
        newPlaylistItem = youTubeApiRestClient.InsertPlaylistItem(newPlaylistItem, "snippet");
```

### Search

Include the class in your ASP.Net project, instantiate the ASP.Net class with your authentication details and call the 'Search' method.
You can handle errors by catching the defined Exception classes.

* See [Search API method documentation](https://developers.google.com/youtube/v3/docs/search/list) for the possible fields

```
        var youTubeApiRestClient = new YouTubeApiRestClient.YouTubeApiRestClient(apiKey: "<your apiKey>");

        string part = "snippet";
        string q = "Google";
        long? maxResults = 50;
        var response = youTubeApiRestClient.Search(part, q, maxResults);
```

### Upload Video

Include the class in your ASP.Net project, instantiate the ASP.Net class with your authentication details and call the 'UploadVideo' method.
You can handle errors by catching the defined Exception classes.

* See [Videos API method documentation](https://developers.google.com/youtube/v3/docs/videos/insert) for the possible fields

```
        var youTubeApiRestClient = new YouTubeApiRestClient.YouTubeApiRestClient(clientId: "<your clientId>", clientSecret: "<your clientSecret>", refreshToken: "<your refreshToken>");

        var video = new Video
        {
            Snippet = new VideoSnippet
            {
                Title = "Default Video Title",
                Description = "Default Video Description",
                Tags = new[] { "tag1", "tag2"},
                CategoryId = "22" // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            },
            Status = new VideoStatus
            {
                PrivacyStatus = "unlisted" // or "private" or "public"
            }
        };
        var filePath = @"REPLACE_ME.mp4"; // Replace with path to actual movie file.

        using (var fileStream = new FileStream(filePath, FileMode.Open))
        {
            video = youTubeApiRestClient.UploadVideo(video, "snippet,status", fileStream, "video/*");
        }
```

