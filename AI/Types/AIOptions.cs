

namespace CloudBrowserClient.AI.Types;

public class AIOptions {
    public OpenAIConfiguration OpenAIConfiguration { get; set; }

    public AIOptions() { }
    public AIOptions(AIOptions original) {
        OpenAIConfiguration = original.OpenAIConfiguration;
    }
}

public class OpenAIConfiguration {
    public string ApiKey { get; set; }
    public string Model { get; set; }
}