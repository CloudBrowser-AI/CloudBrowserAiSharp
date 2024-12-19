namespace CloudBrowserAiSharp.Browser.Types.Response;

public class StartRemoteDesktopResponse {
    /// <summary>
    /// Indicates whether the operation was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Details of any error that occurred.
    /// </summary>
    public ErrorRemoteDesktop Error { get; set; }

    /// <summary>
    /// Password for the remote desktop session.
    /// </summary>
    public string Password { get; set; }
}
