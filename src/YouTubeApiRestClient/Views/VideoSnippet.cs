using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     Basic details about a video, including title, description, uploader, thumbnails
    //     and category.
    [DataContract]
    public class VideoSnippet
    {
        //
        // Summary:
        //     The YouTube video category associated with the video.
        [DataMember(Name="categoryId", EmitDefaultValue = false)]
        public string CategoryId { get; set; }

        //
        // Summary:
        //     The ID that YouTube uses to uniquely identify the channel that the video was
        //     uploaded to.
        [DataMember(Name="channelId", EmitDefaultValue = false)]
        public string ChannelId { get; set; }

        //
        // Summary:
        //     Channel title for the channel that the video belongs to.
        [DataMember(Name="channelTitle", EmitDefaultValue = false)]
        public string ChannelTitle { get; set; }

        //
        // Summary:
        //     The video's description.
        [DataMember(Name="description", EmitDefaultValue = false)]
        public string Description { get; set; }
        
        //
        // Summary:
        //     Indicates if the video is an upcoming/active live broadcast. Or it's "none" if
        //     the video is not an upcoming/active live broadcast.
        [DataMember(Name="liveBroadcastContent", EmitDefaultValue = false)]
        public string LiveBroadcastContent { get; set; }

        //
        // Summary:
        //     System.DateTime representation of Google.Apis.YouTube.v3.Data.VideoSnippet.PublishedAtRaw.
        public DateTime? PublishedAt { get; set; }
        
        //
        // Summary:
        //     The date and time that the video was uploaded. The value is specified in ISO
        //     8601 (YYYY-MM-DDThh:mm:ss.sZ) format.
        [DataMember(Name="publishedAt", EmitDefaultValue = false)]
        public string PublishedAtRaw { get; set; }

        //
        // Summary:
        //     A list of keyword tags associated with the video. Tags may contain spaces. This
        //     field is only visible to the video's uploader.
        [DataMember(Name="tags", EmitDefaultValue = false)]
        public IList<string> Tags { get; set; }

        //
        // Summary:
        //     The video's title.
        [DataMember(Name="title", EmitDefaultValue = false)]
        public string Title { get; set; }
    }
}
