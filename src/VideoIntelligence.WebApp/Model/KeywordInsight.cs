namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents an insight extracted from a keyword
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=KeywordInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class KeywordInsight
    {
        /// <summary>
        /// Unique identifier of the insight.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The text of the keyword
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// The language of the keyword
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// The confidence level of the insight
        /// </summary>
        public double Confidence;

        /// <summary>
        /// List of instances related to the insight
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// Initializes a new instance of the <see cref="KeywordInsight"/> class.
        /// </summary>
        public KeywordInsight()
        {
            // Constructor logic can be added if needed.
        }
    }
}
