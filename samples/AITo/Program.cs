using CloudBrowserAiSharp.Browser.Types;
using CloudBrowserAiSharp;
using PuppeteerSharp;

namespace AITo;

internal class Program {
    const string cloudBrowserToken = "YOUR CLOUDBROWSER.AI TOKEN";
    const string openAiToken = "YOUR OPEN AI TOKEN";

    class CustomType {
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Paragraphs { get; set; }
    }

    static async Task Main(string[] args) {
        using AIService ai = new(cloudBrowserToken, openAiToken);

        var html = await GetHTML("http://www.cloudbrowser.ai").ConfigureAwait(false);

        if (html == null) return;

        var json = await ai.ToJSON(new() {
            Html = html
        }).ConfigureAwait(false);

        var markDown = await ai.ToMarkdown(new() {
            Html = html
        }).ConfigureAwait(false);

        var csv = await ai.ToCSV(new() {
            Html = html,
            Headers = "Name,Price,Duration"
        }).ConfigureAwait(false);

        var custom = await ai.To<CustomType>(html).ConfigureAwait(false);

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
