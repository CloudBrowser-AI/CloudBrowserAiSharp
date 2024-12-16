using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBrowserAiSharp.Session.Types.Response;

public class ListResponse {
    public bool Success { get; set; }
    public ErrorSession Error { get; set; }
    public StoredSession[] Sessions { get; set; }
}

public class StoredSession {
    public string Label { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastUpdate { get; set; }
}
