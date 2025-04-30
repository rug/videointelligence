namespace VideoIntelligence.WebApp.Enums
{
    /// <summary>
    /// Defines the failure codes for video processing errors
    /// </summary>
    /// <remarks>
    /// For more details, visit:
    /// <see href="https://api-portal.videoindexer.ai/api-details#api=Operations&operation=Get-Video-Index&definition=FailureCode">Azure AI Video Indexer API Details</see>
    /// </remarks>
    public enum FailureCode
    {
        /// <summary>
        /// Represents an error where the message is empty
        /// </summary>
        EmptyMessage,

        /// <summary>
        /// Represents an error where the source language is not supported
        /// </summary>
        SourceLanguageNotSupported,

        /// <summary>
        /// Represents an error where the input file has no video and no audio
        /// </summary>
        InputFileWithNoVideoAndNoAudio,

        /// <summary>
        /// Represents an error where the input file has no video, causing a conflict
        /// </summary>
        InputFileWithNoVideoConflict,

        /// <summary>
        /// Represents an error where the input file has no audio, causing a conflict
        /// </summary>
        InputFileWithNoAudioConflict,

        /// <summary>
        /// Represents an error where the file format is invalid
        /// </summary>
        InvalidFileFormat,

        /// <summary>
        /// Represents an error where Azure Media Services (AMS) is not available
        /// </summary>
        AmsNotAvailable,

        /// <summary>
        /// Represents an error where AMS is not available or the file is not accessible
        /// </summary>
        AmsNotAvailableOrFileNotAccessible,

        /// <summary>
        /// Represents an error where the Event Grid is not registered
        /// </summary>
        EventGridNotRegistered,

        /// <summary>
        /// Represents an error where the operation timed out
        /// </summary>
        Timeout,

        /// <summary>
        /// Represents an error where the upload failed
        /// </summary>
        UploadFailed,

        /// <summary>
        /// Represents an error where the AMS gateway timed out
        /// </summary>
        AmsGatewayTimeout,

        /// <summary>
        /// Represents an error where the video was deleted
        /// </summary>
        VideoDeleted,

        /// <summary>
        /// Represents a transient error, suggesting to try again later
        /// </summary>
        TranisentErrorTryAgainLater,

        /// <summary>
        /// Represents a fatal error, requiring support contact
        /// </summary>
        FatalErrorContactSupport,

        /// <summary>
        /// Represents an error where the AMS job was externally canceled
        /// </summary>
        AmsJobExternalCancellation,

        /// <summary>
        /// Represents an error where the asset was not found
        /// </summary>
        AssetWasNotFound,

        /// <summary>
        /// Represents an error where the AMS quota was exceeded
        /// </summary>
        AmsQuotaExceeded,

        /// <summary>
        /// Represents an error where the streaming endpoint could not be reached
        /// </summary>
        UnableToReachStreamingEndpoint,

        /// <summary>
        /// Represents an error where the subscription is read-only and disabled
        /// </summary>
        ReadOnlyDisabledSubscription,

        /// <summary>
        /// Represents an error where the video URL is unreachable
        /// </summary>
        VideoUrlUnreachable,

        /// <summary>
        /// Represents an error where the account upload limit was exceeded
        /// </summary>
        AccountUploadLimitExceeded,

        /// <summary>
        /// Represents an error where the video upload limit was exceeded
        /// </summary>
        VideoUploadLimitExceeded,

        /// <summary>
        /// Represents an error where the audio format is invalid
        /// </summary>
        InvalidAudioFormat,

        /// <summary>
        /// Represents an error where the speech model was not found
        /// </summary>
        SpeechModelNotFound,

        /// <summary>
        /// Represents an error where the speech model has an invalid language
        /// </summary>
        SpeechModelInvalidLanguage,

        /// <summary>
        /// Represents an error where the storage gateway timed out
        /// </summary>
        StorageGatewayTimeout,

        /// <summary>
        /// Represents an error where storage is not available
        /// </summary>
        StorageNotAvailable,

        /// <summary>
        /// Represents an error where the custom linguistic model training is not complete
        /// </summary>
        CustomLinguisticModelTrainingNotComplete,

        /// <summary>
        /// Represents an error where the input file is missing
        /// </summary>
        InputFileMissing,

        /// <summary>
        /// Represents an error where storage access was denied
        /// </summary>
        StorageAccessDenied,

        /// <summary>
        /// Represents an error where the storage managed identity is malformed
        /// </summary>
        StorageManagedIdentityMalformed,

        /// <summary>
        /// Represents an error where the blob was not found in customer storage
        /// </summary>
        BlobNotFoundInCustomerStorage,

        /// <summary>
        /// Represents an error where there is insufficient information for summarization
        /// </summary>
        InsufficientInformationForSummarization,

        /// <summary>
        /// Represents an error where summarization throttling occurred
        /// </summary>
        SummarizationThrottlingError,

        /// <summary>
        /// Represents an error with the Azure OpenAI resource
        /// </summary>
        AoaiResourceError,

        /// <summary>
        /// Represents an error where the Azure OpenAI deployment was not found
        /// </summary>
        AoaiDeploymentNotFound,

        /// <summary>
        /// Represents an error where harmful content was detected
        /// </summary>
        HarmfulContentError,

        /// <summary>
        /// Represents an error where the Azure OpenAI deployment is invalid
        /// </summary>
        AoaiInvalidDeployment,

        /// <summary>
        /// Represents an error where the summarization rate limit is too low
        /// </summary>
        SummarizationRateLimitTooLowError
    }
}
