using VideoIntelligence.WebApp.Model;

namespace VideoIntelligence.WebApp.Models
{
    /// <summary>
    /// Represents insights about animated characters detected in media content
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=AnimatedCharacterInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class AnimatedCharacterInsight
    {
        /// <summary>
        /// The unique identifier for the animated character insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the animated character, including thumbnail IDs
        /// </summary>
        public IList<InsightInstanceWithThumbnailsIds> Instances { get; set; } = new List<InsightInstanceWithThumbnailsIds>();

        /// <summary>
        /// The name of the animated character
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The confidence score for the animated character detection, ranging between 0 and 1
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// The description of the animated character insight
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The thumbnail ID associated with the animated character
        /// </summary>
        public string? ThumbnailId { get; set; }

        /// <summary>
        /// The reference ID for the animated character insight
        /// </summary>
        public string? ReferenceId { get; set; }

        /// <summary>
        /// The list of thumbnails associated with the animated character insight
        /// </summary>
        public IList<InsightThumbnail> Thumbnails { get; set; } = new List<InsightThumbnail>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimatedCharacterInsight"/> class.
        /// </summary>
        public AnimatedCharacterInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
