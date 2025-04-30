using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using VideoIntelligence.WebApp.Model;

namespace VideoIntelligence.WebApp.Services;

/// <summary>
/// Provides chat functionalities by interfacing with the chat completion service,
/// including both a single-response chat and a streaming mode.
/// </summary>
internal class ChatService
{
    /// <summary>
    /// The underlying chat completion service used to generate chat responses.
    /// </summary>
    private readonly IChatCompletionService _chatService;
    private readonly Kernel _kernel;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChatService"/> class.
    /// </summary>
    /// <param name="chatService">
    /// The chat completion service that communicates with Azure OpenAI.
    /// </param>
    /// <param name="kernel">
    /// The configured Semantic Kernel instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if any of the dependencies are null.
    /// </exception>
    public ChatService(IChatCompletionService chatService, Kernel kernel)
    {
        _chatService = chatService ?? throw new ArgumentNullException(nameof(chatService));
        _kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
    }

    /// <summary>
    /// Sends a chat request to the chat completion service and returns the assistant's response as a single message.
    /// </summary>
    /// <param name="request">The chat request containing the conversation history.</param>
    /// <returns>
    /// A task representing the asynchronous operation,
    /// with a <see cref="Message"/> result containing the assistant's reply.
    /// </returns>
    internal async Task<Message> Chat(ChatRequest request)
    {
        // Create a conversation history from the provided chat request.
        ChatHistory history = CreateHistoryFromRequest(request);

        // Create streaming options with the desired behavior.
        var promptExecutionSettings = new PromptExecutionSettings
        {
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
        };

        // Retrieve the chat message content asynchronously from the chat completion service.
        ChatMessageContent response = await _chatService.GetChatMessageContentAsync(history, promptExecutionSettings, _kernel);

        // Construct and return a Message record based on the response.
        return new Message()
        {
            // Determine if the message was sent by the assistant by comparing roles.
            IsAssistant = response.Role == AuthorRole.Assistant,
            // Extract the text from the first item in the response items (assumed to be TextContent).
            Content = (response.Items[0] as TextContent)?.Text ?? string.Empty
        };
    }

    /// <summary>
    /// Streams chat message content from the chat completion service asynchronously.
    /// </summary>
    /// <param name="request">The chat request containing the conversation history.</param>
    /// <returns>
    /// An asynchronous enumerable of strings representing each streamed chat message content.
    /// </returns>
    internal async IAsyncEnumerable<string> Stream(ChatRequest request)
    {

        // Create the conversation history from the request.
        ChatHistory history = CreateHistoryFromRequest(request);

        // Create streaming options with the desired behavior.
        var promptExecutionSettings = new PromptExecutionSettings
        {
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
        };

        // Retrieve the streaming chat message content as an asynchronous enumerable.
        IAsyncEnumerable<StreamingChatMessageContent> response = _chatService.GetStreamingChatMessageContentsAsync(history
            , promptExecutionSettings, _kernel);

        // Stream each content item from the response.
        await foreach (StreamingChatMessageContent content in response)
        {
            yield return content.Content ?? "";
        }
    }

    /// <summary>
    /// Creates a <see cref="ChatHistory"/> object from the provided chat request.
    /// This helper method initializes the conversation with a default system prompt
    /// and adds all user and assistant messages in sequential order.
    /// </summary>
    /// <param name="request">The chat request containing the list of chat messages.</param>
    /// <returns>A <see cref="ChatHistory"/> representing the conversation history.</returns>
    private static ChatHistory CreateHistoryFromRequest(ChatRequest request)
    {
        // Initialize the chat history with a system prompt.
        ChatHistory history = new ChatHistory(@"You are a helpful assistant, specialized in analyzing information about videos. 
                                                When the user asks you to create a webpage about the video, you first get all the transcription and content, then you create the webpage using html and Bootstrap, and save it. Then you give the link to the user. 
                                                A webpage about the video must have an initial section with the summary, and then the complete description of the video content including images.
                                                When the user asks you to create a quiz based on the video, you first get all the transcription and content, and use them to create a multi choice quiz in a webpage using html and Bootstrap, and add a final button that checks the answers and explains the right answer, and finally save it with the provided function. Do not show the HTML to the user, save the webpage and show the link to the user. When an answer is wrong put the message right under the question.                                              
                                                When you receive from the user a message like 'The video was uploaded with success with a unique identifier', respond to the user that now you have all video content and the user can ask you anything about the video.
                                                If the user ask something and you don't have video unique identifier, ask the user to upload a video. Don't do it if the user give you a url video analysis.
                                                Always tell to the user what are you doing step by step.");

        // Iterate through each message in the chat request and add it to the chat history,
        // distinguishing between messages from the assistant and the user.
        foreach (Message message in request.Messages)
        {
            if (message.IsAssistant)
            {
                history.AddAssistantMessage(message.Content);
            }
            else
            {
                history.AddUserMessage(message.Content);
            }
        }

        return history;
    }
}