using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights about topics detected in media content, including metadata, references, and confidence scores
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=TopicInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class TopicInsight
    {
        /// <summary>
        /// The language of the topic insight
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// The unique identifier for the topic insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The list of instances associated with the topic insight
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// The name of the topic
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The reference ID for the topic
        /// </summary>
        public string? ReferenceId { get; set; }

        /// <summary>
        /// The full name of the topic
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// The reference URL providing additional information about the topic
        /// </summary>
        public string? ReferenceUrl { get; set; }

        /// <summary>
        /// The type of reference for the topic
        /// </summary>
        public TopicReferenceType ReferenceType { get; set; }

        /// <summary>
        /// The IPTC name associated with the topic
        /// </summary>
        public string? IptcName { get; set; }

        /// <summary>
        /// The IAB name associated with the topic
        /// </summary>
        public string? IabName { get; set; }


        /// <summary>
        /// The confidence score for the topic detection, ranging between 0 and 1
        /// </summary>
        public double Confidence { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TopicInsight"/> class.
        /// </summary>
        public TopicInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }

    }

   
}
