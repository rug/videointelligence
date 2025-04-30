using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using VideoIntelligence.WebApp.Services;

namespace VideoIntelligence.WebApp.Plugins
{
    /// <summary>
    /// 
    /// </summary>
    public class VideoIndexerPlugin
    {
        private readonly VideoService _videoService;
        private readonly BlobService _blobService;
        private readonly ILogger<VideoIndexerPlugin> _logger;
       

        public VideoIndexerPlugin(VideoService videoService
                , BlobService blobService
                , ILogger<VideoIndexerPlugin> logger)
        {
            _videoService = videoService ?? throw new ArgumentNullException(nameof(videoService));
            _blobService = blobService ?? throw new ArgumentNullException(nameof(blobService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        [KernelFunction]
        [Description(@"Gets information about the video to help summarizing content. The function parameter videoId is a unique identifier of the video.  It gives you the following info:\r\n[Id] is a unique identifier for the video insight,\r\n[Transcript] is the text that is spoken in the video,\r\n[Tags] is the tag in the video,\r\n[OCR] is the visual text in the video,\r\n[Known people] are the people that appear in the video,\r\n[Audio effects] are the sounds in the video,\r\n[Visual labels] are the objects that appears in the video.\r\nUse these insights as part of the video's content, but don't use their initials (written in []) as-is, to summarize the content.\r\n\r\n\r\n\r\n")]
        public async Task<string> ContentForSummaryAsync(string videoId)
        {
            return await _videoService.GetPromptContentForSummaryAsync(videoId); ;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        [KernelFunction]
        [Description("Gets a complete transcription/content of the video. The function parameter videoId is a unique identifier of the video. It is useful to create HTML. It gives you the following info:\r\n[Id] is a unique identifier for the video insight,\r\n[Transcript] is the text that is spoken in the video,\r\n[Tags] is the tag in the video,\r\n[OCR] is the visual text in the video,\r\n[Known people] are the people that appear in the video,\r\n[Audio effects] are the sounds in the video,\r\n[Visual labels] are the objects that appears in the video,\r\n[OCRThumbnailId] is the url of the JPEG image frame in the video. The [OCR] is the visual text of the image.\r\nUse these insights as part of the video's content, but don't use their initials (written in []) as-is.\r\n\r\n\r\n")]
        public async Task<string> FullContentAsync(string videoId)
        {
            return await _videoService.GetFullPromptContentAsync(videoId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        [KernelFunction]
        [Description("Use this function to save/create a webpage. You must pass as parameter the HTML text and the pictures, please use Bootstrap to make it visually pleasant. It returns you the webpage URL that you have to provide to the user.\r\n\r\n")]
        public async Task<string> SaveHtmlPageAsync(string html)
        {
            string htmlPageUrl = string.Empty;

            string pageName = Guid.NewGuid().ToString();
            if (await _blobService.UploadBlobAsync(pageName, Encoding.UTF8.GetBytes(html), "text/html"))
            {
                var thumbnailUri = _blobService.GenerateBlobSASURL(pageName);
                if (thumbnailUri == null)
                {
                    _logger.LogError($"{MethodBase.GetCurrentMethod()} Failed to generate SAS URL fot the web page {pageName}");
                    return string.Empty;
                }
                htmlPageUrl = thumbnailUri.AbsoluteUri;
            }

            return htmlPageUrl;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        [KernelFunction]
        [Description(@"Gets the information you need to find the right point in the video where a certain subject is discussed. 
                        The function parameter videoId is a unique identifier of the video. 
                        It is useful to search in video content.
                        It gives you the following info:
                        - [Time] is a time.
                        - [Transcript] is the text that is spoken in the video.
                        - [OCR] is the visual text in the video.
                        - [VideoUrl] is the link to the video content
                        Use these insights as part of the video's content, but don't use their initials (written in []) as-is.
                        When find the searched information at the end of the response to the user append the link to the video content additing at the end of the url #t=[videotime] 
                        where [videotime] is the seconds of [Time]")]
        public async Task<string> ContentForSearch(string videoId)
        {
            return await _videoService.GetContentForSearch(videoId); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [KernelFunction]
        [Description(@"Upload video for analysis from url. The function parameter ""url"" is a url to the video. 
The function returns a video unique identifier when the the video has been successfully uploaded. 
Give a feedback to the user that the video has been successfully analyzed with a unique identifier and now you have all video content and the user can ask you anything about the video ")]
        public async Task<string> UploadVideoFromUrl(string url)
        {
            string videoId = string.Empty;

            var videoContract = await _videoService.UploadUrlAsync(url);
            if (videoContract != null) videoId = videoContract.Id;

            return url;
        }
    }
}
