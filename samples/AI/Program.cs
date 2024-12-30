using CloudBrowserAiSharp;
using CloudBrowserAiSharp.Browser.Types;
using PuppeteerSharp;

namespace AIQuery;

internal class Program {

    const string cloudBrowserToken = "YOUR CLOUDBROWSER.AI TOKEN";
    const string openAiToken = "YOUR OPEN AI TOKEN";

    static async Task Main(string[] args) {

        var html = await GetHTML("http://www.cloudbrowser.ai").ConfigureAwait(false);

        if (html == null) return;

        using AIService ai = new(cloudBrowserToken, openAiToken);

        //Response format can be created manually but it is easier to use a type
        //await ai.Query(new() {
        //Html = html,
        //Prompt = "Give me the lowest price",
        //ResponseFormat = "{\"response\":\"number\", \"required\":[\"response\"]}"
        //}).ConfigureAwait(false);

        var rpai = await ai.Query<decimal>(new() {
            Html = html,
            Prompt = "Give me the lowest price"
        }).ConfigureAwait(false);

        Console.WriteLine("The lowest price is: {0}", rpai);
    }

    static async Task<string?> GetHTML(string address) {
        using BrowserService svc = new(cloudBrowserToken);

        var rp = await svc.Open().ConfigureAwait(false);

        if (rp.Status == ResponseStatus.Succes) {
            Console.WriteLine("Browser requested");
        } else {
            Console.WriteLine("Error requesting browser: {0}", rp.Status.ToString());
            return null;
        }

        var browser = await Puppeteer.ConnectAsync(new ConnectOptions {
            BrowserWSEndpoint = rp.Address,
            DefaultViewport = null,
            AcceptInsecureCerts = true,
            SlowMo = 0
        }).ConfigureAwait(continueOnCapturedContext: false);

        Console.WriteLine("Browser connected");
        var page = (await browser.PagesAsync().ConfigureAwait(false))[0];

        await page.GoToAsync(address).ConfigureAwait(false);
        return await page.GetContentAsync().ConfigureAwait(false);
    }
}
