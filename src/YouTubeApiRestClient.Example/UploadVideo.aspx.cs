using System;
using System.IO;
using System.Web.Configuration;
using YouTubeApiRestClient.Views;

public partial class UploadVideo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var clientId = WebConfigurationManager.AppSettings["clientId"];
        var clientSecret = WebConfigurationManager.AppSettings["clientSecret"];
        var refreshToken = WebConfigurationManager.AppSettings["refreshToken"];

        var youTubeApiRestClient = new YouTubeApiRestClient.YouTubeApiRestClient(clientId, clientSecret, refreshToken);
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
            litVideo.Text = string.Format("Video id '{0}' was successfully uploaded.", video.Id);
        }
    }
}