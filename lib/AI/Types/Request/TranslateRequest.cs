using CloudBrowserAiSharp.AI.Types;
using System.Reflection.PortableExecutable;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class TranslateRequestT {
    public string Text { get; set; }
    public string IsoLang { get; set; }
}
public class TranslateRequest: TranslateRequestT {
    /// <summary>
    /// The format in which the AI should provide the response.
    /// </summary>
    public string ResponseFormat { get; set; }
}

internal class TranslateRequestI : AIOptions {
    public string Text { get; set; }
    public string IsoLang { get; set; }
    public string ResponseFormat { get; set; }

    public TranslateRequestI(TranslateRequest rq, AIOptions options) : base(options) {
        Text = rq.Text;
        IsoLang = rq.IsoLang;
        ResponseFormat = rq.ResponseFormat;
    }

}
