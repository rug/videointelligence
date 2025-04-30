using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents an element instance with a confidence score, type, matched value, and optional thumbnail ID
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=ElementInstanceWithConfidence3">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class ElementInstanceWithConfidence3 : InsightInstanceWithConfidence
    {
        /// <summary>
        /// The type of the logo instance
        /// </summary>
        public LogoInstanceType Type { get; set; }

        /// <summary>
        /// The matched value associated with the element instance
        /// </summary>
        public string? MatchedValue { get; set; }

        /// <summary>
        /// The identifier of the thumbnail associated with the element instance
        /// </summary>
        public string? ThumbnailId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementInstanceWithConfidence3"/> class.
        /// </summary>
        public ElementInstanceWithConfidence3()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }

}
