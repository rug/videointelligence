namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents language-related information for a video, including detected languages and dominant language
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=VideoLanguage">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class VideoLanguage
    {
        /// <summary>
        /// The languages detected in the video
        /// </summary>
        public string? Languages { get; set; }

        /// <summary>
        /// The dominant language of the video
        /// </summary>
        public string? DominantLanguage { get; set; }

        /// <summary>
        /// A value indicating whether multiple languages are detected in the video
        /// </summary>
        public bool IsMultipleLanguages { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoLanguage"/> class.
        /// </summary>
        public VideoLanguage()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
