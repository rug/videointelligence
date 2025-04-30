namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights related to visual content moderation, including scores for adult and racy content
    /// </summary>
    public class VisualContentModerationInsight
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the visual content moderation insight
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// The score indicating the likelihood of adult content in the video
        /// </summary>
        public double AdultScore { get; set; }

        /// <summary>
        /// The score indicating the likelihood of racy content in the video
        /// </summary>
        public double RacyScore { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualContentModerationInsight"/> class.
        /// </summary>
        public VisualContentModerationInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
