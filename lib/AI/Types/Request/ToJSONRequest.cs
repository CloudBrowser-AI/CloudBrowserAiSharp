using CloudBrowserAiSharp.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class ToJSONRequest {
    /// <summary>
    /// The HTML content to be converted to JSON.
    /// </summary>
    public string Html { get; set; }
    /// <summary>
    /// The format in which the AI should provide the response.
    /// </summary>
    public string ResponseFormat { get; set; }
}

internal class ToJSONRequestI : AIOptions {
    public string Html { get; set; }
    public string ResponseFormat { get; set; }

    public ToJSONRequestI(ToJSONRequest rq, AIOptions options) : base(options) {
        Html = rq.Html;
        ResponseFormat = rq.ResponseFormat;
    }

}
