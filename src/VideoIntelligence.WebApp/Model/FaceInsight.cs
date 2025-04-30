using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights about a face detected in the content, including metadata, instances, and thumbnails
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=FaceInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class FaceInsight
    {
        /// <summary>
        /// The unique identifier for the face insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the face insight, including thumbnail IDs
        /// </summary>
        public IList<InsightInstanceWithThumbnailsIds> Instances { get; set; } = new List<InsightInstanceWithThumbnailsIds>();

        /// <summary>
        /// The name associated with the face insight
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The confidence score for the face insight, ranging between 0 and 1
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// The description of the face insight
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The identifier of the thumbnail associated with the face insight
        /// </summary>
        public string? ThumbnailId { get; set; }

        /// <summary>
        /// The unique identifier of a known person associated with the face insight
        /// </summary>
        public string? KnownPersonId { get; set; }

        /// <summary>
        /// The reference ID for the face insight
        /// </summary>
        public string? ReferenceId { get; set; }

        /// <summary>
        /// The reference type for the face insight
        /// </summary>
        public FaceReferenceType ReferenceType { get; set; }

        /// <summary>
        /// The title associated with the face insight
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The URL of the image associated with the face insight
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// A value indicating whether the face insight has high-quality detection
        /// </summary>
        public bool HighQuality { get; set; }

        /// <summary>
        /// The list of thumbnails associated with the face insight
        /// </summary>
        public List<InsightThumbnail> Thumbnails { get; set; } = new List<InsightThumbnail>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceInsight"/> class.
        /// </summary>
        public FaceInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
