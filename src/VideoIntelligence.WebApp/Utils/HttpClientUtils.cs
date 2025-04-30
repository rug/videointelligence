using System.Web;

namespace VideoIntelligence.WebApp.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpClientUtils
    {
        /// <summary>
        /// Creates an instance of HttpClient with custom headers for API authentication
        /// </summary>
        /// <param name="apiKey">The API key used for authenticating requests</param>
        /// <param name="_accountAccessToken">An optional account access token for authorization headers (default is an empty string)</param>
        /// <returns>A configured HttpClient instance with authentication headers set</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="apiKey"/> is null or whitespace.</exception>
        public static HttpClient CreateHttpClient(string apiKey, string _accountAccessToken = "")
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(apiKey, nameof(apiKey));

            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false,
            };

            var httpClient = new HttpClient(handler);

            // Even on a trial account, you must include the subscription key with the header "Ocp-Apim-Subscription-Key".
            // Not using one will cause the account lookup to fail because Video Indexer doesn’t know which account you are referring to.
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);

            if (!string.IsNullOrWhiteSpace(_accountAccessToken))
            {
                AddAuthorizationHeader(_accountAccessToken, httpClient);
            }
            return httpClient;
        }

        /// <summary>
        /// Constructs a query string from a dictionary of key-value pairs
        /// </summary>
        /// <param name="parameters">The dictionary containing the query parameters as key-value pairs</param>
        /// <returns>A query string representation of the parameters, ready to be appended to a URL</returns>
        public static string CreateQueryString(this IDictionary<string, string> parameters)
        {
            var queryParameters = HttpUtility.ParseQueryString(string.Empty);
            foreach (var parameter in parameters)
            {
                queryParameters[parameter.Key] = parameter.Value;
            }
            return queryParameters?.ToString()??"";
        }

        /// <summary>
        /// Adds or updates a custom header in the DefaultRequestHeaders of the provided HttpClient
        /// </summary>
        /// <param name="headerName">The name of the header to add or update</param>
        /// <param name="headerValue">The value of the header to add or update</param>
        /// <param name="httpClient">The HttpClient instance where the header will be added or updated</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="headerName"/>  or <paramref name="headerValue"/>  is null or whitespace.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="httpClient"/> is null.</exception>
        public static void AddRequestHeader(string headerName, string headerValue, HttpClient httpClient)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(headerName, nameof(headerName));
            ArgumentException.ThrowIfNullOrWhiteSpace(headerValue, nameof(headerValue));
            ArgumentNullException.ThrowIfNull(httpClient, nameof(httpClient));

            if (httpClient.DefaultRequestHeaders.Contains(headerName))
            {
                httpClient.DefaultRequestHeaders.Remove(headerName);
            }
            httpClient.DefaultRequestHeaders.Add(headerName, headerValue);
        }


        /// <summary>
        /// Adds a unique client request ID header to the provided HttpClient instance
        /// Log the request id so you can include it in case you wish to report an issue for API errors or unexpected API behavior
        /// A globally unique identifier (GUID) for the request which can be sent by client for instrumentation purposes. 
        /// The server makes sure all logs associated with handling the request can be linked to the client request id so a client 
        /// can provide this request id in support tickets so support engineers could find the logs linked to this particular request, 
        /// so avoid using the same request id for different requests, including in retry scenarios.
        /// </summary>
        /// <param name="httpClient">The HttpClient to which the header will be added</param>
        /// <exception cref="ArgumentNullException">Thrown when the provided <paramref name="httpClient"/> is null.</exception>
        public static void AddClientRequestIdHeader(HttpClient httpClient)
        {
            ArgumentNullException.ThrowIfNull(httpClient, nameof(httpClient));

            AddRequestHeader("x-ms-client-request-id", Guid.NewGuid().ToString(), httpClient);
        }


        /// <summary>
        /// Adds an authorization header with a JWT Bearer token to the DefaultRequestHeaders of the provided HttpClient.
        /// </summary>
        /// <param name="accountAccessToken">The access token in JWT Bearer format.</param>
        /// <param name="httpClient">The HttpClient instance where the authorization header will be added</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="accountAccessToken"/> is null or empty string</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="httpClient"/> is null.</exception>
        public static void AddAuthorizationHeader(string accountAccessToken, HttpClient httpClient)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(accountAccessToken, nameof(accountAccessToken));
            ArgumentNullException.ThrowIfNull(httpClient);

            AddRequestHeader("Authorization", $"Bearer {accountAccessToken}", httpClient);
        }
    }
}
