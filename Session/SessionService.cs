using CloudBrowserAiSharp.Session.Client;
using CloudBrowserAiSharp.Session.Types.Request;
using CloudBrowserAiSharp.Session.Types.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudBrowserAiSharp;
public class SessionService(string _apiToken) {
    readonly SessionApiClient _client = new();
    public Uri BaseAddress { get => _client.BaseAddress; set => _client.BaseAddress = value; }

    public Task<ListResponse> List(TimeSpan? timeout = null, CancellationToken ct = default) => _client.List(_apiToken, timeout, ct);
    public Task<RemoveResponse> Remove(string label, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Remove(_apiToken, new(label) , timeout, ct);
}
