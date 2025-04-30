using System.Security.Authentication;
using VideoIntelligence.WebApp.Enums;
using VideoIntelligence.WebApp.Model;
using VideoIntelligence.WebApp.Utils;

namespace VideoIntelligence.WebApp.Services
{
    public partial class VideoService
    {
        /// <summary>
        /// Get Video Artifact Download Url
        /// </summary>
        /// <remarks>
        /// For more details, visit:
        /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Artifact-Download-Url">Azure AI Video Indexer API Details</see>
        /// </remarks>
        /// <param name="videoId">The video id</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="videoId"/> is null or whitespace.</exception>
        public async Task<Uri?> GetVideoArtifactDownloadUrlAsync(string videoId, ArtifactType artifactType)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));
            Uri? videoArtifactDownloadUrl = null;
            try
            {
                await EnsureTokenAsync();

                string requestUrl = $"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos/{videoId}/ArtifactUrl?type={artifactType}";

                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    videoArtifactDownloadUrl = new Uri(responseContent.Replace("\"", ""));
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

            return videoArtifactDownloadUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <returns></returns> 
        /// <exception cref="ArgumentException">Thrown when <paramref name="videoId"/> is null or whitespace.</exception>
        public async Task<ArtifactOcrResult?> GetOcrArtifactAsync(string videoId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));

            ArtifactOcrResult? artifactOcrResult = null;
            try
            {
                Uri? videoArtifactDownloadUrl = await GetVideoArtifactDownloadUrlAsync(videoId, ArtifactType.Ocr);
                if (videoArtifactDownloadUrl != null)
                {

                    // TLS 1.2 (or above) is required to send requests
                    var httpHandler = new SocketsHttpHandler();
                    httpHandler.SslOptions.EnabledSslProtocols |= SslProtocols.Tls12;
                    httpHandler.AllowAutoRedirect = true;

                    using (var httpClient = new HttpClient(httpHandler))
                    {

                        HttpResponseMessage response = await httpClient.GetAsync(videoArtifactDownloadUrl.AbsoluteUri);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            if (!string.IsNullOrWhiteSpace(responseContent))
                            {
                                artifactOcrResult = JsonUtils.Deserialize<ArtifactOcrResult?>(responseContent);
                                _logger.LogInformation($"Received data for Ocr from artifact successfully processed.");
                            }
                        }
                        else
                        {
                            _logger.LogError($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }

            return artifactOcrResult;
        }

    }
}
