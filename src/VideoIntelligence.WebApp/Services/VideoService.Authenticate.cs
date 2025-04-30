using VideoIntelligence.WebApp.Utils;

namespace VideoIntelligence.WebApp.Services
{
    public partial class VideoService
    {
        /// <summary>
        /// Retrieves an account access token with the specified permission level from the Video Indexer API.
        /// This token is added to the HTTP client's authorization header for use in subsequent API calls.
        /// </summary>
        /// <param name="permission">
        /// The requested permission. Allowed values include:
        /// <list type="bullet">
        ///   <item><description>Reader - allows reading content.</description></item>
        ///   <item><description>Contributor - allows modifying content.</description></item>
        ///   <item><description>MyAccessAdministrator - allows managing the acting user's permission.</description></item>
        ///   <item><description>Owner - allows managing permissions and modifying content.</description></item>
        ///   <item><description>RestrictedViewer - allows restricted reading of content.</description></item>
        /// </list>
        /// The default permission is set to "Contributor".
        /// </param>
        /// <remarks>
        /// For more details, visit:
        /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Accounts-With-Token">Azure AI Video Indexer API Details</see>
        /// </remarks>
        public async Task AuthenticateAsync(string permission = "Contributor")
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(permission, nameof(permission));

            try
            {
                string url = $"{apiUrl}/Auth/{accountLocation}/Accounts/{accountId}/AccessTokenWithPermission?permission={permission}";

                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    // Log the response id so you can include it in case you wish to report an issue for API errors or unexpected API behavior
                    //_logger.LogInformation($"response.Headers.GetValues("x-ms-request-id").FirstOrDefault()); 

                    // Read the access token from the response content.
                    // The token is returned as a JSON string enclosed in double-quotes, so we trim them.
                    _accountAccessToken = (await response.Content.ReadAsStringAsync()).Trim('"');
                    // Set the token expiration to 1 hour from now.
                    _tokenExpiration = DateTime.UtcNow.AddHours(1).AddMinutes(-1);

                    // Set the Authorization header for the HTTP client using the retrieved access token
                    HttpClientUtils.AddAuthorizationHeader(_accountAccessToken, _httpClient);
                }
                else
                {
                    _logger.LogError($"Failed to deserialize token response. Error Status Code: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message:{ex.Message} Stack Trace:{ex.StackTrace}");
            }
        }


        /// <summary>
        /// Ensures that a valid token is available.
        /// If the token is expired or missing, it refreshes the token in a thread-safe manner.
        /// </summary>
        private async Task EnsureTokenAsync()
        {
            // Quickly check if token is valid. If it is, avoid the semaphore.
            if (!string.IsNullOrEmpty(_accountAccessToken) && DateTime.UtcNow < _tokenExpiration)
            {
                return;
            }

            // Wait to ensure that only one thread can refresh the token.
            await _tokenSemaphore.WaitAsync();
            try
            {
                // Double-check the token validity after entering the semaphore.
                if (string.IsNullOrEmpty(_accountAccessToken) || DateTime.UtcNow >= _tokenExpiration)
                {
                    await AuthenticateAsync();
                }
            }
            finally
            {
                _tokenSemaphore.Release();
            }
        }
    }
}
