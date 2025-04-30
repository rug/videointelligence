namespace VideoIntelligence.WebApp.Model
{

    /// <summary>
    /// Represents a named person detected in media content, including metadata, tags, and associated instances
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=NamedPerson">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class NamedPerson
    {
        /// <summary>
        /// The name of the person 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The reference ID for the person
        /// </summary>
        public string? ReferenceId { get; set; }

        /// <summary>
        /// The reference URL providing additional information about the person
        /// </summary>
        public string? ReferenceUrl { get; set; }

        /// <summary>
        /// The description of the person
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The tags associated with the person
        /// </summary>
        public string[] Tags { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The confidence score for the named person detection
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// A value indicating whether the person detection is custom 
        /// </summary>
        public bool IsCustom { get; set; }

        /// <summary>
        /// The unique identifier for the named person
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The the list of instances associated with the named person, including source information
        /// </summary>
        public IList<InsigntInstanceWithInstanceSource> Instances { get; set; } = new List<InsigntInstanceWithInstanceSource>();

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedPerson"/> class.
        /// </summary>
        public NamedPerson()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
