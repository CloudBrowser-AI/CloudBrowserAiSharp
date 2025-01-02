using CloudBrowserAiSharp;
using System.Text.RegularExpressions;

namespace RemoteDesktop;

internal class Program {
    static async Task Main(string[] args) {
        using BrowserService svc = new("YOUR CLOUDBROWSER.AI TOKEN");

        var rp = await svc.Open().ConfigureAwait(false);

        if (rp.Status == CloudBrowserAiSharp.Browser.Types.ResponseStatus.Succes) {
            Console.WriteLine("Browser requested");
        } else {
            Console.WriteLine("Error requesting browser: {0}", rp.Status.ToString());
            return;
        }

        Console.WriteLine("Browser connected");

        var rmt = await svc.StartRemoteDesktop(rp.Address).ConfigureAwait(false);
        Console.WriteLine("Remote desktop address:");
        Console.WriteLine($"https://browser.cloudbrowser.ai${ObtainId(rp.Address)}/{rmt.Password}");
        await Task.Delay(5000).ConfigureAwait(false);
        await svc.StopRemoteDesktop(rp.Address).ConfigureAwait(false);
        Console.WriteLine("Remote Desktop closed");
    }

    static string ObtainId(string address) {
        string pattern = @"\.ai\/(.*?)\/devtools";
        var match1 = Regex.Match(address, pattern);
        return match1.Groups[1].Value;
    }
}
