namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents the details of a clapperboard extracted from media content.
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=ClapperboardDetails">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class ClapperboardDetails
    {
        /// <summary>
        /// The title of the clapperboard detail
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The content associated with the clapperboard detail
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClapperboardDetails"/> class.
        /// </summary>
        public ClapperboardDetails()
        {
            // Additional initialization logic can be added here if needed.
        }
    }
}
