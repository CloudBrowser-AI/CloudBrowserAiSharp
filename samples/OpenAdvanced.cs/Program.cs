using CloudBrowserAiSharp;
using CloudBrowserAiSharp.Browser.Types;
using PuppeteerSharp;
using PuppeteerSharp.BrowserData;

namespace OpenAdvanced.cs;

internal class Program {
    static async Task Main(string[] args) {
        using BrowserService svc = new("YOUR CLOUDBROWSER.AI TOKEN");

        var rp = await svc.Open(new() {
            Label="MyCustomBrowser",
            //Chromium is supported but we recommend Chrome for best stealth
            Browser = CloudBrowserAiSharp.Browser.Types.SupportedBrowser.Chromium,
            KeepOpen=10 * 60,//This browser will close after 10 minutes without any Puppeteer connected.
            Proxy = new() {
                Host="IP.0.0.0.1",
                Port="3000",
                Password="password",
                Username="username",
            }
        }).ConfigureAwait(false);

        if (rp.Status == ResponseStatus.Succes) {
            Console.WriteLine("Browser requested");
        } else {
            Console.WriteLine("Error requesting browser: {0}", rp.Status.ToString());
            return;
        }

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
        await svc.Close(rp.Address).ConfigureAwait(false);
        //await browser.CloseAsync().ConfigureAwait(false);

        Console.WriteLine("Browser closed");
    }
}
