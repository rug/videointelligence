namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights about a speaker detected in media content, including associated instances and the speaker's name
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=SpeakerInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class SpeakerInsight
    {
        /// <summary>
        /// The unique identifier for the speaker insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the speaker
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// The name of the speaker
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpeakerInsight"/> class.
        /// </summary>
        public SpeakerInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }

    }
}
