using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents an instance of brand insight with its source type
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=BrandInsightInstance">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class BrandInsightInstance : InsigntInstanceWithInstanceSource
    {
        /// <summary>
        /// The source type of the brand insight
        /// </summary>
        public InstanceSource BrandType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandInsightInstance"/> class.
        /// </summary>
        public BrandInsightInstance()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
