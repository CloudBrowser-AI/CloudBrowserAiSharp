using CloudBrowserAiSharp.AI.Types;
using System.Runtime.CompilerServices;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class ToCSVRequest {
    /// <summary>
    /// The HTML content to be converted to CSV.
    /// </summary>
    public string Html { get; set; }
    /// <summary>
    /// (Optional) The headers to be included in the CSV file.
    /// </summary>
    public string Headers { get; set; }
    /// <summary>
    /// The format in which the AI should provide the response.
    /// </summary>
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