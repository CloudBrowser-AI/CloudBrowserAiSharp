using CloudBrowserAiSharp.Browser.Types;
using CloudBrowserAiSharp.Browser.Types.Request;
using CloudBrowserAiSharp.Browser.Types.Response;
using CloudBrowserAiSharp.Session.Types.Request;
using CloudBrowserAiSharp.Session.Types.Response;
using CloudBrowserAiSharp.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CloudBrowserAiSharp.Session.Client;

internal class SessionApiClient() : ClientBase(new Uri("https://production.cloudbrowser.ai")) {

    public Task<ListResponse> List(string token, TimeSpan? timeout = null, CancellationToken ct = default) => Get<ListResponse>("List", token, timeout, ct);
    public Task<RemoveResponse> Remove(string token, RemoveRequest rq, TimeSpan? timeout = null, CancellationToken ct = default) => Post<RemoveResponse, RemoveRequest>("Remove", token, rq, timeout, ct);

    Task<TRP> Post<TRP, TRQ>(string name, string token, TRQ rq, TimeSpan? timeout = null, CancellationToken ct = default) {
        var cli = GetClient();
        return DoPost<TRP, TRQ>(
            $"{cli.BaseAddress}api/v1/session/{name}",
            rq,
            new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } },
            timeout: timeout, ct: ct
        );
    }
    Task<TRP> Get<TRP>(string name, string token, TimeSpan? timeout = null, CancellationToken ct = default) {
        var cli = GetClient();
        return DoGet<TRP>(
            $"{cli.BaseAddress}api/v1/session/{name}",
            new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } },
            timeout: timeout, ct: ct
        );
    }
}
