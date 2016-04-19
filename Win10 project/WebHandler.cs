using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Win10WebService;

namespace Win10_project
{
    class WebHandler
    {
        public static void GetDataFromDB()
        {
            const string serverUrl = "http://localhost:9510";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    String guestURL = "api/guests";
                    HttpResponseMessage guestResponseMessage = client.GetAsync(guestURL).Result;
                    if (guestResponseMessage.IsSuccessStatusCode)
                    {
                        var guestlist =
                            guestResponseMessage.Content.ReadAsAsync<List<Guest>>().Result;
                    }

                }
                catch (Exception e)
                {
                    new MessageDialog("An error occurred: " + e.Message);
                }
            }
        }
    }
}
