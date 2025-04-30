using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class AOAITextualSummarizationJobContract
    {

        /// <summary>
        /// A unique identifier (GUID) for the job.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The account identifier (GUID).
        /// </summary>
        public string AccountId { get; set; } = string.Empty;

        /// <summary>
        /// The video identifier.
        /// </summary>
        public string VideoId { get; set; } = string.Empty;

        /// <summary>
        /// The state of the video indexing job.
        /// </summary>
        public VideoIndexingJobState State { get; set; }

        /// <summary>
        /// The model name used for the job.
        /// </summary>
        public string ModelName { get; set; } = string.Empty;

        /// <summary>
        /// The style of the summary.
        /// </summary>
        public SummaryStyle SummaryStyle { get; set; }

        /// <summary>
        /// The length of the summary.
        /// </summary>
        public SummaryLength SummaryLength { get; set; }

        /// <summary>
        /// Specifies which frames to include.
        /// </summary>
        public IncludedFrames IncludedFrames { get; set; }

        /// <summary>
        /// The creation time in a date-time format.
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// The last update time in a date-time format.
        /// </summary>
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// A message indicating any failure that occurred.
        /// </summary>
        public string FailureMessage { get; set; } = string.Empty;

        /// <summary>
        /// The progress of the job represented as an integer (int32).
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// The deployment name associated with the job.
        /// </summary>
        public string DeploymentName { get; set; } = string.Empty;

        /// <summary>
        /// The disclaimer message.
        /// </summary>
        public string Disclaimer { get; set; } = string.Empty;
    }

   
    /// <summary>
    /// The style of the summary. 
    /// </summary>
    public enum SummaryStyle
    {
        Neutral = 0,
        Casual = 1,
        Formal = 2
    }

    /// <summary>
    ///  The length of the summary. 
    /// </summary>
    public enum SummaryLength
    {
        Medium = 0,
        Short = 1,
        Long = 2
    }

    /// <summary>
    /// Which frames to include when generating the summary. 
    /// </summary>
    public enum IncludedFrames
    {
        None = 0,
        Keyframes = 1
    }
}
