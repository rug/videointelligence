namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Enum representing the artifact types in Video Indexer.
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Artifact-Download-Url">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum ArtifactType
    {
        /// <summary>
        /// Optical Character Recognition (OCR) artifacts to extract text from video frames.
        /// </summary>
        Ocr,

        /// <summary>
        /// Detected faces in the video frames.
        /// </summary>
        Faces,

        /// <summary>
        /// Thumbnails of detected faces in the video.
        /// </summary>
        FacesThumbnails,

        /// <summary>
        /// Results from visual content moderation.
        /// </summary>
        VisualContentModeration,

        /// <summary>
        /// Thumbnails of keyframes in the video.
        /// </summary>
        KeyframesThumbnails,

        /// <summary>
        /// Analysis of emotions shown in the video.
        /// </summary>
        Emotions,

        /// <summary>
        /// Results from textual content moderation of subtitles or transcripts.
        /// </summary>
        TextualContentModeration,

        /// <summary>
        /// Detected audio effects in the video.
        /// </summary>
        AudioEffects,

        /// <summary>
        /// Observed people and their presence in the video.
        /// </summary>
        ObservedPeople,

        /// <summary>
        /// Labels describing objects or concepts detected in the video.
        /// </summary>
        Labels,

        /// <summary>
        /// Transcript of spoken words in the video.
        /// </summary>
        Transcript,

        /// <summary>
        /// Featured clothing detected in the video frames.
        /// </summary>
        FeaturedClothing,

        /// <summary>
        /// Detected clapperboards (used in filmmaking) in the video.
        /// </summary>
        Clapperboards,

        /// <summary>
        /// Detected digital patterns in the video content.
        /// </summary>
        DigitalPatterns,

        /// <summary>
        /// Material that appears without any textual content.
        /// </summary>
        TextlessMaterial,

        /// <summary>
        /// Logos detected in the video frames.
        /// </summary>
        Logos,

        /// <summary>
        /// Objects detected in the video frames.
        /// </summary>
        DetectedObjects
    }

}
