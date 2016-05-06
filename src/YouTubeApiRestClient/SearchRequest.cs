using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeApiRestClient
{
    public class SearchRequest
    {
        #region public enums
        public enum VideoType
        {
            Any,
            Episode,
            Movie
        }
        public enum VideoSyndicated
        {
            Any,
            True
        }
        public enum VideoLicense
        {
            Any,
            CreativeCommon,
            Youtube
        }
        public enum VideoEmbeddable
        {
            Any,
            True
        }
        public enum VideoDuration
        {
            Any,
            Long,
            Medium,
            Short
        }
        public enum VideoDimension
        {
            [FlagValue("2D")]
            TwoD,
            [FlagValue("3D")]
            ThreeD,
            Any
        }
        public enum VideoDefinition
        {
            Any,
            High,
            Standard
        }
        public enum VideoCaption
        {
            Any,
            ClosedCaption,
            None
        }
        public enum Type
        {
            Channel,
            Playlist,
            Video
        }
        public enum SafeSearch
        {
            Moderate,
            None,
            Strict
        }
        public enum Order
        {
            Date,
            Rating,
            Relevance,
            Title,
            VideoCount,
            ViewCount
        }
        public enum EventType
        {
            Completed,
            Live,
            Upcoming
        }
        public enum ChannelType
        {
            Any,
            Show
        }
        #endregion

        #region required parameters
        public string part { get; set; }
        #endregion

        #region filters
        public bool? forContentOwner { get; set; }
        public bool? forDeveloper { get; set; }
        public bool? forMine { get; set; }
        public string relatedToVideoId { get; set; }
        #endregion

        #region Optional parameters
        public string channelId { get; set; }
        public ChannelType? channelType { get; set; }
        public EventType? eventType { get; set; }
        public string location { get; set; }
        public string locationRadius { get; set; }
        public UInt16? maxResults { get; set; }
        public string onBehalfOfContentOwner { get; set; }
        public Order? order { get; set; }
        public string pageToken { get; set; }
        public DateTime? publishedAfter { get; set; }
        public DateTime? publishedBefore { get; set; }
        public string q { get; set; }
        public string regionCode { get; set; }
        public string relevanceLanguage { get; set; }
        public SafeSearch? safeSearch { get; set; }
        public string topicId { get; set; }
        public Type? type { get; set; }
        public VideoCaption? videoCaption { get; set; }
        public string videoCategoryId { get; set; }
        public VideoDefinition? videoDefinition { get; set; }
        public VideoDimension? videoDimension { get; set; }
        public VideoDuration? videoDuration { get; set; }
        public VideoEmbeddable? videoEmbeddable { get; set; }
        public VideoLicense? videoLicense { get; set; }
        public VideoSyndicated? videoSyndicated { get; set; }
        public VideoType? videoType { get; set; }
        #endregion
    }

    internal class FlagValueAttribute : Attribute
    {
        public string value;
        public FlagValueAttribute(string value)
        {
            this.value = value;
        }
    }
}
