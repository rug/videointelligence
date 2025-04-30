namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights about an observed person detected in media content, including associated instances and clothing details
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=ObservedPersonInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class ObservedPersonInsight
    {
        /// <summary>
        /// The unique identifier for the observed person insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the observed person
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// The thumbnail ID associated with the observed person
        /// </summary>
        public string? ThumbnailId { get; set; }

        /// <summary>
        /// The list of clothing details associated with the observed person
        /// </summary>
        public IList<PersonClothingInsight> Clothing { get; set; } = new List<PersonClothingInsight> { };

        /// <summary>
        /// The matching face details for the observed person
        /// </summary>
        public MatchingFace MatchingFace { get; set; } = new MatchingFace();

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservedPersonInsight"/> class.
        /// </summary>
        public ObservedPersonInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
