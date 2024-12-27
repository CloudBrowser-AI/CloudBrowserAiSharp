using CloudBrowserAiSharp;
using CloudBrowserAiSharp.Browser.Types;
using PuppeteerSharp;

namespace AITranslate;

internal class Program {

    const string clToken = "YOUR CLOUDBROWSER.AI TOKEN";
    const string openAiToken = "YOUR OPEN AI TOKEN";

    static async Task Main(string[] args) {
        using AIService ai = new(clToken, new() {
            OpenAIConfiguration = new() {
                ApiKey = openAiToken,
            }
        });

        var text = await GetText("http://www.cloudbrowser.ai","h1").ConfigureAwait(false);

        if (text == null) return;

        var rp = await ai.Translate(new() {
            Text=text,
            IsoLang="ES"
        }).ConfigureAwait(false);

        //var rpai = await ai.Translate<CustomType>(new() {
            //Text=text,
            //IsoLang="ES"
        //}).ConfigureAwait(false);

        Console.WriteLine("{0}", rp.Response);
    }

    static async Task<string?> GetText(string address, string selector) {
        using BrowserService svc = new(clToken);

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
        return await page.EvaluateExpressionAsync<string>($"document.querySelector('{selector}').innerText").ConfigureAwait(false);
    }
}
