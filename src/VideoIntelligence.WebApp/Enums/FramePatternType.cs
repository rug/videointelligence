namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the types of patterns that can appear in video frames
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=FramePatternType">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum FramePatternType
    {
        /// <summary>
        /// Indicates no specific frame pattern
        /// </summary>
        None,

        /// <summary>
        /// Indicates a black frame pattern
        /// </summary>
        Black,

        /// <summary>
        /// Indicates rolling credits in the frame
        /// </summary>
        RollingCredits,

        /// <summary>
        /// Indicates color bars in the frame
        /// </summary>
        ColorBars,

        /// <summary>
        /// Indicates a custom frame pattern
        /// </summary
        Custom
    }
}
