using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBrowserAiSharp.Session.Types.Response;

public class ListResponse {
    /// <summary>
    /// Indicates whether the operation was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Contains error details if the operation failed.
    /// </summary>
    public ErrorSession Error { get; set; }

    /// <summary>
    /// List of stored sessions.
    /// </summary>
    public StoredSession[] Sessions { get; set; }
}

public class StoredSession {
    /// <summary>
    /// Label of the session.
    /// </summary>
    public string Label { get; set; }

    /// <summary>
    /// Date and time when the session was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Date and time when the session was last updated.
    /// </summary>
    public DateTime LastUpdate { get; set; }
}
