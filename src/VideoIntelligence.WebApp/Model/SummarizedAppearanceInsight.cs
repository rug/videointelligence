namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents summarized appearance insights detected in media content, including time range and duration in seconds
    /// </summary>
    public class SummarizedAppearanceInsight
    {
        /// <summary>
        /// The start time of the appearance insight
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// The end time of the appearance insight
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// The start time of the appearance insight in seconds
        /// </summary>
        public double StartSeconds { get; set; }

        /// <summary>
        /// The end time of the appearance insight in seconds
        /// </summary>
        public double EndSeconds { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummarizedAppearanceInsight"/> class.
        /// </summary>
        public SummarizedAppearanceInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
