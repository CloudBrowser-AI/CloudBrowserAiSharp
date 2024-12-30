using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBrowserAiSharp.Session.Types.Response;
public class RemoveResponse {
    /// <summary>
    /// Indicates whether the operation was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Contains error details if the operation failed.
    /// </summary>
    public ErrorSession Error { get; set; }
}
