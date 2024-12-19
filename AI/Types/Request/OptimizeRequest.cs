using CloudBrowserAiSharp.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class OptimizeRequestT {
    /// <summary>
    /// The text to be optimized.
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// The instructions on how to optimize the text.
    /// </summary>
    public string Instruction { get; set; }
}

public class OptimizeRequest: OptimizeRequestT {
    /// <summary>
    /// The format in which the AI should provide the response.
    /// </summary>
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
