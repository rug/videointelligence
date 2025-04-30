namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights for a brand detected in media content, including its metadata, tags, and instances.
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=BrandInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class BrandInsight
    {
        /// <summary>
        /// The name of the brand
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The reference ID for the brand
        /// </summary>
        public string? ReferenceId { get; set; }

        /// <summary>
        /// The reference URL for the brand
        /// </summary>
        public string? ReferenceUrl { get; set; }

        /// <summary>
        /// The description of the brand
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The tags associated with the brand
        /// </summary>
        public string[] Tags { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The confidence score for the brand detection
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// A value indicating whether the brand detection is custom
        /// </summary>
        public bool IsCustom { get; set; }

        /// <summary>
        /// The unique identifier for the brand insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the brand
        /// </summary>
        public IList<BrandInsightInstance> Instances { get; set; } = new List<BrandInsightInstance>();

        /// <summary>
        /// The reference type of the brand insight
        /// </summary>
        public BrandReferenceType ReferenceType { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="BrandInsight"/> class.
        /// </summary>
        public BrandInsight()
        {
            // Additional initialization logic can be added here if needed.
        }
    }

    /// <summary>
    /// Defines the types of references available for a brand insight
    /// </summary>
    public enum BrandReferenceType
    {
        /// <summary>
        /// Indicates that the reference is from Wiki.
        /// </summary>
        Wiki
    }
}
