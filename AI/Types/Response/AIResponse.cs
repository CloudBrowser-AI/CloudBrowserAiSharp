using CloudBrowserClient.Browser.Types;

namespace CloudBrowserClient.AI.Types.Response;

public enum AIError : byte {
    UNKNOWN = 0,
    CONTENT_FLAGGED = 1,
    TOO_LONG = 2,
    INVALID_API_KEY = 3
}

public class AIResponse {
    public ResponseStatus Status { get; set; }
    public string Response { get; set; }
    public AIError? OpenAiError { get; set; }
}