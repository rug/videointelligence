using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents a frame pattern insight, containing instances, pattern type, confidence, and metadata
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=FramePatternInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class FramePatternInsight
    {
        /// <summary>
        /// The unique identifier for the frame pattern insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the frame pattern insight, including confidence levels
        /// </summary>
        public IList<InsightInstanceWithConfidence> Instances { get; set; } = new List<InsightInstanceWithConfidence>();

        /// <summary>
        /// The type of the frame pattern
        /// </summary>
        public FramePatternType PatternType { get; set; }

        /// <summary>
        /// The confidence score for the frame pattern insight, ranging between 0 and 1
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// The name of the frame pattern insight
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The display name of the frame pattern insight
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// The unique identifier of the thumbnail associated with the frame pattern insight
        /// </summary>
        public string? ThumbnailId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FramePatternInsight"/> class.
        /// </summary>
        public FramePatternInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
