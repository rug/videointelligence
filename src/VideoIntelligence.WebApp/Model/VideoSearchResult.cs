namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents the result of a video search, including the list of results and pagination information
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Search-Videos&definition=VideoSearchResult">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public class VideoSearchResult
    {
        /// <summary>
        /// The list of video search result items
        /// </summary>
        public IList<VideoSearchResultItem> Results { get; set; } = new List<VideoSearchResultItem>();

        /// <summary>
        /// The pagination information for the next page of results
        /// </summary>
        public PagingInfo NextPage { get; set; } = new PagingInfo();

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoSearchResult"/> class.
        /// </summary>
        public VideoSearchResult()
        {
            // Additional initialization logic can be added here if necessary.
        }
    }
}
