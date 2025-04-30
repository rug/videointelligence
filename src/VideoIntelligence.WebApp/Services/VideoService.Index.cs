using VideoIntelligence.WebApp.Enums;
using VideoIntelligence.WebApp.Model;
using VideoIntelligence.WebApp.Utils;

namespace VideoIntelligence.WebApp.Services
{
    public partial class VideoService
    {
        /// <summary>
        /// Retrieves the video indexing details from the Video Indexer API for a specified video
        /// </summary>
        /// <param name="videoId">A string representing the unique identifier of the video</param>
        /// <returns>An asynchronous <see cref="Task{VideoContract?}"/> that returns a <see cref="VideoContract"/> object containing
        /// video indexing information if the API call is successful; otherwise, it returns <c>null</c>
        /// <exception cref="ArgumentException">Thrown when <paramref name="videoId"/> is null or whitespace.</exception>
        /// <remarks>
        /// For more details, visit:
        /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index">Azure AI Video Indexer API Details</see>
        /// </remarks>
        public async Task<VideoContract?> GetVideoIndexAsync(string videoId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));

            VideoContract? videoContract = null;

            try
            {
                await EnsureTokenAsync();
                // Build a dictionary of query parameters to configure the API request. These parameters will be appended to the request URL
                var queryParams = new Dictionary<string, string>()
                {
                    // Specifies the language used for translating video insights
                    {"language", "English"},

                    // Option to force re-translation of video insights.
                    // Uncomment the following line to enable re-translation
                    //{ "reTranslate", "true"},

                    // Specifies whether to include streaming URLs in the video index.
                    {"includeStreamingUrls", "true"},

                    // Insights to include in the response. For example, to include only Transcript and Faces in the insights,
                    // pass the value 'Transcript,Faces'. Only array fields under the insights element are supported.
                    // An empty value will include all insights.
                    // Options are: AudioEffects, Blocks, Brands, Clapperboards, CustomInsights, DetectedObjects,
                    // Emotions, Faces, FramePatterns, Keywords, Labels, Logos, NamedLocations, NamedPeople,
                    // ObservedPeople, Ocr, Scenes, Sentiments, Shots, Speakers, TextlessMaterial, Topics, Transcript, VisualContentModeration. 
                    {"includedInsights", ""},

                    // Insights to exclude from the response. For example, to get all insights except Transcript and Faces,
                    // pass the value 'Transcript,Faces'. Only array fields under the insights element are supported.
                    // An empty value will exclude no insight. This query parameter cannot be provided if the 'includeInsights' parameter is provided.
                    // Options are: AudioEffects, Blocks, Brands, Clapperboards, CustomInsights, DetectedObjects,
                    // Emotions, Faces, FramePatterns, Keywords, Labels, Logos, NamedLocations, NamedPeople,
                    // ObservedPeople, Ocr, Scenes, Sentiments, Shots, Speakers, TextlessMaterial, Topics, Transcript, VisualContentModeration.
                    //{"excludedInsights", ""},

                    // Indicates whether to include the deprecated SummarizedInsights field.
                    // Passing 'false' is recommended.
                    {"includeSummarizedInsights", "false"},
                }.CreateQueryString();

                string requestUrl = $"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos/{videoId}/Index?{queryParams}";

                HttpClientUtils.AddClientRequestIdHeader(_httpClient);
                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string videoIndexResult = await response.Content.ReadAsStringAsync();
                    videoContract = JsonUtils.Deserialize<VideoContract>(videoIndexResult);
                    _logger.LogInformation($"Video index data successfully processed.");
                }
                else
                {
                    _logger.LogError($"Video Id:{videoId} Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Video Id:{videoId} Error Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }

            return videoContract;
        }

        /// <summary>
        /// Asynchronously polls the Video Indexer API until the indexing process for the specified video completes.
        /// The method continuously sends requests to check the indexing state. When the video is processed,
        /// it logs the full JSON result and exits the loop. If the video indexing fails, an exception is thrown.
        /// </summary>
        /// <param name="videoId">A unique identifier for the video whose indexing status is being monitored.</param>
        /// <returns> Prints video index when the index is complete, otherwise throws exception </returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="videoId"/> is null or whitespace.</exception>
        /// <remarks>
        /// For more details, visit:
        /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index">Azure AI Video Indexer API Details</see>
        /// </remarks>
        private async Task WaitForIndexAsync(string videoId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));

            _logger.LogInformation($"Waiting for video {videoId} to finish indexing.");

            try
            {
                // Poll indefinitely until the video indexing process finishes or fails
                while (true)
                {
                    await EnsureTokenAsync();
                    var queryParams = new Dictionary<string, string>()
                    {
                        {"language", "English"}
                    }.CreateQueryString();

                    var requestUrl = $"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos/{videoId}/Index?{queryParams}";
                    HttpClientUtils.AddClientRequestIdHeader(_httpClient);
                    HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string videoIndexResult = await response.Content.ReadAsStringAsync();
                        VideoContract? videoContract = JsonUtils.Deserialize<VideoContract?>(videoIndexResult);
                        if (videoContract != null)
                        {
                            // If job is finished
                            if (videoContract.State == VideoState.Processed)
                            {
                                _logger.LogError($"The video index has completed. Here is the full JSON of the index for video ID {videoId}: \n{videoIndexResult}");
                                return;
                            }
                            else if (videoContract.State == VideoState.Failed)
                            {
                                _logger.LogError($"The video index failed for video ID {videoId}");
                                throw new Exception(videoIndexResult);
                            }
                            // Job hasn't finished
                            _logger.LogInformation($"The video index state is {videoContract.State} Progress: {videoContract.Videos?.FirstOrDefault()?.ProcessingProgress}");
                            await Task.Delay(_pollingInteval);
                        }
                        else
                        {
                            _logger.LogError($"VideoContract is NULL {videoId}");
                        }

                    }
                    else
                    {
                        _logger.LogError($"Error Status Code: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }
        }
    }
}
