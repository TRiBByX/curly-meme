using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Win10WebService;
using Win10_project.Annotations;

namespace Win10_project
{
    class WebHandler : INotifyPropertyChanged
    {
        public static ObservableCollection<Guest> Guests { get; set; }

        private WebHandler() { }

        private WebHandler(ObservableCollection<Guest> guests)
        {
            Guests = guests;
        }

        static readonly WebHandler _instance = new WebHandler();
        public static WebHandler Instance
        {
            get
            {
                return _instance;
            }
        }

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
                            guestResponseMessage.Content.ReadAsAsync<ObservableCollection<Guest>>().Result;

                        Guests = guestlist;
                    }

                }
                catch (Exception e)
                {
                    new MessageDialog("An error occurred: " + e.Message);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
