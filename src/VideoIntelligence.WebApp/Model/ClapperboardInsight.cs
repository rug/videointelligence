namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights associated with clapperboards in media files
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=ClapperboardInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class ClapperboardInsight
    {
        /// <summary>
        /// The unique identifier for the clapperboard insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the clapperboard insight
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// A unique identifier for the thumbnail associated with the clapperboard insight
        /// </summary>
        public string? ThumbnailId { get; set; }

        /// <summary>
        /// A value indicating whether the clapperboard is a head slate
        /// </summary>
        public bool IsHeadSlate { get; set; }

        /// <summary>
        /// List of fields with details about the clapperboard
        /// </summary>
        public IList<ClapperboardDetails> Fields { get; set; } = new List<ClapperboardDetails>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ClapperboardInsight"/> class.
        /// </summary>
        public ClapperboardInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
