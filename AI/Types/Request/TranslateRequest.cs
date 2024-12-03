using CloudBrowserClient.AI.Types;
using System.Reflection.PortableExecutable;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class TranslateRequest {
    public string Text { get; set; }
    public string IsoLang { get; set; }
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
