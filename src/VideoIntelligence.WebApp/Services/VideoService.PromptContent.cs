using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using VideoIntelligence.WebApp.Enums;
using VideoIntelligence.WebApp.Model;
using VideoIntelligence.WebApp.Utils;

namespace VideoIntelligence.WebApp.Services
{
    public partial class VideoService
    {

        /// <summary>
        /// Retrieves the prompt OCR content from the Video Indexer API for the specified video.
        /// The prompt OCR endpoint provides OCR-related details such as computed text from video frames.
        /// </summary>
        /// <param name="videoId">A unique identifier for the video.</param>
        /// <returns>
        /// A Task that represents the asynchronous operation. The task result contains a <see cref="PromptContentContract"/>
        /// object holding the OCR prompt details if the request is successful; otherwise, it returns <c>null</c>.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="videoId"/> is null or whitespace.</exception>
        /// <remarks>
        /// For more details, visit:
        /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Prompt-Ocr">Azure AI Video Indexer API Details</see>
        /// </remarks>
        public async Task<PromptContentContract?> GetPromptContentAsync(string videoId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));
            PromptContentContract? promptContentContract = null;
            try
            {
                string requestUrl = $"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos/{videoId}/PromptContent";
                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    // If successful, read and output the JSON response.
                    string promptContentResult = await response.Content.ReadAsStringAsync();
                    promptContentContract = JsonUtils.Deserialize<PromptContentContract>(promptContentResult);
                    _logger.LogInformation($"Prompt Content successfully processed.");
                }
                else
                {
                    _logger.LogError($"Error Status Code: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message:{ex.Message} Stack Trace:{ex.StackTrace}");
            }

