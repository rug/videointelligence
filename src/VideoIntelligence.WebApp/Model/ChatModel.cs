namespace VideoIntelligence.WebApp.Model;

/// <summary>
/// Represents a chat request containing a collection of messages to be processed in a conversation.
/// </summary>
public record ChatRequest(List<Message> Messages)
{
    // This record aggregates all conversation messages.
};

/// <summary>
/// Represents an individual chat message within a conversation.
/// </summary>
public record Message
{
    /// <summary>
    /// Gets or sets a value indicating whether the message was sent by the assistant.
    /// If <c>true</c>, the message originates from the AI or chatbot; otherwise, it is from the user.
    /// </summary>
    public required bool IsAssistant { get; set; }

    /// <summary>
    /// Gets or sets the content of the message.
    /// This contains the text of the message sent either by the user or the assistant.
    /// </summary>
    public required string Content { get; set; }
}
