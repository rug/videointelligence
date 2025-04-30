namespace VideoIntelligence.WebApp.Model
{
    public class ArtifactOcrResult
    {
        /// <summary>
        /// The list of ocr result items
        /// </summary>
        public IList<ArtifactOcrResultItem> Results { get; set; } = new List<ArtifactOcrResultItem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoSearchResult"/> class.
        /// </summary>
        public ArtifactOcrResult()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
