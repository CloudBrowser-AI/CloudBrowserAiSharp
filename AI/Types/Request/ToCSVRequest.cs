using CloudBrowserClient.AI.Types;
using System.Runtime.CompilerServices;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class ToCSVRequest {
    public string Html { get; set; }
    public string Headers { get; set; }
    public string ResponseFormat { get; set; }
}

internal class ToCSVRequestI : AIOptions {
    public string Html { get; set; }
    public string Headers { get; set; }
    public string ResponseFormat { get; set; }

    public ToCSVRequestI(ToCSVRequest rq, AIOptions options) : base(options) {
        Html = rq.Html;
        Headers = rq.Headers;
        ResponseFormat = rq.ResponseFormat;
    }

}