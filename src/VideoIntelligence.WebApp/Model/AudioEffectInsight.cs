using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights for audio effects detected in a media file.
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=AudioEffectInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class AudioEffectInsight
    {
        /// <summary>
        /// The unique identifier for the audio effect insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances with confidence levels associated with the audio effect
        /// </summary>
        public IList<InsightInstanceWithConfidence> Instances { get; set; } = new List<InsightInstanceWithConfidence>();

        /// <summary>
        /// The type of audio effect detected
        /// </summary>
        public AudioEffectType Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioEffectInsight"/> class.
        /// </summary>
        public AudioEffectInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }

   
}
