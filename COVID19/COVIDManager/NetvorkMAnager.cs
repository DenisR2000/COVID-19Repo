using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace COVIDManager
{
    public class NetvorkManager
    {
        public string GetJson(string url) => new WebClient().DownloadString(url);
    }
}
