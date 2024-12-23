using CloudBrowserAiSharp.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class QueryRequestT {
    /// <summary>
    /// The HTML content to be processed.
    /// </summary>
    public string Html { get; set; }
    /// <summary>
    /// The prompt with instructions on what to do with the HTML content.
    /// </summary>
    public string Prompt { get; set; }
}

public class QueryRequest: QueryRequestT {
    /// <summary>
    /// The format in which the AI should provide the response.
    /// </summary>
    public string ResponseFormat { get; set; }
}

internal class QueryRequestI: AIOptions {
    public string Html { get; set; }
    public string Prompt { get; set; }
    public string ResponseFormat { get; set; }

    public QueryRequestI(QueryRequest rq, AIOptions options): base(options) {
        Html = rq.Html;
        Prompt = rq.Prompt;
        ResponseFormat = rq.ResponseFormat;
    }

}
