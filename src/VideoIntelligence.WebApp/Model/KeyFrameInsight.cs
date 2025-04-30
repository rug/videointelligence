namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents a key frame insight containing related instances.
    /// </summary> 
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=KeyFrameInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class KeyFrameInsight
    {
        /// <summary>
        /// Unique identifier for the key frame insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with this key frame insight.
        /// </summary>
        public List<KeyFrameInsightInstance> Instances { get; set; } = new List<KeyFrameInsightInstance>();

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyFrameInsight"/> class.
        /// </summary>
        public KeyFrameInsight()
        {
            // Additional initialization logic can be added here if required.
        }
    }
}
