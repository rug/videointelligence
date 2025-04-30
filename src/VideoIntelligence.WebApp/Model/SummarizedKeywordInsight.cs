namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SummarizedKeywordInsight
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsTranscript { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

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
