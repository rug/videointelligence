namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents an instance of insight with start and end times, including adjustments.
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=InsightInstance">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class InsightInstance
    {
        /// <summary>
        /// The time that the object appears in the frame
        /// </summary>
        public TimeSpan Start { get; set; } 

        /// <summary>
        /// The time that the object no longer appears in the frame
        /// </summary>
        public TimeSpan End { get; set; }
        
        /// <summary>
        /// Adjusted start time of the video when using the editor
        /// </summary>
        public TimeSpan AdjustedStart { get; set; }

        /// <summary>
        /// Adjusted end time of the video when using the editor
        /// </summary>
        public TimeSpan AdjustedEnd { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsightInstance"/> class.
        /// </summary>
        public InsightInstance()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
