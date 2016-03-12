using System;
using System.Web.Configuration;
using YouTubeApiRestClient.Views;

public partial class PlaylistUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var clientId = WebConfigurationManager.AppSettings["clientId"];
        var clientSecret = WebConfigurationManager.AppSettings["clientSecret"];
        var refreshToken = WebConfigurationManager.AppSettings["refreshToken"];

        var youTubeApiRestClient = new YouTubeApiRestClient.YouTubeApiRestClient(clientId, clientSecret, refreshToken);

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

        litPlaylistItem.Text = string.Format("Playlist item id {0} was added to playlist id {1}.", newPlaylistItem.Id, newPlaylist.Id);
    }
}