namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents the contract for prompt content, including partition, name, and associated sections
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Prompt-Ocr&definition=PromptContentContract">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class PromptContentContract
    {
        /// <summary>
        /// The partition associated with the prompt content
        /// </summary>
        public string? Partition { get; set; }

        /// <summary>
        /// The name of the prompt content
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The list of sections associated with the prompt content
        /// </summary>
        public IList<PromptContentItemDS> Sections { get; set; } = new List<PromptContentItemDS>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PromptContentContract"/> class.
        /// </summary>
        public PromptContentContract()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
