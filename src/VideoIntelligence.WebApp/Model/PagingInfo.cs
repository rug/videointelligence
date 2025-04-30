namespace VideoIntelligence.WebApp.Model
{
    /// <summary>
    /// Represents pagination information for managing data retrieval
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// The number of items per page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The number of items to skip
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// A value indicating whether the pagination process is complete
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// The total count of items
        /// </summary>
        public int TotalCount { get; set; }
    }
}
