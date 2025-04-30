using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents the progress state of a job, including its creation and update times, progress, type, and state.
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Job-Status&definition=JobProgressState">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class JobProgressState
    {
        /// <summary>
        /// The creation time of the job. 
        /// </summary>
        public string? CreationTime { get; set; }

        /// <summary>
        /// The last update time of the job. 
        /// </summary>
        public string? LastUpdateTime { get; set; }

        /// <summary>
        /// The progress of the job as a percentage
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// The type of job. 
        /// </summary>
        public string? JobType { get; set; } 

        /// <summary>
        /// The state of the video indexing job.
        /// </summary>
        public VideoIndexingJobState State { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobProgressState"/> class.
        /// </summary>
        public JobProgressState()
        {
            // Constructor logic can be added if required.
        }
    }

    

    
}
