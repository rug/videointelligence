namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents an insight associated with a specific label
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=LabelInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class LabelInsight
    {
        /// <summary>
        /// Unique identifier for the label insight.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the label
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The language of the label
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// List of instances associated with this label, including confidence details.
        /// </summary>
        public IList<InsightInstanceWithConfidence> Instances { get; set; } = new List<InsightInstanceWithConfidence>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelInsight"/> class.
        /// </summary>
        public LabelInsight()
        {
            // Additional initialization logic can be added here if required.
        }
    }
}
