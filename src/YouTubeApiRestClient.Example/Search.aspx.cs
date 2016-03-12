using System;
using System.Collections.Generic;
using System.Web.Configuration;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var apiKey = WebConfigurationManager.AppSettings["apiKey"];

        var youTubeApiRestClient = new YouTubeApiRestClient.YouTubeApiRestClient(apiKey);

        string part = "snippet";
        string q = "Google";
        long? maxResults = 50;
        var response = youTubeApiRestClient.Search(part, q, maxResults);

        List<string> videos = new List<string>();
        List<string> channels = new List<string>();
        List<string> playlists = new List<string>();

        // Add each result to the appropriate list, and then display the lists of
        // matching videos, channels, and playlists.
        foreach (var searchResult in response.Items)
        {
            switch (searchResult.Id.Kind)
            {
                case "youtube#video":
                    videos.Add(string.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                    break;

                case "youtube#channel":
                    channels.Add(string.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                    break;

                case "youtube#playlist":
                    playlists.Add(string.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                    break;
            }
        }

        litVideos.Text = string.Format("Videos:<br/>{0}<br/>", string.Join("<br/>", videos));
        litChannels.Text = string.Format("Channels:<br/>{0}<br/>", string.Join("<br/>", channels));
        litPlayLists.Text = string.Format("Playlists:<br/>{0}<br/>", string.Join("<br/>", playlists));
    }
}