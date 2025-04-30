using VideoIntelligence.WebApp.Models;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights extracted from a video, including metadata, transcript, and detected elements
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=VideoInsights">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class VideoInsights
    {
        /// <summary>
        /// The version of the insights
        /// </summary>
        public string? Version { get; set; }

        /// <summary>
        /// The duration of the video in a formatted string
        /// </summary>
        public string? Duration { get; set; }

        /// <summary>
        /// The source language of the video
        /// </summary>
        public string? SourceLanguage { get; set; }

        /// <summary>
        /// The array of source languages detected in the video
        /// </summary>
        public string[] SourceLanguages { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The primary language of the video
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// The array of languages detected in the video
        /// </summary>
        public string[] Languages { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The transcript lines extracted from the video
        /// </summary>
        public IList<TranscriptLineInsight> Transcript { get; set; } = new List<TranscriptLineInsight>();

        /// <summary>
        /// The full transcript text by concatenating all transcript lines
        /// </summary>
        public string TranscriptText
        {
            get
            {
                return string.Join(" ", Transcript.Select(t => t.Text).ToList());
            }
        }

        /// <summary>
        /// The OCR (Optical Character Recognition) insights from the video
        /// </summary>
        public IList<OcrInsight> Ocr { get; set; } = new List<OcrInsight>();

        /// <summary>
        /// The keywords detected in the video
        /// </summary>
        public IList<KeywordInsight> Keywords { get; set; } = new List<KeywordInsight>();

        /// <summary>
        /// The topics detected in the video
        /// </summary>
        public IList<TopicInsight> Topics { get; set; } = new List<TopicInsight>();

        /// <summary>
        /// The faces detected in the video
        /// </summary>
        public IList<FaceInsight> Faces { get; set; } = new List<FaceInsight>();

        /// <summary>
        /// The animated characters detected in the video
        /// </summary>
        public IList<AnimatedCharacterInsight> AnimatedCharacters { get; set; } = new List<AnimatedCharacterInsight>();

        /// <summary>
        /// The labels detected in the video
        /// </summary>
        public IList<LabelInsight> Labels { get; set; } = new List<LabelInsight>();

        /// <summary>
        /// The scenes detected in the video based on visual cues
        /// Scenes: A collection of related shots that depict a single event. 
        /// Scenes are determined by color coherence and semantic relationships between shots
        /// </summary>
        public IList<SceneInsight> Scenes { get; set; } = new List<SceneInsight>();

        /// <summary>
        /// The shots detected in the video.
        /// A sequence of frames captured by a single camera without interruption. 
        /// Azure Video Indexer detects shots based on visual transitions (abrupt or gradual changes)
        /// </summary>
        public IList<ShotInsight> Shots { get; set; } = new List<ShotInsight>();

        /// <summary>
        /// The brands detected in the video
        /// </summary>
        public IList<BrandInsight> Brands { get; set; } = new List<BrandInsight> { };

        /// <summary>
        /// The named locations detected in the video
        /// </summary>
        public IList<NamedLocation> NamedLocations { get; set; } = new List<NamedLocation> { };

        /// <summary>
        /// The named people detected in the video
        /// </summary>
        public IList<NamedPerson> NamedPeople { get; set; } = new List<NamedPerson> { };

        /// <summary>
        /// The audio effects detected in the video
        /// </summary>
        public IList<AudioEffectInsight> AudioEffects { get; set; } = new List<AudioEffectInsight> { };

        /// <summary>
        /// The observed people detected in the video
        /// </summary>
        public IList<ObservedPersonInsight> ObservedPeople { get; set; } = new List<ObservedPersonInsight> { };

        /// <summary>
        /// The objects detected in the video
        /// </summary>
        public IList<DetectedObjectInsight> DetectedObjects { get; set; } = new List<DetectedObjectInsight> { };

        /// <summary>
        /// The sentiments detected in the video
        /// </summary>
        public IList<SentimentInsight> Sentiments { get; set; } = new List<SentimentInsight> { };

        /// <summary>
        /// The emotions detected in the video
        /// </summary>
        public IList<EmotionInsight> Emotions { get; set; } = new List<EmotionInsight> { };

        /// <summary>
        /// The visual content moderation insights from the video
        /// </summary>
        public IList<VisualContentModerationInsight> VisualContentModeration { get; set; } = new List<VisualContentModerationInsight> { };

        /// <summary>
        /// The blocks detected in the video
        /// </summary>
        public IList<BlockInsight> Blocks { get; set; } = new List<BlockInsight> { };

        /// <summary>
        /// The frame patterns detected in the video
        /// </summary>
        public IList<FramePatternInsight> FramePatterns { get; set; } = new List<FramePatternInsight> { };

        /// <summary>
        /// The speakers detected in the video
        /// </summary>
        public IList<SpeakerInsight> Speakers { get; set; } = new List<SpeakerInsight> { };

        /// <summary>
        /// The clapperboards detected in the video
        /// </summary>
        public IList<ClapperboardInsight> Clapperboards { get; set; } = new List<ClapperboardInsight> { };

        /// <summary>
        /// The logos detected in the video
        /// </summary>
        public IList<LogoInsight> Logos { get; set; } = new List<LogoInsight> { };

        /// <summary>
        /// The textless material detected in the video
        /// </summary>
        public IList<TextlessMaterialInsight> TextlessMaterial { get; set; } = new List<TextlessMaterialInsight> { };

        /// <summary>
        /// The custom insights detected in the video
        /// </summary>
        public IList<CustomInsight> CustomInsights { get; set; } = new List<CustomInsight> { };

        /// <summary>
        /// The textual content moderation insights from the video
        /// </summary>
        public TextualContentModeration TextualContentModeration { get; set; } = new TextualContentModeration { };

        /// <summary>
        /// The statistics associated with the video insights
        /// </summary>
        public VideoInsightsStatistics Statistics { get; set; } = new VideoInsightsStatistics { };

        /// <summary>
        /// The confidence score for the source language detection
        /// </summary>
        public double SourceLanguageConfidence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoInsights"/> class.
        /// </summary>
        public VideoInsights()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
