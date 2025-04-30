namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class TextualContentModeration
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();
        
        /// <summary>
        /// 
        /// </summary>
        public int BannedWordsCount { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public double BannedWordsRatio { get; set; }
    }
}
