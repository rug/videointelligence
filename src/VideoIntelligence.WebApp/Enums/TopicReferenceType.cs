namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the types of references available for topics detected in media content.
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=TopicReferenceType">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum TopicReferenceType
    {
        /// <summary>
        /// Represents a reference from Azure Video Indexer
        /// </summary>
        VideoIndexer,

        /// <summary>
        /// Represents a reference from Wikipedia
        /// </summary>
        Wikipedia
    }
}
