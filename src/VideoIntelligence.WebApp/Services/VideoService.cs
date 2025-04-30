using System.Security.Authentication;
using VideoIntelligence.WebApp.Utils;

namespace VideoIntelligence.WebApp.Services
{
    /// <summary>
    /// Provides a service for interacting with the Video Indexer API.
    /// </summary>
    public partial class VideoService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<VideoService> _logger;
        private readonly BlobService _blobService;

        /// <summary>
        /// The base URL for the Video Indexer API
        /// </summary>
        private const string apiUrl = "https://api.videoindexer.ai";

        /// <summary>
        /// Account ID is a globally unique identifier (GUID) for the account.
        /// Retrieve it from the Account settings available at https://www.videoindexer.ai/ 
        /// </summary>
        private readonly string accountId = "";

        ///<summary>
        /// The API key required for authenticating requests to the Video Indexer API.
        /// Both primary and secondary keys can be found in your Profile at https://api-portal.videoindexer.ai/profile.
        /// This key is mandatory even for trial accounts.
        /// </summary>
        private readonly string apiKey = "";

        /// <summary>
        /// Specifies the Azure region for routing API calls.
        /// For trial accounts, set this value to "trial". For production, use the supported region string,
        /// generally in lowercase without spaces (e.g., "westeurope").
        /// </summary>
        private readonly string accountLocation = "";

        /// <summary>
        /// Stores the account access token used for authenticated API requests.
        /// Note that access tokens typically expire after one hour.
        /// </summary>
        private string _accountAccessToken = "";

        // Token expiration time.
        private DateTime _tokenExpiration = DateTime.MinValue;

        // A semaphore to ensure thread safety during token refresh.
        private readonly SemaphoreSlim _tokenSemaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// The time interval between polling attempts for long-running operations (e.g., indexing).
        /// This is set to 10 seconds.
        /// </summary>
        private readonly TimeSpan _pollingInteval = TimeSpan.FromSeconds(10);

        /// <summary>
        /// The shared HTTP client used for sending API requests.
        /// This client is configured with appropriate authentication headers and TLS settings.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoIndexerClient"/> class.
        /// The constructor validates that the required configuration values are available in the environment,
        /// sets up the HTTP client with TLS 1.2 (or above), and adds the authorization header.
        /// </summary>
        /// <exception cref="Exception">
        /// Thrown when one or more required environment variables (ACCOUNT_ID, API_KEY, or ACCOUNT_LOCATION) are missing.
        /// </exception>
        public VideoService(IConfiguration configuration
                            , ILogger<VideoService> logger
                            , BlobService blobService)
        {
            _configuration = configuration;
            if (!Valid())
            {
                throw new Exception("Missing environment variable: ACCOUNT_ID, API_KEY or ACCOUNT_LOCATION !");
            }
            apiKey = _configuration["AzureVideoIndexer:ApiKey"] ?? "";
            accountId = _configuration["AzureVideoIndexer:AccountId"] ?? "";
            accountLocation = _configuration["AzureVideoIndexer:AccountLocation"] ?? "";
            // TLS 1.2 (or above) is required to send requests
            var httpHandler = new SocketsHttpHandler();
            httpHandler.SslOptions.EnabledSslProtocols |= SslProtocols.Tls12;

            _httpClient = HttpClientUtils.CreateHttpClient(apiKey);
            _blobService = blobService ?? throw new ArgumentNullException(nameof(blobService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        /// <summary>
        /// Validates that the required configuration values for the Video Indexer client are present.
        /// </summary>
        /// <returns>
        /// <c>true</c> if <see cref="accountId"/>, <see cref="apiKey"/>, and <see cref="accountLocation"/>
        /// are non-null and contain non-whitespace characters; otherwise, <c>false</c>.
        /// </returns>
        private bool Valid() => !string.IsNullOrWhiteSpace(_configuration["AzureVideoIndexer:AccountId"] ?? "")
                                && !string.IsNullOrWhiteSpace(_configuration["AzureVideoIndexer:ApiKey"] ?? "")
                                && !string.IsNullOrWhiteSpace(_configuration["AzureVideoIndexer:AccountLocation"] ?? "");

        
    }
}
