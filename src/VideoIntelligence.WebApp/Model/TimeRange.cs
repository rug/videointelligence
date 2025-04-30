namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents a time range with a start and end time.
    /// </summary>
    public class TimeRange
    {
        /// <summary>
        /// The start time of the range
        /// </summary>
        public TimeSpan Start { get; set; }

        /// <summary>
        /// The end time of the range.
        /// </summary>
        public TimeSpan End { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeRange"/> class.
        /// </summary>
        public TimeRange()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }

}
