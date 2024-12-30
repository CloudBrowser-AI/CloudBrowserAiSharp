using CloudBrowserAiSharp.Browser.Types;
using CloudBrowserAiSharp;
using PuppeteerSharp;

namespace AIOptimize;

internal class Program {

    const string clToken = "YOUR CLOUDBROWSER.AI TOKEN";
    const string openAiToken = "YOUR OPEN AI TOKEN";

    static async Task Main(string[] args) {
        using AIService ai = new(clToken, new() {
            OpenAIConfiguration = new() {
                ApiKey = openAiToken,
            }
        });

        //Response format can be created manually but it is easier to use a type
        //await ai.Optimize(new() {
            //Text= "FakeBrand Boa XL Max Water Pump Pliers in a Festive Christmas Ornament",
            //Instruction= "SEO for an online store product title"
        //}).ConfigureAwait(false);

        var rpai = await ai.Optimize<string>(new() {
            Text= "FakeBrand Boa XL Max Water Pump Pliers in a Festive Christmas Ornament",
            Instruction= "SEO for an online store product title"
        }).ConfigureAwait(false);

        Console.WriteLine("Optimized title: {0}", rpai);
    }

}
