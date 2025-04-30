using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents a match found during a video search, including details about the match type, text, and timing
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Search-Videos&definition=VideoSearchMatch">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class VideoSearchMatch
    {
        /// <summary>
        /// The start time of the match in the video
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// The type of match found
        /// </summary>
        public VideoMatchType Type { get; set; }

        /// <summary>
        /// The subtype of the match, providing additional context
        /// </summary>
        public string? SubType { get; set; }

        /// <summary>
        /// The text associated with the match
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// The exact text of the match, if available
        /// </summary>
        public string? ExactText { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoSearchMatch"/> class.
        /// </summary>
        public VideoSearchMatch()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }   
}
