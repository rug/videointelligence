using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents the contract for video metadata and insights in the Azure Video Indexer
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=VideoContract">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class VideoContract
    {
        /// <summary>
        /// The account ID associated with the video
        /// </summary>
        public string? AccountId { get; set; }

        /// <summary>
        /// The unique identifier for the video
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The name of the video
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The username of the video owner
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// The creation date of the video
        /// </summary>
        public string? Created { get; set; }

        /// <summary>
        /// A value indicating whether the video is owned by the user
        /// </summary>
        public bool IsOwned { get; set; }

        /// <summary>
        /// A value indicating whether the video is editable
        /// </summary>
        public bool IsEditable { get; set; }

        /// <summary>
        /// A value indicating whether the video is a base video
        /// </summary>
        public bool IsBase { get; set; }

        /// <summary>
        /// The duration of the video in a formatted string
        /// </summary>
        public string? Duration { get; set; }

        /// <summary>
        /// The duration of the video in seconds
        /// </summary>
        public int DurationInSeconds { get; set; }

        /// <summary>
        /// The summarized insights associated with the video
        /// </summary>
        public SummarizedInsight SummarizedInsights { get; set; } = new SummarizedInsight();

        /// <summary>
        /// The list of video indexes associated with the video
        /// </summary>
        public IList<VideoIndex> Videos { get; set; } = new List<VideoIndex>();

        /// <summary>
        /// The list of video time ranges associated with the video
        /// </summary>
        public IList<VideoTimeRange> VideosRanges { get; set; } = new List<VideoTimeRange>();

        /// <summary>
        /// The partition associated with the video
        /// </summary>
        public string? Partition { get; set; }

        /// <summary>
        /// The description of the video
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The privacy mode of the video (eg., Private, Public).
        /// </summary>
        public PrivacyMode PrivacyMode { get; set; }

        /// <summary>
        /// The state of the video (eg., Uploaded, Processing, Processed, Failed).
        /// </summary>
        public VideoState State { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoContract"/> class
        /// </summary>
        public VideoContract()
        {
            // Additional initialization logic can be added here if necessary
        }
    }
}
