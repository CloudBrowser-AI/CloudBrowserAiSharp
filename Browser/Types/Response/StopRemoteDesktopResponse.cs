﻿namespace CloudBrowserClient.Browser.Types.Response;

public class StoptRemoteDesktopResponse {
    public bool Success { get; set; }
    public ErrorRemoteDesktop Error { get; set; }
}