namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents the response containing video frames and pagination information
    /// </summary> 
    public class VideoFramesResponse
    {
        /// <summary>
        /// The list of frame results in the response
        /// </summary>
        public List<FrameResult> Results { get; set; } = new List<FrameResult>();

        /// <summary>
        /// The pagination information for the next page of results
        /// </summary>
        public PagingInfo NextPage { get; set; } = new PagingInfo();
    }
}
