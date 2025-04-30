namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents a named location detected in media content, including its metadata, tags, and associated instances
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=NamedLocation">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class NamedLocation
    {
        /// <summary>
        /// The name of the location
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The reference ID for the location
        /// </summary>
        public string? ReferenceId { get; set; }

        /// <summary>
        /// The reference URL providing additional information about the location
        /// </summary>
        public string? ReferenceUrl { get; set; }

        /// <summary>
        /// The description of the location
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The tags associated with the location
        /// </summary>
        public string[] Tags { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The confidence score for the location detection
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// A value indicating whether the location detection is custom
        /// </summary>
        public bool IsCustom { get; set; }

        /// <summary>
        /// The unique identifier for the named location
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the location, including source information
        /// </summary>
        public IList<InsigntInstanceWithInstanceSource> Instances { get; set; } = new List<InsigntInstanceWithInstanceSource>();

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedLocation"/> class.
        /// </summary>
        public NamedLocation()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
