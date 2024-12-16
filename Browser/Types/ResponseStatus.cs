namespace CloudBrowserAiSharp.Browser.Types;

public enum ResponseStatus {
    Unknown = 0,
    Succes = 200,
    AuthorizationError = 401,
    NoSubscription = 402,
    NoUnits = 403,
    BrowserLimit = 404,
    AIError = 405,
    LabelInUse = 406
}