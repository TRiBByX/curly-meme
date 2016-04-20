using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Eventmaker.Common;
using Win10WebService;
using Win10_project.Annotations;
using Win10_project.Model;

namespace Win10_project.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public SingletonViewModel SingletonViewModel { get; private set; }
        public String Name { get; set; }
        public int Guest_no { get; set; }
        public String Address { get; set; }
        public Guest SelectedGuest { get; set; }
        public ICommand AddGuestCommand { get; set; }
        public ICommand DeleteGuestCommand { get; set; }
        public ICommand UpdateGuestCommand { get; set; }

        public ViewModel()
        {
            SingletonViewModel = SingletonViewModel.Instance;
            AddGuestCommand = new RelayCommand(AddGuest);
            DeleteGuestCommand = new RelayCommand(DeleteGuest);
            UpdateGuestCommand = new RelayCommand(UpdateGuest);
        }

        public void UpdateGuest()
        {
            SingletonViewModel.UpdateGuest(SelectedGuest, Name, Address);
        }

        public void AddGuest()
        {
            SingletonViewModel.AddGuest(Guest_no, Name, Address);
        }

        public void DeleteGuest()
        {
            SingletonViewModel.DeleteGuest(SelectedGuest);
        }

        #region Notify Property Change Support
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void
            OnPropertyChanged

            ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
