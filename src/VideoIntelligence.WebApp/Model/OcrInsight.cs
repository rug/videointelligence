namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents insights for OCR (Optical Character Recognition) detected in media content
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=OcrInsight">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class OcrInsight
    {
        /// <summary>
        /// The unique identifier for the OCR insight
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The text content extracted through OCR
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// The language of the extracted text
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// The confidence score for the OCR detection, ranging between 0 and 1
        /// </summary>
        public double Confidence;

        /// <summary>
        /// The left coordinate of the detected text area
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// The top coordinate of the detected text area
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// The width of the detected text area
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the detected text area
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The angle of rotation for the detected text area
        /// </summary>
        public int Angle { get; set; }

        /// <summary>
        /// The list of instances associated with the OCR detection
        /// </summary>
        public IList<InsightInstance> Instances { get; set; } = new List<InsightInstance>();

        /// <summary>
        /// Initializes a new instance of the <see cref="OcrInsight"/> class.
        /// </summary>
        public OcrInsight()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
