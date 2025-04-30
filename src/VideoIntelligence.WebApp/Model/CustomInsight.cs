using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents a custom insight with associated display type and results
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=CustomInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class CustomInsight
    {
        /// <summary>
        /// The name of the custom insight
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The display name for the custom insight
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// The display type of the custom insight
        /// </summary>
        public DisplayType DisplayType { get; set; }

        /// <summary>
        /// Tthe list of results associated with the custom insight
        /// </summary>
        public IList<CustomInsightResult> Results { get; set; } = new List<CustomInsightResult>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomInsight"/> class.
        /// </summary>
        public CustomInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
