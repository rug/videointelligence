using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights about shots detected in media content, including keyframes, tags, and associated instances
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=ShotInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class ShotInsight
    {
        /// <summary>
        /// The unique identifier for the shot insight
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// The list of keyframes associated with the shot
        /// </summary>
        public IList<KeyFrameInsight> KeyFrames { get; set; } = new List<KeyFrameInsight>();


        /// <summary>
        /// The tags describing the characteristics of the shot
        /// </summary>
        public ShotTag[] Tags { get; set; } = Array.Empty<ShotTag>();

        /// <summary>
        /// The list of instances associated with the shot insight
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ShotInsight"/> class.
        /// </summary>
        public ShotInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
