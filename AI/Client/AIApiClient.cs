using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudBrowserClient.AI.Types.Response;
using CloudBrowserPublicApi.Shared.Data.AI.Request;

namespace CloudBrowserClient.AI.Client;

internal class AIApiClient() : ClientBase(new Uri("https://production.cloudbrowser.ai")) {

    public Uri BaseAddress { get => GetClient().BaseAddress; set => GetClient().BaseAddress = value; }

    public Task<AIResponse> Query(string apiKey, QueryRequestI rq, TimeSpan? timeout = null, CancellationToken ct = default) => Post<AIResponse, QueryRequestI>(apiKey, "query", rq, timeout, ct);
    public Task<AIResponse> Summarize(string apiKey, SummarizeRequestI rq, TimeSpan? timeout = null, CancellationToken ct = default) => Post<AIResponse, SummarizeRequestI>(apiKey, "summarize", rq, timeout, ct);
    public Task<AIResponse> Optimize(string apiKey, OptimizeRequestI rq, TimeSpan? timeout = null, CancellationToken ct = default) => Post<AIResponse, OptimizeRequestI>(apiKey, "optimize", rq, timeout, ct);
    public Task<AIResponse> Translate(string apiKey, TranslateRequestI rq, TimeSpan? timeout = null, CancellationToken ct = default) => Post<AIResponse, TranslateRequestI>(apiKey, "translate", rq, timeout, ct);
    public Task<AIResponse> Describe(string apiKey, DescribeRequestI rq, TimeSpan? timeout = null, CancellationToken ct = default) => Post<AIResponse, DescribeRequestI>(apiKey, "describe", rq, timeout, ct);
    public Task<AIResponse> ToJSON(string apiKey, ToJSONRequestI rq, TimeSpan? timeout = null, CancellationToken ct = default) => Post<AIResponse, ToJSONRequestI>(apiKey, "toJSON", rq, timeout, ct);
    public Task<AIResponse> ToCSV(string apiKey, ToCSVRequestI rq, TimeSpan? timeout = null, CancellationToken ct = default) => Post<AIResponse, ToCSVRequestI>(apiKey, "toCSV", rq, timeout, ct);
    public Task<AIResponse> ToMarkdown(string apiKey, ToMarkdownRequestI rq, TimeSpan? timeout = null, CancellationToken ct = default) => Post<AIResponse, ToMarkdownRequestI>(apiKey, "toMarkdown", rq, timeout, ct);


    Task<TRP> Post<TRP, TRQ>(string name, string token, TRQ rq, TimeSpan? timeout = null, CancellationToken ct = default) {
        var cli = GetClient();
        return DoPost<TRP, TRQ>(
            $"{cli.BaseAddress}api/v1/ai/{name}",
            rq,
            new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } },
            timeout: timeout, ct: ct
        );
    }
    Task<TRP> Get<TRP>(string name, string token, TimeSpan? timeout = null, CancellationToken ct = default) {
        var cli = GetClient();
        return DoGet<TRP>(
            $"{cli.BaseAddress}api/v1/ai/{name}",
            new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } },
            timeout: timeout, ct: ct
        );
    }
}