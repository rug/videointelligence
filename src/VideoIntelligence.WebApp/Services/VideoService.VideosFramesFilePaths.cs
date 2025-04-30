using System.Reflection;
using VideoIntelligence.WebApp.Model;
using VideoIntelligence.WebApp.Utils;

namespace VideoIntelligence.WebApp.Services
{
    public partial class VideoService
    {
        /// <summary>
        /// Get sas urls of a video's frames which are extracted during indexing
        /// </summary> 
        /// <remarks>
        /// For more details, visit:
        /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Frames-File-Paths">Azure AI Video Indexer API Details</see>
        /// </remarks>
        /// <param name="videoId">The video id</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="videoId"/> is null or whitespace.</exception>
        public async Task<VideoFramesResponse?> GetFramesFilePathsAsync(string videoId, int skip = 0, int pageSize = 1000)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));

            VideoFramesResponse? videoFramesResponse = null;

            try
            {
                var queryParams = new Dictionary<string, string>() { 
                
                // [string]
                { "videoId", videoId },
                
                // [integer]
                { "urlsLifetimeSeconds", 86400.ToString() },

                // [integer] page size
                { "pageSize", pageSize.ToString() },

                    // [integer] The number of frames to skip
                { "skip", skip.ToString() }}.CreateQueryString();

                await EnsureTokenAsync();

                string requestUrl = $"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos/{videoId}/FramesFilePaths?{queryParams}";
                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string videoFramesResult = await response.Content.ReadAsStringAsync();
                    videoFramesResponse = JsonUtils.Deserialize<VideoFramesResponse>(videoFramesResult);
                    _logger.LogInformation($"Received data successfully processed.");
                }
                else
                {
                    _logger.LogError($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }

            return videoFramesResponse;
        }

        /// <summary>
        /// Get all Frames Paths
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="videoId"/> is null or whitespace.</exception>
        public async Task<VideoFramesResponse?> GetAllFramesFilePaths(string videoId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));

            VideoFramesResponse? framesFilePaths = null;
            try
            {
                framesFilePaths = await GetFramesFilePathsAsync(videoId);
                if (framesFilePaths == null)
                {
                    _logger.LogWarning($"{MethodBase.GetCurrentMethod()} no frames");
                    return framesFilePaths;
                }
                int skip = framesFilePaths.Results.Count;

                while (framesFilePaths?.NextPage.TotalCount > framesFilePaths?.Results.Count)
                {
                    VideoFramesResponse? nextPageResult = await GetFramesFilePathsAsync(videoId, skip);
                    if (nextPageResult?.Results.Count > 0)
                    {
                        skip += nextPageResult.Results.Count;
                        framesFilePaths.Results.AddRange(nextPageResult.Results);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }

            return framesFilePaths;
        }
    }
}
