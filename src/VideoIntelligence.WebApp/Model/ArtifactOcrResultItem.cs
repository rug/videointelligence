namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ArtifactOcrResultItem
    {
        
        /// <summary>
        /// 
        /// </summary>
        public ArtifactOcr Ocr { get; set; } = new ArtifactOcr();   

        /// <summary>
        /// 
        /// </summary>
        public int FrameIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FramesFilePath { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class ArtifactOcr
    {
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ContentWithNoWhiteSpace => Content.Replace("\n", "").Replace("\r", "").Replace(" ", "");
    }

    /// <summary>
    /// 
    /// </summary>
    public class ShotDetail
    {
        /// <summary>
        /// Ocr content
        /// </summary>
        public string Ocr { get; set; } = string.Empty;

        /// <summary>
        /// The start time of the frame
        /// </summary>
        public TimeSpan StartTime { get; set; } 

        /// <summary>
        /// The end time of the frame
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// The file path of the frame result.
        /// </summary>
        public string FilePath { get; set; } = string.Empty;
    }
}
