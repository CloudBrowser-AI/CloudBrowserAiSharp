using CloudBrowserAiSharp;
using CloudBrowserAiSharp.Browser.Types;
using PuppeteerSharp;

namespace SaveAndRestoreSession;

internal class Program {

    static async Task Main(string[] args) {
        using BrowserService svc = new("YOUR CLOUDBROWSER.AI TOKEN");

        //FIRST VISIT--------------------------------------------------------------------
        var browser = await OpenAndConnect(svc).ConfigureAwait(false);
        if (browser == null)
            return;

        var page = (await browser.PagesAsync().ConfigureAwait(false))[0];

        await page.GoToAsync("http://app.cloudbrowser.ai").ConfigureAwait(false);
        Console.WriteLine("Web visited");

        await Login(page).ConfigureAwait(false);
        await Task.Delay(5000).ConfigureAwait(false);

        await browser.CloseAsync().ConfigureAwait(false);
        Console.WriteLine("Browser closed");

        //SECOND VISIT-------------------------------------------------------------------
        await Task.Delay(1000).ConfigureAwait(false);

        browser = await OpenAndConnect(svc).ConfigureAwait(false);
        if (browser == null)
            return;

        page = (await browser.PagesAsync().ConfigureAwait(false))[0];

        await page.GoToAsync("http://app.cloudbrowser.ai").ConfigureAwait(false);
        Console.WriteLine("Web visited again");

        //This time, logging in is not necessary.
        await Task.Delay(5000).ConfigureAwait(false);

        await browser.CloseAsync().ConfigureAwait(false);
        Console.WriteLine("Browser closed");
    }

    static async Task<IBrowser?> OpenAndConnect(BrowserService svc) {
        var rp = await svc.Open(new() {
            Label = "Session",
            SaveSession = true,
            RecoverSession = true
        }).ConfigureAwait(false);

        if (rp.Status == ResponseStatus.Succes) {
            Console.WriteLine("Browser requested");
        } else {
            Console.WriteLine("Error requesting browser: {0}", rp.Status.ToString());
            return null;
        }

        return await Puppeteer.ConnectAsync(new ConnectOptions {
            BrowserWSEndpoint = rp.Address,
            DefaultViewport = null,
            AcceptInsecureCerts = true,
            SlowMo = 0
        }).ConfigureAwait(continueOnCapturedContext: false);
    }

    static async Task Login(IPage page) {
        await page.TypeAsync("[type=\"email\"]", "email").ConfigureAwait(false);
        await page.TypeAsync("[type=\"password\"]", "password").ConfigureAwait(false);
        await page.ClickAsync("[type=\"submit\"]").ConfigureAwait(false);
    }

}