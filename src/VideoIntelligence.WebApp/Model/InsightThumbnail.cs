namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents a thumbnail associated with an insight, including instances and optional file name.
    /// </summary>
    public class InsightThumbnail
    {
        /// <summary>
        /// Unique identifier for the insight thumbnail
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of insight instances related to the thumbnail
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// The file name of the thumbnail, if available
        /// </summary>
        public string? FileName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsightThumbnail"/> class.
        /// </summary>
        public InsightThumbnail()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
