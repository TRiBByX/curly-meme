using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Win10_project
{
    class WebHandler
    {
        public static void GetDataFromDB()
        {
            const string serverUrl = "http://localhost:9510";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }
    }
}
