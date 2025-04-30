namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights about logos detected in media content
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=LogoInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class LogoInsight
    {
        /// <summary>
        /// The unique identifier for the logo insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the detected logo, including confidence levels
        /// </summary>
        public IList<ElementInstanceWithConfidence3> Instances { get; set; } = new List<ElementInstanceWithConfidence3>();

        /// <summary>
        /// The reference ID for the logo
        /// </summary>
        public string? ReferenceId { get; set; }

        /// <summary>
        /// The thumbnail ID associated with the logo
        /// </summary>
        public string? ThumbnailId { get; set; }

        /// <summary>
        /// The name of the logo
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description of the logo insight
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The reference URL providing additional information about the logo
        /// </summary>
        public string? ReferenceUrl { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogoInsight"/> class.
        /// </summary>
        public LogoInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
