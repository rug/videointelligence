namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the types of sentiments detected in media content
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=SentimentType">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum SentimentType
    {
        /// <summary>
        /// Represents a negative sentiment
        /// </summary>
        Negative,

        /// <summary>
        /// Represents a neutral sentiment
        /// </summary>
        Neutral,

        /// <summary>
        /// Represents a positive sentiment
        /// </summary>
        Positive,

        /// <summary>
        /// Represents an undetermined sentiment
        /// </summary>
        Undetermined
    }
}
