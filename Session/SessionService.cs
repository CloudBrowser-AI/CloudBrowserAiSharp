using CloudBrowserAiSharp.Session.Client;
using CloudBrowserAiSharp.Session.Types.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudBrowserAiSharp;
public class SessionService(string apiToken) {
    readonly SessionApiClient _client = new();

    /// <summary>
    /// Gets or sets the base address of the AI API client. By default, this is the public URL of the API, but it can be changed if needed.
    /// </summary>
    public Uri BaseAddress { get => _client.BaseAddress; set => _client.BaseAddress = value; }

    /// <summary>
    /// Retrieves the list of stored sessions.
    /// </summary>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task<ListResponse> List(TimeSpan? timeout = null, CancellationToken ct = default) => _client.List(apiToken, timeout, ct);

    /// <summary>
    /// Removes a stored session by its label.
    /// </summary>
    /// <param name="label">Label of the session to remove.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task<RemoveResponse> Remove(string label, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Remove(apiToken, new(label), timeout, ct);

}
