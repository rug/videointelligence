namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents an insight instance that includes associated thumbnail IDs
    /// </summary>
    public class InsightInstanceWithThumbnailsIds : InsigntInstanceWithInstanceSource
    {
        /// <summary>
        /// The list of thumbnail IDs associated with the insight instance
        /// </summary>
        public string[] ThumbnailsIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="InsightInstanceWithThumbnailsIds"/> class.
        /// </summary>
        public InsightInstanceWithThumbnailsIds()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
