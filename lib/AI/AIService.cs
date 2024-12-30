using System;
using System.Threading;
using System.Threading.Tasks;
using CloudBrowserAiSharp.AI.Client;
using CloudBrowserAiSharp.AI.Types;
using CloudBrowserAiSharp.AI.Types.Response;
using CloudBrowserAiSharp.Serialization;
using CloudBrowserPublicApi.Shared.Data.AI.Request;

namespace CloudBrowserAiSharp;

/// <summary>
/// Service to communicate with the AI API from Cloudbrowser.AI
/// </summary>
public class AIService: IDisposable {

    readonly AIApiClient _client = new();

    readonly string apiToken;
    readonly AIOptions defaultAIOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="AIService"/> class
    /// </summary>
    /// <param name="apiToken">The CloudBrowser.AI API token for authentication.</param>
    /// <param name="defaultAIOptions">The default AI options to use for requests, which can be overridden in each call if needed.</param>
    public AIService(string apiToken, AIOptions defaultAIOptions = null) {
        this.apiToken = apiToken;
        this.defaultAIOptions = defaultAIOptions;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AIService"/> class
    /// </summary>
    /// <param name="apiToken">The CloudBrowser.AI API token for authentication.</param>
    /// <param name="openAiToken">The OpenAI token for authentication, which can be overridden in each call if needed.</param>
    /// <param name="openAiModel">The OpenAI model to use for requests, which can be overridden in each call if needed.</param>
    public AIService(string apiToken, string openAiToken, string openAiModel = null) {
        this.apiToken = apiToken;
        this.defaultAIOptions = new() {
            OpenAIConfiguration = new() {
                ApiKey = openAiToken,
                Model = openAiModel
            }
        };
    }

    /// <summary>
    /// Gets or sets the base address of the AI API client. By default, this is the public URL of the API, but it can be changed if needed.
    /// </summary>
    public Uri BaseAddress { get => _client.BaseAddress; set => _client.BaseAddress = value; }

    /// <summary>
    /// Method to perform an AI query over HTML content.
    /// </summary>
    /// <param name="rq">The query request containing the HTML content and the specific query.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the query.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the query if needed.</param>
    /// <returns>The AI response.</returns>
    public Task<AIResponse> Query(QueryRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Query(apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);

    /// <summary>
    /// Method to summarize HTML content in the language of your choice.
    /// </summary>
    /// <param name="rq">The summarize request containing the HTML content.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The AI response.</returns>
    public Task<AIResponse> Summarize(SummarizeRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Summarize(apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);

    /// <summary>
    /// Optimizes a given text based on an instruction.
    /// </summary>
    /// <param name="rq">The request containing the text to be optimized.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The AI response.</returns>
    public Task<AIResponse> Optimize(OptimizeRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Optimize(apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);

    /// <summary>
    /// Translates the provided text.
    /// </summary>
    /// <param name="rq">The request containing the text to be translated.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The AI response.</returns>
    public Task<AIResponse> Translate(TranslateRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Translate(apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);

    /// <summary>
    /// Analyzes an image and answers a question about it.
    /// </summary>
    /// <param name="rq">The describe request containing the image in base64 format.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The AI response.</returns>
    public Task<AIResponse> Describe(DescribeRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.Describe(apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
    
    /// <summary>
    /// Converts HTML content to JSON format.
    /// </summary>
    /// <param name="rq">The request containing the HTML to be converted.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The AI response.</returns>
    public Task<AIResponse> ToJSON(ToJSONRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.ToJSON(apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);

    /// <summary>
    /// Converts HTML content to CSV format.
    /// </summary>
    /// <param name="rq">The request containing the HTML to be converted.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The AI response.</returns>
    public Task<AIResponse> ToCSV(ToCSVRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.ToCSV(apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);

    /// <summary>
    /// Converts HTML content to Markdown format.
    /// </summary>
    /// <param name="rq">The request containing the HTML to be converted.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The AI response.</returns>
    public Task<AIResponse> ToMarkdown(ToMarkdownRequest rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) => _client.ToMarkdown(apiToken, new(rq, aiOptions ?? defaultAIOptions), timeout, ct);
   
    /// <summary>
    /// Performs an AI query over HTML content and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the response should be deserialized.</typeparam>
    /// <param name="rq">The query request containing the HTML and the prompt.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The deserialized AI response.</returns>
    public Task<T> Query<T>(QueryRequestT rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.Query(apiToken, new(new() {
            Html = rq.Html,
            Prompt = rq.Prompt,
            ResponseFormat = Serializer.ToResponseFormat<T>()
        }, aiOptions ?? defaultAIOptions), timeout, ct));
    }

    /// <summary>
    /// Summarizes HTML content and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the response should be deserialized.</typeparam>
    /// <param name="rq">The summarize request containing the HTML content and the language code.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The deserialized AI response.</returns>
    public Task<T> Summarize<T>(SummarizeRequestT rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.Summarize(apiToken, new(new() {
            Html = rq.Html,
            IsoLang = rq.IsoLang,
            ResponseFormat = Serializer.ToResponseFormat<T>()
        }, aiOptions ?? defaultAIOptions), timeout, ct));
    }

    /// <summary>
    /// Optimizes text based on the provided instruction and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the response should be deserialized.</typeparam>
    /// <param name="rq">The optimize request.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The deserialized AI response.</returns>
    public Task<T> Optimize<T>(OptimizeRequestT rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.Optimize(apiToken, new(new() {
            Instruction = rq.Instruction,
            Text = rq.Text,
            ResponseFormat = Serializer.ToResponseFormat<T>()
        }, aiOptions ?? defaultAIOptions), timeout, ct));
    }

    /// <summary>
    /// Translates text and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the response should be deserialized.</typeparam>
    /// <param name="rq">The translate request.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The deserialized AI response.</returns>
    public Task<T> Translate<T>(TranslateRequestT rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.Translate(apiToken, new(new() {
            IsoLang = rq.IsoLang,
            Text = rq.Text,
            ResponseFormat = Serializer.ToResponseFormat<T>()
        }, aiOptions ?? defaultAIOptions), timeout, ct));
    }

    /// <summary>
    /// Analyzes an image and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the response should be deserialized.</typeparam>
    /// <param name="rq">The describe request.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The deserialized AI response.</returns>
    public Task<T> Describe<T>(DescribeRequestT rq, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.Describe(apiToken, new(new() {
            Base64Image = rq.Base64Image,
            ImageUrl = rq.ImageUrl,
            Question = rq.Question,
            ResponseFormat = Serializer.ToResponseFormat<T>()
        }, aiOptions ?? defaultAIOptions), timeout, ct));
    }

    /// <summary>
    /// Converts HTML content to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the response should be deserialized.</typeparam>
    /// <param name="html">The HTML content to be converted.</param>
    /// <param name="aiOptions">Optional parameter to override the default AI options.</param>
    /// <param name="timeout">Optional parameter to specify a timeout for the request.</param>
    /// <param name="ct">Optional parameter for a cancellation token to cancel the request if needed.</param>
    /// <returns>The deserialized AI response.</returns>
    public Task<T> To<T>(string html, AIOptions aiOptions = null, TimeSpan? timeout = null, CancellationToken ct = default) {
        return Serializer.ToObject<T>(_client.ToJSON(apiToken, new(new() {
            Html = html,
            ResponseFormat = Serializer.ToResponseFormat<T>()
        }, aiOptions ?? defaultAIOptions), timeout, ct));
    }

    /// <summary>
    /// This class can produce multiple clients, which is why it is important to dispose of this object if it is not going to be used anymore.
    /// </summary>
    public void Dispose() {
        _client?.Dispose();
    }
}





