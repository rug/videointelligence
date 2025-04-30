using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents the index of a video, including metadata, insights, and processing details
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=VideoIndex">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class VideoIndex
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
        /// The privacy mode of the video
        /// </summary>
        public PrivacyMode PrivacyMode { get; set; }

        /// <summary>
        /// The processing progress of the video
        /// </summary>
        public string? ProcessingProgress { get; set; }

        /// <summary>
        /// The failure message, if any, for the video processing
        /// </summary>
        public string? FailureMessage { get; set; }

        /// <summary>
        /// The failure code for the video processing
        /// </summary>
        public FailureCode FailureCode { get; set; }

        /// <summary>
        /// The external ID associated with the video
        /// </summary>
        public string? ExternalId { get; set; }

        /// <summary>
        /// The external URL associated with the video
        /// </summary>
        public string? ExternalUrl { get; set; }

        /// <summary>
        /// The metadata associated with the video
        /// </summary>
        public string? Metadata { get; set; }

        /// <summary>
        /// The insights associated with the video
        /// </summary>
        public VideoInsights Insights { get; set; } = new VideoInsights();

        /// <summary>
        /// The thumbnail ID associated with the video
        /// </summary>
        public string? ThumbnailId { get; set; }

        /// <summary>
        /// The width of the video
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the video
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The published URL of the video
        /// </summary>
        public string? PublishedUrl { get; set; }

        /// <summary>
        /// The published proxy URL of the video
        /// </summary>
        public string? PublishedProxyUrl { get; set; }

        /// <summary>
        /// A value indicating whether the source language should be detected
        /// </summary>
        public bool DetectSourceLanguage { get; set; }

        /// <summary>
        /// The mode for automatic language detection
        /// </summary>
        public LanguageAutoDetectMode LanguageAutoDetectMode { get; set; }

        /// <summary>
        /// The source language of the video
        /// </summary>
        public string? SourceLanguage { get; set; }

        /// <summary>
        /// The array of source languages for the video
        /// </summary>
        public string[] SourceLanguages { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The language of the video
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// The array of languages for the video
        /// </summary>
        public string[] Languages { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The indexing preset for the video
        /// </summary>
        public string? IndexingPreset { get; set; }

        /// <summary>
        /// The streaming preset for the video
        /// </summary>
        public string? StreamingPreset { get; set; }

        /// <summary>
        /// The linguistic model ID associated with the video
        /// </summary>
        public string? LinguisticModelId { get; set; }

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
        /// A value indicating whether the video contains adult content
        /// </summary>
        public bool IsAdult { get; set; }

        /// <summary>
        /// The array of excluded AI features for the video
        /// </summary>
        public ExcludedAI[] ExcludedAIs { get; set; } = Array.Empty<ExcludedAI>();

        /// <summary>
        /// The view token for the video
        /// </summary>
        public string? ViewToken { get; set; }

        /// <summary>
        /// A value indicating whether the video is searchable
        /// </summary>
        public bool IsSearchable { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoIndex"/> class
        /// </summary>
        public VideoIndex()
        {
            // Additional initialization logic can be added here if necessary
        }
    }
}
