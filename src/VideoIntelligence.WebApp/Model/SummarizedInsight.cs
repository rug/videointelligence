using VideoIntelligence.WebApp.Enums;

namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SummarizedInsight
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public PrivacyMode PrivacyMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SummarizedDurationInsight Duration { get; set; } = new SummarizedDurationInsight();

        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailVideoId { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailId { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public IList<SummarizedKeywordInsight> Keywords { get; set; } = new List<SummarizedKeywordInsight>();

        /// <summary>
        /// 
        /// </summary>
        public IList<SummarizedKeywordTopicInsight> Topics { get; set; } = new List<SummarizedKeywordTopicInsight>();
    }
}
