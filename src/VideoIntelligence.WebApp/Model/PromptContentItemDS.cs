namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents a section of prompt content with a unique identifier, time range, and associated frames
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Prompt-Ocr&definition=PromptContentItemDS">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class PromptContentItemDS
    {
        /// <summary>
        /// The unique identifier for the prompt content section
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The start time of the prompt content section
        /// </summary>
        public TimeSpan Start { get; set; }

        /// <summary>
        /// The end time of the prompt content section
        /// </summary>
        public TimeSpan End { get; set; }

        /// <summary>
        /// The textual content associated with the section
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// The list of frames associated with the section
        /// </summary>
        public string[] Frames { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PromptContentItemDS"/> class.
        /// </summary>
        public PromptContentItemDS()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
