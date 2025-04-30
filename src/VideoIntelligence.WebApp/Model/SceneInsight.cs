namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights about scenes detected in media content
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=SceneInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class SceneInsight
    {
        /// <summary>
        /// The unique identifier for the scene insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the scene insight
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SceneInsight"/> class.
        /// </summary>
        public SceneInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
