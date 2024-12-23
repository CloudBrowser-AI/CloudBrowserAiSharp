namespace CloudBrowserAiSharp.Browser.Types.Response;

public class SimpleResponse {
    /// <summary>
    /// Indicates whether the operation was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Details of any error that occurred.
    /// </summary>
    public ErrorRemoteDesktop Error { get; set; }
}
