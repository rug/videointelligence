namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights about a line of transcript detected in media content, including text, language, confidence, and associated instances
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=TranscriptLineInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class TranscriptLineInsight
    {
        /// <summary>
        /// The unique identifier for the transcript line insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The text content of the transcript line
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// The language of the transcript line
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// The confidence score for the transcript line detection, ranging between 0 and 1
        /// </summary>
        public double Confidence;

        /// <summary>
        /// The unique identifier for the speaker associated with the transcript line
        /// </summary>
        public int SpeakerId { get; set; }

        /// <summary>
        /// The list of instances associated with the transcript line insight
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TranscriptLineInsight"/> class
        /// </summary>
        public TranscriptLineInsight()
        {
            // Additional initialization logic can be added here if necessary
        }

    }
}
