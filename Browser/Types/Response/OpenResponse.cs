namespace CloudBrowserAiSharp.Browser.Types.Response;

public class OpenResponse {
    /// <summary>
    /// Status of the response.
    /// </summary>
    public ResponseStatus Status { get; set; }

    /// <summary>
    /// Address to connect to the browser
    /// </summary>
    public string Address { get; set; }
}
