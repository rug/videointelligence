namespace VideoIntelligence.WebApp.Enums
{

    /// <summary>
    /// Defines the AI features that can be excluded during processing
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=ExcludedAI">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum ExcludedAI
    {
        /// <summary>
        /// Excludes face detection
        /// </summary>
        Faces,

        /// <summary>
        /// Excludes observed people detection
        /// </summary>
        ObservedPeople,

        /// <summary>
        /// Excludes emotion detection
        /// </summary>
        Emotions,

        /// <summary>
        /// Excludes label detection
        /// </summary>
        Labels,

        /// <summary>
        /// Excludes rolling credits detection
        /// </summary>
        RollingCredits,

        /// <summary>
        /// Excludes detected objects
        /// </summary>
        DetectedObjects,

        /// <summary>
        /// Excludes celebrity detection
        /// </summary>
        Celebrities,

        /// <summary>
        /// Excludes known people detection
        /// </summary>
        KnownPeople,

        /// <summary>
        /// Excludes OCR (Optical Character Recognition).
        /// </summary>
        OCR,

        /// <summary>
        /// Excludes clapperboard detection
        /// </summary>
        Clapperboard,

        /// <summary>
        /// Excludes logo detection
        /// </summary>
        Logos,

        /// <summary>
        /// Excludes speaker detection
        /// </summary>
        Speakers,

        /// <summary>
        /// Excludes topic detection
        /// </summary>
        Topics,

        /// <summary>
        /// Excludes keyword detection
        /// </summary>
        Keywords,

        /// <summary>
        /// Excludes entity detection
        /// </summary>
        Entities,

        /// <summary>
        /// Excludes featured clothing detection
        /// </summary>
        FeaturedClothing,

        /// <summary>
        /// Excludes matched person detection
        /// </summary>
        MatchedPerson,

        /// <summary>
        /// Excludes shot type detection
        /// </summary>
        ShotType,

        /// <summary>
        /// Excludes people-detected clothing detection
        /// </summary>
        PeopleDetectedClothing
    }
}
