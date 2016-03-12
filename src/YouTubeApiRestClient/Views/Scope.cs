namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     Available OAuth 2.0 scopes for use with the YouTube Data API.
    public static class Scope
    {
        //
        // Summary:
        //     Manage your YouTube account
        public static string Youtube
        {
            get { return "https://www.googleapis.com/auth/youtube"; }
        }

        //
        // Summary:
        //     Manage your YouTube account
        public static string YoutubeForceSsl
        {
            get { return "https://www.googleapis.com/auth/youtube.force-ssl"; }
        }

        //
        // Summary:
        //     View and manage your assets and associated content on YouTube
        public static string Youtubepartner
        {
            get { return "https://www.googleapis.com/auth/youtubepartner"; }
        }

        //
        // Summary:
        //     View private information of your YouTube channel relevant during the audit process
        //     with a YouTube partner
        public static string YoutubepartnerChannelAudit
        {
            get { return "https://www.googleapis.com/auth/youtubepartner-channel-audit"; }
        }

        //
        // Summary:
        //     View your YouTube account
        public static string YoutubeReadonly
        {
            get { return "https://www.googleapis.com/auth/youtube.readonly"; }
        }

        //
        // Summary:
        //     Manage your YouTube videos
        public static string YoutubeUpload
        {
            get { return "https://www.googleapis.com/auth/youtube.upload"; }
        }
    }
}
