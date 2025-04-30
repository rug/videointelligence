namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents an insight instance with an associated confidence score
    /// </summary>
    public class InsightInstanceWithConfidence : InsightInstance
    {
        /// <summary>
        /// The confidence score for the object detection, ranging between 0 and 1
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsightInstanceWithConfidence"/> class.
        /// </summary>
        public InsightInstanceWithConfidence()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
