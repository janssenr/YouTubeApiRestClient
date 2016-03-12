using System;
using System.Runtime.Serialization;

namespace YouTubeApiRestClient.Views
{
    //
    // Summary:
    //     Basic details about a video category, such as its localized title.
    [DataContract]
    public class VideoStatus
    {
        //
        // Summary:
        //     This value indicates if the video can be embedded on another website.
        [DataMember(Name="embeddable", EmitDefaultValue = false)]
        public bool? Embeddable { get; set; }

        //
        // Summary:
        //     The ETag of the item.
        public string ETag { get; set; }
        
        //
        // Summary:
        //     This value explains why a video failed to upload. This property is only present
        //     if the uploadStatus property indicates that the upload failed.
        [DataMember(Name="failureReason", EmitDefaultValue = false)]
        public string FailureReason { get; set; }
        
        //
        // Summary:
        //     The video's license.
        [DataMember(Name="license", EmitDefaultValue = false)]
        public string License { get; set; }
        
        //
        // Summary:
        //     The video's privacy status.
        [DataMember(Name="privacyStatus", EmitDefaultValue = false)]
        public string PrivacyStatus { get; set; }
        
        //
        // Summary:
        //     This value indicates if the extended video statistics on the watch page can be
        //     viewed by everyone. Note that the view count, likes, etc will still be visible
        //     if this is disabled.
        [DataMember(Name="publicStatsViewable", EmitDefaultValue = false)]
        public bool? PublicStatsViewable { get; set; }
        
        //
        // Summary:
        //     System.DateTime representation of Google.Apis.YouTube.v3.Data.VideoStatus.PublishAtRaw.
        public DateTime? PublishAt { get; set; }
        
        //
        // Summary:
        //     The date and time when the video is scheduled to publish. It can be set only
        //     if the privacy status of the video is private. The value is specified in ISO
        //     8601 (YYYY-MM-DDThh:mm:ss.sZ) format.
        [DataMember(Name="publishAt", EmitDefaultValue = false)]
        public string PublishAtRaw { get; set; }
        
        //
        // Summary:
        //     This value explains why YouTube rejected an uploaded video. This property is
        //     only present if the uploadStatus property indicates that the upload was rejected.
        [DataMember(Name="rejectionReason", EmitDefaultValue = false)]
        public string RejectionReason { get; set; }
        
        //
        // Summary:
        //     The status of the uploaded video.
        [DataMember(Name="uploadStatus", EmitDefaultValue = false)]
        public string UploadStatus { get; set; }
    }
}
