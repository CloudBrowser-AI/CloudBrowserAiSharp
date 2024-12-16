using CloudBrowserAiSharp.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class ToJSONRequest {
    public string Html { get; set; }
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
