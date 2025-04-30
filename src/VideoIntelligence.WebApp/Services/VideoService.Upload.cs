using VideoIntelligence.WebApp.Enums;
using VideoIntelligence.WebApp.Model;
using VideoIntelligence.WebApp.Utils;

namespace VideoIntelligence.WebApp.Services
{
    public partial class VideoService
    {
        /// <summary>
		/// Uploads the given video, starts indexing it and returns a new Video id
		/// </summary>
		/// <param name="videoUrl">Upload and index the video from URL - this is best practice and very robust compared to uploading a video from local file.
		/// The video URL, MUST BE HTTPS</param>
		/// <returns>returns a new Video id</returns>
		public async Task<string> FileUploadAsync(byte[] content, string fileName, string contentType = "")
        {
            
            string newVideoId = "";

            try
            {
                await EnsureTokenAsync();
                
                //Build Query Parameter Dictionary
                var queryDictionary = new Dictionary<string, string>
                {
                    // [string] The video name
                    { "name", Guid.NewGuid().ToString() },
                    
                    // [string] The video description.
                    //{ "description", Uri.EscapeDataString("video description") },

                    // [string] The video privacy mode. Allowed values: Private / Public
                    { "privacy", PrivacyMode.Private.ToString() },
                   
                    // [string] Index priority, can be used in paid regions only. Allowed values: Low / Normal / High
                    //{ "priority" , "Low" },

                    // [string] Format - uri. A public url of the video/audio file(url encoded).
                    // It is recommended to use readonly urls (e.g.when using Azure Storage SAS urls).
                    // If not specified, the file should be passed as a multipart/form body content.
                    { "videoUrl" , "" }
                };

                var multipartContent = new MultipartFormDataContent();
                
                // Create a MemoryStream from the byte array.
                using var memoryStream = new MemoryStream(content);

                // Create StreamContent using the MemoryStream.
                using var streamContent = new StreamContent(memoryStream);
  
                multipartContent.Add(streamContent, "fileName", Guid.NewGuid().ToString());

                var queryParams = queryDictionary.CreateQueryString();
                string url = $"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos?{queryParams}";
                HttpResponseMessage response = await _httpClient.PostAsync(url, multipartContent);

                if (response.IsSuccessStatusCode)
                {
                    var uploadResult = await response.Content.ReadAsStringAsync();
                    // Get the video ID from the upload result
                    newVideoId = JsonUtils.Deserialize<VideoContract?>(uploadResult)?.Id ?? "";
                    _logger.LogInformation($"Video ID {newVideoId} was uploaded successfully");

                    await WaitForIndexAsync(newVideoId);

                    await _blobService.UploadBlobAsync(newVideoId, content, contentType);
                    _logger.LogInformation($"Video ID {newVideoId} was uploaded successfully on azure store");
                }
                else
                {
                    _logger.LogError($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} StackTrace: {ex.StackTrace}");
            }


            return newVideoId;
        }

        /// <summary>
        /// https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Upload-Video
        /// </summary>
        /// <param name="videoUrl"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task<VideoContract?> UploadUrlAsync(string videoUrl)
        {
            if (string.IsNullOrWhiteSpace(videoUrl))
            {
                throw new ArgumentNullException(nameof(videoUrl));
            }
            if (!Uri.IsWellFormedUriString(videoUrl, UriKind.Absolute))
            {
                throw new ArgumentException("VideoUrl is not valid");
            }

            VideoContract? videoContract = null;

            try
            {
                await EnsureTokenAsync();
                //Build Query Parameter Dictionary
                var queryDictionary = new Dictionary<string, string>
                {
                    // [string] The video name
                    { "name", Guid.NewGuid().ToString() },
                    
                    // [string] The video description.
                    //{ "description", Uri.EscapeDataString("video description") },

                    // [string] The video privacy mode. Allowed values: Private / Public
                    { "privacy", PrivacyMode.Private.ToString() },
                   
                    // [string] Index priority, can be used in paid regions only. Allowed values: Low / Normal / High
                    //{ "priority" , "Low" },

                    // [string] Format - uri. A public url of the video/audio file(url encoded).
                    // It is recommended to use readonly urls (e.g.when using Azure Storage SAS urls).
                    // If not specified, the file should be passed as a multipart/form body content.
                    //{ "videoUrl" , Uri.EscapeDataString(videoUrl) }
                    { "videoUrl" , videoUrl }
                };

                var queryParams = queryDictionary.CreateQueryString();

                string url = $"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos?{queryParams}";
                HttpClientUtils.AddClientRequestIdHeader(_httpClient);
                HttpResponseMessage response = await _httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    var uploadResult = await response.Content.ReadAsStringAsync();

                    // Get the video ID from the upload result
                    videoContract = JsonUtils.Deserialize<VideoContract?>(uploadResult);
                    if (videoContract != null)
                    {
                        _logger.LogInformation($"Video ID {videoContract.Id} was uploaded successfully");
                        await WaitForIndexAsync(videoContract.Id);

                        await _blobService.UploadBlobFromUrlAsync(videoUrl, videoContract.Id);
                        _logger.LogInformation($"Video ID {videoContract.Id} was uploaded successfully on azure store");

                    }
                    else
                    {
                        _logger.LogWarning($"videoContract is empty!!!");
                    }
                }
                else
                {
                    Console.WriteLine($"Error Status Code: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} StackTrace: {ex.StackTrace}");
            }

            return videoContract;
        }
    }
}
