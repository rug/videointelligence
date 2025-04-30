namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents statistics related to speaker activities within a video
    /// </summary> 
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=VideoInsightsStatistics">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class VideoInsightsStatistics
    {
        /// <summary>
        /// 
        /// </summary>
        public int CorrespondenceCount { get; set; }

        /// <summary>
        /// The ratio of speaker talk-to-listen activities, mapped by speaker ID
        /// </summary>
        public Dictionary<int, double> SpeakerTalkToListenRatio { get; set; } = new Dictionary<int, double>();

        /// <summary>
        /// The longest monolog duration for each speaker, mapped by speaker ID
        /// </summary>
        public Dictionary<int, int> SpeakerLongestMonolog { get; set; } = new Dictionary<int, int>();

        /// <summary>
        /// The number of fragments spoken by each speaker, mapped by speaker ID
        /// </summary>
        public Dictionary<int, int> SpeakerNumberOfFragments { get; set; } = new Dictionary<int, int>();

        /// <summary>
        /// The word count for each speaker, mapped by speaker ID.
        /// </summary>
        public Dictionary<int, int> SpeakerWordCount { get; set; } = new Dictionary<int, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoInsightsStatistics"/> class.
        /// </summary>
        public VideoInsightsStatistics()
        {
            // Additional initialization logic, if necessary.
        }
    }
}
