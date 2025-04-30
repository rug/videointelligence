namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents a matching face detected in media content, including its ID and confidence score
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=MatchingFace">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class MatchingFace
    {
        /// <summary>
        /// The unique identifier for the matching face
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The confidence score for the matching face detection, ranging between 0 and 1
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchingFace"/> class.
        /// </summary>
        public MatchingFace()
        {
            // Additional initialization logic can be added here if necessary.

        }
    }
}
