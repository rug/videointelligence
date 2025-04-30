namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class TextlessMaterialInsight
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FirstTextedShotId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int FirstTextlessShotId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int NumberOfShots { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public double Confidence { get; set; }
    }
}
