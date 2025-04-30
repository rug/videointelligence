namespace VideoIntelligence.WebApp.Model
{

    /// <summary>
    /// 
    /// </summary>
    public class SummarizedKeywordTopicInsight
    {
        /// <summary>
        /// 
        /// </summary>
        public string ReferenceUrl { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string IptcName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string IabName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public IList<SummarizedAppearanceInsight> Appearances { get; set; } = new List<SummarizedAppearanceInsight>();

    }
}
