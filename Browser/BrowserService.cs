using System;
using System.Threading;
using System.Threading.Tasks;
using CloudBrowserAiSharp.Browser.Client;
using CloudBrowserAiSharp.Browser.Types;
using CloudBrowserAiSharp.Browser.Types.Response;

namespace CloudBrowserAiSharp;

/// <summary>
/// Service to communicate with the Browser API from Cloudbrowser.AI
/// </summary>
/// <param name="apiToken">The API token for authentication.</param>
public class BrowserService(string apiToken) {

    readonly BrowserApiClient _client = new();

    /// <summary>
    /// Gets or sets the base address of the AI API client. By default, this is the public URL of the API, but it can be changed if needed.
    /// </summary>
    public Uri BaseAddress { get => _client.BaseAddress; set => _client.BaseAddress = value; }

    /// <summary>
    /// Opens a new browser
    /// </summary>
    /// <param name="options">Options for opening the browser.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task<OpenResponse> Open(BrowserOptions options = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Open(apiToken, options, timeout: timeout, ct: ct);

    /// <summary>
    /// Retrieves the list of currently open browsers.
    /// </summary>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task<GetResponse> Get(TimeSpan? timeout = null, CancellationToken ct = default) => _client.Get(apiToken, timeout: timeout, ct: ct);

    /// <summary>
    /// Closes the browser at the specified address.
    /// </summary>
    /// <param name="address">Address of the browser to close.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task<SimpleResponse> Close(string address, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Close(apiToken, new(address), timeout: timeout, ct: ct);

    /// <summary>
    /// Starts a remote desktop session.
    /// </summary>
    /// <param name="address">Address of the browser you want to open the desktop session.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task<StartRemoteDesktopResponse> StartRemoteDesktop(string address, TimeSpan? timeout = null, CancellationToken ct = default) => _client.StartRemoteDesktop(apiToken, new(address), timeout: timeout, ct: ct);

    /// <summary>
    /// Stops the remote desktop session
    /// </summary>
    /// <param name="address">Address of the browser you want to close the remote desktop session.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task<StoptRemoteDesktopResponse> StopRemoteDesktop(string address, TimeSpan? timeout = null, CancellationToken ct = default) => _client.StopRemoteDesktop(apiToken, new(address), timeout: timeout, ct: ct);

}

