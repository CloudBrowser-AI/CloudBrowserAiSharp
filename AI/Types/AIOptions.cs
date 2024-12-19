

namespace CloudBrowserAiSharp.AI.Types;

public class AIOptions {
    /// <summary>
    /// The configuration settings for OpenAI.
    /// </summary>
    public OpenAIConfiguration OpenAIConfiguration { get; set; }

    public AIOptions() { }
    public AIOptions(AIOptions original) {
        OpenAIConfiguration = original.OpenAIConfiguration;
    }
}

public class OpenAIConfiguration {
    /// <summary>
    /// The API key for accessing OpenAI services.
    /// </summary>
    public string ApiKey { get; set; }
    /// <summary>
    /// The model to be used for OpenAI services
    /// </summary>
    public string Model { get; set; }
}
