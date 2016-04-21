﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Win10WebService;

namespace Win10_project.Facade
{
    class GuestViewFacade
    {
        const string serverUrl = "http://localhost:9510";

        public static bool PostGuest(int guest_no, string name, string address)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                var postresponse = client.PostAsJsonAsync("api/guest_view", new Guest { Guest_No = guest_no, Name = name, Address = address }).Result;
                return postresponse.IsSuccessStatusCode;
            }
        }

        public static void DeleteGuest(Guest guest)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                var postresponse = client.DeleteAsync($"api/guest_view/{guest.Guest_No}").Result;
            }
        }

        public static void PutGuest(Guest guest, string name = null, string address = null)
        {
            if (name != null)
            {
                guest.Name = name;
            }
            if (address != null)
            {
                guest.Address = address;
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                var postresponse = client.PutAsJsonAsync($"api/guest_view/{guest.Guest_No}", guest).Result;
            }
        }

        public static ObservableCollection<Guest> GetAllGuests()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    String guestURL = "api/guest_view";
                    var guestResponseMessage = client.GetAsync(guestURL).Result;
                    if (guestResponseMessage.IsSuccessStatusCode)
                    {
                        var guestlist =
                            guestResponseMessage.Content.ReadAsAsync<ObservableCollection<Guest>>().Result;

                        return guestlist;
                    }

                }
                catch (Exception e)
                {
                    new MessageDialog("An error occurred: " + e.Message);
                }

                return null;
            }
        }
    }
}
