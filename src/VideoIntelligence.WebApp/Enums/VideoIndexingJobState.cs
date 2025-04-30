namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the states of the video indexing job
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Job-Status&definition=VideoIndexingJobState">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum VideoIndexingJobState
    {
        /// <summary>
        /// The job has been created (or received) but processing has not begun
        /// </summary>
        NotStarted = 0,

        /// <summary>
        /// The job is actively running—that is, the video is being downloaded/acquired and processed.
        /// </summary>
        Processing = 1,

        /// <summary>
        /// The video indexing has completed successfully, and the insights (or indexing results) are available.
        /// </summary>
        Processed = 2,

        /// <summary>
        /// An error occurred during processing so that the indexing did not complete successfully.
        /// </summary>
        Failed = 3,

        /// <summary>
        /// Finalizing The job is in its final stages (for example, wrapping up post–processing tasks 
        /// such as generating summaries or any additional insight extraction).
        /// </summary>
        Finalizing = 4,

        /// <summary>
        /// The job was canceled—either by user intervention or by a system decision
        /// </summary>
        Canceled = 6,

        /// <summary>
        /// The job ended in an undefined or unexpected state that does not fall into the categories above
        /// </summary>
        Unknown = 6
    }

}
