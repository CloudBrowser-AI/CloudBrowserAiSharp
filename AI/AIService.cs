using System;
using System.Threading;
using System.Threading.Tasks;
using CloudBrowserClient.AI.Client;
using CloudBrowserClient.AI.Types;
using CloudBrowserClient.AI.Types.Response;
using CloudBrowserClient.Browser.Types;
using CloudBrowserClient.Browser.Types.Response;
using CloudBrowserPublicApi.Shared.Data.AI.Request;

namespace CloudBrowserClient.AI;

public class AIService(string _apiToken, AIOptions defaultAIOptions = null) {

    readonly AIApiClient _client = new();


    public Task<AIResponse> Query(string apiKey, QueryRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Query(apiKey, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> Summarize(string apiKey, SummarizeRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Summarize(apiKey, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> Optimize(string apiKey, OptimizeRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Optimize(apiKey, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> Translate(string apiKey, TranslateRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Translate(apiKey, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> Describe(string apiKey, DescribeRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Describe(apiKey, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> ToJSON(string apiKey, ToJSONRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.ToJSON(apiKey, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> ToCSV(string apiKey, ToCSVRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.ToCSV(apiKey, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> ToMarkdown(string apiKey, ToMarkdownRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.ToMarkdown(apiKey, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);

}
