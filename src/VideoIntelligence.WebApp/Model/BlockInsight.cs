namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights for detected blocks in a media file
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=BlockInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class BlockInsight
    {
        /// <summary>
        /// The unique identifier for the block insight
        /// </summary>
        public int Id{ get; set; }

        /// <summary>
        /// The list of instances associated with the block insight
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockInsight"/> class.
        /// </summary>
        public BlockInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
