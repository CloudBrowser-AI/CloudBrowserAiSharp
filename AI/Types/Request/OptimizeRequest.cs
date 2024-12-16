using CloudBrowserAiSharp.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class OptimizeRequestT {
    public string Text { get; set; }
    public string Instruction { get; set; }
}

public class OptimizeRequest: OptimizeRequestT {
    public string ResponseFormat { get; set; }
}

internal class OptimizeRequestI : AIOptions {
    public string Text { get; set; }
    public string Instruction { get; set; }
    public string ResponseFormat { get; set; }

    public OptimizeRequestI(OptimizeRequest rq, AIOptions options) : base(options) {
        Text = rq.Text;
        Instruction = rq.Instruction;
        ResponseFormat = rq.ResponseFormat;
    }

}
