using CloudBrowserAiSharp.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class SummarizeRequestT {
    /// <summary>
    /// The HTML content to be summarized.
    /// </summary>
    public string Html { get; set; }
    /// <summary>
    /// (Optional) The ISO language code indicating the language in which the summary should be provided.
    /// </summary>
    public string IsoLang { get; set; }
}


public class SummarizeRequest: SummarizeRequestT {
    /// <summary>
    /// The format in which the AI should provide the response.
    /// </summary>
    public string ResponseFormat { get; set; }
}

internal class SummarizeRequestI : AIOptions {
    public string Html { get; set; }
    public string IsoLang { get; set; }
    public string ResponseFormat { get; set; }

    public SummarizeRequestI(SummarizeRequest rq, AIOptions options) : base(options) {
        Html = rq.Html;
        IsoLang = rq.IsoLang;
        ResponseFormat = rq.ResponseFormat;
    }

}
