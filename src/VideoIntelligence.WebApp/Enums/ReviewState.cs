namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the states of a review process
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=ReviewState">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum ReviewState
    {
        /// <summary>
        /// Represents a state where no review has been initiated
        /// </summary>
        None,

        /// <summary>
        /// Represents a state where the review is currently in progress
        /// </summary>
        InProgress,

        /// <summary>
        /// Represents a state where the review has been completed
        /// </summary>
        Completed
    }
}
