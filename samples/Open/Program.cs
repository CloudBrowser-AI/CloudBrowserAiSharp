using CloudBrowserAiSharp;
using CloudBrowserAiSharp.Browser.Types;
using PuppeteerSharp;

namespace Open;

internal class Program {
    static async Task Main(string[] args) {
        using BrowserService svc = new("YOUR CLOUDBROWSER.AI TOKEN");
        
        //Request Cloud Browser AI to open a browser
        //using default settings
        var rp = await svc.Open().ConfigureAwait(false);

        var browser = await Puppeteer.ConnectAsync(new ConnectOptions {
            BrowserWSEndpoint = rp.Address,
            DefaultViewport = null,
            AcceptInsecureCerts = true,
            SlowMo = 0
        }).ConfigureAwait(continueOnCapturedContext: false);

        Console.WriteLine("Browser connected");

        var page = (await browser.PagesAsync().ConfigureAwait(false))[0];

        await page.GoToAsync("http://www.cloudbrowser.ai").ConfigureAwait(false);
        Console.WriteLine("Web visited");

        await Task.Delay(5000).ConfigureAwait(false);

        //You can close the browser using puppetter or CloudBrowser AI api
        //await svc.Close(rp.Address).ConfigureAwait(false);
        await browser.CloseAsync().ConfigureAwait(false);

        Console.WriteLine("Browser closed");
    }
}
