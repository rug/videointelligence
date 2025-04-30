namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the states of a video during its lifecycle in the system.
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=VideoState">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum VideoState
    {
        /// <summary>
        /// Represents a state where the video has been uploaded but not yet processed.
        /// </summary>
        Uploaded,

        /// <summary>
        /// Represents a state where the video is currently being processed.
        /// </summary>
        Processing,

        /// <summary>
        /// Represents a state where the video has been successfully processed.
        /// </summary>
        Processed,

        /// <summary>
        /// Represents a state where the video processing has failed.
        /// </summary>
        Failed
    }
}
