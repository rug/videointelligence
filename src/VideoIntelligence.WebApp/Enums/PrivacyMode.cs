namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the privacy modes available for videos in the system
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=PrivacyMode">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum PrivacyMode
    {
        /// <summary>
        /// Represents a privacy mode where the video is private and not accessible to the public
        /// </summary>
        Private,

        /// <summary>
        /// Represents a privacy mode where the video is public and accessible to everyone
        /// </summary>
        Public
    }
}
