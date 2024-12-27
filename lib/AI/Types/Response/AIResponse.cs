using CloudBrowserAiSharp.Browser.Types;

namespace CloudBrowserAiSharp.AI.Types.Response;

/// <summary>
/// Represents the different types of errors that can occur in the AI service.
/// </summary>
public enum AIError : byte {
    /// <summary>
    /// The error is unknown.
    /// </summary>
    UNKNOWN = 0,
    /// <summary>
    /// The content was flagged.
    /// </summary>
    CONTENT_FLAGGED = 1,
    /// <summary>
    /// The content is too long.
    /// </summary>
    TOO_LONG = 2,
    /// <summary>
    /// The API key is invalid.
    /// </summary>
    INVALID_API_KEY = 3,
    /// <summary>
    /// Not Enought quota
    /// </summary>
    QUOTA = 4
}


public class AIResponse {
    /// <summary>
    /// The status of the AI's response.
    /// </summary>
    public ResponseStatus Status { get; set; }
    /// <summary>
    /// The content of the AI's response.
    /// </summary>
    public string Response { get; set; }
    /// <summary>
    /// (Optional) Any error information, present only if ResponseStatus is AIError.
    /// </summary>
    public AIError? OpenAiError { get; set; }
}