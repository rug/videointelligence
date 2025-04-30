using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights about sentiments detected in media content, including scores and associated instances
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=SentimentInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class SentimentInsight
    {
        /// <summary>
        /// The unique identifier for the sentiment insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the sentiment insight
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// The sentiment score, ranging between 0 and 1
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// The average sentiment score across all instances
        /// </summary>
        public double AverageScore { get; set; }

        /// <summary>
        /// The type of sentiment detected
        /// </summary>
        public SentimentType SentimentType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentInsight"/> class.
        /// </summary>
        public SentimentInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
