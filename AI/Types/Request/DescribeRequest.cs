using CloudBrowserAiSharp.AI.Types;

namespace CloudBrowserPublicApi.Shared.Data.AI.Request;

public class DescribeRequestT {
    /// <summary>
    /// The question to be asked to the AI.
    /// </summary>
    public string Question { get; set; }
    /// <summary>
    /// The image in Base64 format to be analyzed by the AI. If ImageUrl is set, this is not needed
    /// </summary>
    public string Base64Image { get; set; }
    /// <summary>
    /// The url from the image to be analyzed by the AI. If Base64Image is set, this is not needed
    /// </summary>
    public string ImageUrl { get; set; }
}

public class DescribeRequest: DescribeRequestT {
    /// <summary>
    /// The format in which the AI should provide the response.
    /// </summary>
    public string ResponseFormat { get; set; }
}


internal class DescribeRequestI: AIOptions {
    public string Question { get; set; }
    public string Base64Image { get; set; }
    public string ImageUrl { get; set; }
    public string ResponseFormat { get; set; }

    public DescribeRequestI(DescribeRequest rq, AIOptions options) : base(options) {
        Question = rq.Question;
        Base64Image = rq.Base64Image;
        ImageUrl = rq.ImageUrl;
        ResponseFormat = rq.ResponseFormat;
    }

}

