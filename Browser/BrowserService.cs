using System;
using System.Threading;
using System.Threading.Tasks;
using CloudBrowserClient.Browser.Client;
using CloudBrowserClient.Browser.Types;
using CloudBrowserClient.Browser.Types.Response;

namespace CloudBrowserClient;

public class BrowserService(string _apiToken){

    readonly BrowserApiClient _client = new();
    public Uri BaseAddress { get => _client.BaseAddress; set => _client.BaseAddress = value; }

    public Task<OpenResponse> Open(BrowserOptions options = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Open(_apiToken, options, timeout: timeout, ct: ct);

    public Task<GetResponse> Get(TimeSpan? timeout = null, CancellationToken ct = default) => _client.Get(_apiToken, timeout: timeout, ct: ct);

    public Task<SimpleResponse> Close(string address, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Close(_apiToken, new(address), timeout: timeout, ct: ct);

    public Task<StartRemoteDesktopResponse> StartRemoteDesktop(string address, TimeSpan? timeout = null, CancellationToken ct = default) => _client.StartRemoteDesktop(_apiToken, new(address), timeout: timeout, ct: ct);

    public Task<StoptRemoteDesktopResponse> StopRemoteDesktop(string address, TimeSpan? timeout = null, CancellationToken ct = default) => _client.StopRemoteDesktop(_apiToken, new(address), timeout: timeout, ct: ct);

}
