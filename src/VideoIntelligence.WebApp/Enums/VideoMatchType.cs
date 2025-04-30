namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the types of matches that can be detected in media content.
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Search-Videos&definition=MatchType">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum VideoMatchType
    {
        /// <summary>
        /// Represents a match found in the transcript
        /// </summary>
        Transcript,

        /// <summary>
        /// Represents a match found in the topics
        /// </summary>
        Topic,

        /// <summary>
        /// Represents a match found through Optical Character Recognition (OCR)
        /// </summary>
        Ocr,

        /// <summary>
        /// Represents a match found in annotations
        /// </summary>
        Annotations,

        /// <summary>
        /// Represents a match found in detected objects
        /// </summary>
        DetectedObjects,

        /// <summary>
        /// Represents a match found in the title
        /// </summary>
        Title,

        /// <summary>
        /// Represents a match found in the description
        /// </summary>
        Description,

        /// <summary>
        /// Represents a match found in faces detected in the media
        /// </summary>
        Face,

        /// <summary>
        /// Represents a match found in the owner information
        /// </summary>
        Owner,

        /// <summary>
        /// Represents a match found in brands detected in the media
        /// </summary>
        Brand,

        /// <summary>
        /// Represents a match found in named locations
        /// </summary>
        NamedLocation,

        /// <summary>
        /// Represents a match found in named persons
        /// </summary>
        NamedPerson,

        /// <summary>
        /// Represents a match found in animated characters
        /// </summary>
        AnimatedCharacters,

        /// <summary>
        /// Represents a match found in metadata
        /// </summary>
        Metadata,

        /// <summary>
        /// Represents a match found in custom insights
        /// </summary>
        CustomInsights
    }

}
