using CloudBrowserAiSharp.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class ToMarkdownRequest {
    /// <summary>
    /// The HTML content to be converted to Markdown.
    /// </summary>
    public string Html { get; set; }
}

internal class ToMarkdownRequestI : AIOptions {
    public string Html { get; set; }

    public ToMarkdownRequestI(ToMarkdownRequest rq, AIOptions options) : base(options) {
        Html = rq.Html;
    }

}
