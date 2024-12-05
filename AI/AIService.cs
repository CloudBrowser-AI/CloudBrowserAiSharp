using System;
using System.Threading;
using System.Threading.Tasks;
using CloudBrowserClient.AI.Client;
using CloudBrowserClient.AI.Types;
using CloudBrowserClient.AI.Types.Response;
using CloudBrowserClient.Serialization;
using CloudBrowserPublicApi.Shared.Data.AI.Request;

namespace CloudBrowserClient.AI;

public class AIService(string _apiToken, AIOptions defaultAIOptions = null) {

    readonly AIApiClient _client = new();


    public Task<AIResponse> Query(QueryRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Query(_apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> Summarize(SummarizeRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Summarize(_apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> Optimize(OptimizeRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Optimize(_apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> Translate(TranslateRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Translate(_apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> Describe(DescribeRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Describe(_apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> ToJSON(ToJSONRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.ToJSON(_apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> ToCSV(ToCSVRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.ToCSV(_apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    public Task<AIResponse> ToMarkdown(ToMarkdownRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.ToMarkdown(_apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);



    public Task<T> Query<T>(QueryRequestT rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.Query(_apiToken, new(new() {
            Html = rq.Html,
            Promt = rq.Promt,
            ResponseFormat = Serializer.ToResponseFormat<T>()
        },
        aiOptions ?? defaultAIOptions), timeout, ct));
    }
    public Task<T> Summarize<T>(SummarizeRequestT rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.Summarize(_apiToken, new(new() {
            Html = rq.Html,
            IsoLang = rq.IsoLang,
            ResponseFormat = Serializer.ToResponseFormat<T>()
        }, aiOptions ?? defaultAIOptions), timeout, ct));
    }
    public Task<T> Optimize<T>(OptimizeRequestT rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.Optimize(_apiToken,
            new(new() {
                Instruction = rq.Instruction,
                Text = rq.Text,
                ResponseFormat = Serializer.ToResponseFormat<T>()
            }, aiOptions ?? defaultAIOptions), timeout, ct));
    }
    public Task<T> Translate<T>(TranslateRequestT rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.Translate(_apiToken, new(new() {
            IsoLang = rq.IsoLang,
            Text = rq.Text,
            ResponseFormat = Serializer.ToResponseFormat<T>()
        }, aiOptions ?? defaultAIOptions), timeout, ct));
    }
    public Task<T> Describe<T>(DescribeRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.Describe(_apiToken, new(new() {
            Base64Image = rq.Base64Image,
            Question = rq.Question,
            ResponseFormat = Serializer.ToResponseFormat<T>()
        }, aiOptions ?? defaultAIOptions), timeout, ct));
    }
    public Task<T> To<T>(string html, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.ToJSON(_apiToken, new(new() { 
            Html = html, 
            ResponseFormat = Serializer.ToResponseFormat<T>() 
        }, aiOptions ?? defaultAIOptions), timeout, ct));
    }

}
