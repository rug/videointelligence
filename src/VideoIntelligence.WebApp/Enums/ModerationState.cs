namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the moderation states for content
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=ModerationState">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum ModerationState
    {
        /// <summary>
        /// Represents content that is acceptable
        /// </summary>
        OK,

        /// <summary>
        /// Represents content that is explicit
        /// </summary>
        Explicit,

        /// <summary>
        /// Represents content that has been removed
        /// </summary>
        Removed,

        /// <summary>
        /// Represents a state where moderation has not been applied
        /// </summary>
        None
    }
}
