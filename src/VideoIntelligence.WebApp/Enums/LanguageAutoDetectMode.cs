namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the modes for automatic language detection
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=LanguageAutoDetectMode">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum LanguageAutoDetectMode
    {
        /// <summary>
        /// Represents a mode where no language detection is applied
        /// </summary>
        None,

        /// <summary>
        /// Represents a mode where a single language is detected
        /// </summary>
        Single,

        /// <summary>
        /// Represents a mode where multiple languages are detected
        /// </summary>
        Multi
    }
}
