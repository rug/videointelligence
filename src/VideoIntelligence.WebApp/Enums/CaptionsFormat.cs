namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the formats supported for captions in media content.
    /// </summary>
    public enum CaptionsFormat
    {
        /// <summary>
        /// Represents captions in VTT (WebVTT) format
        /// </summary>
        Vtt,

        /// <summary>
        /// Represents captions in TTML (Timed Text Markup Language) format
        /// </summary>
        Ttml,

        /// <summary>
        /// Represents captions in SRT (SubRip Text) format
        /// </summary>
        Srt,

        /// <summary>
        /// Represents captions in plain text (TXT) format
        /// </summary>
        Txt,

        /// <summary>
        /// Represents captions in CSV (Comma-Separated Values) format
        /// </summary>
        Csv
    }
}
