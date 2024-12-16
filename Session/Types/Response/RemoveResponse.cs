using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBrowserAiSharp.Session.Types.Response;
public class RemoveResponse {
    public bool Success { get; set; }
    public ErrorSession Error { get; set; }
}
