using System;
using YouTubeApiRestClient.Utils;

namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     The "search" collection of methods.
    public class SearchResource
    {
        //
        // Summary:
        //     Returns a collection of search results that match the query parameters specified
        //     in the API request. By default, a search result set identifies matching video,
        //     channel, and playlist resources, but you can also configure queries to only retrieve
        //     a specific type of resource.
        public class ListRequest
        {
            //
            // Summary:
            //     Constructs a new List request.
            public ListRequest(string part)
            {
                Part = part;
            }

            //
            // Summary:
            //     The channelId parameter indicates that the API response should only contain resources
            //     created by the channel
            [RequestParameter("channelId", RequestParameterType.Query)]
            public string ChannelId { get; set; }

            //
            // Summary:
            //     The channelType parameter lets you restrict a search to a particular type of
            //     channel.
            [RequestParameterAttribute("channelType", RequestParameterType.Query)]
            public ChannelTypeEnum? ChannelType { get; set; }

            //
            // Summary:
            //     The eventType parameter restricts a search to broadcast events.
            [RequestParameterAttribute("eventType", RequestParameterType.Query)]
            public EventTypeEnum? EventType { get; set; }

            //
            // Summary:
            //     Note: This parameter is intended exclusively for YouTube content partners. The
            //     forContentOwner parameter restricts the search to only retrieve resources owned
            //     by the content owner specified by the onBehalfOfContentOwner parameter. The user
            //     must be authenticated using a CMS account linked to the specified content owner
            //     and onBehalfOfContentOwner must be provided.
            [RequestParameterAttribute("forContentOwner", RequestParameterType.Query)]
            public bool? ForContentOwner { get; set; }

            //
            // Summary:
            //     The forMine parameter restricts the search to only retrieve videos owned by the
            //     authenticated user. If you set this parameter to true, then the type parameter's
            //     value must also be set to video.
            [RequestParameterAttribute("forMine", RequestParameterType.Query)]
            public bool? ForMine { get; set; }

            //
            // Summary:
            //     The location parameter restricts a search to videos that have a geographical
            //     location specified in their metadata. The value is a string that specifies geographic
            //     latitude/longitude coordinates e.g. (37.42307,-122.08427)
            [RequestParameterAttribute("location", RequestParameterType.Query)]
            public string Location { get; set; }

            //
            // Summary:
            //     The locationRadius, in conjunction with the location parameter, defines a geographic
            //     area. If the geographic coordinates associated with a video fall within that
            //     area, then the video may be included in search results. This parameter value
            //     must be a floating point number followed by a measurement unit. Valid measurement
            //     units are m, km, ft, and mi. For example, valid parameter values include 1500m,
            //     5km, 10000ft, and 0.75mi. The API does not support locationRadius parameter values
            //     larger than 1000 kilometers.
            [RequestParameterAttribute("locationRadius", RequestParameterType.Query)]
            public string LocationRadius { get; set; }

            //
            // Summary:
            //     The maxResults parameter specifies the maximum number of items that should be
            //     returned in the result set.
            [RequestParameterAttribute("maxResults", RequestParameterType.Query)]
            public long? MaxResults { get; set; }

            //
            // Summary:
            //     Note: This parameter is intended exclusively for YouTube content partners. The
            //     onBehalfOfContentOwner parameter indicates that the request's authorization credentials
            //     identify a YouTube CMS user who is acting on behalf of the content owner specified
            //     in the parameter value. This parameter is intended for YouTube content partners
            //     that own and manage many different YouTube channels. It allows content owners
            //     to authenticate once and get access to all their video and channel data, without
            //     having to provide authentication credentials for each individual channel. The
            //     CMS account that the user authenticates with must be linked to the specified
            //     YouTube content owner.
            [RequestParameterAttribute("onBehalfOfContentOwner", RequestParameterType.Query)]
            public string OnBehalfOfContentOwner { get; set; }

            //
            // Summary:
            //     The order parameter specifies the method that will be used to order resources
            //     in the API response.
            [RequestParameterAttribute("order", RequestParameterType.Query)]
            public OrderEnum? Order { get; set; }

            //
            // Summary:
            //     The pageToken parameter identifies a specific page in the result set that should
            //     be returned. In an API response, the nextPageToken and prevPageToken properties
            //     identify other pages that could be retrieved.
            [RequestParameterAttribute("pageToken", RequestParameterType.Query)]
            public string PageToken { get; set; }

            //
            // Summary:
            //     The part parameter specifies a comma-separated list of one or more search resource
            //     properties that the API response will include. The part names that you can include
            //     in the parameter value are id and snippet. If the parameter identifies a property
            //     that contains child properties, the child properties will be included in the
            //     response. For example, in a search result, the snippet property contains other
            //     properties that identify the result's title, description, and so forth. If you
            //     set part=snippet, the API response will also contain all of those nested properties.
            [RequestParameterAttribute("part", RequestParameterType.Query)]
            public string Part { get; private set; }

            //
            // Summary:
            //     The publishedAfter parameter indicates that the API response should only contain
            //     resources created after the specified time. The value is an RFC 3339 formatted
            //     date-time value (1970-01-01T00:00:00Z).
            [RequestParameterAttribute("publishedAfter", RequestParameterType.Query)]
            public DateTime? PublishedAfter { get; set; }

            //
            // Summary:
            //     The publishedBefore parameter indicates that the API response should only contain
            //     resources created before the specified time. The value is an RFC 3339 formatted
            //     date-time value (1970-01-01T00:00:00Z).
            [RequestParameterAttribute("publishedBefore", RequestParameterType.Query)]
            public DateTime? PublishedBefore { get; set; }

            //
            // Summary:
            //     The q parameter specifies the query term to search for.
            [RequestParameterAttribute("q", RequestParameterType.Query)]
            public string Q { get; set; }

            //
            // Summary:
            //     The regionCode parameter instructs the API to return search results for the specified
            //     country. The parameter value is an ISO 3166-1 alpha-2 country code.
            [RequestParameterAttribute("regionCode", RequestParameterType.Query)]
            public string RegionCode { get; set; }

            //
            // Summary:
            //     The relatedToVideoId parameter retrieves a list of videos that are related to
            //     the video that the parameter value identifies. The parameter value must be set
            //     to a YouTube video ID and, if you are using this parameter, the type parameter
            //     must be set to video.
            [RequestParameterAttribute("relatedToVideoId", RequestParameterType.Query)]
            public string RelatedToVideoId { get; set; }

            //
            // Summary:
            //     The safeSearch parameter indicates whether the search results should include
            //     restricted content as well as standard content.
            [RequestParameterAttribute("safeSearch", RequestParameterType.Query)]
            public SafeSearchEnum? SafeSearch { get; set; }

            //
            // Summary:
            //     The topicId parameter indicates that the API response should only contain resources
            //     associated with the specified topic. The value identifies a Freebase topic ID.
            [RequestParameterAttribute("topicId", RequestParameterType.Query)]
            public string TopicId { get; set; }

            //
            // Summary:
            //     The type parameter restricts a search query to only retrieve a particular type
            //     of resource. The value is a comma-separated list of resource types.
            [RequestParameterAttribute("type", RequestParameterType.Query)]
            public string Type { get; set; }

            //
            // Summary:
            //     The videoCaption parameter indicates whether the API should filter video search
            //     results based on whether they have captions.
            [RequestParameterAttribute("videoCaption", RequestParameterType.Query)]
            public VideoCaptionEnum? VideoCaption { get; set; }

            //
            // Summary:
            //     The videoCategoryId parameter filters video search results based on their category.
            [RequestParameterAttribute("videoCategoryId", RequestParameterType.Query)]
            public string VideoCategoryId { get; set; }

            //
            // Summary:
            //     The videoDefinition parameter lets you restrict a search to only include either
            //     high definition (HD) or standard definition (SD) videos. HD videos are available
            //     for playback in at least 720p, though higher resolutions, like 1080p, might also
            //     be available.
            [RequestParameterAttribute("videoDefinition", RequestParameterType.Query)]
            public VideoDefinitionEnum? VideoDefinition { get; set; }

            //
            // Summary:
            //     The videoDimension parameter lets you restrict a search to only retrieve 2D or
            //     3D videos.
            [RequestParameterAttribute("videoDimension", RequestParameterType.Query)]
            public VideoDimensionEnum? VideoDimension { get; set; }

            //
            // Summary:
            //     The videoDuration parameter filters video search results based on their duration.
            [RequestParameterAttribute("videoDuration", RequestParameterType.Query)]
            public VideoDurationEnum? VideoDuration { get; set; }

            //
            // Summary:
            //     The videoEmbeddable parameter lets you to restrict a search to only videos that
            //     can be embedded into a webpage.
            [RequestParameterAttribute("videoEmbeddable", RequestParameterType.Query)]
            public VideoEmbeddableEnum? VideoEmbeddable { get; set; }

            //
            // Summary:
            //     The videoLicense parameter filters search results to only include videos with
            //     a particular license. YouTube lets video uploaders choose to attach either the
            //     Creative Commons license or the standard YouTube license to each of their videos.
            [RequestParameterAttribute("videoLicense", RequestParameterType.Query)]
            public VideoLicenseEnum? VideoLicense { get; set; }

            //
            // Summary:
            //     The videoSyndicated parameter lets you to restrict a search to only videos that
            //     can be played outside youtube.com.
            [RequestParameterAttribute("videoSyndicated", RequestParameterType.Query)]
            public VideoSyndicatedEnum? VideoSyndicated { get; set; }

            //
            // Summary:
            //     The videoType parameter lets you restrict a search to a particular type of videos.
            [RequestParameterAttribute("videoType", RequestParameterType.Query)]
            public VideoTypeEnum? VideoType { get; set; }

            //
            // Summary:
            //     The channelType parameter lets you restrict a search to a particular type of
            //     channel.
            public enum ChannelTypeEnum
            {
                //
                // Summary:
                //     Return all channels.
                Any = 0,
                //
                // Summary:
                //     Only retrieve shows.
                Show = 1
            }
            //
            // Summary:
            //     The eventType parameter restricts a search to broadcast events.
            public enum EventTypeEnum
            {
                //
                // Summary:
                //     Only include completed broadcasts.
                Completed = 0,
                //
                // Summary:
                //     Only include active broadcasts.
                Live = 1,
                //
                // Summary:
                //     Only include upcoming broadcasts.
                Upcoming = 2
            }
            //
            // Summary:
            //     The order parameter specifies the method that will be used to order resources
            //     in the API response.
            public enum OrderEnum
            {
                //
                // Summary:
                //     Resources are sorted in reverse chronological order based on the date they were
                //     created.
                Date = 0,
                //
                // Summary:
                //     Resources are sorted from highest to lowest rating.
                Rating = 1,
                //
                // Summary:
                //     Resources are sorted based on their relevance to the search query. This is the
                //     default value for this parameter.
                Relevance = 2,
                //
                // Summary:
                //     Resources are sorted alphabetically by title.
                Title = 3,
                //
                // Summary:
                //     Channels are sorted in descending order of their number of uploaded videos.
                VideoCount = 4,
                //
                // Summary:
                //     Resources are sorted from highest to lowest number of views.
                ViewCount = 5
            }
            //
            // Summary:
            //     The safeSearch parameter indicates whether the search results should include
            //     restricted content as well as standard content.
            public enum SafeSearchEnum
            {
                //
                // Summary:
                //     YouTube will filter some content from search results and, at the least, will
                //     filter content that is restricted in your locale. Based on their content, search
                //     results could be removed from search results or demoted in search results. This
                //     is the default parameter value.
                Moderate = 0,
                //
                // Summary:
                //     YouTube will not filter the search result set.
                None = 1,
                //
                // Summary:
                //     YouTube will try to exclude all restricted content from the search result set.
                //     Based on their content, search results could be removed from search results or
                //     demoted in search results.
                Strict = 2
            }
            //
            // Summary:
            //     The videoCaption parameter indicates whether the API should filter video search
            //     results based on whether they have captions.
            public enum VideoCaptionEnum
            {
                //
                // Summary:
                //     Do not filter results based on caption availability.
                Any = 0,
                //
                // Summary:
                //     Only include videos that have captions.
                ClosedCaption = 1,
                //
                // Summary:
                //     Only include videos that do not have captions.
                None = 2
            }
            //
            // Summary:
            //     The videoDefinition parameter lets you restrict a search to only include either
            //     high definition (HD) or standard definition (SD) videos. HD videos are available
            //     for playback in at least 720p, though higher resolutions, like 1080p, might also
            //     be available.
            public enum VideoDefinitionEnum
            {
                //
                // Summary:
                //     Return all videos, regardless of their resolution.
                Any = 0,
                //
                // Summary:
                //     Only retrieve HD videos.
                High = 1,
                //
                // Summary:
                //     Only retrieve videos in standard definition.
                Standard = 2
            }
            //
            // Summary:
            //     The videoDimension parameter lets you restrict a search to only retrieve 2D or
            //     3D videos.
            public enum VideoDimensionEnum
            {
                //
                // Summary:
                //     Restrict search results to exclude 3D videos.
                Value2d = 0,
                //
                // Summary:
                //     Restrict search results to only include 3D videos.
                Value3d = 1,
                //
                // Summary:
                //     Include both 3D and non-3D videos in returned results. This is the default value.
                Any = 2
            }
            //
            // Summary:
            //     The videoDuration parameter filters video search results based on their duration.
            public enum VideoDurationEnum
            {
                //
                // Summary:
                //     Do not filter video search results based on their duration. This is the default
                //     value.
                Any = 0,
                //
                // Summary:
                //     Only include videos longer than 20 minutes.
                Long = 1,
                //
                // Summary:
                //     Only include videos that are between four and 20 minutes long (inclusive).
                Medium = 2,
                //
                // Summary:
                //     Only include videos that are less than four minutes long.
                Short = 3
            }
            //
            // Summary:
            //     The videoEmbeddable parameter lets you to restrict a search to only videos that
            //     can be embedded into a webpage.
            public enum VideoEmbeddableEnum
            {
                //
                // Summary:
                //     Return all videos, embeddable or not.
                Any = 0,
                //
                // Summary:
                //     Only retrieve embeddable videos.
                True = 1
            }
            //
            // Summary:
            //     The videoLicense parameter filters search results to only include videos with
            //     a particular license. YouTube lets video uploaders choose to attach either the
            //     Creative Commons license or the standard YouTube license to each of their videos.
            public enum VideoLicenseEnum
            {
                //
                // Summary:
                //     Return all videos, regardless of which license they have, that match the query
                //     parameters.
                Any = 0,
                //
                // Summary:
                //     Only return videos that have a Creative Commons license. Users can reuse videos
                //     with this license in other videos that they create. Learn more.
                CreativeCommon = 1,
                //
                // Summary:
                //     Only return videos that have the standard YouTube license.
                Youtube = 2
            }
            //
            // Summary:
            //     The videoSyndicated parameter lets you to restrict a search to only videos that
            //     can be played outside youtube.com.
            public enum VideoSyndicatedEnum
            {
                //
                // Summary:
                //     Return all videos, syndicated or not.
                Any = 0,
                //
                // Summary:
                //     Only retrieve syndicated videos.
                True = 1
            }
            //
            // Summary:
            //     The videoType parameter lets you restrict a search to a particular type of videos.
            public enum VideoTypeEnum
            {
                //
                // Summary:
                //     Return all videos.
                Any = 0,
                //
                // Summary:
                //     Only retrieve episodes of shows.
                Episode = 1,
                //
                // Summary:
                //     Only retrieve movies.
                Movie = 2
            }
        }
    }
}
