using CloudBrowserClient.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class QueryRequestT {
    public string Html { get; set; }
    public string Promt { get; set; }
}

public class QueryRequest: QueryRequestT {
    public string ResponseFormat { get; set; }
}

internal class QueryRequestI: AIOptions {
    public string Html { get; set; }
    public string Promt { get; set; }
    public string ResponseFormat { get; set; }

    public QueryRequestI(QueryRequest rq, AIOptions options): base(options) {
        Html = rq.Html;
        Promt = rq.Promt;
        ResponseFormat = rq.ResponseFormat;
    }

}
