using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights about an emotion detected in the content
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=EmotionInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class EmotionInsight
    {
        /// <summary>
        /// The unique identifier for the emotion insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances related to the detected emotion, including confidence levels
        /// </summary>
        public IList<InsightInstanceWithConfidence> Instances { get; set; } = new List<InsightInstanceWithConfidence>();

        /// <summary>
        /// The type of emotion detected in the content
        /// </summary>
        public EmotionType Type { get; set; }
    }

}
