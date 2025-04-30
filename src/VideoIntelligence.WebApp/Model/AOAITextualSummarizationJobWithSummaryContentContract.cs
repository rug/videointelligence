namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class AOAITextualSummarizationJobWithSummaryContentContract : AOAITextualSummarizationJobContract
    {
        /// <summary>
        /// 
        /// </summary>
        public string Summary { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string SensitiveContentPercent { get; set; } = string.Empty;
    }
}
