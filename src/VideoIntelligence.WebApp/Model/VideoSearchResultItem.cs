using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents an item in the video search results, including metadata, insights, and processing details
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Search-Videos&definition=VideoSearchResultItem">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class VideoSearchResultItem
    {
        /// <summary>
        /// The account ID associated with the video
        /// </summary>
        public string? AccountId { get; set; }

        /// <summary>
        /// The unique identifier for the video
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// The partition associated with the video
        /// </summary>
        public string? Partition { get; set; }

        /// <summary>
        /// The external ID associated with the video
        /// </summary>
        public string? ExternalId { get; set; }

        /// <summary>
        /// The metadata associated with the video
        /// </summary>
        public string? Metadata { get; set; }

        /// <summary>
        /// The name of the video
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description of the video
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The creation date of the video
        /// </summary>
        public string? Created { get; set; }

        /// <summary>
        /// The last modified date of the video
        /// </summary>
        public string? LastModified { get; set; }

        /// <summary>
        /// The last indexed date of the video
        /// </summary>
        public string? LastIndexed { get; set; }

        /// <summary>
        /// The privacy mode of the video
        /// </summary>
        public PrivacyMode PrivacyMode { get; set; }

        /// <summary>
        /// The username of the video owner
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// A value indicating whether the video is owned by the user
        /// </summary>
        public bool IsOwned { get; set; }

        /// <summary>
        /// A value indicating whether the video is a base video
        /// </summary>
        public bool IsBase { get; set; }

        /// <summary>
        /// A value indicating whether the video has a source video file
        /// </summary>
        public bool HasSourceVideoFile { get; set; }

        /// <summary>
        /// The state of the video
        /// </summary>
        public VideoState State { get; set; }

        /// <summary>
        /// The moderation state of the video
        /// </summary>
        public ModerationState ModerationState { get; set; }

        /// <summary>
        /// The review state of the video
        /// </summary>
        public ReviewState ReviewState { get; set; }

        /// <summary>
        /// A value indicating whether the video is searchable
        /// </summary>
        public bool IsSearchable { get; set; }

        /// <summary>
        /// The processing progress of the video
        /// </summary>
        public string? ProcessingProgress { get; set; }

        /// <summary>
        /// The duration of the video in seconds
        /// </summary>
        public int DurationInSeconds { get; set; }

        /// <summary>
        /// The thumbnail video ID associated with the video
        /// </summary>
        public string? ThumbnailVideoId { get; set; }

        /// <summary>
        /// The thumbnail ID associated with the video
        /// </summary>
        public string? ThumbnailId { get; set; }

        /// <summary>
        /// The list of search matches found in the video
        /// </summary>
        public IList<VideoSearchMatch> SearchMatches { get; set; } = new List<VideoSearchMatch>();

        /// <summary>
        /// The indexing preset for the video
        /// </summary>
        public string? IndexingPreset { get; set; }

        /// <summary>
        /// The streaming preset for the video
        /// </summary>
        public string? StreamingPreset { get; set; }

        /// <summary>
        /// The source language of the video
        /// </summary>
        public string? SourceLanguage { get; set; }

        /// <summary>
        /// The array of source languages detected in the video
        /// </summary>
        public string[] SourceLanguages { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The person model ID associated with the video
        /// </summary>
        public string? PersonModelId { get; set; }

        /// <summary>
        /// The animation model ID associated with the video
        /// </summary>
        public string? AnimationModelId { get; set; }

        /// <summary>
        /// The logo group ID associated with the video
        /// </summary>
        public string? LogoGroupId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoSearchResultItem"/> class.
        /// </summary>
        public VideoSearchResultItem()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
