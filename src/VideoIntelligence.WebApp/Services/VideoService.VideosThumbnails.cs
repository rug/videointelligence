using VideoIntelligence.WebApp.Enums;
using VideoIntelligence.WebApp.Model;

namespace VideoIntelligence.WebApp.Services
{
    public partial class VideoService
    {
        /// <summary>
        /// Get Video Thumbnail
        /// https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Thumbnail
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="thumbnailId">The thumbnail Id</param>
        /// <param name="thumbnailFormat">Thumbnail format. Allowed values: Jpeg / Base64</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="videoId"/> or <paramref name="thumbnailId"/> is null or whitespace.</exception>
        public async Task<byte[]> GetVideoThumbnailAsync(string videoId, string thumbnailId, ThumbnailFormat thumbnailFormat = ThumbnailFormat.Jpeg)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));
            ArgumentException.ThrowIfNullOrWhiteSpace(thumbnailId, nameof(thumbnailId));

            byte[] thumbnailData = Array.Empty<byte>();
            try
            {
                await EnsureTokenAsync();
                string requestUrl = $"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos/{videoId}/Thumbnails/{thumbnailId}?format={thumbnailFormat}";

                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read the content as a byte array
                    thumbnailData = await response.Content.ReadAsByteArrayAsync();
                    _logger.LogInformation($"video thumbnail {thumbnailId} retrieved successfully.");
                }
                else
                {
                    _logger.LogError($"Status Code: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message: {ex.Message} StackTrace: {ex.StackTrace}");
            }


            return thumbnailData;
        }


        /// <summary>
        /// Retrieves url thumbnails for a specified video.
        /// The thumbnails are uploaded to a Blob storage, and a Shared Access Signature (SAS) URL is generated for each thumbnail
        /// </summary>
        /// <param name="videoId">The ID of the video to process</param>
        /// <returns>A list of keyframe instances with their corresponding thumbnail URLs</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="videoId"/> is null or whitespace.</exception>
        public async Task<string> GetVideoThumbnailUrlAsync(string videoId, string thumbnailId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));

            string thumbnailUrl = string.Empty;
            try
            {
                // Retrieve thumbnail data
                var thumbnailData = await GetVideoThumbnailAsync(videoId, thumbnailId, ThumbnailFormat.Jpeg);
                if (thumbnailData == null || thumbnailData.Length == 0)
                    return string.Empty;

                // Upload to Blob storage
                var uploadSuccess = await _blobService.UploadBlobAsync($"{thumbnailId}", thumbnailData, "image/jpeg");
                if (!uploadSuccess)
                {
                    _logger.LogError($"Failed to upload thumbnail for ThumbnailId: {thumbnailId}");
                    return string.Empty;
                }

                // Generate SAS URL
                var thumbnailUri = _blobService.GenerateBlobSASURL(thumbnailId);
                if (thumbnailUri == null)
                {
                    _logger.LogError($"Failed to generate SAS URL for ThumbnailId: {thumbnailId}");
                    return string.Empty;
                }

                thumbnailUrl = thumbnailUri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Video Id: {videoId} Error Message: {ex.Message} StackTrace: {ex.StackTrace}");
            }


            return thumbnailUrl;
        }


        /// <summary>
        /// Retrieves keyframe thumbnails for a specified video.
        /// The thumbnails are uploaded to a Blob storage, and a Shared Access Signature (SAS) URL is generated for each thumbnail
        /// </summary>
        /// <param name="videoId">The ID of the video to process</param>
        /// <returns>A list of keyframe instances with their corresponding thumbnail URLs</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="videoId"/> is null or whitespace.</exception>
        public async Task<List<KeyFrameInsightInstanceWithThumbnailUrl>> GetKeyFrameThumbnailsAsync(string videoId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));

            var keyFrameThumbnails = new List<KeyFrameInsightInstanceWithThumbnailUrl>();
            try
            {
                // Fetch the video contract
                var videoContract = await GetVideoIndexAsync(videoId);
                if (videoContract?.Videos == null || !videoContract.Videos.Any())
                {
                    _logger.LogError($"No videos found for videoId: {videoId}");
                    return keyFrameThumbnails;
                }

                // Process each video
                foreach (var video in videoContract.Videos)
                {
                    if (video.Insights?.Shots == null || !video.Insights.Shots.Any())
                        continue;

                    // Process each shot
                    foreach (ShotInsight shot in video.Insights.Shots)
                    {
                        if (shot.KeyFrames == null || !shot.KeyFrames.Any())
                            continue;

                        // Process each keyframe
                        foreach (var shotKeyFrames in shot.KeyFrames)
                        {
                            if (shotKeyFrames.Instances == null || !shotKeyFrames.Instances.Any())
                                continue;

                            // Process each keyframe instance
                            foreach (var shotKeyFrameInstance in shotKeyFrames.Instances)
                            {
                                // Retrieve thumbnail data
                                var thumbnailData = await GetVideoThumbnailAsync(videoId, shotKeyFrameInstance.ThumbnailId, ThumbnailFormat.Jpeg);
                                if (thumbnailData == null || thumbnailData.Length == 0)
                                    continue;

                                // Upload to Blob storage
                                var uploadSuccess = await _blobService.UploadBlobAsync($"{shotKeyFrameInstance.ThumbnailId}", thumbnailData, "image/jpeg");
                                if (!uploadSuccess)
                                {
                                    _logger.LogError($"Failed to upload thumbnail for ThumbnailId: {shotKeyFrameInstance.ThumbnailId}");
                                    continue;
                                }

                                // Generate SAS URL
                                var thumbnailUri = _blobService.GenerateBlobSASURL(shotKeyFrameInstance.ThumbnailId);
                                if (thumbnailUri == null)
                                {
                                    _logger.LogError($"Failed to generate SAS URL for ThumbnailId: {shotKeyFrameInstance.ThumbnailId}");
                                    continue;
                                }
                                // Add to the list
                                keyFrameThumbnails.Add(new KeyFrameInsightInstanceWithThumbnailUrl()
                                {
                                    ThumbnailId = shotKeyFrameInstance.ThumbnailId,
                                    Start = shotKeyFrameInstance.Start,
                                    AdjustedStart = shotKeyFrameInstance.AdjustedStart,
                                    End = shotKeyFrameInstance.End,
                                    AdjustedEnd = shotKeyFrameInstance.AdjustedEnd,
                                    ThumbnailUrl = thumbnailUri.AbsoluteUri
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Video Id: {videoId} Error Message: {ex.Message} StackTrace: {ex.StackTrace}");
            }


            return keyFrameThumbnails;
        }

    }
}
