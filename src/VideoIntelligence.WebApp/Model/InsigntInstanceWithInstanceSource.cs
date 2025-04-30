using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents an insight instance with an associated source.
    /// </summary>
    public class InsigntInstanceWithInstanceSource : InsightInstance
    {
        /// <summary>
        /// The source of the insight instance
        /// </summary>
        public InstanceSource InstanceSource { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsightInstanceWithInstanceSource"/> class.
        /// </summary>
        public InsigntInstanceWithInstanceSource()
        {
            // Additional initialization logic can be added here if required.
        }
    }
}
