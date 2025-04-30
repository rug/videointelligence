namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents each individual frame result
    /// </summary>
    public class FrameResult
    {
        /// <summary>
        /// The name associated with the frame result
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The index of the frame within the sequence
        /// </summary>
        public int FrameIndex { get; set; }

        /// <summary>
        /// The start time of the frame
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// The end time of the frame
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// The file path of the frame result.
        /// </summary>
        public string FilePath { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameResult"/> class.
        /// </summary>
        public FrameResult()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
