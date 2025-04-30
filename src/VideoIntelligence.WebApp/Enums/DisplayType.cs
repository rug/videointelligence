namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the available display types for custom insights
    /// </summary> 
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=DisplayType">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum DisplayType
    {
        /// <summary>
        /// Represents a capsule display type
        /// </summary>
        Capsule,

        /// <summary>
        /// Represents a capsule and tags display type
        /// </summary>
        CapsuleAndTags
    }
}
