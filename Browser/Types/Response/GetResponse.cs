using System;

namespace CloudBrowserAiSharp.Browser.Types.Response;

public class GetResponse {
    /// <summary>
    /// Error status of the response.
    /// </summary>
    public ResponseStatus Error { get; set; }

    /// <summary>
    /// Array of browser sessions included in the response.
    /// </summary>
    public BrowserData[] Browsers { get; set; }
}

public class BrowserData {
    /// <summary>
    /// Date and time when the browser session started.
    /// </summary>
    public DateTime StartedOn { get; set; }

    /// <summary>
    /// Label of the browser session.
    /// </summary>
    public string Label { get; set; }

    /// <summary>
    /// Address of the browser session.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Remote desktop password for the browser session. If it is null, remote desktop is closed.
    /// </summary>
    public string VNCPass { get; set; }
}

