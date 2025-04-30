using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using VideoIntelligence.WebApp.Model;
using VideoIntelligence.WebApp.Services;

namespace VideoIntelligence.WebApp.Components.Chat;

/// <summary>
/// The chat component manages the conversation UI and interactions with the chat service.
/// </summary>
public partial class Chat
{
    /// <summary>
    /// Gets an instance of <see cref="ChatService"/> that handles processing of chat requests.
    /// This property is injected via dependency injection.
    /// </summary>
    [Inject]
    internal ChatService? ChatHandler { get; init; }

    [Inject]
    internal BlobService? BlobHandler { get; init; }

    [Inject]
    internal VideoService? VideoHandler { get; init; }

    /// <summary>
    /// Holds the collection of all chat messages exchanged in the conversation.
    /// </summary>
    List<Message> messages = new();

    /// <summary>
    /// References the DOM element used for capturing the user's message input.
    /// </summary>
    ElementReference writeMessageElement;

    /// <summary>
    /// Stores the current text entered by the user into the chat input.
    /// </summary>
    string? userMessageText;

    /// <summary>
    /// Called after the component has rendered.
    /// On first render, it loads a JavaScript module that attaches
    /// an event listener to the message input element to allow submission on "Enter" key press.
    /// </summary>
    /// <param name="firstRender">Indicates whether this is the first render of the component.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {
                // Load the JavaScript module associated with this component.
                await using var module = await JS.InvokeAsync<IJSObjectReference>("import", "./Components/Chat/Chat.razor.js");

                // Attach the "submitOnEnter" JavaScript function to the input element.
                await module.InvokeVoidAsync("submitOnEnter", writeMessageElement);
            }
            catch (JSDisconnectedException)
            {
                // Not an error
            }
        }
    }

    /// <summary>
    /// Initiates sending a chat message. This method performs several operations:
    /// 1. Validates that the chat service is available and the user input is not empty.
    /// 2. Updates the UI by adding the user's message.
    /// 3. Creates a <see cref="ChatRequest"/> from the current message history and sends it to the chat service.
    /// 4. Streams the assistant's reply in incremental chunks and updates the UI accordingly.
    /// </summary>
    /// <returns>A task that represents the asynchronous send message operation.</returns>
    async void SendMessage()
    {
        // Ensure that the chat service handler has been injected.
        if (ChatHandler is null) { return; }

        // Only send the message if userMessageText is not null, empty, or whitespace.
        if (!string.IsNullOrWhiteSpace(userMessageText))
        {
            // Add the user's message to the UI
            // TODO: Don't rely on "magic strings" for the Role
            messages.Add(new Message() {
                IsAssistant = false,
                Content = userMessageText
                });

            // Clear the user input after the message has been captured.
            userMessageText = null;

            // Create a chat request with the current message history.
            ChatRequest request = new ChatRequest(messages);

            // Insert a temporary assistant message to indicate that a response is being generated.
            Message assistantMessage = new Message() {
                IsAssistant = true,
                Content = ""
                };
            messages.Add(assistantMessage);

            // Notify the UI of state changes.
            StateHasChanged();

            // Request a streaming response from the chat service.
            IAsyncEnumerable<string> chunks = ChatHandler.Stream(request);

            // Process each incoming chunk by appending it to the assistant's message.
            await foreach (var chunk in chunks)
            {
                assistantMessage.Content += chunk;

                // Update the UI on each streaming chunk.
                StateHasChanged();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    private async Task HandleFileSelected(InputFileChangeEventArgs e)
    {
        // Ensure that the chat service handler has been injected.
        if (VideoHandler is null) { return; }
        foreach (var file in e.GetMultipleFiles())
        {
            var fileName = file.Name;
            var fileSize = file.Size;

            // Read file content as a stream
            using var stream = file.OpenReadStream(maxAllowedSize: 200 * 1024 * 1024); // Limit to 200 MB
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);

            byte[] fileBytes = memoryStream.ToArray(); // Convert file content to byte array

            string videoId = await VideoHandler.FileUploadAsync(fileBytes, fileName, file.ContentType);

            if (!string.IsNullOrWhiteSpace(videoId))
            {
                userMessageText = $"The video was uploaded with success with a unique identifier {videoId}";
                SendMessage();
            }
        }

        //userMessageText = $"The video was uploaded with success with a unique identifier i9ib9vqapl";
        //SendMessage();
        
    }

}