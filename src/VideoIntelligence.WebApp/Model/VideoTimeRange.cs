namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents a time range associated with a specific video
    /// </summary>
    public class VideoTimeRange
    {
        /// <summary>
        /// The unique identifier for the video
        /// </summary>
        public string? VideoId { get; set; }

        /// <summary>
        /// The time range for the video
        /// </summary>
        public TimeRange Range { get; set; } = new TimeRange();

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoTimeRange"/> class.
        /// </summary>
        public VideoTimeRange()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
