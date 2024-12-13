using CloudBrowserClient.Session.Client;
using CloudBrowserClient.Session.Types.Request;
using CloudBrowserClient.Session.Types.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudBrowserClient;
public class SessionService(string _apiToken) {
    readonly SessionApiClient _client = new();

    public Task<ListResponse> List(TimeSpan? timeout = null, CancellationToken ct = default) => _client.List(_apiToken, timeout, ct);
    public Task<RemoveResponse> Remove(string label, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Remove(_apiToken, new(label) , timeout, ct);
}
