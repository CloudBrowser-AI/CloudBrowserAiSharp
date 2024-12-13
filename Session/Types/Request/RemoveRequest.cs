using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBrowserClient.Session.Types.Request;
internal class RemoveRequest {
    public string Label { get; set; }

    public RemoveRequest(string label) {
        Label = label;
    }
}
