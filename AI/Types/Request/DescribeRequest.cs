using CloudBrowserClient.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class DescribeRequestT {
    public string Question { get; set; }
    public string Base64Image { get; set; }
}

public class DescribeRequest: DescribeRequestT {
    public string ResponseFormat { get; set; }
}

internal class DescribeRequestI: AIOptions {
    public string Question { get; set; }
    public string Base64Image { get; set; }
    public string ResponseFormat { get; set; }

    public DescribeRequestI(DescribeRequest rq, AIOptions options) : base(options) {
        Question = rq.Question;
        Base64Image = rq.Base64Image;
        ResponseFormat = rq.ResponseFormat;
    }

}

