﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Win10WebService;

namespace Win10_project.Model
{
    public class SingletonViewModel
    {
        public static ObservableCollection<Guest> Guests { get; set; }

        private SingletonViewModel()
        {
            Guests = new ObservableCollection<Guest>();
            GetAllGuests();
        }

        private static SingletonViewModel instance;

        public static SingletonViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonViewModel();
                }
                return instance;    
            }
        }

        public static void GetAllGuests()
        {
            //Guests = HotelDBFacade.GetAllGuests();
            Guests = Facade.GuestViewFacade.GetAllGuests();
        }

        public static void AddGuest(int guest_no, string name, string address)
        {
            //HotelDBFacade.PostGuest(guest_no, name, address);
            Facade.GuestViewFacade.PostGuest(guest_no, name, address);
        }

        public static void DeleteGuest(Guest guest)
        {
            //HotelDBFacade.DeleteGuest(guest);
            Facade.GuestViewFacade.DeleteGuest(guest);
        }

        public static void UpdateGuest(Guest guest, string name, string address)
        {
            //HotelDBFacade.PutGuest(guest, name, address); 
            Facade.GuestViewFacade.PutGuest(guest, name, address);  
        }
    }
}
