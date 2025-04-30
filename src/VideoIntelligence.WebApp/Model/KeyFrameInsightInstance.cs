using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents an instance of a key frame insight, including thumbnail information
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=KeyFrameInsightInstance">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class KeyFrameInsightInstance : InsightInstance
    {
        /// <summary>
        /// The identifier of the thumbnail associated with the key frame insight
        /// </summary>
        public string ThumbnailId { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyFrameInsightInstance"/> class.
        /// </summary>
        public KeyFrameInsightInstance()
        {
            // Additional initialization logic can be added here if required.
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class KeyFrameInsightInstanceWithThumbnailUrl : KeyFrameInsightInstance
    {
        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailUrl { get; set; } = string.Empty;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyFrameInsightInstanceWithThumbnailUrl"/> class.
        /// </summary>
        public KeyFrameInsightInstanceWithThumbnailUrl()
        {
            // Additional initialization logic can be added here if required.
        }
    }
}
