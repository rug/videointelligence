using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights for detected objects in a media file
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <list type="bullet">
    /// <item><see href="https://learn.microsoft.com/en-us/azure/azure-video-indexer/object-detection-insight">Azure Video Indexer Documentation</see></item>
    /// <item><see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=DetectedObjectInsight">Azure AI Video Indexer API Details</see></item>
    /// </list>
    /// <remarks>
    public class DetectedObjectInsight
    {
        /// <summary>
        /// Incremental number of IDs of the detected objects in the media file
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The instance details tracked for the detected object
        /// </summary>
        public InsightInstanceWithConfidence Instances { get; set; } = new InsightInstanceWithConfidence();

        /// <summary>
        /// The type of the detected object
        /// </summary>
        public DetectedObjectType Type { get; set; }

        /// <summary>
        /// A unique identifier representing a single detection of the object
        /// </summary>
        public string? ThumbnailId { get; set; }

        /// <summary>
        /// The display name for the detected object
        /// </summary>
        public string? DisplayName { get; set; }
        
        /// <summary>
        /// A unique identifier in the WikiData structure
        /// </summary>
        public string? WikiDataId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DetectedObjectInsight"/> class.
        /// </summary>
        public DetectedObjectInsight()
        {
            // Additional initialization logic can be added here if required.
        }
    }
}
