namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the tags used to describe the characteristics of a shot
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=ShotTag">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum ShotTag
    {
        /// <summary>
        /// Represents a wide shot
        /// </summary>
        Wide,

        /// <summary>
        /// Represents a medium shot
        /// </summary>
        Medium,

        /// <summary>
        /// Represents a close-up shot
        /// </summary>
        CloseUp,

        /// <summary>
        /// Represents an extreme close-up shot
        /// </summary>
        ExtremeCloseUp,

        /// <summary>
        /// Represents a shot with two subjects
        /// </summary>
        Two,

        /// <summary>
        /// Represents a shot with multiple faces
        /// </summary>
        MultipleFaces,

        /// <summary>
        /// Represents an indoor shot
        /// </summary>
        Indoor,

        /// <summary>
        /// Represents an outdoor shot
        /// </summary>
        Outdoor,

        /// <summary>
        /// Represents a shot with a face positioned on the left
        /// </summary>
        LeftFace,

        /// <summary>
        /// Represents a shot with a face positioned at the center
        /// </summary>
        CenterFace,

        /// <summary>
        /// Represents a shot with a face positioned on the right
        /// </summary>
        RightFace
    }
}
