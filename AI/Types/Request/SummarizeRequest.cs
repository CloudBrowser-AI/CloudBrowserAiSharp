using CloudBrowserClient.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class SummarizeRequestT {
    public string Html { get; set; }
    public string IsoLang { get; set; }
}

public class SummarizeRequest: SummarizeRequestT {
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
