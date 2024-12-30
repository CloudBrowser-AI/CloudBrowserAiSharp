using CloudBrowserAiSharp;
using CloudBrowserAiSharp.Browser.Types;
using PuppeteerSharp;

namespace GetAndClose;

internal class Program {
    static async Task Main(string[] args) {
        using BrowserService svc = new("YOUR CLOUDBROWSER.AI TOKEN");

        var rp = await svc.Open().ConfigureAwait(false);

        if (rp.Status == ResponseStatus.Succes) {
            Console.WriteLine("Browser requested");
        } else {
            Console.WriteLine("Error requesting browser: {0}", rp.Status.ToString());
            return;
        }

        var browser = await Puppeteer.ConnectAsync(new () {
            BrowserWSEndpoint = rp.Address,
            DefaultViewport = null,
            AcceptInsecureCerts = true,
            SlowMo = 0
        }).ConfigureAwait(continueOnCapturedContext: false);
        Console.WriteLine("Browser connected");

        var page = (await browser.PagesAsync().ConfigureAwait(false))[0];
        await page.GoToAsync("http://www.cloudbrowser.ai").ConfigureAwait(false);
        Console.WriteLine("Web visited");

        browser.Disconnect();
        Console.WriteLine("Browser disconnected");

        var rpGet = await svc.Get().ConfigureAwait(false);

        Console.WriteLine("Label | Address | Started On | VNC Opened | VNC Pass");
        foreach (var b in rpGet.Browsers) {
            Console.WriteLine("{0} | {1} | {2} | {3} | {4}", b.Label, b.Address, b.StartedOn, b.VNCPass != null, b.VNCPass);
            await svc.Close(b.Address).ConfigureAwait(false); 
        }
    }
}
