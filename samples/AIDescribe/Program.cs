using CloudBrowserAiSharp.Browser.Types;
using CloudBrowserAiSharp;
using PuppeteerSharp;
using System.Xml.Linq;

namespace AIDescribe;

internal class Program {

    const string clToken = "YOUR CLOUDBROWSER.AI TOKEN";
    const string openAiToken = "YOUR OPEN AI TOKEN";

    static async Task Main(string[] args) {

        var src = await GetImageAddress("http://www.cloudbrowser.ai","img").ConfigureAwait(false);

        if (src == null) return;

        using AIService ai = new(clToken, new() {
            OpenAIConfiguration = new() {
                ApiKey = openAiToken,
            }
        });

        //Response format can be created manually but it is easier to use a type
        //await ai.Describe(new() {
            //Base64Image = DownloadImage(src)
            //ImageUrl= src,
            //Question="Is the image red?"
            //ResponseFormat = "{\"response\":\"bool\", \"required\":[\"response\"]}"
        //}).ConfigureAwait(false);

        var rpai = await ai.Describe<bool>(new() {
            //Base64Image = DownloadImage(src) //You can send bytes instead of the iamge url
            ImageUrl= src,
            Question="Is the image red?"
        }).ConfigureAwait(false);

        Console.WriteLine("The lowest price is: {0}", rpai);
    }

    static async Task<string?> GetImageAddress(string address, string selector) {
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
        var element = await page.QuerySelectorAsync(selector).ConfigureAwait(false);
        return await element.EvaluateFunctionAsync<string>("(el, attr) => el.getAttribute(attr)", "src").ConfigureAwait(false);
    }
}
