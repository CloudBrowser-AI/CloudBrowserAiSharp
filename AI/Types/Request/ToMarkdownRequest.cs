using CloudBrowserAiSharp.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class ToMarkdownRequest {
    public string Html { get; set; }
}
internal class ToMarkdownRequestI : AIOptions {
    public string Html { get; set; }

    public ToMarkdownRequestI(ToMarkdownRequest rq, AIOptions options) : base(options) {
        Html = rq.Html;
    }

}
