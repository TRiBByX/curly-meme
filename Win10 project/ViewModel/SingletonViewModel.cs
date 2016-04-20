using System;
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
        public ObservableCollection<Guest> ObservableCollection { get; set; }

        private SingletonViewModel()
        {
            ObservableCollection = new ObservableCollection<Guest>();
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

        public static ObservableCollection<Guest> Guests()
        {
            var i = new ViewModel.ViewModel().GetallGuests();
            return i;
        } 
    }
}
