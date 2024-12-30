using System.ComponentModel.DataAnnotations;

namespace CloudBrowserAiSharp.Browser.Types;
public class BrowserOptions {
    /// <summary>
    /// Arguments to be passed to the browser. If null, default args will be assigned by CloudBrowser.AI.
    /// </summary>
    public string[] Args { get; set; }

    /// <summary>
    /// Default arguments to be ignored. If null, default values assigned by CloudBrowser.AI will be used.
    /// </summary>
    public string[] IgnoredDefaultArgs { get; set; }

    /// <summary>
    /// Indicates whether the browser should run in headless mode. If null, it won't be headless
    /// </summary>
    public bool? Headless { get; set; }

    /// <summary>
    /// Extensions to be loaded in the browser. Each extension must be compressed in a zip file.
    /// Each entry in the byte[][] array represents the bytes of a single extension.
    /// For example, to send 2 extensions,there must be 2 zip files, and therefore the byte[][] array will contain 2 byte arrays, each representing one zip file.
    /// </summary>
    public byte[][] Extensions { get; set; }

    /// <summary>
    /// CloudBrowser.AI special stealth system. We recommend to use it. If null it will be enabled.
    /// </summary>
    public bool? Stealth { get; set; }

    /// <summary>
    /// Specifies the browser to be used. If null, Chrome will be used.
    /// </summary>
    public SupportedBrowser? Browser { get; set; }

    /// <summary>
    /// Proxy settings for the browser. If null, CloudBrowser.AI will assign one proxy
    /// </summary>
    public BrowserOptionsProxy Proxy { get; set; }

    /// <summary>
    /// Time in seconds. If any puppetter is connected during this seconds, browser will be removed from CloudBrowser.AI
    /// If null 300s will be the default time (5 minuts)
    /// Min value is 180s (3 minutes)
    /// Value 0 or negative will mean "forever open". So even if any puppetter is connected during days, browser won't be closed by CloudBrowser.AI
    /// </summary>
    public int? KeepOpen { get; set; }

    /// <summary>
    /// Label for the browser session. If null or empty a random label will be generated
    /// Two browsers with the same label can't be opened
    /// In case you want to restore the session, this label will be used as identifier
    /// </summary>
    public string Label { get; set; }

    /// <summary>
    /// If true, cookies, localstorage and browser settings will be saved, so after closing a browser, you will be able to use them in the future in a new session
    /// </summary>
    public bool SaveSession { get; set; }

    /// <summary>
    /// If true, cookies, localstorage and browser settings will be restored from a previous session (if exists)
    /// </summary>
    public bool RecoverSession { get; set; }
}
