namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the sources for instances of insights in media content.
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=InstanceSource">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum InstanceSource
    {
        /// <summary>
        /// Represents a general source for the instance
        /// </summary>
        General,

        /// <summary>
        /// Represents a transcript source for the instance
        /// </summary>
        Transcript,

        /// <summary>
        /// Represents an OCR (Optical Character Recognition) source for the instance
        /// </summary>
        Ocr,

        /// <summary>
        /// Represents a title source for the instance
        /// </summary>
        Title
    }
}
