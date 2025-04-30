using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using System.Reflection;
using System.Security.Authentication;
using System.Security.Cryptography;

namespace VideoIntelligence.WebApp.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class BlobService 
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _containerClient;
        private readonly string _containerName;
        private readonly ILogger<BlobService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobService"/> class.
        /// </summary>
        /// <param name="containerName">The name of the blob container</param>
        /// <exception cref="ArgumentException">Thrown when the connection string, container name, or blob name is null or whitespace</exception>
        public BlobService(IConfiguration configuration, ILogger<BlobService> logger)
        {
            string _clientConnectionString = configuration["StorageAccount:ConnectionString"] ?? "";
            if (string.IsNullOrEmpty(_clientConnectionString))
            {
                throw new Exception("Storage Account Connection String is empty!");
            }

            _containerName = configuration["StorageAccount:ContainerName"] ?? "";
            if (string.IsNullOrEmpty(_containerName))
            {
                throw new Exception("Storage account container name name is empty!");
            }
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            // Initialize the BlobServiceClient
            _blobServiceClient = new BlobServiceClient(_clientConnectionString);

            // Create the container client using the service client object
            _containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        }

        /// <summary>
        /// Uploads content to an Azure Blob asynchronously with content validation
        /// </summary>
        /// <param name="blobName">The name of the blob</param>
        /// <param name="fileContent">The byte array containing the file content to upload</param>
        /// <returns>True if the blob was successfully uploaded and validated; otherwise, false</returns>
        public async Task<bool> UploadBlobAsync(string blobName, byte[] fileContent, string contentType)
        {
            ArgumentNullException.ThrowIfNull(blobName, nameof(blobName));
            ArgumentNullException.ThrowIfNull(fileContent, nameof(fileContent));
            ArgumentNullException.ThrowIfNull(fileContent, nameof(contentType));

            bool uploaded = false;

            try
            {
                // Get a BlockBlobClient for the blob
                BlockBlobClient blockBlobClient = _containerClient.GetBlockBlobClient(blobName);

                // Set the blob HTTP headers, including the file type.
                var httpHeaders = new BlobHttpHeaders
                {
                    ContentType = contentType // e.g., "application/json", "image/jpeg", etc.
                };

                // Create the upload options with the specified HTTP headers.
                var uploadOptions = new BlobUploadOptions
                {
                    HttpHeaders = httpHeaders
                };

                // Use a MemoryStream to upload the file content
                using (MemoryStream stream = new MemoryStream(fileContent))
                {
                    var response = await blockBlobClient.UploadAsync(stream, uploadOptions);
                    // Validate the upload by comparing hashes
                    if (response?.Value.ContentHash != null)
                    {
                        stream.Position = 0;
                        byte[] computedHash = MD5.Create().ComputeHash(stream);

                        uploaded = ValidateContentHash(response.Value.ContentHash, computedHash);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error uploading blob: {ex.Message}");
            }

            return uploaded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="fileContent"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async Task<bool> UploadBlobFromUrlAsync(string videoUrl, string videoName)
        {
            ArgumentNullException.ThrowIfNull(videoUrl, nameof(videoUrl));
            ArgumentNullException.ThrowIfNull(videoName, nameof(videoName));
            bool uploaded = false;

            try
            {
                Uri? videoDownloadUrl = new Uri(videoUrl);
                if (videoDownloadUrl != null)
                {

                    // TLS 1.2 (or above) is required to send requests
                    var httpHandler = new SocketsHttpHandler();
                    httpHandler.SslOptions.EnabledSslProtocols |= SslProtocols.Tls12;
                    httpHandler.AllowAutoRedirect = true;


                    using (var httpClient = new HttpClient(httpHandler))
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(videoDownloadUrl.AbsoluteUri);

                        if (response.IsSuccessStatusCode)
                        {
                            byte[] videoContent = await response.Content.ReadAsByteArrayAsync();

                            uploaded = await UploadBlobAsync(videoName, videoContent, response.Content.Headers.ContentType?.MediaType ?? "");
                            if (!uploaded)
                            {
                                _logger.LogError($"Failed to upload to Azure Store: {videoName}");
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
                _logger.LogError($"{MethodBase.GetCurrentMethod()} Error Message:{ex.Message} StackTrace:{ex.StackTrace}");
            }

            return uploaded;
        }

        /// <summary>
        /// Generates a Shared Access Signature (SAS) URI for a specific blob in Azure Blob Storage
        /// </summary>
        /// <param name="blobName">The name of the blob for which the SAS URI will be created</param>
        /// <param name="permissions">The permissions to grant for the SAS token (e.g., read, write)</param>
        /// <param name="expiryInDays">The number of days until the SAS token expires</param>
        /// <returns>A URI with the SAS token appended if the blob is authorized with a Shared Key; otherwise, returns null if the SAS URI cannot be generated</returns>
        /// <exception cref="ArgumentNullException">Thrown when the provided blobClient is null</exception>
        public Uri? GenerateBlobSASURL(string blobName, BlobContainerSasPermissions permissions = BlobContainerSasPermissions.Read, int expiryInDays = 1)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(blobName, nameof(blobName));

            try
            {
                // Get a BlockBlobClient for the blob
                BlockBlobClient blockBlobClient = _containerClient.GetBlockBlobClient(blobName);

                // Check if BlobContainerClient object has been authorized with Shared Key
                if (blockBlobClient.CanGenerateSasUri)
                {
                    // Configure the BlobSasBuilder to define SAS token properties
                    BlobSasBuilder sasBuilder = new BlobSasBuilder()
                    {
                        BlobContainerName = blockBlobClient.GetParentBlobContainerClient().Name,
                        BlobName = blockBlobClient.Name,
                        Resource = "b"
                    };

                    // Set the expiration time for the SAS token.
                    sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddDays(expiryInDays);

                    // Set the permissions for the SAS token
                    sasBuilder.SetPermissions(permissions);

                    // Generate the SAS URI using the BlobClient.
                    Uri sasURI = blockBlobClient.GenerateSasUri(sasBuilder);
                    return sasURI;
                }
                else
                {
                    _logger.LogError($"Cannot generate SAS token.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating service sas blob : {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Validates if the content hash matches the computed hash
        /// </summary>
        /// <param name="contentHash">The hash returned by the blob upload response</param>
        /// <param name="computedHash">The hash computed from the original content</param>
        /// <returns>True if the hashes match; otherwise, false</returns>
        private bool ValidateContentHash(byte[] contentHash, byte[] computedHash)
        {
            if (contentHash.Length != computedHash.Length) return false;

            for (int i = 0; i < contentHash.Length; i++)
            {
                if (contentHash[i] != computedHash[i]) return false;
            }

            return true;
        }
    }
}
