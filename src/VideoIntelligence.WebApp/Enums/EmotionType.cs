namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the types of emotions that can be detected
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=EmotionType">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum EmotionType
    {
        /// <summary>
        /// Indicates the emotion of anger.
        /// </summary>
        Anger,

        /// <summary>
        /// Indicates the emotion of fear.
        /// </summary>
        Fear,

        /// <summary>
        /// Indicates the emotion of joy or happiness.
        /// </summary>
        Joy,

        /// <summary>
        /// Indicates a neutral or emotionless state.
        /// </summary>
        Neutral,

        /// <summary>
        /// Indicates the emotion of sadness.
        /// </summary>
        Sad
    }
}
