namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights for custom content, including type, subtype, metadata, and associated instances
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=CustomInsightResult">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class CustomInsightResult
    {
        /// <summary>
        /// The list of instances with confidence levels associated with the custom insight
        /// </summary>
        public IList<InsightInstanceWithConfidence> Instances { get; set; } = new List<InsightInstanceWithConfidence>();

        /// <summary>
        /// The type of the custom insight
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// The subtype of the custom insight
        /// </summary>
        public string? SubType { get; set; }

        /// <summary>
        /// The metadata associated with the custom insight
        /// </summary>
        public string? Metadata { get; set; }

        /// <summary>
        /// The unique identifier for the custom insight result
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The WikiData ID for the custom insight, if available
        /// </summary>
        public string? WikiDataId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomInsightResult"/> class.
        /// </summary>
        public CustomInsightResult()
        {
            // Additional initialization logic can be added here if required.
        }
    }
}