            return promptContentContract;
        }

        /// <summary>
        /// Generates Prompt OCR from video insights by creating a prompt content job with the Video Indexer API.
        /// This triggers the API to generate OCR prompt content using a specified language model and prompt style.
        /// </summary>
        /// <param name="videoId">The unique identifier of the video for which the prompt OCR content should be generated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="videoId"/> is null or whitespace.</exception>
        /// <remarks>
        /// For more details, visit:
        /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Create-Prompt-Ocr">Azure AI Video Indexer API Details</see>
        /// </remarks>
        public async Task GeneratePromptContentAsync(string videoId, PromptContentLanguageModel modelName, PromptContentStyle promptStyle)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));

            try
            {
                HttpClientUtils.AddClientRequestIdHeader(_httpClient);

                //Build Query Parameter Dictionary
                var queryDictionary = new Dictionary<string, string>
                {
                    // Specifies the language model to use for creating the prompt content.
                    { "modelName", modelName.ToString()},

                    // Defines the style of the generated prompt content.
                    // Allowed values include: Full (for detailed prompt) or Summarized.
                    { "promptStyle", promptStyle.ToString() }
                };


                var queryParams = queryDictionary.CreateQueryString();

                string url = $"{apiUrl}/{accountLocation}/Accounts/{accountId}/Videos/{videoId}/PromptContent?{queryParams}";
                HttpResponseMessage response = await _httpClient.PostAsync(url, null);

                //Response: 202 Accepted created prompt content job
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Accepted created prompt content job.");
                }
                else
                {
                    _logger.LogError($"Error Status Code: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }
        }


        /// <summary>
        /// Generates a summary prompt content based on video insights by first initiating the prompt content job,
        /// then retrieving and formatting the results from the Video Indexer API.
        /// </summary>
        /// <param name="videoId">
        /// A unique identifier for the video whose insights are used to generate the prompt content.
        /// </param>
        /// <param name="modelName">
        /// The language model to use for generating the prompt content. The default is <see cref="PromptContentLanguageModel.GPT4O"/>.
        /// </param>
        /// <param name="promptStyle">
        /// The style in which the prompt should be generated. The default is <see cref="PromptContentStyle.Full"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation with a string result containing the formatted prompt.
        /// If the retrieved prompt content is null, an empty string (or partial summary) is returned.
        /// </returns>
        public async Task<string> GetPromptContentForSummaryAsync(string videoId, PromptContentLanguageModel modelName = PromptContentLanguageModel.GPT4O, PromptContentStyle promptStyle = PromptContentStyle.Full)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));
            StringBuilder promptContentStringBuilder = new StringBuilder();
            try
            {
                // Ensure a valid token is available.
                await EnsureTokenAsync();

                // Initiate the creation of prompt content by calling the video indexer API.
                // This method uses the specified language model and prompt style to generate the prompt.
                await GeneratePromptContentAsync(videoId, modelName, promptStyle);

                // Retrieve the generated prompt content from the API.
                PromptContentContract? promptContentContract = await GetPromptContentAsync(videoId);
                if (promptContentContract == null)
                {
                    _logger.LogWarning($"Empty prompt content");
                    return promptContentStringBuilder.ToString();
                }

                // Build the header section of the summary prompt using the video's title and a brief description.
                promptContentStringBuilder.Append($"You are given the video titled: {promptContentContract.Name} including its visual, audio and text insights");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Id] is a unique identifier for the video insight,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Transcript] is the text that is spoken in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Tags] is the tag in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[OCR] is the visual text in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Known people] are the people that appear in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Audio effects] are the sounds in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Visual labels] are the objects that appears in the video.");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("Use these insights as part of the video's content, but don't use their initials (writen in []) as-is, to summarize the content.");
                promptContentStringBuilder.Append(Environment.NewLine);
                promptContentStringBuilder.Append(Environment.NewLine);

                foreach (var item in promptContentContract.Sections)
                {
                    promptContentStringBuilder.Append(Environment.NewLine);
                    promptContentStringBuilder.Append(Environment.NewLine);
                    promptContentStringBuilder.Append($"[Id] {item.Id}{Environment.NewLine}{RemoveTitleFromContent(item.Content)}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }

            return promptContentStringBuilder.ToString();
        }


        /// <summary>
        /// Generates a summary prompt content based on video insights by first initiating the prompt content job,
        /// then retrieving and formatting the results from the Video Indexer API.
        /// </summary>
        /// <param name="videoId">
        /// A unique identifier for the video whose insights are used to generate the prompt content.
        /// </param>
        /// <param name="modelName">
        /// The language model to use for generating the prompt content. The default is <see cref="PromptContentLanguageModel.GPT4O"/>.
        /// </param>
        /// <param name="promptStyle">
        /// The style in which the prompt should be generated. The default is <see cref="PromptContentStyle.Full"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation with a string result containing the formatted prompt.
        /// If the retrieved prompt content is null, an empty string (or partial summary) is returned.
        /// </returns>
        public async Task<string> GetFullPromptContentAsync(string videoId, PromptContentLanguageModel modelName = PromptContentLanguageModel.GPT4O)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));
            StringBuilder promptContentStringBuilder = new StringBuilder();
            try
            {
                await EnsureTokenAsync();

                // Initiate the creation of prompt content by calling the video indexer API.
                // This method uses the specified language model and prompt style to generate the prompt.
                await GeneratePromptContentAsync(videoId, modelName, PromptContentStyle.Full);

                // Retrieve the generated prompt content from the API.
                PromptContentContract? promptContentContract = await GetPromptContentAsync(videoId);
                if (promptContentContract == null)
                {
                    _logger.LogWarning($"{MethodBase.GetCurrentMethod()} empty prompt content");
                    return promptContentStringBuilder.ToString();
                }

                // Build the header section of the summary prompt using the video's title and a brief description.
                promptContentStringBuilder.Append($"You are given the video titled: {promptContentContract.Name} including its visual, audio and text insights");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Id] is a unique identifier for the video insight,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Transcript] is the text that is spoken in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Tags] is the tag in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[OCR] is the visual text in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Known people] are the people that appear in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Audio effects] are the sounds in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Visual labels] are the objects that appears in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[OCRThumbnailId] is the url of the JPEG image frame in the video. The [OCR] is the visual text of the image.");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("Use these insights as part of the video's content, but don't use their initials (writen in []) as-is.");
                promptContentStringBuilder.Append(Environment.NewLine);
                promptContentStringBuilder.Append(Environment.NewLine);

                foreach (var item in promptContentContract.Sections)
                {
                    promptContentStringBuilder.Append(Environment.NewLine);
                    promptContentStringBuilder.Append(Environment.NewLine);
                    promptContentStringBuilder.Append($"[Id] {item.Id}{Environment.NewLine}{RemoveTitleFromContent(item.Content)}");
                    if (item.Frames.Length > 0)
                    {
                        promptContentStringBuilder.Append(Environment.NewLine);
                        promptContentStringBuilder.Append($"[OCRThumbnailId] {await GetVideoThumbnailUrlAsync(videoId, item.Frames[0])}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }

            return promptContentStringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="videoId"></param>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public async Task<string> GetContentForSearch(string videoId, PromptContentLanguageModel modelName = PromptContentLanguageModel.GPT4O)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(videoId, nameof(videoId));
            StringBuilder promptContentStringBuilder = new StringBuilder();
            try
            {
                await EnsureTokenAsync();
                // Initiate the creation of prompt content by calling the video indexer API.
                // This method uses the specified language model and prompt style to generate the prompt.
                await GeneratePromptContentAsync(videoId, modelName, PromptContentStyle.Full);

                // Retrieve the generated prompt content from the API.
                VideoContract? videoContract = await GetVideoIndexAsync(videoId);
                if (videoContract == null)
                {
                    _logger.LogWarning($"{MethodBase.GetCurrentMethod()} empty prompt content");
                    return promptContentStringBuilder.ToString();
                }

                // Build the header section of the summary prompt using the video's title and a brief description.
                promptContentStringBuilder.Append($"You are given the video titled: {videoContract.Name} including its visual and text insights");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Time] is a time ");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[Transcript] is the text that is spoken in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);

                promptContentStringBuilder.Append("[OCR] is the visual text in the video,");
                promptContentStringBuilder.Append(Environment.NewLine);


                promptContentStringBuilder.Append("Use these insights as part of the video's content, but don't use their initials (writen in []) as-is.");
                promptContentStringBuilder.Append(Environment.NewLine);
                promptContentStringBuilder.Append(Environment.NewLine);

                foreach (var video in videoContract.Videos)
                {
                    foreach (var videoTranscript in video.Insights.Transcript)
                    {
                        promptContentStringBuilder.Append(Environment.NewLine);
                        promptContentStringBuilder.Append(Environment.NewLine);
                        promptContentStringBuilder.Append($"[Time] {videoTranscript.Instances.First().Start.ToString("hh\\:mm\\:ss")}");
                        promptContentStringBuilder.Append(Environment.NewLine);
                        promptContentStringBuilder.Append($"[Transcript] {videoTranscript.Text}");
                        if (video.Insights.Ocr.Count > 0)
                        {
                            if (video.Insights.Ocr.ToList().Exists(f => f.Instances.Count >= 0 && f.Instances.ToList().Exists(d => videoTranscript.Instances.ToList().Exists(t => t.Start.ToString("hh\\:mm\\:ss") == d.Start.ToString("hh\\:mm\\:ss")))))
                            {
                                promptContentStringBuilder.Append(Environment.NewLine);
                                promptContentStringBuilder.Append($"[OCR] {string.Join(" ", video.Insights.Ocr.ToList().FindAll(f => f.Instances.Count >= 0 && f.Instances.ToList().Exists(d => videoTranscript.Instances.ToList().Exists(t => t.Start.ToString("hh\\:mm\\:ss") == d.Start.ToString("hh\\:mm\\:ss")))).Select(s => s.Text).ToArray())}");
                            }
                        }
                    }
                }

                var videoUri = _blobService.GenerateBlobSASURL(videoId);
                if (videoUri != null)
                {
                    promptContentStringBuilder.Append(Environment.NewLine);
                    promptContentStringBuilder.Append($"[VideoUrl] {videoUri.AbsoluteUri}");
                }
                else
                {
                    _logger.LogError($"{MethodBase.GetCurrentMethod()} Failed to generate SAS URL fot the web page {videoUri}");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }

            return promptContentStringBuilder.ToString();
        }


        /// <summary>
        /// Removes any line starting with "[Video title]" from the provided input string.
        /// </summary>
        /// <param name="input">
        /// The input string from which to remove the "[Video title]" section. This parameter must not be null.
        /// </param>
        /// <returns>
        /// A modified string with all lines beginning with "[Video title]" removed. If no such line is found, the original string is returned.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="input"/> is null.
        /// </exception>
        private string RemoveTitleFromContent(string input)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(input, nameof(input));

            // Define a regex pattern to match the [Video title] section.
            // The pattern ^\[Video title\].*\n matches any line that starts with "[Video title]"
            // The RegexOptions.Multiline flag enables ^ to match the beginning of each line.
            string pattern = @"^\[Video title\].*\n";

            // Replace the matched pattern with an empty string, effectively removing it from the input.
            return Regex.Replace(input, pattern, string.Empty, RegexOptions.Multiline);
        }
    }
}
