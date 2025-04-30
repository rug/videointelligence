namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights about a person's clothing detected in media content
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=PersonClothingInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class PersonClothingInsight
    {
        /// <summary>
        /// The unique identifier for the clothing insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The type of clothing detected (e.g., shirt, jacket, etc.)
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Additional properties associated with the clothing insight
        /// </summary>
        public object Properties { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonClothingInsight"/> class.
        /// </summary>
        public PersonClothingInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
